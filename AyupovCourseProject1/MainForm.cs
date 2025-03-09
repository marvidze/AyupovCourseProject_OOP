namespace AyupovCourseProject1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonSortDataBase_Click(object sender, EventArgs e)
        {
            SortDialogForm sortForm = new SortDialogForm();
            DialogResult result = sortForm.ShowDialog();
        }

        private void ButtonFilterDataBase_Click(object sender, EventArgs e)
        {
            FilterDialogForm filterForm = new FilterDialogForm();
            DialogResult result = filterForm.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MyDocumet doc = new MyDocumet();
            DataGridViewRow row = (DataGridViewRow)DataGridView.Rows[0].Clone();
            row.Cells[0].Value = doc.ID;
            row.Cells[1].Value = doc.SenderName;
            row.Cells[2].Value = doc.DocumentTitle;
            row.Cells[3].Value = doc.ReceiptDate;
            row.Cells[4].Value = doc.DocumentTopic;
            row.Cells[5].Value = doc.DocumentContetnt;
            DataGridView.Rows.Add(row);
        }
    }
}
