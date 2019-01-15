namespace Equivalence_Rewriter
{
    partial class StatementBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtVal = new System.Windows.Forms.TextBox();
            this.btnParse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtVal
            // 
            this.txtVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtVal.Location = new System.Drawing.Point(0, 0);
            this.txtVal.Name = "txtVal";
            this.txtVal.Size = new System.Drawing.Size(289, 20);
            this.txtVal.TabIndex = 0;
            // 
            // btnParse
            // 
            this.btnParse.AutoSize = true;
            this.btnParse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnParse.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnParse.Location = new System.Drawing.Point(289, 0);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(44, 172);
            this.btnParse.TabIndex = 1;
            this.btnParse.Text = "Parse";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // StatementBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.txtVal);
            this.Controls.Add(this.btnParse);
            this.Name = "StatementBox";
            this.Size = new System.Drawing.Size(333, 172);
            this.Load += new System.EventHandler(this.StatementBox_Load);
            this.FontChanged += new System.EventHandler(this.StatementBox_FontChanged);
            this.Resize += new System.EventHandler(this.StatementBox_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtVal;
        private System.Windows.Forms.Button btnParse;
    }
}
