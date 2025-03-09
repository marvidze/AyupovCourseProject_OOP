namespace AyupovCourseProject1
{
    partial class SortDialogForm
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
            label1 = new Label();
            ButtonSortID = new Button();
            ButtonSortSenderName = new Button();
            ButtonSortReeiptDate = new Button();
            ButtonClose = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(233, 21);
            label1.TabIndex = 0;
            label1.Text = "Выберите вариант сортировки:";
            // 
            // ButtonSortID
            // 
            ButtonSortID.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ButtonSortID.Location = new Point(12, 33);
            ButtonSortID.Name = "ButtonSortID";
            ButtonSortID.Size = new Size(288, 48);
            ButtonSortID.TabIndex = 3;
            ButtonSortID.Text = "Сортировать по ID";
            ButtonSortID.UseVisualStyleBackColor = true;
            // 
            // ButtonSortSenderName
            // 
            ButtonSortSenderName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ButtonSortSenderName.Location = new Point(12, 87);
            ButtonSortSenderName.Name = "ButtonSortSenderName";
            ButtonSortSenderName.Size = new Size(288, 48);
            ButtonSortSenderName.TabIndex = 3;
            ButtonSortSenderName.Text = "Сортировать по имени отправителя";
            ButtonSortSenderName.UseVisualStyleBackColor = true;
            // 
            // ButtonSortReeiptDate
            // 
            ButtonSortReeiptDate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ButtonSortReeiptDate.Location = new Point(12, 141);
            ButtonSortReeiptDate.Name = "ButtonSortReeiptDate";
            ButtonSortReeiptDate.Size = new Size(288, 48);
            ButtonSortReeiptDate.TabIndex = 4;
            ButtonSortReeiptDate.Text = "Сортировать по дате приёма";
            ButtonSortReeiptDate.UseVisualStyleBackColor = true;
            ButtonSortReeiptDate.Click += ButtonSortReeiptDate_Click;
            // 
            // ButtonClose
            // 
            ButtonClose.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ButtonClose.Location = new Point(12, 363);
            ButtonClose.Name = "ButtonClose";
            ButtonClose.Size = new Size(288, 48);
            ButtonClose.TabIndex = 4;
            ButtonClose.Text = "Выйти без сортировки";
            ButtonClose.UseVisualStyleBackColor = true;
            ButtonClose.Click += ButtonClose_Click;
            // 
            // SortDataBaseForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(312, 423);
            Controls.Add(ButtonClose);
            Controls.Add(ButtonSortReeiptDate);
            Controls.Add(ButtonSortSenderName);
            Controls.Add(ButtonSortID);
            Controls.Add(label1);
            Name = "SortDataBaseForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Параметры сортировки";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button ButtonSortID;
        private Button ButtonSortSenderName;
        private Button ButtonSortReeiptDate;
        private Button ButtonClose;
    }
}