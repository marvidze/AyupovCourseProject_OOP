﻿namespace AyupovCourseProject1
{
    partial class WelcomeForm
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
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(29, 82);
            label1.Name = "label1";
            label1.Size = new Size(745, 150);
            label1.TabIndex = 0;
            label1.Text = "Курсовой проект по дисциплине\r\n«Объектно-ориентированное программирование».\r\n\r\nРазработка программы с использованием объектно-ориентированного подхода. \r\n«Канцелярия»\r\n\r\n";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(214, 250);
            label2.Name = "label2";
            label2.Size = new Size(374, 21);
            label2.TabIndex = 1;
            label2.Text = "Разработчик - студент группы 23ВП1 Аюпов М.Р.";
            // 
            // WelcomeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "WelcomeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Окно приветствия";
            Load += WelcomeForm_Load;
            Click += FormClick;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
    }
}