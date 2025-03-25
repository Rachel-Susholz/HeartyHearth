namespace HeartyHearthWinForm
{
    public abstract class MultiFormBase : Form
    {
        protected BindingSource BindSource = new BindingSource();
        public int PrimaryKeyId { get; protected set; }
        protected abstract DataTable[] GetDataTablesForChangeCheck();
        protected abstract bool SaveData();
        protected virtual void PreClose()
        {
            BindSource.EndEdit();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            PreClose();
            DataTable[] tables = GetDataTablesForChangeCheck();
            bool hasChanges = false;
            foreach (DataTable dt in tables)
            {
                if (SQLUtility.DoesTableHaveChanges(dt))
                {
                    hasChanges = true;
                    break;
                }
            }
            if (hasChanges)
            {
                DialogResult res = MessageBox.Show($"Do you want to save changes to {this.Text} before closing?",
                    Application.ProductName, MessageBoxButtons.YesNoCancel);
                if (res == DialogResult.Yes)
                {
                    if (!SaveData())
                    {
                        e.Cancel = true;
                        this.Activate();
                        return;
                    }
                }
                else if (res == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    this.Activate();
                    return;
                }
            }
            base.OnFormClosing(e);
        }
    }
}
