namespace AyupovCourseProject1
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            DataGridView = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            SenderName = new DataGridViewTextBoxColumn();
            DocumentTitle = new DataGridViewTextBoxColumn();
            ReceiptDate = new DataGridViewTextBoxColumn();
            DocumentTopic = new DataGridViewTextBoxColumn();
            DocumentContent = new DataGridViewTextBoxColumn();
            ButtonLoadDataBase = new Button();
            ButtonSaveDataBase = new Button();
            ButtonDeleteDataBase = new Button();
            ButtonExit = new Button();
            ButtonSortDataBase = new Button();
            ButtonFilterDataBase = new Button();
            ButtonAddDocument = new Button();
            button1 = new Button();
            button2 = new Button();
            TextBox = new TextBox();
            label1 = new Label();
            ButtonSEarchDocument = new Button();
            textBox1 = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)DataGridView).BeginInit();
            SuspendLayout();
            // 
            // DataGridView
            // 
            DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView.Columns.AddRange(new DataGridViewColumn[] { ID, SenderName, DocumentTitle, ReceiptDate, DocumentTopic, DocumentContent });
            DataGridView.Location = new Point(16, 66);
            DataGridView.Name = "DataGridView";
            DataGridView.Size = new Size(1019, 295);
            DataGridView.TabIndex = 0;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Width = 25;
            // 
            // SenderName
            // 
            SenderName.HeaderText = "Отправитель";
            SenderName.Name = "SenderName";
            SenderName.ReadOnly = true;
            SenderName.Width = 150;
            // 
            // DocumentTitle
            // 
            DocumentTitle.HeaderText = "Заголовок";
            DocumentTitle.Name = "DocumentTitle";
            DocumentTitle.ReadOnly = true;
            DocumentTitle.Width = 150;
            // 
            // ReceiptDate
            // 
            ReceiptDate.HeaderText = "Дата приёма";
            ReceiptDate.Name = "ReceiptDate";
            ReceiptDate.ReadOnly = true;
            ReceiptDate.Width = 200;
            // 
            // DocumentTopic
            // 
            DocumentTopic.HeaderText = "Тема";
            DocumentTopic.Name = "DocumentTopic";
            DocumentTopic.ReadOnly = true;
            DocumentTopic.Width = 150;
            // 
            // DocumentContent
            // 
            DocumentContent.HeaderText = "Содаржание";
            DocumentContent.Name = "DocumentContent";
            DocumentContent.ReadOnly = true;
            DocumentContent.Width = 300;
            // 
            // ButtonLoadDataBase
            // 
            ButtonLoadDataBase.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ButtonLoadDataBase.Location = new Point(210, 485);
            ButtonLoadDataBase.Name = "ButtonLoadDataBase";
            ButtonLoadDataBase.Size = new Size(188, 55);
            ButtonLoadDataBase.TabIndex = 1;
            ButtonLoadDataBase.Text = "Загрузить базу данных";
            ButtonLoadDataBase.UseVisualStyleBackColor = true;
            // 
            // ButtonSaveDataBase
            // 
            ButtonSaveDataBase.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ButtonSaveDataBase.Location = new Point(16, 485);
            ButtonSaveDataBase.Name = "ButtonSaveDataBase";
            ButtonSaveDataBase.Size = new Size(188, 55);
            ButtonSaveDataBase.TabIndex = 1;
            ButtonSaveDataBase.Text = "Сохранить базу данных";
            ButtonSaveDataBase.UseVisualStyleBackColor = true;
            // 
            // ButtonDeleteDataBase
            // 
            ButtonDeleteDataBase.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ButtonDeleteDataBase.Location = new Point(404, 485);
            ButtonDeleteDataBase.Name = "ButtonDeleteDataBase";
            ButtonDeleteDataBase.Size = new Size(188, 55);
            ButtonDeleteDataBase.TabIndex = 1;
            ButtonDeleteDataBase.Text = "Удалить базу данных";
            ButtonDeleteDataBase.UseVisualStyleBackColor = true;
            // 
            // ButtonExit
            // 
            ButtonExit.BackgroundImage = (Image)resources.GetObject("ButtonExit.BackgroundImage");
            ButtonExit.BackgroundImageLayout = ImageLayout.Zoom;
            ButtonExit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ButtonExit.Location = new Point(977, 485);
            ButtonExit.Name = "ButtonExit";
            ButtonExit.Size = new Size(50, 55);
            ButtonExit.TabIndex = 1;
            ButtonExit.UseVisualStyleBackColor = true;
            ButtonExit.Click += ButtonExit_Click;
            // 
            // ButtonSortDataBase
            // 
            ButtonSortDataBase.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ButtonSortDataBase.Location = new Point(16, 12);
            ButtonSortDataBase.Name = "ButtonSortDataBase";
            ButtonSortDataBase.Size = new Size(188, 48);
            ButtonSortDataBase.TabIndex = 2;
            ButtonSortDataBase.Text = "Сортировать";
            ButtonSortDataBase.UseVisualStyleBackColor = true;
            ButtonSortDataBase.Click += ButtonSortDataBase_Click;
            // 
            // ButtonFilterDataBase
            // 
            ButtonFilterDataBase.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ButtonFilterDataBase.Location = new Point(223, 12);
            ButtonFilterDataBase.Name = "ButtonFilterDataBase";
            ButtonFilterDataBase.Size = new Size(188, 48);
            ButtonFilterDataBase.TabIndex = 3;
            ButtonFilterDataBase.Text = "Фильтровать по дате";
            ButtonFilterDataBase.UseVisualStyleBackColor = true;
            ButtonFilterDataBase.Click += ButtonFilterDataBase_Click;
            // 
            // ButtonAddDocument
            // 
            ButtonAddDocument.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ButtonAddDocument.Location = new Point(210, 367);
            ButtonAddDocument.Name = "ButtonAddDocument";
            ButtonAddDocument.Size = new Size(188, 55);
            ButtonAddDocument.TabIndex = 1;
            ButtonAddDocument.Text = "Добавить документ";
            ButtonAddDocument.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.Location = new Point(404, 367);
            button1.Name = "button1";
            button1.Size = new Size(188, 55);
            button1.TabIndex = 1;
            button1.Text = "Удалить документ";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button2.Location = new Point(16, 367);
            button2.Name = "button2";
            button2.Size = new Size(188, 55);
            button2.TabIndex = 1;
            button2.Text = "Редактировать документ";
            button2.UseVisualStyleBackColor = true;
            // 
            // TextBox
            // 
            TextBox.Location = new Point(598, 391);
            TextBox.Multiline = true;
            TextBox.Name = "TextBox";
            TextBox.ScrollBars = ScrollBars.Vertical;
            TextBox.Size = new Size(373, 152);
            TextBox.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(598, 367);
            label1.Name = "label1";
            label1.Size = new Size(131, 21);
            label1.TabIndex = 5;
            label1.Text = "Вывод значений:";
            // 
            // ButtonSEarchDocument
            // 
            ButtonSEarchDocument.BackgroundImage = (Image)resources.GetObject("ButtonSEarchDocument.BackgroundImage");
            ButtonSEarchDocument.BackgroundImageLayout = ImageLayout.Zoom;
            ButtonSEarchDocument.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ButtonSEarchDocument.Location = new Point(977, 9);
            ButtonSEarchDocument.Name = "ButtonSEarchDocument";
            ButtonSEarchDocument.Size = new Size(50, 48);
            ButtonSEarchDocument.TabIndex = 3;
            ButtonSEarchDocument.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(627, 28);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(344, 23);
            textBox1.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(627, 4);
            label2.Name = "label2";
            label2.Size = new Size(235, 21);
            label2.TabIndex = 5;
            label2.Text = "Поиск документа по заголовку:";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1039, 552);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(TextBox);
            Controls.Add(ButtonSEarchDocument);
            Controls.Add(ButtonFilterDataBase);
            Controls.Add(ButtonSortDataBase);
            Controls.Add(ButtonExit);
            Controls.Add(ButtonDeleteDataBase);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(ButtonAddDocument);
            Controls.Add(ButtonSaveDataBase);
            Controls.Add(ButtonLoadDataBase);
            Controls.Add(DataGridView);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Главная программа";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)DataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DataGridView;
        private Button ButtonLoadDataBase;
        private Button ButtonSaveDataBase;
        private Button ButtonDeleteDataBase;
        private Button ButtonExit;
        private Button ButtonSortDataBase;
        private Button ButtonFilterDataBase;
        private Button ButtonAddDocument;
        private Button button1;
        private Button button2;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn SenderName;
        private DataGridViewTextBoxColumn DocumentTitle;
        private DataGridViewTextBoxColumn ReceiptDate;
        private DataGridViewTextBoxColumn DocumentTopic;
        private DataGridViewTextBoxColumn DocumentContent;
        private TextBox TextBox;
        private Label label1;
        private Button ButtonSEarchDocument;
        private TextBox textBox1;
        private Label label2;
    }
}
