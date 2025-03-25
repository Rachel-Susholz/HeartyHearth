namespace HeartyHearthWinForm
{
    partial class frmChangeStatus
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblRecipeName;
        private System.Windows.Forms.Label lblDrafted;
        private System.Windows.Forms.Label lblPublished;
        private System.Windows.Forms.Label lblArchived;
        private System.Windows.Forms.Label lblCurrentStatus;
        private System.Windows.Forms.Button btnDraft;
        private System.Windows.Forms.Button btnPublish;
        private System.Windows.Forms.Button btnArchive;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.lblRecipeName = new System.Windows.Forms.Label();
            this.lblDrafted = new System.Windows.Forms.Label();
            this.lblPublished = new System.Windows.Forms.Label();
            this.lblArchived = new System.Windows.Forms.Label();
            this.lblCurrentStatus = new System.Windows.Forms.Label();
            this.btnDraft = new System.Windows.Forms.Button();
            this.btnPublish = new System.Windows.Forms.Button();
            this.btnArchive = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblRecipeName
            // 
            this.lblRecipeName.AutoSize = true;
            this.lblRecipeName.Location = new System.Drawing.Point(20, 20);
            this.lblRecipeName.Name = "lblRecipeName";
            this.lblRecipeName.Size = new System.Drawing.Size(100, 20);
            this.lblRecipeName.TabIndex = 0;
            this.lblRecipeName.Text = "Recipe Name";
            // 
            // lblDrafted
            // 
            this.lblDrafted.AutoSize = true;
            this.lblDrafted.Location = new System.Drawing.Point(20, 60);
            this.lblDrafted.Name = "lblDrafted";
            this.lblDrafted.Size = new System.Drawing.Size(65, 20);
            this.lblDrafted.TabIndex = 1;
            this.lblDrafted.Text = "Drafted:";
            // 
            // lblPublished
            // 
            this.lblPublished.AutoSize = true;
            this.lblPublished.Location = new System.Drawing.Point(20, 90);
            this.lblPublished.Name = "lblPublished";
            this.lblPublished.Size = new System.Drawing.Size(80, 20);
            this.lblPublished.TabIndex = 2;
            this.lblPublished.Text = "Published:";
            // 
            // lblArchived
            // 
            this.lblArchived.AutoSize = true;
            this.lblArchived.Location = new System.Drawing.Point(20, 120);
            this.lblArchived.Name = "lblArchived";
            this.lblArchived.Size = new System.Drawing.Size(70, 20);
            this.lblArchived.TabIndex = 3;
            this.lblArchived.Text = "Archived:";
            // 
            // lblCurrentStatus
            // 
            this.lblCurrentStatus.AutoSize = true;
            this.lblCurrentStatus.Location = new System.Drawing.Point(20, 150);
            this.lblCurrentStatus.Name = "lblCurrentStatus";
            this.lblCurrentStatus.Size = new System.Drawing.Size(102, 20);
            this.lblCurrentStatus.TabIndex = 4;
            this.lblCurrentStatus.Text = "Current Status:";
            // 
            // btnDraft
            // 
            this.btnDraft.Location = new System.Drawing.Point(20, 200);
            this.btnDraft.Name = "btnDraft";
            this.btnDraft.Size = new System.Drawing.Size(100, 30);
            this.btnDraft.TabIndex = 5;
            this.btnDraft.Text = "Draft";
            this.btnDraft.UseVisualStyleBackColor = true;
            this.btnDraft.Click += new System.EventHandler(this.btnDraft_Click);
            // 
            // btnPublish
            // 
            this.btnPublish.Location = new System.Drawing.Point(140, 200);
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(100, 30);
            this.btnPublish.TabIndex = 6;
            this.btnPublish.Text = "Publish";
            this.btnPublish.UseVisualStyleBackColor = true;
            this.btnPublish.Click += new System.EventHandler(this.btnPublish_Click);
            // 
            // btnArchive
            // 
            this.btnArchive.Location = new System.Drawing.Point(260, 200);
            this.btnArchive.Name = "btnArchive";
            this.btnArchive.Size = new System.Drawing.Size(100, 30);
            this.btnArchive.TabIndex = 7;
            this.btnArchive.Text = "Archive";
            this.btnArchive.UseVisualStyleBackColor = true;
            this.btnArchive.Click += new System.EventHandler(this.btnArchive_Click);
            // 
            // frmChangeStatus
            // 
            this.ClientSize = new System.Drawing.Size(400, 260);
            this.Controls.Add(this.btnArchive);
            this.Controls.Add(this.btnPublish);
            this.Controls.Add(this.btnDraft);
            this.Controls.Add(this.lblCurrentStatus);
            this.Controls.Add(this.lblArchived);
            this.Controls.Add(this.lblPublished);
            this.Controls.Add(this.lblDrafted);
            this.Controls.Add(this.lblRecipeName);
            this.Name = "frmChangeStatus";
            this.Text = "Change Recipe Status";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
    }
}
