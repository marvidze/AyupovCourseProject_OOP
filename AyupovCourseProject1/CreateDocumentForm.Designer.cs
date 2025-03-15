namespace AyupovCourseProject1
{
    partial class CreateDocumentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox_content = new TextBox();
            textBox_topic = new TextBox();
            textBox_title = new TextBox();
            textBox_name = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            ButtonConfirm = new Button();
            buttonExit = new Button();
            SuspendLayout();
            // 
            // textBox_content
            // 
            textBox_content.Location = new Point(153, 166);
            textBox_content.Multiline = true;
            textBox_content.Name = "textBox_content";
            textBox_content.Size = new Size(230, 134);
            textBox_content.TabIndex = 11;
            // 
            // textBox_topic
            // 
            textBox_topic.Location = new Point(153, 104);
            textBox_topic.Name = "textBox_topic";
            textBox_topic.Size = new Size(230, 23);
            textBox_topic.TabIndex = 12;
            // 
            // textBox_title
            // 
            textBox_title.Location = new Point(153, 56);
            textBox_title.Name = "textBox_title";
            textBox_title.Size = new Size(230, 23);
            textBox_title.TabIndex = 13;
            // 
            // textBox_name
            // 
            textBox_name.Location = new Point(153, 12);
            textBox_name.Name = "textBox_name";
            textBox_name.Size = new Size(230, 23);
            textBox_name.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(12, 168);
            label4.Name = "label4";
            label4.Size = new Size(101, 21);
            label4.TabIndex = 7;
            label4.Text = "Содержание";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(12, 102);
            label3.Name = "label3";
            label3.Size = new Size(45, 21);
            label3.TabIndex = 8;
            label3.Text = "Тема";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(12, 54);
            label2.Name = "label2";
            label2.Size = new Size(84, 21);
            label2.TabIndex = 9;
            label2.Text = "Заголовок";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(135, 21);
            label1.TabIndex = 10;
            label1.Text = "Имя отправителя";
            // 
            // ButtonConfirm
            // 
            ButtonConfirm.DialogResult = DialogResult.Cancel;
            ButtonConfirm.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ButtonConfirm.Location = new Point(12, 321);
            ButtonConfirm.Name = "ButtonConfirm";
            ButtonConfirm.Size = new Size(177, 48);
            ButtonConfirm.TabIndex = 15;
            ButtonConfirm.Text = "Создать";
            ButtonConfirm.UseVisualStyleBackColor = true;
            ButtonConfirm.Click += this.ButtonConfirm_Click;
            // 
            // buttonExit
            // 
            buttonExit.DialogResult = DialogResult.Cancel;
            buttonExit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonExit.Location = new Point(206, 321);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(177, 48);
            buttonExit.TabIndex = 16;
            buttonExit.Text = "Отмена";
            buttonExit.UseVisualStyleBackColor = true;
            // 
            // CreateDocumentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 381);
            Controls.Add(ButtonConfirm);
            Controls.Add(buttonExit);
            Controls.Add(textBox_content);
            Controls.Add(textBox_topic);
            Controls.Add(textBox_title);
            Controls.Add(textBox_name);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "CreateDocumentForm";
            Text = "Создание документа";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_content;
        private TextBox textBox_topic;
        private TextBox textBox_title;
        private TextBox textBox_name;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button ButtonConfirm;
        private Button buttonExit;
    }
}