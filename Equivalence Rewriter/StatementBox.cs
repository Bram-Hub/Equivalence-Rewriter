using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Equivalence_Rewriter
{
    public partial class StatementBox : UserControl
    {
        public StatementBox()
        {
            InitializeComponent();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////
        /////KEY PROPERTIES, CLASS VARIABLES AND CONSTANTS///////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////

        private static int MAX_WIDTH = Screen.AllScreens.Sum(s => s.Bounds.Width);

        private Statement val = null;

        public bool Editing
        {
            get { return !txtVal.ReadOnly; }
            set
            {
                if (txtVal.ReadOnly = !value)
                {
                    btnParse.Text = "Edit";
                    txtVal.Text = val != null ? val.ToString() : "";
                    txtVal.TextAlign = HorizontalAlignment.Center;
                }
                else
                {
                    btnParse.Text = "Parse";
                    txtVal.Text = val != null ? val.Lisp : "";
                    txtVal.TextAlign = HorizontalAlignment.Left;
                }
            }
        }

        public Statement Value
        {
            get { return Editing ? null : val; }
            set
            {
                val = value;
                Editing = val == null;
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////
        /////FORM METHODS////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////

        private void StatementBox_Load(object sender, EventArgs e)
        {
            FixSize();
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            if (Editing)
            {
                txtVal.Text = txtVal.Text.Trim();
                if (txtVal.Text.Length > 0)
                {
                    Statement s = Statement.NewParse(txtVal.Text);
                    if (s == null)
                    {
                        MessageBox.Show("Lisp statement is invalid. Please revise your entry.", "Invalid Statement", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtVal.Focus();
                    }
                    else Value = s;
                    //if (s != null) MessageBox.Show(s.Lisp + "\n\n" + Equivalence.RegexString(s) + "\n\n" + Equivalence.FormatString(s));
                }
                else MessageBox.Show("Please enter a valid logic statement in lisp syntax.", "Enter Statement");
            }
            else
            {
                Editing = true;
                txtVal.Focus();
            }
        }

        private void StatementBox_FontChanged(object sender, EventArgs e) { FixSize(); }

        private void StatementBox_Resize(object sender, EventArgs e) { FixSize(); }

        /////////////////////////////////////////////////////////////////////////////////////////////////
        /////NON-FORM METHODS////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////

        private void FixSize()
        {
            int h = txtVal.Height, w = Width;
            if (MaximumSize.Height == h && MinimumSize.Height == h) return;
            //MaximumSize = MinimumSize = new Size(0, h);
            MinimumSize = new Size(0, h);
            MaximumSize = new Size(MAX_WIDTH, h);
        }

        
    }
}
