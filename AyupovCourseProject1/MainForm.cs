using System.Data.SQLite;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Reflection.Metadata;

namespace AyupovCourseProject1
{
    public partial class MainForm : Form
    {
        private DatabaseService _databaseService;
        private string _currentDbPath;

        private List<MyDocument> documents = new List<MyDocument>
        {

        };
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
            SaveLoadDialogForm sortForm = new SaveLoadDialogForm();
            DialogResult result = sortForm.ShowDialog();
        }

        private void ButtonFilterDataBase_Click(object sender, EventArgs e)
        {
            FilterDialogForm filterForm = new FilterDialogForm();
            DialogResult result = filterForm.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
        "������ ������� ������������ ���� ������ ��� ������� �����?",
        "����� ��������",
        MessageBoxButtons.YesNoCancel,
        MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // ������� ������������ ���� ������
                OpenExistingDatabase();
            }
            else if (result == DialogResult.No)
            {
                // ������� ����� ���� ������
                CreateNewDatabase();
            }
            else
            {
                // ������������ ����� "������" ��� ������ ������
                MessageBox.Show("�������� ��������. ���������� ����� �������.", "����������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close(); // ��������� ����������
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {

            if (DataGridView.SelectedRows.Count > 0)
            {
                // �������� Id ���������� ���������
                int documentId = (int)DataGridView.SelectedRows[0].Cells["Id"].Value;

                // ������� ��������
                DeleteDocument(documentId);

                // ��������� DataGridView
                LoadDataIntoGridView();

                MessageBox.Show("�������� ������� ������!", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string? documentContent = selectedRow.Cells["DocumentContent"].Value.ToString();
                TextBox.Text = documentContent;
            }
        }

        private void ButtonLoadDataBase_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "SQLite Database Files (*.db)|*.db";
                openFileDialog.Title = "�������� ���� ���� ������";

                // ���� ������������ ������ ���� � ����� "��"
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // �������� ���� � ���������� �����
                        string selectedDbPath = openFileDialog.FileName;

                        // ������� ����� ��������� DatabaseService � ��������� ������
                        _databaseService = new DatabaseService(selectedDbPath);

                        // ��������� ������ � DataGridView
                        LoadDataIntoGridView();

                        // �������� ������������ �� �������� ��������
                        MessageBox.Show("���� ������ ������� ���������!", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // ���� ��������� ������, ���������� ���������
                        MessageBox.Show($"������ ��� �������� ���� ������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void DeleteDatabase(string dbPath)
        {
            if (File.Exists(dbPath))
            {
                // ����������� ������������� � ������������
                var result = MessageBox.Show(
                    "�� �������, ��� ������ ������� ���� ������? ��� �������� ������ ��������.",
                    "������������� ��������",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _databaseService?.Dispose(); // ����������� �������
                        _databaseService = null; // �������� ������
                        // ������� ���� ���� ������
                        File.Delete(dbPath);
                        MessageBox.Show("���� ������ ������� �������.", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // ���� ��������� ������, ���������� ���������
                        MessageBox.Show($"������ ��� �������� ���� ������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("���� ���� ������ �� ������.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDataIntoGridView()
        {
            var documents = _databaseService.GetDocuments();
            DataGridView.DataSource = documents;
        }

        private void ButtonDeleteDataBase_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_currentDbPath))
            {
                DeleteDatabase(_currentDbPath);
                _currentDbPath = null; // ������� ������� ����
                DataGridView.DataSource = null; // ������� DataGridView
            }
            else
            {
                MessageBox.Show("���� ������ �� ���������.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void CreateDocument(string senderName, string documentTitle, DateTime receiptDate, string documentTopic, string documentContent)
        {
            using (var context = new ApplicationContext(_currentDbPath))
            {
                MyDocument document = new MyDocument(senderName, documentTitle, receiptDate, documentTopic, documentContent);

                context.Documents.Add(document);
                context.SaveChanges();
            }
        }
        public void DeleteDocument(int documentId)
        {
            using (var context = new ApplicationContext(_currentDbPath))
            {
                var document = context.Documents.Find(documentId);
                if (document != null)
                {
                    context.Documents.Remove(document);
                    context.SaveChanges();
                }
            }
        }
        public void EditDocument(int documentId, string senderName, string documentTitle, DateTime receiptDate, string documentTopic, string documentContent)
        {
            using (var context = new ApplicationContext(_currentDbPath))
            {
                var document = context.Documents.Find(documentId);
                if (document != null)
                {
                    document.SenderName = senderName;
                    document.DocumentTitle = documentTitle;
                    document.ReceiptDate = receiptDate;
                    document.DocumentTopic = documentTopic;
                    document.DocumentContent = documentContent;

                    context.SaveChanges();
                }
            }
        }

        private void ButtonAddDocument_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            CreateDocument("Marat", "Title", date, "Topic", "COOOOOOOOOOOOOOOOOONTEEEEEEEEEEEEEEENT");
            LoadDataIntoGridView();
            MessageBox.Show("�������� ������� ������!", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonRedactDocument_Click(object sender, EventArgs e)
        {
            if (DataGridView.SelectedRows.Count > 0)
            {
                // �������� Id ���������� ���������
                int documentId = (int)DataGridView.SelectedRows[0].Cells["Id"].Value;

                // ����������� ��������
                //EditDocument(documentId, senderName, documentTitle, receiptDate, documentTopic, documentContent);

                // ��������� DataGridView
                LoadDataIntoGridView();

                MessageBox.Show("�������� ������� ��������������!", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("�������� �������� ��� ��������������.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenExistingDatabase()
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "SQLite Database Files (*.db)|*.db";
                openFileDialog.Title = "�������� ���� ���� ������";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // �������� ���� � ���������� �����
                        _currentDbPath = openFileDialog.FileName;

                        // ������� ����� ��������� DatabaseService � ��������� ������
                        _databaseService = new DatabaseService(_currentDbPath);

                        // ��������� ������ � DataGridView
                        LoadDataIntoGridView();

                        MessageBox.Show("���� ������ ������� ���������!", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"������ ��� �������� ���� ������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Close(); // ��������� ���������� � ������ ������
                    }
                }
                else
                {
                    MessageBox.Show("���� ���� ������ �� ������. ���������� ����� �������.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close(); // ��������� ����������, ���� ������������ �� ������ ����
                }
            }
        }

        private void CreateNewDatabase()
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "SQLite Database Files (*.db)|*.db";
                saveFileDialog.Title = "������� ����� ���� ������";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // �������� ���� � ������ �����
                        _currentDbPath = saveFileDialog.FileName;

                        // ������� ����� ��������� DatabaseService � ����� ������
                        _databaseService = new DatabaseService(_currentDbPath);

                        // ������� ��������� ���� ������ (���� � ���)
                        _databaseService.CreateNewDatabase(_currentDbPath);

                        // ������� DataGridView (��� ��� ���� ������ �����)
                        DataGridView.DataSource = null;

                        MessageBox.Show("����� ���� ������ ������� �������!", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"������ ��� �������� ���� ������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Close(); // ��������� ���������� � ������ ������
                    }
                }
                else
                {
                    MessageBox.Show("�������� ���� ������ ��������. ���������� ����� �������.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close(); // ��������� ����������, ���� ������������ �� ������ ����
                }
            }
        }
    }
}
