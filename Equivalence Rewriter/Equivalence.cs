using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Equivalence_Rewriter
{
    public class Equivalence
    {
        public string Name { get; private set; }
        public Statement S1 { get; private set; }
        public Statement S2 { get; private set; }
        public Regex RE1 { get; private set; }
        public Regex RE2 { get; private set; }
        public string FS1 { get; private set; }
        public string FS2 { get; private set; }
        public Dictionary<string, int> AMap1 { get; private set; }
        public Dictionary<string, int> AMap2 { get; private set; }


        public string Rule { get { return string.Format("{0} {1} {2}", S1, Statement.USE_SYMBOLS ? "\u21D4" : "<=>", S2); } }

        public Equivalence(string name, string s1, string s2)
        {
            Name = name;
            S1 = Statement.NewParse(s1);
            S2 = Statement.NewParse(s2);
            MakeStrings();
        }

        public Equivalence(string name, Statement s1, Statement s2)
        {
            Name = name;
            S1 = s1;
            S2 = s2;
            MakeStrings();
        }

        private void MakeStrings()
        {
            RE1 = new Regex(RegexString(S1), RegexOptions.Compiled);
            RE2 = new Regex(RegexString(S2), RegexOptions.Compiled);
            FS1 = FormatString(S1, AMap1 = new Dictionary<string, int>());
            FS2 = FormatString(S2, AMap2 = new Dictionary<string, int>());
        }

        public static string RegexString(Statement s) { return string.Format("^{0}$", RegexString(s, new Dictionary<string, int>())); }
        public static string RegexString(Statement s, Dictionary<string, int> map)
        {
            string n = s.Name;
            if (s is Atomic)
            {
                Atomic a = s as Atomic;
                if (a.IsConstant) return n;
                if (map.ContainsKey(n)) return string.Format(@"\{0}", map[n]);
                map[n] = map.Count + 1;
                return @"([A-Z]|\(.+\))";
            }
            return string.Format(@"\({0} {1}\)", s.Name, string.Join(" ", s.Args.Select(a => RegexString(a, map)).ToArray()));
        }

        public static string FormatString(Statement s, Dictionary<string, int> map)
        {
            string n = s.Name;
            if (s is Atomic)
            {
                Atomic a = s as Atomic;
                if (a.IsConstant) return n;
                if (!map.ContainsKey(n)) map[n] = map.Count;
                return "{" + map[n] + "}";
            }
            return string.Format("({0} {1})", s.Name, string.Join(" ", s.Args.Select(a => FormatString(a, map)).ToArray()));
        }

        public HashSet<string> GetAtomics(Statement s) { return GetAtomics(s, new HashSet<string>()); }
        public HashSet<string> GetAtomics(Statement s, HashSet<string> set)
        {
            if (!(s is Atomic)) foreach (Statement a in s.Args) return GetAtomics(a, set);
            else if (!((Atomic)s).IsConstant) set.Add(s.Name);
            return set;
        }

        public List<Statement> Equivalences(Statement s)
        {
            List<Statement> list = new List<Statement>();
            string lisp = s.Lisp;
            HashSet<string> atoms = GetAtomics(s);
            foreach (Match m in RE1.Matches(lisp))
            {
                GroupCollection gc = m.Groups;

                string[] lisps = new string[AMap2.Count];
                foreach (string k in AMap1.Keys)
                    if (AMap2.ContainsKey(k))
                        lisps[AMap2[k]] = gc[AMap1[k] + 1].Value;
                for (int i = 0; i < lisps.Length; ++i)
                {
                    if (lisps[i] == null)
                    {
                        char c = 'A';
                        while (atoms.Contains(c.ToString())) ++c;
                        atoms.Add(c.ToString());
                        lisps[i] = c.ToString();
                    }
                }

                Statement n = Statement.NewParse(string.Format(FS2, lisps));
                if (n != null) list.Add(n);
            }
            atoms = GetAtomics(s);
            foreach (Match m in RE2.Matches(lisp))
            {
                GroupCollection gc = m.Groups;

                string[] lisps = new string[AMap1.Count];
                foreach (string k in AMap2.Keys)
                    if (AMap1.ContainsKey(k))
                        lisps[AMap1[k]] = gc[AMap2[k] + 1].Value;
                for (int i = 0; i < lisps.Length; ++i)
                {
                    if (lisps[i] == null)
                    {
                        char c = 'A';
                        while (atoms.Contains(c.ToString())) ++c;
                        atoms.Add(c.ToString());
                        lisps[i] = c.ToString();
                    }
                }

                Statement n = Statement.NewParse(string.Format(FS1, lisps));
                if (n != null) list.Add(n);
            }

            return list;
        }




        public override string ToString() { return Name; }
    }
}
