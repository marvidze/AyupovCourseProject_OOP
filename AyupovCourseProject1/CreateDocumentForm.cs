using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AyupovCourseProject1
{
    public partial class CreateDocumentForm : Form
    {
        private DatabaseService databaseService;

        public CreateDocumentForm() => InitializeComponent();

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            string senderName = textBox_name.Text;
            string title = textBox_title.Text;
            string topic = textBox_topic.Text;
            string content = textBox_content.Text;
            databaseService.CreateDocument(senderName, title, dateTime, topic, content);
            this.DialogResult = DialogResult.OK;
            Close();
        }

        public CreateDocumentForm(string currentDbPath)
        {
            InitializeComponent();
            databaseService = new DatabaseService(currentDbPath);
        }

        private void CreateDocumentForm_Load(object sender, EventArgs e)
        {
            textBox_name.Text = "Иванов Иван Иванович";
            textBox_title.Text = "Заголовок";
            textBox_topic.Text = "Тема";
            textBox_content.Text = "Содержание";
        }
    }
}
