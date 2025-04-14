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
            ButtonExit = new Button();
            ButtonFilterDataBase = new Button();
            ButtonAddDocument = new Button();
            ButtonDelete = new Button();
            buttonRedactDocument = new Button();
            TextBoxContent = new TextBox();
            label1 = new Label();
            ButtonSEarchDocument = new Button();
            TextBoxSearch = new TextBox();
            label2 = new Label();
            buttonRestFilter = new Button();
            label3 = new Label();
            labelDBPath = new Label();
            label4 = new Label();
            labelCountOfElements = new Label();
            buttonCreatePDF = new Button();
            ((System.ComponentModel.ISupportInitialize)DataGridView).BeginInit();
            SuspendLayout();
            // 
            // DataGridView
            // 
            DataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView.Location = new Point(16, 79);
            DataGridView.Name = "DataGridView";
            DataGridView.ReadOnly = true;
            DataGridView.Size = new Size(1133, 282);
            DataGridView.TabIndex = 0;
            DataGridView.SelectionChanged += DataGridView_SelectionChanged;
            // 
            // ButtonLoadDataBase
            // 
            ButtonLoadDataBase.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ButtonLoadDataBase.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ButtonLoadDataBase.Location = new Point(404, 485);
            ButtonLoadDataBase.Name = "ButtonLoadDataBase";
            ButtonLoadDataBase.Size = new Size(188, 55);
            ButtonLoadDataBase.TabIndex = 1;
            ButtonLoadDataBase.Text = "Загрузить базу данных";
            ButtonLoadDataBase.UseVisualStyleBackColor = true;
            ButtonLoadDataBase.Click += ButtonLoadDataBase_Click;
            // 
            // ButtonSaveDataBase
            // 
            ButtonSaveDataBase.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ButtonSaveDataBase.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ButtonSaveDataBase.Location = new Point(16, 485);
            ButtonSaveDataBase.Name = "ButtonSaveDataBase";
            ButtonSaveDataBase.Size = new Size(188, 55);
            ButtonSaveDataBase.TabIndex = 1;
            ButtonSaveDataBase.Text = "Сохранить базу данных";
            ButtonSaveDataBase.UseVisualStyleBackColor = true;
            ButtonSaveDataBase.Click += ButtonSaveDataBase_Click;
            // 
            // ButtonExit
            // 
            ButtonExit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ButtonExit.BackgroundImage = (Image)resources.GetObject("ButtonExit.BackgroundImage");
            ButtonExit.BackgroundImageLayout = ImageLayout.Zoom;
            ButtonExit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ButtonExit.Location = new Point(1099, 488);
            ButtonExit.Name = "ButtonExit";
            ButtonExit.Size = new Size(50, 55);
            ButtonExit.TabIndex = 1;
            ButtonExit.UseVisualStyleBackColor = true;
            ButtonExit.Click += ButtonExit_Click;
            // 
            // ButtonFilterDataBase
            // 
            ButtonFilterDataBase.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ButtonFilterDataBase.Location = new Point(16, 25);
            ButtonFilterDataBase.Name = "ButtonFilterDataBase";
            ButtonFilterDataBase.Size = new Size(188, 48);
            ButtonFilterDataBase.TabIndex = 3;
            ButtonFilterDataBase.Text = "Фильтровать по дате";
            ButtonFilterDataBase.UseVisualStyleBackColor = true;
            ButtonFilterDataBase.Click += ButtonFilterDataBase_Click;
            // 
            // ButtonAddDocument
            // 
            ButtonAddDocument.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
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
            ButtonDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
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
            buttonRedactDocument.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonRedactDocument.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonRedactDocument.Location = new Point(16, 367);
            buttonRedactDocument.Name = "buttonRedactDocument";
            buttonRedactDocument.Size = new Size(188, 55);
            buttonRedactDocument.TabIndex = 1;
            buttonRedactDocument.Text = "Редактировать документ";
            buttonRedactDocument.UseVisualStyleBackColor = true;
            buttonRedactDocument.Click += ButtonRedactDocument_Click;
            // 
            // TextBoxContent
            // 
            TextBoxContent.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxContent.ImeMode = ImeMode.KatakanaHalf;
            TextBoxContent.Location = new Point(598, 391);
            TextBoxContent.MaximumSize = new Size(1200, 300);
            TextBoxContent.MinimumSize = new Size(225, 75);
            TextBoxContent.Multiline = true;
            TextBoxContent.Name = "TextBoxContent";
            TextBoxContent.ReadOnly = true;
            TextBoxContent.ScrollBars = ScrollBars.Vertical;
            TextBoxContent.Size = new Size(495, 152);
            TextBoxContent.TabIndex = 4;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
            ButtonSEarchDocument.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonSEarchDocument.BackgroundImage = (Image)resources.GetObject("ButtonSEarchDocument.BackgroundImage");
            ButtonSEarchDocument.BackgroundImageLayout = ImageLayout.Zoom;
            ButtonSEarchDocument.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ButtonSEarchDocument.Location = new Point(1099, 25);
            ButtonSEarchDocument.Name = "ButtonSEarchDocument";
            ButtonSEarchDocument.Size = new Size(50, 48);
            ButtonSEarchDocument.TabIndex = 3;
            ButtonSEarchDocument.UseVisualStyleBackColor = true;
            ButtonSEarchDocument.Click += ButtonSearchDocument_Click;
            // 
            // TextBoxSearch
            // 
            TextBoxSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            TextBoxSearch.Location = new Point(713, 50);
            TextBoxSearch.Name = "TextBoxSearch";
            TextBoxSearch.Size = new Size(380, 23);
            TextBoxSearch.TabIndex = 6;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(713, 25);
            label2.Name = "label2";
            label2.Size = new Size(235, 21);
            label2.TabIndex = 5;
            label2.Text = "Поиск документа по заголовку:";
            // 
            // buttonRestFilter
            // 
            buttonRestFilter.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonRestFilter.Location = new Point(210, 25);
            buttonRestFilter.Name = "buttonRestFilter";
            buttonRestFilter.Size = new Size(188, 48);
            buttonRestFilter.TabIndex = 3;
            buttonRestFilter.Text = "Отменить фильтрацию";
            buttonRestFilter.UseVisualStyleBackColor = true;
            buttonRestFilter.Click += ButtonRestFilter_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(16, 1);
            label3.Name = "label3";
            label3.Size = new Size(148, 21);
            label3.TabIndex = 7;
            label3.Text = "Путь открытой БД: ";
            // 
            // labelDBPath
            // 
            labelDBPath.AutoSize = true;
            labelDBPath.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelDBPath.Location = new Point(170, 1);
            labelDBPath.Name = "labelDBPath";
            labelDBPath.Size = new Size(0, 21);
            labelDBPath.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(404, 48);
            label4.Name = "label4";
            label4.Size = new Size(161, 21);
            label4.TabIndex = 9;
            label4.Text = "Показано элементов:";
            // 
            // labelCountOfElements
            // 
            labelCountOfElements.AutoSize = true;
            labelCountOfElements.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelCountOfElements.Location = new Point(571, 48);
            labelCountOfElements.Name = "labelCountOfElements";
            labelCountOfElements.Size = new Size(70, 21);
            labelCountOfElements.TabIndex = 10;
            labelCountOfElements.Text = "5 из 100";
            // 
            // buttonCreatePDF
            // 
            buttonCreatePDF.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonCreatePDF.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonCreatePDF.Location = new Point(210, 488);
            buttonCreatePDF.Name = "buttonCreatePDF";
            buttonCreatePDF.Size = new Size(188, 55);
            buttonCreatePDF.TabIndex = 1;
            buttonCreatePDF.Text = "Создать PDF";
            buttonCreatePDF.UseVisualStyleBackColor = true;
            buttonCreatePDF.Click += ButtonCreatePDF_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1161, 552);
            Controls.Add(labelCountOfElements);
            Controls.Add(label4);
            Controls.Add(labelDBPath);
            Controls.Add(label3);
            Controls.Add(TextBoxSearch);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(TextBoxContent);
            Controls.Add(ButtonSEarchDocument);
            Controls.Add(buttonRestFilter);
            Controls.Add(ButtonFilterDataBase);
            Controls.Add(ButtonExit);
            Controls.Add(buttonRedactDocument);
            Controls.Add(ButtonDelete);
            Controls.Add(ButtonAddDocument);
            Controls.Add(ButtonSaveDataBase);
            Controls.Add(buttonCreatePDF);
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
        private Button ButtonExit;
        private Button ButtonFilterDataBase;
        private Button ButtonAddDocument;
        private Button ButtonDelete;
        private Button buttonRedactDocument;
        private TextBox TextBoxContent;
        private Label label1;
        private Button ButtonSEarchDocument;
        private TextBox TextBoxSearch;
        private Label label2;
        private Button buttonRestFilter;
        private Label label3;
        private Label labelDBPath;
        private Label label4;
        private Label labelCountOfElements;
        private Button buttonCreatePDF;
    }
}
