﻿namespace Program
{
    partial class FormTeacher
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            comboBox1 = new ComboBox();
            button1 = new Button();
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
            // textBox1
            // 
            textBox1.Location = new Point(168, 6);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(143, 23);
            textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(168, 56);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(143, 23);
            textBox2.TabIndex = 7;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(168, 106);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(143, 23);
            textBox3.TabIndex = 8;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(168, 206);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(143, 23);
            textBox4.TabIndex = 10;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(168, 256);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(143, 23);
            textBox5.TabIndex = 11;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Кандидат наук", "Доктор наук" });
            comboBox1.Location = new Point(168, 156);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(143, 23);
            comboBox1.TabIndex = 12;
            // 
            // button1
            // 
            button1.Location = new Point(168, 306);
            button1.Name = "button1";
            button1.Size = new Size(143, 23);
            button1.TabIndex = 13;
            button1.Text = "Сохранить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FormTeacher
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(359, 371);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormTeacher";
            Text = "FormTeacher";
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
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private ComboBox comboBox1;
        private Button button1;
    }
}