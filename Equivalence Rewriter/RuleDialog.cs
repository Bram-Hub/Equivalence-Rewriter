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
    public partial class RuleDialog : Form
    {
        public RuleDialog(Equivalence e)
        {
            InitializeComponent();
            Value = e;
            this.Text = e != null ? "Edit Equivalence Rule" : "Add Equivalence Rule";
            if (!Statement.USE_SYMBOLS) lblArrow.Text = "<=>";
        }

        public Equivalence Value
        {
            get { return new Equivalence(txtName.Text, sBox1.Value, sBox2.Value); }
            set
            {
                if (value != null)
                {
                    txtName.Text = value.Name;
                    sBox1.Value = value.S1;
                    sBox2.Value = value.S2;
                    //lblRule.Text = value.Rule;
                }
                else
                {
                    txtName.Text = lblRule.Text = "";
                    sBox1.Value = sBox2.Value = null;
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length < 1)
            {
                MessageBox.Show("Enter a name for the rule.", "Enter Name");
                txtName.Focus();
            }
            else if (sBox1.Value == null || sBox2.Value == null)
            {
                MessageBox.Show("Enter a value for both logic statements in the rule.", "Enter Rule");
                if (sBox1.Value == null) sBox1.Focus();
                else sBox2.Focus();
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        public static Equivalence Show(Equivalence e)
        {
            RuleDialog d = new RuleDialog(e);
            e = d.ShowDialog() == DialogResult.OK ? d.Value : null;
            d.Dispose();
            return e;
        }

        
    }
}
