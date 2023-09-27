namespace Lab_work_5
{
    partial class FormLoad
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
            label3 = new Label();
            comboBoxTeacher = new ComboBox();
            comboBoxSubject = new ComboBox();
            textBoxGroupNumber = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(94, 15);
            label1.TabIndex = 0;
            label1.Text = "Преподаватель:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 59);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 1;
            label2.Text = "Предмет:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 109);
            label3.Name = "label3";
            label3.Size = new Size(92, 15);
            label3.TabIndex = 2;
            label3.Text = "Номер группы:";
            // 
            // comboBoxTeacher
            // 
            comboBoxTeacher.FormattingEnabled = true;
            comboBoxTeacher.Location = new Point(142, 6);
            comboBoxTeacher.Name = "comboBoxTeacher";
            comboBoxTeacher.Size = new Size(459, 23);
            comboBoxTeacher.TabIndex = 3;
            // 
            // comboBoxSubject
            // 
            comboBoxSubject.FormattingEnabled = true;
            comboBoxSubject.Location = new Point(142, 56);
            comboBoxSubject.Name = "comboBoxSubject";
            comboBoxSubject.Size = new Size(459, 23);
            comboBoxSubject.TabIndex = 4;
            // 
            // textBoxGroupNumber
            // 
            textBoxGroupNumber.Location = new Point(142, 106);
            textBoxGroupNumber.Name = "textBoxGroupNumber";
            textBoxGroupNumber.Size = new Size(459, 23);
            textBoxGroupNumber.TabIndex = 5;
            // 
            // button1
            // 
            button1.DialogResult = DialogResult.OK;
            button1.Location = new Point(142, 158);
            button1.Name = "button1";
            button1.Size = new Size(459, 23);
            button1.TabIndex = 6;
            button1.Text = "Сохранить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FormLoad
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(783, 193);
            Controls.Add(button1);
            Controls.Add(textBoxGroupNumber);
            Controls.Add(comboBoxSubject);
            Controls.Add(comboBoxTeacher);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormLoad";
            Text = "FormLoad";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox comboBoxTeacher;
        private ComboBox comboBoxSubject;
        private TextBox textBoxGroupNumber;
        private Button button1;
    }
}
