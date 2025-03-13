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
        "Хотите открыть существующую базу данных или создать новую?",
        "Выбор действия",
        MessageBoxButtons.YesNoCancel,
        MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Открыть существующую базу данных
                OpenExistingDatabase();
            }
            else if (result == DialogResult.No)
            {
                // Создать новую базу данных
                CreateNewDatabase();
            }
            else
            {
                // Пользователь нажал "Отмена" или закрыл диалог
                MessageBox.Show("Действие отменено. Приложение будет закрыто.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close(); // Закрываем приложение
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {

            if (DataGridView.SelectedRows.Count > 0)
            {
                // Получаем Id выбранного документа
                int documentId = (int)DataGridView.SelectedRows[0].Cells["Id"].Value;

                // Удаляем документ
                DeleteDocument(documentId);

                // Обновляем DataGridView
                LoadDataIntoGridView();

                MessageBox.Show("Документ успешно удален!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Выберите документ для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                openFileDialog.Title = "Выберите файл базы данных";

                // Если пользователь выбрал файл и нажал "ОК"
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Получаем путь к выбранному файлу
                        string selectedDbPath = openFileDialog.FileName;

                        // Создаем новый экземпляр DatabaseService с выбранным файлом
                        _databaseService = new DatabaseService(selectedDbPath);

                        // Загружаем данные в DataGridView
                        LoadDataIntoGridView();

                        // Сообщаем пользователю об успешной загрузке
                        MessageBox.Show("База данных успешно загружена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // Если произошла ошибка, показываем сообщение
                        MessageBox.Show($"Ошибка при загрузке базы данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void DeleteDatabase(string dbPath)
        {
            if (File.Exists(dbPath))
            {
                // Запрашиваем подтверждение у пользователя
                var result = MessageBox.Show(
                    "Вы уверены, что хотите удалить базу данных? Это действие нельзя отменить.",
                    "Подтверждение удаления",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _databaseService?.Dispose(); // Освобождаем ресурсы
                        _databaseService = null; // Обнуляем ссылку
                        // Удаляем файл базы данных
                        File.Delete(dbPath);
                        MessageBox.Show("База данных успешно удалена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // Если произошла ошибка, показываем сообщение
                        MessageBox.Show($"Ошибка при удалении базы данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Файл базы данных не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                _currentDbPath = null; // Очищаем текущий путь
                DataGridView.DataSource = null; // Очищаем DataGridView
            }
            else
            {
                MessageBox.Show("База данных не загружена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            MessageBox.Show("Документ успешно создан!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonRedactDocument_Click(object sender, EventArgs e)
        {
            if (DataGridView.SelectedRows.Count > 0)
            {
                // Получаем Id выбранного документа
                int documentId = (int)DataGridView.SelectedRows[0].Cells["Id"].Value;

                // Редактируем документ
                //EditDocument(documentId, senderName, documentTitle, receiptDate, documentTopic, documentContent);

                // Обновляем DataGridView
                LoadDataIntoGridView();

                MessageBox.Show("Документ успешно отредактирован!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Выберите документ для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenExistingDatabase()
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "SQLite Database Files (*.db)|*.db";
                openFileDialog.Title = "Выберите файл базы данных";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Получаем путь к выбранному файлу
                        _currentDbPath = openFileDialog.FileName;

                        // Создаем новый экземпляр DatabaseService с выбранным файлом
                        _databaseService = new DatabaseService(_currentDbPath);

                        // Загружаем данные в DataGridView
                        LoadDataIntoGridView();

                        MessageBox.Show("База данных успешно загружена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при загрузке базы данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Close(); // Закрываем приложение в случае ошибки
                    }
                }
                else
                {
                    MessageBox.Show("Файл базы данных не выбран. Приложение будет закрыто.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close(); // Закрываем приложение, если пользователь не выбрал файл
                }
            }
        }

        private void CreateNewDatabase()
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "SQLite Database Files (*.db)|*.db";
                saveFileDialog.Title = "Создать новую базу данных";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Получаем путь к новому файлу
                        _currentDbPath = saveFileDialog.FileName;

                        // Создаем новый экземпляр DatabaseService с новым файлом
                        _databaseService = new DatabaseService(_currentDbPath);

                        // Создаем структуру базы данных (если её нет)
                        _databaseService.CreateNewDatabase(_currentDbPath);

                        // Очищаем DataGridView (так как база данных новая)
                        DataGridView.DataSource = null;

                        MessageBox.Show("Новая база данных успешно создана!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при создании базы данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Close(); // Закрываем приложение в случае ошибки
                    }
                }
                else
                {
                    MessageBox.Show("Создание базы данных отменено. Приложение будет закрыто.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close(); // Закрываем приложение, если пользователь не выбрал файл
                }
            }
        }
    }
}
