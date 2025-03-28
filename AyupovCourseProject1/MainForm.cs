using System.Data.SQLite;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Reflection.Metadata;

namespace AyupovCourseProject1
{
    public partial class MainForm : Form
    {

        public static DatabaseService DatabaseService { get; private set; } = null!;
        private string CurrentDbPath { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonFilterDataBase_Click(object sender, EventArgs e)
        {
            FilterDialogForm filterForm = new FilterDialogForm();
            DialogResult result = filterForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                DataGridView.DataSource = DatabaseService.GetDocumentsByDate(filterForm.startDate, filterForm.endTime);
            }
            else
            {
                MessageBox.Show("���������� ��������");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show
                    (
                    "������ ������� ������������ ���� ������ ��� ������� �����? \n(�� -> ������� ���� ������, ��� -> ������� ���� ������)",
                    "����� ��������",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question
                    );

            if (dialogResult == DialogResult.Yes)
            {
                OpenExistingDatabase();
            }
            else if (dialogResult == DialogResult.No)
            {
                CreateNewDatabase();
            }
            else
            {
                MessageBox.Show("�������� ��������. ���������� ����� �������.", "����������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {

            if (DataGridView.SelectedRows.Count > 0)
            {
                int documentId = (int)DataGridView.SelectedRows[0].Cells["Id"].Value;
                DeleteDocument(documentId);
                LoadDataIntoGridView();
            }
            else
            {
                MessageBox.Show("�������� �������� ��� ��������.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (DataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = DataGridView.SelectedRows[0];
                string? documentContent = selectedRow.Cells["����������"].Value.ToString();
                TextBoxContent.Text = documentContent;
            }
        }

        private void ButtonLoadDataBase_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "SQLite Database Files (*.db)|*.db";
            openFileDialog.Title = "�������� ���� ���� ������";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string selectedDbPath = openFileDialog.FileName;

                    DatabaseService = new DatabaseService(selectedDbPath);
                    CurrentDbPath = selectedDbPath;
                    labelDBPath.Text = CurrentDbPath;

                    LoadDataIntoGridView();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"������ ��� �������� ���� ������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void DeleteDatabase(string dbPath)
        {
            DialogResult dialogResult = MessageBox.Show(
                "�� �������, ��� ������ ������� ���� ������? ��� �������� ������ ��������.",
                "������������� ��������",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    DatabaseService?.Dispose();
                    DatabaseService = null;
                    File.Delete(dbPath);
                    MessageBox.Show("���� ������ ������� �������.", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"������ ��� �������� ���� ������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadDataIntoGridView()
        {
            var documents = DatabaseService.GetDocuments();
            DataGridView.DataSource = ConvertToDataTable(documents);
        }

        private DataTable ConvertToDataTable(List<MyDocument> documents)
        {
            DataTable table = new DataTable();

            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("��� �����������", typeof(string));
            table.Columns.Add("���������", typeof(string));
            table.Columns.Add("���� ��������", typeof(DateTime));
            table.Columns.Add("����", typeof(string));
            table.Columns.Add("����������", typeof(string));

            foreach (var doc in documents)
            {
                table.Rows.Add(doc.ID, doc.SenderName, doc.DocumentTitle, doc.ReceiptDate, doc.DocumentTopic, doc.DocumentContent);
            }

            return table;
        }

        private void ButtonDeleteDataBase_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CurrentDbPath))
            {
                DeleteDatabase(CurrentDbPath);
                CurrentDbPath = null!;
                DataGridView.DataSource = null;
            }
            else
            {
                MessageBox.Show("���� ������ �� ���������.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteDocument(int documentId)
        {
            DatabaseService.DeleteDocument(documentId);
        }


        private void ButtonAddDocument_Click(object sender, EventArgs e)
        {
            CreateDocumentForm createDocumentForm = new CreateDocumentForm(CurrentDbPath);
            DialogResult result = createDocumentForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadDataIntoGridView();
                MessageBox.Show("�������� ������� ������!", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ButtonRedactDocument_Click(object sender, EventArgs e)
        {
            if (DataGridView.SelectedRows.Count > 0)
            {

                int documentId = (int)DataGridView.SelectedRows[0].Cells["Id"].Value;

                RedactDocumentForm redactDocumentForm = new RedactDocumentForm(documentId, CurrentDbPath);
                DialogResult result = redactDocumentForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    LoadDataIntoGridView();
                    MessageBox.Show("�������� ������� ��������������!", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("�������� �������� ��� ��������������.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenExistingDatabase()
        {
            OpenFileDialog openFileDialog = new()
            {
                Filter = "SQLite Database Files (*.db)|*.db",
                Title = "�������� ���� ���� ������"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    CurrentDbPath = openFileDialog.FileName;
                    labelDBPath.Text = CurrentDbPath;
                    DatabaseService = new DatabaseService(CurrentDbPath);
                    LoadDataIntoGridView();
                    MessageBox.Show("���� ������ ������� ���������!", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"������ ��� �������� ���� ������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            else
            {
                MessageBox.Show("���� ���� ������ �� ������. ���������� ����� �������.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

        }

        private void CreateNewDatabase()
        {
            SaveFileDialog saveFileDialog = new()
            {
                Filter = "SQLite Database Files (*.db)|*.db",
                Title = "������� ����� ���� ������"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    CurrentDbPath = saveFileDialog.FileName;
                    labelDBPath.Text = CurrentDbPath;
                    DatabaseService = new DatabaseService(CurrentDbPath);
                    DatabaseService.CreateNewDatabase(CurrentDbPath);
                    DataGridView.DataSource = null;
                    MessageBox.Show("����� ���� ������ ������� �������!", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"������ ��� �������� ���� ������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            else
            {
                MessageBox.Show("�������� ���� ������ ��������. ���������� ����� �������.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

        }

        private void ButtonSaveDataBase_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "�������� ����� ���������� ���� ������";
                saveFileDialog.Filter = "SQLite Database (*.sqlite, *.db, *.sqlite3)|*.sqlite;*.db;*.sqlite3|��� ����� (*.*)|*.*";
                saveFileDialog.DefaultExt = ".sqlite";
                saveFileDialog.AddExtension = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string destinationPath = saveFileDialog.FileName;

                    try
                    {
                        string currentDatabasePath =  CurrentDbPath; 

                        if (File.Exists(currentDatabasePath))
                        {
                            File.Copy(currentDatabasePath, destinationPath, overwrite: true);
                            MessageBox.Show($"���� ������ ������� ��������� �:\n{destinationPath}", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("������: �������� ���� ������ �� �������!", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"������ ��� ���������� ���� ������:\n{ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ButtonSEarchDocument_Click(object sender, EventArgs e)
        {
            string searchText = TextBoxSearch.Text;

            var filteredDocuments = DatabaseService.SearchDocumentsByTitle(searchText);

            DataGridView.DataSource = filteredDocuments;
        }

        private void ButtonRestFilter_Click(object sender, EventArgs e)
        {
            LoadDataIntoGridView();
        }
    }
}
