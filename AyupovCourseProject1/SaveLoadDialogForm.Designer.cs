namespace AyupovCourseProject1
{
    partial class SaveLoadDialogForm
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
            ButtonCreateDB = new Button();
            buttonLoadDB = new Button();
            buttonExti = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(219, 9);
            label1.Name = "label1";
            label1.Size = new Size(233, 32);
            label1.TabIndex = 0;
            label1.Text = "Добро пожаловать!";
            // 
            // ButtonCreateDB
            // 
            ButtonCreateDB.DialogResult = DialogResult.Yes;
            ButtonCreateDB.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ButtonCreateDB.Location = new Point(12, 58);
            ButtonCreateDB.Name = "ButtonCreateDB";
            ButtonCreateDB.Size = new Size(288, 48);
            ButtonCreateDB.TabIndex = 4;
            ButtonCreateDB.Text = "Создать базу данных";
            ButtonCreateDB.UseVisualStyleBackColor = true;
            ButtonCreateDB.Click += ButtonCreate_Click;
            // 
            // buttonLoadDB
            // 
            buttonLoadDB.DialogResult = DialogResult.No;
            buttonLoadDB.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonLoadDB.Location = new Point(359, 58);
            buttonLoadDB.Name = "buttonLoadDB";
            buttonLoadDB.Size = new Size(288, 48);
            buttonLoadDB.TabIndex = 4;
            buttonLoadDB.Text = "Загрузить базу данных";
            buttonLoadDB.UseVisualStyleBackColor = true;
            buttonLoadDB.Click += ButtonLoad_Click;
            // 
            // buttonExti
            // 
            buttonExti.DialogResult = DialogResult.Cancel;
            buttonExti.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonExti.Location = new Point(198, 112);
            buttonExti.Name = "buttonExti";
            buttonExti.Size = new Size(288, 48);
            buttonExti.TabIndex = 4;
            buttonExti.Text = "Выход";
            buttonExti.UseVisualStyleBackColor = true;
            buttonExti.Click += ButtonClose_Click;
            // 
            // SaveLoadDialogForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(659, 166);
            Controls.Add(buttonExti);
            Controls.Add(buttonLoadDB);
            Controls.Add(ButtonCreateDB);
            Controls.Add(label1);
            Name = "SaveLoadDialogForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Загрузить\\создать базу данных";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button ButtonCreateDB;
        private Button buttonLoadDB;
        private Button buttonExti;
    }
}