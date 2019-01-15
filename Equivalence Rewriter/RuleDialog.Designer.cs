namespace Equivalence_Rewriter
{
    partial class RuleDialog
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
            this.buttons = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpName = new System.Windows.Forms.GroupBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblArrow = new System.Windows.Forms.Label();
            this.lblRule = new System.Windows.Forms.Label();
            this.sBox2 = new Equivalence_Rewriter.StatementBox();
            this.sBox1 = new Equivalence_Rewriter.StatementBox();
            this.buttons.SuspendLayout();
            this.grpName.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttons
            // 
            this.buttons.BackColor = System.Drawing.SystemColors.Control;
            this.buttons.Controls.Add(this.btnOk);
            this.buttons.Controls.Add(this.btnCancel);
            this.buttons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttons.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttons.Location = new System.Drawing.Point(0, 207);
            this.buttons.Name = "buttons";
            this.buttons.Size = new System.Drawing.Size(384, 28);
            this.buttons.TabIndex = 6;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnOk.AutoSize = true;
            this.btnOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(147, 0);
            this.btnOk.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(38, 28);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnCancel.AutoSize = true;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(189, 0);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(64, 28);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // grpName
            // 
            this.grpName.Controls.Add(this.txtName);
            this.grpName.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpName.Location = new System.Drawing.Point(0, 0);
            this.grpName.Name = "grpName";
            this.grpName.Size = new System.Drawing.Size(384, 58);
            this.grpName.TabIndex = 0;
            this.grpName.TabStop = false;
            this.grpName.Text = "Rule Name";
            // 
            // txtName
            // 
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtName.Location = new System.Drawing.Point(3, 25);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(378, 29);
            this.txtName.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblRule);
            this.groupBox2.Controls.Add(this.sBox2);
            this.groupBox2.Controls.Add(this.lblArrow);
            this.groupBox2.Controls.Add(this.sBox1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(384, 148);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rule Definition";
            // 
            // lblArrow
            // 
            this.lblArrow.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblArrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArrow.Location = new System.Drawing.Point(3, 45);
            this.lblArrow.Name = "lblArrow";
            this.lblArrow.Size = new System.Drawing.Size(378, 31);
            this.lblArrow.TabIndex = 1;
            this.lblArrow.Text = "⇔";
            this.lblArrow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRule
            // 
            this.lblRule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRule.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRule.Location = new System.Drawing.Point(3, 96);
            this.lblRule.Name = "lblRule";
            this.lblRule.Size = new System.Drawing.Size(378, 49);
            this.lblRule.TabIndex = 3;
            this.lblRule.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRule.UseMnemonic = false;
            // 
            // sBox2
            // 
            this.sBox2.AutoSize = true;
            this.sBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.sBox2.Editing = true;
            this.sBox2.Location = new System.Drawing.Point(3, 76);
            this.sBox2.Margin = new System.Windows.Forms.Padding(11);
            this.sBox2.MaximumSize = new System.Drawing.Size(1680, 20);
            this.sBox2.MinimumSize = new System.Drawing.Size(0, 20);
            this.sBox2.Name = "sBox2";
            this.sBox2.Size = new System.Drawing.Size(378, 20);
            this.sBox2.TabIndex = 2;
            this.sBox2.Value = null;
            // 
            // sBox1
            // 
            this.sBox1.AutoSize = true;
            this.sBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.sBox1.Editing = true;
            this.sBox1.Location = new System.Drawing.Point(3, 25);
            this.sBox1.Margin = new System.Windows.Forms.Padding(6);
            this.sBox1.MaximumSize = new System.Drawing.Size(1680, 20);
            this.sBox1.MinimumSize = new System.Drawing.Size(0, 20);
            this.sBox1.Name = "sBox1";
            this.sBox1.Size = new System.Drawing.Size(378, 20);
            this.sBox1.TabIndex = 0;
            this.sBox1.Value = null;
            // 
            // RuleDialog
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 235);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpName);
            this.Controls.Add(this.buttons);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MinimumSize = new System.Drawing.Size(400, 269);
            this.Name = "RuleDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.buttons.ResumeLayout(false);
            this.buttons.PerformLayout();
            this.grpName.ResumeLayout(false);
            this.grpName.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel buttons;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grpName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.GroupBox groupBox2;
        private StatementBox sBox1;
        private System.Windows.Forms.Label lblArrow;
        private System.Windows.Forms.Label lblRule;
        private StatementBox sBox2;

    }
}