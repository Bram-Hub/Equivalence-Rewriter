using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Equivalence_Rewriter
{
    public partial class frmER : Form
    {
        public frmER()
        {
            InitializeComponent();
        }

        private void frmER_Load(object sender, EventArgs e)
        {
            //Add some default equivalence rules to the list

            AddRule(new Equivalence("Double Negation", "(not (not A))", "A"));

            AddRule(new Equivalence("Association (and)", "(and A (and B C))", "(and (and A B) C)"));
            AddRule(new Equivalence("Association (or)", "(or A (or B C))", "(or (or A B) C)"));
            AddRule(new Equivalence("Association (iff)", "(iff A (iff B C))", "(iff (iff A B) C)"));

            AddRule(new Equivalence("Commutation (and)", "(and A B)", "(and B A)"));
            AddRule(new Equivalence("Commutation (or)", "(or A B)", "(or B A)"));
            AddRule(new Equivalence("Commutation (iff)", "(iff A B)", "(iff B A)"));

            AddRule(new Equivalence("Idempotence (and)", "(and A A)", "A"));
            AddRule(new Equivalence("Idempotence (or)", "(or A A)", "A"));

            AddRule(new Equivalence("DeMorgan (and)", "(not (and A B))", "(or (not A) (not B))"));
            AddRule(new Equivalence("DeMorgan (or)", "(not (or A B))", "(and (not A) (not B))"));

            AddRule(new Equivalence("Distribution (and)", "(and A (or B C))", "(or (and A B) (and A C))"));
            AddRule(new Equivalence("Distribution (or)", "(or A (and B C))", "(and (or A B) (or A C))"));

            AddRule(new Equivalence("Absorption (and)", "(and A (or A B))", "A"));
            AddRule(new Equivalence("Absorption (or)", "(or A (and A B))", "A"));

            AddRule(new Equivalence("Reduction (and)", "(and A (or (not A) B))", "(and A B)"));
            AddRule(new Equivalence("Reduction (or)", "(or A (and (not A) B))", "(or A B)"));

            AddRule(new Equivalence("Contraposition", "(if A B)", "(if (not B) (not A))"));
            AddRule(new Equivalence("Exportation", "(if A (if B C))", "(if (and A B) C)"));

            AddRule(new Equivalence("Implication (and)", "(if A B)", "(or (not A) B)"));
            AddRule(new Equivalence("Implication (or)", "(if A B)", "(not (or A (not B)))"));

            AddRule(new Equivalence("Equivalence (if)", "(iff A B)", "(and (if A B) (if B A))"));
            AddRule(new Equivalence("Equivalence (and)", "(iff A B)", "(or (and A B) (and (not A) (not B)))"));
        }

        //The current Statement entered in the upper left
        private Statement Entry
        {
            get { return sBox.Value; }
            set { sBox.Value = value; }
        }
        private bool HasEntry { get { return sBox.Value != null; } }

        private void addRuleMenuItem_Click(object sender, EventArgs e)
        {
            Equivalence rule = RuleDialog.Show(null);
            if (rule != null)
            {
                AddRule(rule);
                lstRules.SelectedIndex = lstRules.Items.Count - 1;
            }
        }

        private void applyAllMenuItem_Click(object sender, EventArgs e)
        {
            if (HasEntry)
            {
                List<Statement> list = new List<Statement>();
                foreach (object r in lstRules.Items) list.AddRange(((Equivalence)r).Equivalences(Entry));
                lstEquivalent.Items.Clear();
                lstEquivalent.Items.AddRange(list.ToArray());
            }
        }

        private void applyRuleMenuItem_Click(object sender, EventArgs e) { ApplyRule(lstRules.SelectedItem as Equivalence); }

        private void editMenuItem_Click(object sender, EventArgs e)
        {
            int sel = lstRules.SelectedIndex;
            if (sel < 0) return;

            Equivalence rule = RuleDialog.Show(lstRules.SelectedItem as Equivalence);
            if (rule != null)
            {
                lstRules.Items[sel] = rule;
                lstRules.SelectedIndex = sel;
            }
        }

        private void lstRules_DoubleClick(object sender, EventArgs e) { ApplyRule(lstRules.SelectedItem as Equivalence); }

        private void lstEquivalent_DoubleClick(object sender, EventArgs e)
        {
            Statement sel = lstEquivalent.SelectedItem as Statement;
            if (HasEntry && sel != null) Entry = sel;
        }

        private void lstRules_SelectedIndexChanged(object sender, EventArgs e)
        {
            Equivalence sel = lstRules.SelectedItem as Equivalence;
            if (sel != null)
            {
                lblRule.Text = sel.Rule;
                editMenuItem.Visible = applyRuleMenuItem.Visible = removeRuleMenuItem.Visible = true;
            }
            else
            {
                lblRule.Text = "";
                editMenuItem.Visible = applyRuleMenuItem.Visible = removeRuleMenuItem.Visible = false;
            }
        }

        private void removeRuleMenuItem_Click(object sender, EventArgs e)
        {
            int sel = lstRules.SelectedIndex;
            if (sel < 0 || MessageBox.Show(string.Format("Remove {0}?", (lstRules.SelectedItem as Equivalence).Name), "Remove Rule", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            lstRules.Items.RemoveAt(sel);
            lstRules.SelectedIndex = sel < lstRules.Items.Count ? sel : sel - 1;
        }

        //Add an equivalence rule to the list
        public void AddRule(Equivalence rule)
        {
            lstRules.Items.Add(rule);
        }

        //Display equivalent statements in the list below the Statement box
        public void ApplyRule(Equivalence rule)
        {
            if (HasEntry && rule != null)
            {
                List<Statement> list = rule.Equivalences(Entry);
                lstEquivalent.Items.Clear();
                lstEquivalent.Items.AddRange(list.ToArray());
            }
        }

        
        
    }
}
