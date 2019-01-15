using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Equivalence_Rewriter
{
    public abstract class Statement
    {
        //Change this flag to true/false to force the use of plain-text symbols in the case that they don't show on your computer
        public const bool USE_SYMBOLS = false;

        public static string TRUE = "T" /*"\u22A4"*/, FALSE = USE_SYMBOLS ? "\u22A5" : "F", NOT = USE_SYMBOLS ? "\u00AC" : "~";


        //A pre-defined collection of binary operators used to parse user input
        protected static Binary[] BinOps = new Binary[] {    new Binary("and", USE_SYMBOLS ? "\u2227" : "&"),       //Conjunction (and)
                                                                new Binary("or", USE_SYMBOLS ? "\u2228" : "|"),     //Disjunction (or)
                                                                new Binary("if", USE_SYMBOLS ? "\u2192" : "->"),    //Conditional (if-then)
                                                                new Binary("iff", USE_SYMBOLS ? "\u2194" : "<->"),  //Biconditional (iff)
                                                                new Binary("xor", USE_SYMBOLS ? "\u2295" : "xor"),  //Exclusive or (xor) \u22BB
                                                                new Binary("=", "=")                                //Equals (=)
                                                            };
        
        //A regex for recognizing integers in square brackets
        private static Regex intRE = new Regex(@"\[(\d+)\]",RegexOptions.Compiled);

        //A temporary buffer for storing pieces of a lisp parse-in-progress
        private static List<Statement> buffer = new List<Statement>();

        //Returns the Lisp-like syntax of this Statement
        public string Lisp
        {
            get
            {
                if (!HasArgs) return Name;
                return string.Format("({0} {1})", Name, string.Join(" ", Args.Select(s => s.Lisp).ToArray()));
            }
        }
        public Statement[] Args { get; set; }
        public int ArgCount { get { return Args != null ? Args.Length : 0; } }
        public bool HasArgs { get { return ArgCount > 0; } }
        public abstract string Name { get; }

        //Returns true if the Statement needs parentheses around it when turning it to text.
        //For example, Conditionals need parentheses, but single-letter Variables and Negated statements don't
        public abstract bool NeedsParens { get; }
        
        //Attempts to parse an entire lisp string using the available types of statements.
        //This is called from outside the class, and cleans up after it is done. Returns
        //null on failure to parse (bad formatted input)
        public static Statement NewParse(string lisp)
        {
            //Make the statement doesn't have numbers enclosed in brackets (used during parsing as references) 
            if (intRE.IsMatch(lisp)) return null;
            buffer.Clear();
            Statement s = Parse(lisp);
            buffer.Clear();
            return s;
        }

        //Attempts to parse an entire lisp string using the available types of statements. Returns null on failure.
        protected static Statement Parse(string lisp)
        {
            Statement s = null;
            lisp = lisp.Trim();
            int e = lisp.IndexOf(')');
            if (e >= 0) //There is a claim in parentheses to deal with (any non-atomic)
            {
                while (e >= 0)
                {
                    string part = lisp.Substring(0, e + 1);
                    int st = part.LastIndexOf('(');
                    if (st < 0) return null;
                    part = part.Substring(st);

                    
                    //Try and parse the enclosed portion (into s), and return null on failure
                    if (!Negation.TryParse(part, out s) &&   //Check for negations
                        !Binary.TryParse(part, out s) &&     //Check for binary claims
                        !Function.TryParse(part, out s))     //Check for Functions
                            return null;

                    //Add the new statement to the buffer and leave a reference to it in its place in the string
                    int x = buffer.Count;
                    buffer.Add(s);
                    lisp = string.Format("{0}[{1}]{2}", lisp.Substring(0, st), x, lisp.Substring(e + 1));
                    e = lisp.IndexOf(')');
                }
                return s;
            } //The claim is atomic or an integer (an index of an already parsed statement in the buffer)
            else if (FromBuffer(lisp, out s) || Atomic.TryParse(lisp, out s)) return s;
            
            return null;
        }

        //Returns true if the lisp is a reference to a statement in the buffer (and stores it in s)
        private static bool FromBuffer(string lisp, out Statement s)
        {
            Match m = intRE.Match(lisp);
            if (m.Success && m.Length == lisp.Length)
            {
                int i = int.Parse(m.Groups[1].Value);
                s = i < buffer.Count ? buffer[i] : null;
            }
            else s = null;
            return s != null;
        }

        public abstract override string ToString();
        public string ToParenString() { return NeedsParens ? string.Format("({0})", this.ToString()) : this.ToString(); }
    }


    //An uppercase letter which serves as a wildcard Statement that can represent a variable or another statement.
    //May also represent a tautology or contradiction, if "true" or "false" is written.
    //All other statements must be composed of these or Functions at their deepest level.
    //Ex: A, B, C, etc.
    //Note: This class is also also used to store constants (lowercase words), but is only used this way in
    //the context of another type of statement that exclusively takes constants as its only argument(s).
    //Ex: the x1 in function F(x1) or bacon in Eats(bacon), but x1 and bacon can NOT be written on their own outside of a statement like this
    public class Atomic : Statement
    {
        private static Regex template = new Regex("^(?:[A-Z]|true|false)$", RegexOptions.Compiled);
        private string name;
        public override string Name { get { return name; } }
        public override bool NeedsParens { get { return false; } }

        public bool IsConstant { get { return char.IsLower(name[0]); } }

        public Atomic(string name) { this.name = name; }

        public static bool TryParse(string lisp, out Statement s)
        {
            s = template.IsMatch(lisp) ? new Atomic(lisp) : null;
            return s != null;
        }

        public override string ToString()
        {
            if (Name.Equals("true")) return TRUE;
            if (Name.Equals("false")) return FALSE;
            return Name;
        }
    }

    //Represents a negated statement (has a single statement argument)
    //Ex: Lisp (not A) translates to ~A
    public class Negation : Statement
    {
        private static Regex template = new Regex(@"^\(not\s+(\S.*)\)$", RegexOptions.Compiled);
        public Statement Arg { get { return HasArgs ? Args[0] : null; } }
        public override string Name { get { return "not"; } }
        public override bool NeedsParens { get { return false; } }

        public Negation() { }

        public static bool TryParse(string lisp, out Statement s)
        {
            Match m = template.Match(lisp);
            if (!m.Success)
            {
                s = null;
                return false;
            }
            Statement arg = Statement.Parse(m.Groups[1].Value);
            if (arg != null)
            {
                s = new Negation();
                s.Args = new Statement[] { arg };
            }
            else s = null;
            return s != null;
        }

        public override string ToString() { return string.Format("{0}{1}", NOT, Arg.ToParenString()); }
    }

    //Represents a statement with two arguments separated by a symbol (if-then, and, or, etc)
    //The lisp has first the name of the type of statement (lowercase), followed by two other statements as arguments
    //Ex: Lisp (if A B) translates to A -> B, Lisp (and X Y) translates to X ^ Y
    //Specific instances of each operator are stored statically in the BinOps array of the Statement class for comparison
    public class Binary : Statement
    {
        private Regex template;
        private string name;
        public override string Name { get { return name; } }
        public string Symbol { get; set; }
        public override bool NeedsParens { get { return true; } }

        public Binary(string name, string symbol)
        {
            this.name = name;
            this.Symbol = symbol;
            template = new Regex(string.Format(@"^\({0}\s+(\S.*)\s+(\S.*)\)$", name), RegexOptions.Compiled);
        }

        //Compare the lisp against templates for the binary operators pre-established in the Statement
        //class's static BinOps array and if a match is made, parse the lisp into a BinOperator
        public static bool TryParse(string lisp, out Statement s)
        {
            foreach (Binary op in Statement.BinOps)
            {
                Match m = op.template.Match(lisp);
                if (m.Success)
                {
                    Statement s1 = Statement.Parse(m.Groups[1].Value), s2 = Statement.Parse(m.Groups[2].Value);
                    if (s1 != null && s2 != null)
                    {
                        s = new Binary(op.Name, op.Symbol);
                        s.Args = new Statement[] { s1, s2 };
                    }
                    else s = null;
                    return s != null;
                }
            }
            s = null;
            return false;
        }

        public override string ToString()
        {
            if (ArgCount != 2) return Name;
            return string.Format("{0} {1} {2}", Args[0].ToParenString(), Symbol, Args[1].ToParenString());
        }
    }

    //Represents any function with a 1+ letter name (first letter capital) and 1+ fixed variables of any number of lowercase letters
    //Ex: F(x1), LeftOf(x,y), Eats(bacon)
    public class Function : Statement
    {
        private static Regex template = new Regex(@"^\(([A-Z][a-zA-Z]*)(\s+[a-z][a-z_0-9]*)+\)$", RegexOptions.Compiled);
        private string name;
        public override string Name { get { return name; } }
        public override bool NeedsParens { get { return false; } }

        public Function(string n) { name = n; }

        public static bool TryParse(string lisp, out Statement s)
        {
            Match m = template.Match(lisp);
            if (!m.Success)
            {
                s = null;
                return false;
            }

            GroupCollection gc = m.Groups;
            s = new Function(gc[1].Value);
            CaptureCollection cc =             gc[2].Captures;
            s.Args = new Statement[cc.Count];

            for (int i = 0; i < cc.Count; ++i) s.Args[i] = new Atomic(cc[i].Value.Trim());

            return true;
        }

        public override string ToString()
        { return string.Format("{0}({1})", Name, string.Join(",", Args.Select(s => s.ToString()).ToArray())); }
    }


}
