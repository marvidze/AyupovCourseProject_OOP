using System.Data.SQLite;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Reflection.Metadata;
using QuestPDF;
using QuestPDF.Fluent;

namespace AyupovCourseProject1
{
    public partial class MainForm : Form
    {

        private static DatabaseService DatabaseService { get; set; } = null!;
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
                (List<MyDocument>, int) pair = DatabaseService.GetDocumentsByDate(filterForm.startDate, filterForm.endTime);
                DataGridView.DataSource = pair.Item1;
                labelCountOfElements.Text = pair.Item2 + " �� " + DatabaseService.GetCountOfDocuments();
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
            List<MyDocument> documents = DatabaseService.GetDocuments();
            DataGridView.DataSource = ConvertToDataTable(documents);
            labelCountOfElements.Text = $"{documents.Count} �� {DatabaseService.GetCountOfDocuments()}";
        }

        private DataTable ConvertToDataTable(List<MyDocument> documents)
        {
            DataTable table = new DataTable();

            table.Columns.AddRange(new[]
            {
                new DataColumn("ID", typeof(int)),
                new DataColumn("��� �����������", typeof(string)),
                new DataColumn("���������", typeof(string)),
                new DataColumn("���� ��������", typeof(DateTime)),
                new DataColumn("����", typeof(string)),
                new DataColumn("����������", typeof(string))
            });

            foreach (var doc in documents)
            {
                table.Rows.Add(doc.ID, doc.SenderName, doc.DocumentTitle,
                              doc.ReceiptDate, doc.DocumentTopic, doc.DocumentContent);
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
            SaveFileDialog saveFileDialog = new()
            {
                Title = "�������� ����� ���������� ���� ������",
                Filter = "SQLite Database (*.sqlite, *.db, *.sqlite3)|*.sqlite;*.db;*.sqlite3|��� ����� (*.*)|*.*",
                DefaultExt = ".sqlite",
                AddExtension = true,
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string destinationPath = saveFileDialog.FileName;

                try
                {
                    if (File.Exists(CurrentDbPath))
                    {
                        File.Copy(CurrentDbPath, destinationPath, overwrite: true);
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


        private void ButtonSearchDocument_Click(object sender, EventArgs e)
        {
            string searchText = TextBoxSearch.Text;
            (List<MyDocument>, int) pair = DatabaseService.SearchDocumentsByTitle(searchText);
            List<MyDocument> filteredDocuments = pair.Item1;
            int countOfElements = pair.Item2;

            DataGridView.DataSource = ConvertToDataTable(filteredDocuments);
            labelCountOfElements.Text = countOfElements + " �� " + DatabaseService.GetCountOfDocuments();
        }

        private void ButtonRestFilter_Click(object sender, EventArgs e)
        {
            LoadDataIntoGridView();
        }

        public void ExportToPdf(string filePath)
        {
            try
            {
                List<MyDocument> documents = DatabaseService.GetDocuments();

                DocumentPdfTemplate pdf = new(documents);

                pdf.GeneratePdf(filePath);

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = filePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��������� PDF: {ex.Message}",
                              "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCreatePDF_Click(object sender, EventArgs e)
        {
            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveDialog.FileName = $"�����_��_����_������_{DateTime.Now:yyyyMMddhh}.pdf";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportToPdf(saveDialog.FileName);
                }
            }
        }
    }
}
