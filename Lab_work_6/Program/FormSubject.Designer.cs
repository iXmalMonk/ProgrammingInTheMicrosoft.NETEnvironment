namespace Program
{
    partial class FormSubject
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
            textBoxName = new TextBox();
            button1 = new Button();
            numericUpDownNumberOfHours = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUpDownNumberOfHours).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(117, 15);
            label1.TabIndex = 0;
            label1.Text = "Название предмета:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 98);
            label2.Name = "label2";
            label2.Size = new Size(110, 15);
            label2.TabIndex = 1;
            label2.Text = "Количество часов:";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(157, 6);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(100, 23);
            textBoxName.TabIndex = 2;
            // 
            // button1
            // 
            button1.DialogResult = DialogResult.OK;
            button1.Location = new Point(157, 195);
            button1.Name = "button1";
            button1.Size = new Size(100, 23);
            button1.TabIndex = 4;
            button1.Text = "Сохранить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // numericUpDownNumberOfHours
            // 
            numericUpDownNumberOfHours.Location = new Point(157, 96);
            numericUpDownNumberOfHours.Name = "numericUpDownNumberOfHours";
            numericUpDownNumberOfHours.Size = new Size(100, 23);
            numericUpDownNumberOfHours.TabIndex = 5;
            // 
            // FormSubject
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 231);
            Controls.Add(numericUpDownNumberOfHours);
            Controls.Add(button1);
            Controls.Add(textBoxName);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormSubject";
            Text = "FormSubject";
            ((System.ComponentModel.ISupportInitialize)numericUpDownNumberOfHours).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBoxName;
        private Button button1;
        private NumericUpDown numericUpDownNumberOfHours;
    }
}
