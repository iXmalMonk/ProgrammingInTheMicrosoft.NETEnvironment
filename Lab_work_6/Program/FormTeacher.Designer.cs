namespace Program
{
    partial class FormTeacher
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
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            textBoxSurname = new TextBox();
            textBoxName = new TextBox();
            textBoxPatronymic = new TextBox();
            textBoxJobTitle = new TextBox();
            comboBoxAcademicDegree = new ComboBox();
            button1 = new Button();
            numericUpDownExperience = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUpDownExperience).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 0;
            label1.Text = "Фамилия:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 59);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 1;
            label2.Text = "Имя:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 109);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 2;
            label3.Text = "Отчество:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 159);
            label4.Name = "label4";
            label4.Size = new Size(95, 15);
            label4.TabIndex = 3;
            label4.Text = "Ученая степень:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 209);
            label5.Name = "label5";
            label5.Size = new Size(72, 15);
            label5.TabIndex = 4;
            label5.Text = "Должность:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 259);
            label6.Name = "label6";
            label6.Size = new Size(38, 15);
            label6.TabIndex = 5;
            label6.Text = "Стаж:";
            // 
            // textBoxSurname
            // 
            textBoxSurname.Location = new Point(168, 6);
            textBoxSurname.Name = "textBoxSurname";
            textBoxSurname.Size = new Size(143, 23);
            textBoxSurname.TabIndex = 6;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(168, 56);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(143, 23);
            textBoxName.TabIndex = 7;
            // 
            // textBoxPatronymic
            // 
            textBoxPatronymic.Location = new Point(168, 106);
            textBoxPatronymic.Name = "textBoxPatronymic";
            textBoxPatronymic.Size = new Size(143, 23);
            textBoxPatronymic.TabIndex = 8;
            // 
            // textBoxJobTitle
            // 
            textBoxJobTitle.Location = new Point(168, 206);
            textBoxJobTitle.Name = "textBoxJobTitle";
            textBoxJobTitle.Size = new Size(143, 23);
            textBoxJobTitle.TabIndex = 10;
            // 
            // comboBoxAcademicDegree
            // 
            comboBoxAcademicDegree.FormattingEnabled = true;
            comboBoxAcademicDegree.Items.AddRange(new object[] { "Кандидат наук", "Доктор наук" });
            comboBoxAcademicDegree.Location = new Point(168, 156);
            comboBoxAcademicDegree.Name = "comboBoxAcademicDegree";
            comboBoxAcademicDegree.Size = new Size(143, 23);
            comboBoxAcademicDegree.TabIndex = 12;
            // 
            // button1
            // 
            button1.DialogResult = DialogResult.OK;
            button1.Location = new Point(168, 306);
            button1.Name = "button1";
            button1.Size = new Size(143, 23);
            button1.TabIndex = 13;
            button1.Text = "Сохранить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // numericUpDownExperience
            // 
            numericUpDownExperience.Location = new Point(168, 257);
            numericUpDownExperience.Name = "numericUpDownExperience";
            numericUpDownExperience.Size = new Size(143, 23);
            numericUpDownExperience.TabIndex = 14;
            // 
            // FormTeacher
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(359, 371);
            Controls.Add(numericUpDownExperience);
            Controls.Add(button1);
            Controls.Add(comboBoxAcademicDegree);
            Controls.Add(textBoxJobTitle);
            Controls.Add(textBoxPatronymic);
            Controls.Add(textBoxName);
            Controls.Add(textBoxSurname);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormTeacher";
            Text = "FormTeacher";
            ((System.ComponentModel.ISupportInitialize)numericUpDownExperience).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textBoxSurname;
        private TextBox textBoxName;
        private TextBox textBoxPatronymic;
        private TextBox textBoxJobTitle;
        private ComboBox comboBoxAcademicDegree;
        private Button button1;
        private NumericUpDown numericUpDownExperience;
    }
}
