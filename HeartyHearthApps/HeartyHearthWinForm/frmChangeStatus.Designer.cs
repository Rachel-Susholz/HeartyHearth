namespace HeartyHearthWinForm
{
    partial class frmChangeStatus
    {
        private System.ComponentModel.IContainer components = null;
        private TableLayoutPanel tblMain;
        private Label lblRecipeName;
        private TableLayoutPanel tblStatus;
        private Label lblCurrentStatus;
        private TableLayoutPanel tblHeadings;
        private Label lblCaptionDrafted;
        private Label lblCaptionPublished;
        private Label lblCaptionArchived;
        private TableLayoutPanel tblDates;
        private Label lblCaptionStatusDates;
        private Label lblDrafted;
        private Label lblPublished;
        private Label lblArchived;
        private TableLayoutPanel tblButtons;
        private Button btnDraft;
        private Button btnPublish;
        private Button btnArchive;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Designer generated code
        private void InitializeComponent()
        {
            this.tblMain = new TableLayoutPanel();
            this.lblRecipeName = new Label();
            this.tblStatus = new TableLayoutPanel();
            this.lblCurrentStatus = new Label();
            this.tblHeadings = new TableLayoutPanel();
            this.lblCaptionDrafted = new Label();
            this.lblCaptionPublished = new Label();
            this.lblCaptionArchived = new Label();
            this.tblDates = new TableLayoutPanel();
            this.lblCaptionStatusDates = new Label();
            this.lblDrafted = new Label();
            this.lblPublished = new Label();
            this.lblArchived = new Label();
            this.tblButtons = new TableLayoutPanel();
            this.btnDraft = new Button();
            this.btnPublish = new Button();
            this.btnArchive = new Button();

            // tblMain
            this.tblMain.AutoSize = true;
            this.tblMain.Dock = DockStyle.Fill;
            this.tblMain.ColumnCount = 1;
            this.tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tblMain.RowCount = 5;
            this.tblMain.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.tblMain.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.tblMain.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.tblMain.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.tblMain.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.tblMain.Controls.Add(this.lblRecipeName, 0, 0);
            this.tblMain.Controls.Add(this.tblStatus, 0, 1);
            this.tblMain.Controls.Add(this.tblHeadings, 0, 2);
            this.tblMain.Controls.Add(this.tblDates, 0, 3);
            this.tblMain.Controls.Add(this.tblButtons, 0, 4);

            // lblRecipeName
            this.lblRecipeName.AutoSize = true;
            this.lblRecipeName.Dock = DockStyle.Fill;
            this.lblRecipeName.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblRecipeName.Text = "Cheese Bread";
            this.lblRecipeName.TextAlign = ContentAlignment.MiddleCenter;
            this.lblRecipeName.Margin = new Padding(0, 2, 0, 2);

            // tblStatus
            this.tblStatus.AutoSize = true;
            this.tblStatus.Dock = DockStyle.Fill;
            this.tblStatus.ColumnCount = 1;
            this.tblStatus.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tblStatus.RowCount = 1;
            this.tblStatus.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.tblStatus.Controls.Add(this.lblCurrentStatus, 0, 0);

            // lblCurrentStatus
            this.lblCurrentStatus.AutoSize = true;
            this.lblCurrentStatus.Dock = DockStyle.Fill;
            this.lblCurrentStatus.Font = new Font("Segoe UI", 12F);
            this.lblCurrentStatus.Text = "Current Status: drafted";
            this.lblCurrentStatus.TextAlign = ContentAlignment.MiddleCenter;
            this.lblCurrentStatus.Margin = new Padding(0, 2, 0, 2);

            // tblHeadings
            this.tblHeadings.AutoSize = true;
            this.tblHeadings.Dock = DockStyle.Fill;
            this.tblHeadings.ColumnCount = 3;
            this.tblHeadings.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            this.tblHeadings.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            this.tblHeadings.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
            this.tblHeadings.RowCount = 1;
            this.tblHeadings.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.tblHeadings.Controls.Add(this.lblCaptionDrafted, 0, 0);
            this.tblHeadings.Controls.Add(this.lblCaptionPublished, 1, 0);
            this.tblHeadings.Controls.Add(this.lblCaptionArchived, 2, 0);

            // lblCaptionDrafted
            this.lblCaptionDrafted.AutoSize = false;
            this.lblCaptionDrafted.Dock = DockStyle.Fill;
            this.lblCaptionDrafted.Text = "Drafted";
            this.lblCaptionDrafted.TextAlign = ContentAlignment.MiddleCenter;
            this.lblCaptionDrafted.Margin = new Padding(0, 2, 0, 2);

            // lblCaptionPublished
            this.lblCaptionPublished.AutoSize = false;
            this.lblCaptionPublished.Dock = DockStyle.Fill;
            this.lblCaptionPublished.Text = "Published";
            this.lblCaptionPublished.TextAlign = ContentAlignment.MiddleCenter;
            this.lblCaptionPublished.Margin = new Padding(0, 2, 0, 2);

            // lblCaptionArchived
            this.lblCaptionArchived.AutoSize = false;
            this.lblCaptionArchived.Dock = DockStyle.Fill;
            this.lblCaptionArchived.Text = "Archived";
            this.lblCaptionArchived.TextAlign = ContentAlignment.MiddleCenter;
            this.lblCaptionArchived.Margin = new Padding(0, 2, 0, 2);

            // tblDates
            this.tblDates.AutoSize = true;
            this.tblDates.Dock = DockStyle.Fill;
            this.tblDates.ColumnCount = 4;
            this.tblDates.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            this.tblDates.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            this.tblDates.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            this.tblDates.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
            this.tblDates.RowCount = 1;
            this.tblDates.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.tblDates.Controls.Add(this.lblCaptionStatusDates, 0, 0);
            this.tblDates.Controls.Add(this.lblDrafted, 1, 0);
            this.tblDates.Controls.Add(this.lblPublished, 2, 0);
            this.tblDates.Controls.Add(this.lblArchived, 3, 0);

            // lblCaptionStatusDates
            this.lblCaptionStatusDates.AutoSize = true;
            this.lblCaptionStatusDates.Text = "Status Dates:";
            this.lblCaptionStatusDates.TextAlign = ContentAlignment.MiddleLeft;
            this.lblCaptionStatusDates.Margin = new Padding(0, 2, 5, 2);

            // lblDrafted
            this.lblDrafted.AutoSize = false;
            this.lblDrafted.BorderStyle = BorderStyle.FixedSingle;
            this.lblDrafted.Dock = DockStyle.Fill;
            this.lblDrafted.Text = "";
            this.lblDrafted.TextAlign = ContentAlignment.MiddleCenter;
            this.lblDrafted.Margin = new Padding(2);

            // lblPublished
            this.lblPublished.AutoSize = false;
            this.lblPublished.BorderStyle = BorderStyle.FixedSingle;
            this.lblPublished.Dock = DockStyle.Fill;
            this.lblPublished.Text = "";
            this.lblPublished.TextAlign = ContentAlignment.MiddleCenter;
            this.lblPublished.Margin = new Padding(2);

            // lblArchived
            this.lblArchived.AutoSize = false;
            this.lblArchived.BorderStyle = BorderStyle.FixedSingle;
            this.lblArchived.Dock = DockStyle.Fill;
            this.lblArchived.Text = "";
            this.lblArchived.TextAlign = ContentAlignment.MiddleCenter;
            this.lblArchived.Margin = new Padding(2);

            // tblButtons
            this.tblButtons.AutoSize = true;
            this.tblButtons.Dock = DockStyle.Fill;
            this.tblButtons.ColumnCount = 3;
            this.tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            this.tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            this.tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
            this.tblButtons.RowCount = 1;
            this.tblButtons.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.tblButtons.Controls.Add(this.btnDraft, 0, 0);
            this.tblButtons.Controls.Add(this.btnPublish, 1, 0);
            this.tblButtons.Controls.Add(this.btnArchive, 2, 0);
            this.tblButtons.Margin = new Padding(0, 5, 0, 5);

            // btnDraft
            this.btnDraft.AutoSize = true;
            this.btnDraft.Anchor = AnchorStyles.None;
            this.btnDraft.Enabled = false;
            this.btnDraft.Margin = new Padding(2);
            this.btnDraft.Text = "Draft";

            // btnPublish
            this.btnPublish.AutoSize = true;
            this.btnPublish.Anchor = AnchorStyles.None;
            this.btnPublish.Margin = new Padding(2);
            this.btnPublish.Text = "Publish";

            // btnArchive
            this.btnArchive.AutoSize = true;
            this.btnArchive.Anchor = AnchorStyles.None;
            this.btnArchive.Margin = new Padding(2);
            this.btnArchive.Text = "Archive";

            // frmChangeStatus
            this.ClientSize = new Size(600, 250);
            this.Controls.Add(this.tblMain);
            this.Name = "frmChangeStatus";
            this.Text = "Recipe - Change Status";

            this.tblButtons.ResumeLayout(false);
            this.tblButtons.PerformLayout();
            this.tblDates.ResumeLayout(false);
            this.tblDates.PerformLayout();
            this.tblHeadings.ResumeLayout(false);
            this.tblHeadings.PerformLayout();
            this.tblStatus.ResumeLayout(false);
            this.tblStatus.PerformLayout();
            this.tblMain.ResumeLayout(false);
            this.tblMain.PerformLayout();
            this.ResumeLayout(false);
        }
        #endregion
    }
}