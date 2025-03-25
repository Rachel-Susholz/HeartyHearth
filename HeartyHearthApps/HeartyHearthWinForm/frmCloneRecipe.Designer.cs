namespace HeartyHearthWinForm
{
    partial class frmCloneRecipe
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel tblMain;
        private System.Windows.Forms.ComboBox cbxRecipes;
        private System.Windows.Forms.Button btnClone;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.cbxRecipes = new System.Windows.Forms.ComboBox();
            this.btnClone = new System.Windows.Forms.Button();
            this.tblMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblMain
            // 
            this.tblMain.AutoSize = true;
            this.tblMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tblMain.ColumnCount = 1;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tblMain.Controls.Add(this.cbxRecipes, 0, 0);
            this.tblMain.Controls.Add(this.btnClone, 0, 1);
            this.tblMain.Location = new System.Drawing.Point(12, 12);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 2;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tblMain.Size = new System.Drawing.Size(160, 72);
            this.tblMain.TabIndex = 0;
            // 
            // cbxRecipes
            // 
            this.cbxRecipes.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxRecipes.FormattingEnabled = true;
            this.cbxRecipes.Location = new System.Drawing.Point(3, 3);
            this.cbxRecipes.Name = "cbxRecipes";
            this.cbxRecipes.Size = new System.Drawing.Size(154, 28);
            this.cbxRecipes.TabIndex = 0;
            // 
            // btnClone
            // 
            this.btnClone.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnClone.AutoSize = true;
            this.btnClone.Location = new System.Drawing.Point(3, 42);
            this.btnClone.Name = "btnClone";
            this.btnClone.Size = new System.Drawing.Size(94, 30);
            this.btnClone.TabIndex = 1;
            this.btnClone.Text = "Clone";
            this.btnClone.UseVisualStyleBackColor = true;
            // 
            // frmCloneRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 150);
            this.Controls.Add(this.tblMain);
            this.Name = "frmCloneRecipe";
            this.Text = "Hearty Hearth - Clone a Recipe";
            this.tblMain.ResumeLayout(false);
            this.tblMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
