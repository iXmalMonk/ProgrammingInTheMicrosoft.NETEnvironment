namespace WindowsFormsControlLibraryLoad
{
    partial class UserControlLoad
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTeacher = new System.Windows.Forms.Label();
            this.labelSubject = new System.Windows.Forms.Label();
            this.labelGroupNumber = new System.Windows.Forms.Label();
            this.textBoxTeacher = new System.Windows.Forms.TextBox();
            this.textBoxSubject = new System.Windows.Forms.TextBox();
            this.textBoxGroupNumber = new System.Windows.Forms.TextBox();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTeacher
            // 
            this.labelTeacher.AutoSize = true;
            this.labelTeacher.Location = new System.Drawing.Point(3, 20);
            this.labelTeacher.Name = "labelTeacher";
            this.labelTeacher.Size = new System.Drawing.Size(86, 13);
            this.labelTeacher.TabIndex = 0;
            this.labelTeacher.Text = "Преподаватель";
            // 
            // labelSubject
            // 
            this.labelSubject.AutoSize = true;
            this.labelSubject.Location = new System.Drawing.Point(301, 20);
            this.labelSubject.Name = "labelSubject";
            this.labelSubject.Size = new System.Drawing.Size(52, 13);
            this.labelSubject.TabIndex = 1;
            this.labelSubject.Text = "Предмет";
            // 
            // labelGroupNumber
            // 
            this.labelGroupNumber.AutoSize = true;
            this.labelGroupNumber.Location = new System.Drawing.Point(3, 70);
            this.labelGroupNumber.Name = "labelGroupNumber";
            this.labelGroupNumber.Size = new System.Drawing.Size(80, 13);
            this.labelGroupNumber.TabIndex = 2;
            this.labelGroupNumber.Text = "Номер группы";
            // 
            // textBoxTeacher
            // 
            this.textBoxTeacher.Location = new System.Drawing.Point(95, 17);
            this.textBoxTeacher.Name = "textBoxTeacher";
            this.textBoxTeacher.Size = new System.Drawing.Size(200, 20);
            this.textBoxTeacher.TabIndex = 3;
            // 
            // textBoxSubject
            // 
            this.textBoxSubject.Location = new System.Drawing.Point(359, 17);
            this.textBoxSubject.Name = "textBoxSubject";
            this.textBoxSubject.Size = new System.Drawing.Size(180, 20);
            this.textBoxSubject.TabIndex = 4;
            // 
            // textBoxGroupNumber
            // 
            this.textBoxGroupNumber.Location = new System.Drawing.Point(95, 67);
            this.textBoxGroupNumber.Name = "textBoxGroupNumber";
            this.textBoxGroupNumber.Size = new System.Drawing.Size(200, 20);
            this.textBoxGroupNumber.TabIndex = 5;
            // 
            // buttonRemove
            // 
            this.buttonRemove.ForeColor = System.Drawing.Color.Red;
            this.buttonRemove.Location = new System.Drawing.Point(359, 67);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(180, 20);
            this.buttonRemove.TabIndex = 6;
            this.buttonRemove.Text = "X";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // UserControlLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.textBoxGroupNumber);
            this.Controls.Add(this.textBoxSubject);
            this.Controls.Add(this.textBoxTeacher);
            this.Controls.Add(this.labelGroupNumber);
            this.Controls.Add(this.labelSubject);
            this.Controls.Add(this.labelTeacher);
            this.Name = "UserControlLoad";
            this.Size = new System.Drawing.Size(571, 104);
            this.Click += new System.EventHandler(this.UserControlLoad_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UserControlLoad_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTeacher;
        private System.Windows.Forms.Label labelSubject;
        private System.Windows.Forms.Label labelGroupNumber;
        private System.Windows.Forms.TextBox textBoxTeacher;
        private System.Windows.Forms.TextBox textBoxSubject;
        private System.Windows.Forms.TextBox textBoxGroupNumber;
        private System.Windows.Forms.Button buttonRemove;
    }
}
