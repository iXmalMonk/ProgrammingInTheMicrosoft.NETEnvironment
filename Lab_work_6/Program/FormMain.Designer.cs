namespace Program
{
    partial class FormMain
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
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            subjectToolStripMenuItem = new ToolStripMenuItem();
            addToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            teacherToolStripMenuItem = new ToolStripMenuItem();
            addToolStripMenuItem1 = new ToolStripMenuItem();
            editToolStripMenuItem1 = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            addToolStripMenuItem2 = new ToolStripMenuItem();
            editToolStripMenuItem2 = new ToolStripMenuItem();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            listViewSubject = new ListView();
            columnHeader1 = new ColumnHeader();
            tabPage2 = new TabPage();
            listViewTeacher = new ListView();
            columnHeader2 = new ColumnHeader();
            tabPage3 = new TabPage();
            listViewLoad = new ListView();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            menuStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, subjectToolStripMenuItem, teacherToolStripMenuItem, loadToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(684, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(48, 20);
            fileToolStripMenuItem.Text = "Файл";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(109, 22);
            exitToolStripMenuItem.Text = "Выход";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // subjectToolStripMenuItem
            // 
            subjectToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addToolStripMenuItem, editToolStripMenuItem });
            subjectToolStripMenuItem.Name = "subjectToolStripMenuItem";
            subjectToolStripMenuItem.Size = new Size(76, 20);
            subjectToolStripMenuItem.Text = "Предметы";
            // 
            // addToolStripMenuItem
            // 
            addToolStripMenuItem.Name = "addToolStripMenuItem";
            addToolStripMenuItem.Size = new Size(154, 22);
            addToolStripMenuItem.Text = "Добавить";
            addToolStripMenuItem.Click += addToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(154, 22);
            editToolStripMenuItem.Text = "Редактировать";
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            // 
            // teacherToolStripMenuItem
            // 
            teacherToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addToolStripMenuItem1, editToolStripMenuItem1 });
            teacherToolStripMenuItem.Name = "teacherToolStripMenuItem";
            teacherToolStripMenuItem.Size = new Size(104, 20);
            teacherToolStripMenuItem.Text = "Преподаватели";
            // 
            // addToolStripMenuItem1
            // 
            addToolStripMenuItem1.Name = "addToolStripMenuItem1";
            addToolStripMenuItem1.Size = new Size(154, 22);
            addToolStripMenuItem1.Text = "Добавить";
            addToolStripMenuItem1.Click += addToolStripMenuItem1_Click;
            // 
            // editToolStripMenuItem1
            // 
            editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            editToolStripMenuItem1.Size = new Size(154, 22);
            editToolStripMenuItem1.Text = "Редактировать";
            editToolStripMenuItem1.Click += editToolStripMenuItem1_Click;
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addToolStripMenuItem2, editToolStripMenuItem2 });
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(69, 20);
            loadToolStripMenuItem.Text = "Нагрузка";
            // 
            // addToolStripMenuItem2
            // 
            addToolStripMenuItem2.Name = "addToolStripMenuItem2";
            addToolStripMenuItem2.Size = new Size(154, 22);
            addToolStripMenuItem2.Text = "Добавить";
            addToolStripMenuItem2.Click += addToolStripMenuItem2_Click;
            // 
            // editToolStripMenuItem2
            // 
            editToolStripMenuItem2.Name = "editToolStripMenuItem2";
            editToolStripMenuItem2.Size = new Size(154, 22);
            editToolStripMenuItem2.Text = "Редактировать";
            editToolStripMenuItem2.Click += editToolStripMenuItem2_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 24);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(684, 337);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(listViewSubject);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(676, 309);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Предметы";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // listViewSubject
            // 
            listViewSubject.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            listViewSubject.Dock = DockStyle.Fill;
            listViewSubject.FullRowSelect = true;
            listViewSubject.GridLines = true;
            listViewSubject.Location = new Point(3, 3);
            listViewSubject.Name = "listViewSubject";
            listViewSubject.Size = new Size(670, 303);
            listViewSubject.TabIndex = 0;
            listViewSubject.UseCompatibleStateImageBehavior = false;
            listViewSubject.View = View.Details;
            listViewSubject.KeyUp += new KeyEventHandler(listViewSubject_KeyUp);
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Предмет";
            columnHeader1.Width = 700;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(listViewTeacher);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(676, 309);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Преподаватели";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // listViewTeacher
            // 
            listViewTeacher.Columns.AddRange(new ColumnHeader[] { columnHeader2 });
            listViewTeacher.Dock = DockStyle.Fill;
            listViewTeacher.FullRowSelect = true;
            listViewTeacher.GridLines = true;
            listViewTeacher.Location = new Point(3, 3);
            listViewTeacher.Name = "listViewTeacher";
            listViewTeacher.Size = new Size(670, 303);
            listViewTeacher.TabIndex = 0;
            listViewTeacher.UseCompatibleStateImageBehavior = false;
            listViewTeacher.View = View.Details;
            listViewTeacher.KeyUp += new KeyEventHandler(listViewTeacher_KeyUp);
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Преподаватель";
            columnHeader2.Width = 700;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(listViewLoad);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(676, 309);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Нагрузка";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // listViewLoad
            // 
            listViewLoad.Columns.AddRange(new ColumnHeader[] { columnHeader3, columnHeader4, columnHeader5 });
            listViewLoad.Dock = DockStyle.Fill;
            listViewLoad.FullRowSelect = true;
            listViewLoad.GridLines = true;
            listViewLoad.Location = new Point(3, 3);
            listViewLoad.Name = "listViewLoad";
            listViewLoad.Size = new Size(670, 303);
            listViewLoad.TabIndex = 0;
            listViewLoad.UseCompatibleStateImageBehavior = false;
            listViewLoad.View = View.Details;
            listViewLoad.KeyUp += new KeyEventHandler(listViewLoad_KeyUp);
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Преподаватель";
            columnHeader3.Width = 250;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Предмет";
            columnHeader4.Width = 250;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Номер группы";
            columnHeader5.Width = 100;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 361);
            Controls.Add(tabControl1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FormMain";
            Text = "FormMain";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem subjectToolStripMenuItem;
        private ToolStripMenuItem addToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem teacherToolStripMenuItem;
        private ToolStripMenuItem addToolStripMenuItem1;
        private ToolStripMenuItem editToolStripMenuItem1;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem addToolStripMenuItem2;
        private ToolStripMenuItem editToolStripMenuItem2;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ListView listViewTeacher;
        private ColumnHeader columnHeader2;
        private TabPage tabPage3;
        private ListView listViewLoad;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ListView listViewSubject;
        private ColumnHeader columnHeader1;
    }
}
