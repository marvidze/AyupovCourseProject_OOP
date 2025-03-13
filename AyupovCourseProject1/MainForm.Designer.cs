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
            ButtonLoadDataBase = new Button();
            ButtonSaveDataBase = new Button();
            ButtonDeleteDataBase = new Button();
            ButtonExit = new Button();
            ButtonFilterDataBase = new Button();
            ButtonAddDocument = new Button();
            ButtonDelete = new Button();
            buttonRedactDocument = new Button();
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
            DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView.Location = new Point(16, 66);
            DataGridView.Name = "DataGridView";
            DataGridView.Size = new Size(1018, 295);
            DataGridView.TabIndex = 0;
            DataGridView.SelectionChanged += DataGridView_SelectionChanged;
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
            ButtonLoadDataBase.Click += ButtonLoadDataBase_Click;
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
            ButtonDeleteDataBase.Click += ButtonDeleteDataBase_Click;
            // 
            // ButtonExit
            // 
            ButtonExit.BackgroundImage = (Image)resources.GetObject("ButtonExit.BackgroundImage");
            ButtonExit.BackgroundImageLayout = ImageLayout.Zoom;
            ButtonExit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ButtonExit.Location = new Point(984, 485);
            ButtonExit.Name = "ButtonExit";
            ButtonExit.Size = new Size(50, 55);
            ButtonExit.TabIndex = 1;
            ButtonExit.UseVisualStyleBackColor = true;
            ButtonExit.Click += ButtonExit_Click;
            // 
            // ButtonFilterDataBase
            // 
            ButtonFilterDataBase.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ButtonFilterDataBase.Location = new Point(16, 12);
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
            ButtonAddDocument.Click += ButtonAddDocument_Click;
            // 
            // ButtonDelete
            // 
            ButtonDelete.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ButtonDelete.Location = new Point(404, 367);
            ButtonDelete.Name = "ButtonDelete";
            ButtonDelete.Size = new Size(188, 55);
            ButtonDelete.TabIndex = 1;
            ButtonDelete.Text = "Удалить документ";
            ButtonDelete.UseVisualStyleBackColor = true;
            ButtonDelete.Click += ButtonDelete_Click;
            // 
            // buttonRedactDocument
            // 
            buttonRedactDocument.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonRedactDocument.Location = new Point(16, 367);
            buttonRedactDocument.Name = "buttonRedactDocument";
            buttonRedactDocument.Size = new Size(188, 55);
            buttonRedactDocument.TabIndex = 1;
            buttonRedactDocument.Text = "Редактировать документ";
            buttonRedactDocument.UseVisualStyleBackColor = true;
            buttonRedactDocument.Click += buttonRedactDocument_Click;
            // 
            // TextBox
            // 
            TextBox.Location = new Point(598, 391);
            TextBox.Multiline = true;
            TextBox.Name = "TextBox";
            TextBox.ScrollBars = ScrollBars.Vertical;
            TextBox.Size = new Size(380, 152);
            TextBox.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(598, 367);
            label1.Name = "label1";
            label1.Size = new Size(232, 21);
            label1.TabIndex = 5;
            label1.Text = "Вывод содержания документа:";
            // 
            // ButtonSEarchDocument
            // 
            ButtonSEarchDocument.BackgroundImage = (Image)resources.GetObject("ButtonSEarchDocument.BackgroundImage");
            ButtonSEarchDocument.BackgroundImageLayout = ImageLayout.Zoom;
            ButtonSEarchDocument.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ButtonSEarchDocument.Location = new Point(984, 12);
            ButtonSEarchDocument.Name = "ButtonSEarchDocument";
            ButtonSEarchDocument.Size = new Size(50, 48);
            ButtonSEarchDocument.TabIndex = 3;
            ButtonSEarchDocument.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(598, 28);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(380, 23);
            textBox1.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(598, 4);
            label2.Name = "label2";
            label2.Size = new Size(235, 21);
            label2.TabIndex = 5;
            label2.Text = "Поиск документа по заголовку:";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1045, 552);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(TextBox);
            Controls.Add(ButtonSEarchDocument);
            Controls.Add(ButtonFilterDataBase);
            Controls.Add(ButtonExit);
            Controls.Add(ButtonDeleteDataBase);
            Controls.Add(buttonRedactDocument);
            Controls.Add(ButtonDelete);
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
        private Button ButtonFilterDataBase;
        private Button ButtonAddDocument;
        private Button ButtonDelete;
        private Button buttonRedactDocument;
        private TextBox TextBox;
        private Label label1;
        private Button ButtonSEarchDocument;
        private TextBox textBox1;
        private Label label2;
    }
}
