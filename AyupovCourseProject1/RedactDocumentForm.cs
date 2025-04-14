using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyModel;

namespace AyupovCourseProject1
{
    public partial class RedactDocumentForm : Form
    {
        private MyDocument document;
        private DatabaseService databaseService;
        private int documentId;

        public RedactDocumentForm() => InitializeComponent();

        public RedactDocumentForm(int documentId, string currentDbPath)
        {
            InitializeComponent();
            this.documentId = documentId;
            databaseService = new DatabaseService(currentDbPath);
            document = databaseService.FindDocumentById(documentId);
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            databaseService.RedactDocument(documentId, textBox_name.Text, textBox_title.Text, textBox_topic.Text, textBox_content.Text);
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void RedactDocumentForm_Load(object sender, EventArgs e)
        {
            textBox_name.Text = document.SenderName;
            textBox_title.Text = document.DocumentTitle;
            textBox_topic.Text = document.DocumentTopic;
            textBox_content.Text = document.DocumentContent;
        }

        private void RedactDocument(int documentId, string senderName, string documentTitle, string documentTopic, string documentContent)
        {
            databaseService.RedactDocument(documentId, senderName, documentTitle, documentTopic, documentContent);
        }
    }
}
