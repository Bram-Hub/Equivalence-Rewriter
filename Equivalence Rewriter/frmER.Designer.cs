namespace Equivalence_Rewriter
{
    partial class frmER
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grpEquiv = new System.Windows.Forms.GroupBox();
            this.lstEquivalent = new System.Windows.Forms.ListBox();
            this.grpRules = new System.Windows.Forms.GroupBox();
            this.lstRules = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.addRuleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applyRuleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRule = new System.Windows.Forms.Label();
            this.removeRuleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applyAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sBox = new Equivalence_Rewriter.StatementBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpEquiv.SuspendLayout();
            this.grpRules.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grpEquiv);
            this.splitContainer1.Panel1.Controls.Add(this.sBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grpRules);
            this.splitContainer1.Size = new System.Drawing.Size(581, 383);
            this.splitContainer1.SplitterDistance = 314;
            this.splitContainer1.TabIndex = 3;
            // 
            // grpEquiv
            // 
            this.grpEquiv.Controls.Add(this.lstEquivalent);
            this.grpEquiv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpEquiv.Location = new System.Drawing.Point(0, 31);
            this.grpEquiv.Name = "grpEquiv";
            this.grpEquiv.Size = new System.Drawing.Size(314, 352);
            this.grpEquiv.TabIndex = 2;
            this.grpEquiv.TabStop = false;
            this.grpEquiv.Text = "Equivalent Statements";
            // 
            // lstEquivalent
            // 
            this.lstEquivalent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstEquivalent.FormattingEnabled = true;
            this.lstEquivalent.ItemHeight = 24;
            this.lstEquivalent.Location = new System.Drawing.Point(3, 25);
            this.lstEquivalent.Name = "lstEquivalent";
            this.lstEquivalent.Size = new System.Drawing.Size(308, 316);
            this.lstEquivalent.TabIndex = 1;
            this.lstEquivalent.DoubleClick += new System.EventHandler(this.lstEquivalent_DoubleClick);
            // 
            // grpRules
            // 
            this.grpRules.Controls.Add(this.lstRules);
            this.grpRules.Controls.Add(this.menuStrip1);
            this.grpRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRules.Location = new System.Drawing.Point(0, 0);
            this.grpRules.Name = "grpRules";
            this.grpRules.Size = new System.Drawing.Size(263, 383);
            this.grpRules.TabIndex = 0;
            this.grpRules.TabStop = false;
            this.grpRules.Text = "Equivalence Rules";
            // 
            // lstRules
            // 
            this.lstRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRules.FormattingEnabled = true;
            this.lstRules.ItemHeight = 24;
            this.lstRules.Location = new System.Drawing.Point(3, 49);
            this.lstRules.Name = "lstRules";
            this.lstRules.Size = new System.Drawing.Size(257, 316);
            this.lstRules.TabIndex = 1;
            this.lstRules.SelectedIndexChanged += new System.EventHandler(this.lstRules_SelectedIndexChanged);
            this.lstRules.DoubleClick += new System.EventHandler(this.lstRules_DoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRuleMenuItem,
            this.editMenuItem,
            this.removeRuleMenuItem,
            this.applyAllMenuItem,
            this.applyRuleMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 25);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(257, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // addRuleMenuItem
            // 
            this.addRuleMenuItem.Name = "addRuleMenuItem";
            this.addRuleMenuItem.Padding = new System.Windows.Forms.Padding(0);
            this.addRuleMenuItem.Size = new System.Drawing.Size(33, 20);
            this.addRuleMenuItem.Text = "&Add";
            this.addRuleMenuItem.Click += new System.EventHandler(this.addRuleMenuItem_Click);
            // 
            // editMenuItem
            // 
            this.editMenuItem.Name = "editMenuItem";
            this.editMenuItem.Padding = new System.Windows.Forms.Padding(0);
            this.editMenuItem.Size = new System.Drawing.Size(31, 20);
            this.editMenuItem.Text = "&Edit";
            this.editMenuItem.Visible = false;
            this.editMenuItem.Click += new System.EventHandler(this.editMenuItem_Click);
            // 
            // applyRuleMenuItem
            // 
            this.applyRuleMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.applyRuleMenuItem.Name = "applyRuleMenuItem";
            this.applyRuleMenuItem.Padding = new System.Windows.Forms.Padding(0);
            this.applyRuleMenuItem.Size = new System.Drawing.Size(68, 20);
            this.applyRuleMenuItem.Text = "Apply &Rule";
            this.applyRuleMenuItem.Visible = false;
            this.applyRuleMenuItem.Click += new System.EventHandler(this.applyRuleMenuItem_Click);
            // 
            // lblRule
            // 
            this.lblRule.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblRule.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRule.Location = new System.Drawing.Point(0, 383);
            this.lblRule.Name = "lblRule";
            this.lblRule.Size = new System.Drawing.Size(581, 25);
            this.lblRule.TabIndex = 4;
            this.lblRule.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRule.UseMnemonic = false;
            // 
            // removeRuleMenuItem
            // 
            this.removeRuleMenuItem.Name = "removeRuleMenuItem";
            this.removeRuleMenuItem.Padding = new System.Windows.Forms.Padding(0);
            this.removeRuleMenuItem.Size = new System.Drawing.Size(54, 20);
            this.removeRuleMenuItem.Text = "Re&move";
            this.removeRuleMenuItem.Visible = false;
            this.removeRuleMenuItem.Click += new System.EventHandler(this.removeRuleMenuItem_Click);
            // 
            // applyAllMenuItem
            // 
            this.applyAllMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.applyAllMenuItem.Name = "applyAllMenuItem";
            this.applyAllMenuItem.Padding = new System.Windows.Forms.Padding(0);
            this.applyAllMenuItem.Size = new System.Drawing.Size(59, 20);
            this.applyAllMenuItem.Text = "A&pply All";
            this.applyAllMenuItem.Click += new System.EventHandler(this.applyAllMenuItem_Click);
            // 
            // sBox
            // 
            this.sBox.AutoSize = true;
            this.sBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.sBox.Editing = true;
            this.sBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sBox.Location = new System.Drawing.Point(0, 0);
            this.sBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.sBox.MaximumSize = new System.Drawing.Size(1680, 31);
            this.sBox.MinimumSize = new System.Drawing.Size(0, 31);
            this.sBox.Name = "sBox";
            this.sBox.Size = new System.Drawing.Size(314, 31);
            this.sBox.TabIndex = 0;
            this.sBox.Value = null;
            // 
            // frmER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 408);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lblRule);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "frmER";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Equivalence Rewriter";
            this.Load += new System.EventHandler(this.frmER_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.grpEquiv.ResumeLayout(false);
            this.grpRules.ResumeLayout(false);
            this.grpRules.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpEquiv;
        private System.Windows.Forms.ListBox lstEquivalent;
        private StatementBox sBox;
        private System.Windows.Forms.GroupBox grpRules;
        private System.Windows.Forms.ListBox lstRules;
        private System.Windows.Forms.Label lblRule;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addRuleMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applyRuleMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeRuleMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applyAllMenuItem;



    }
}

