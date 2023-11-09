﻿using System.Data;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Program
{
    public partial class FormMain : Form
    {
        private readonly Npgsql.NpgsqlConnection _connection;

        public FormMain()
        {
            InitializeComponent();
            _connection = new Npgsql.NpgsqlConnection("Server=localhost;Port=5432;Database=net;User Id = postgres;Password=5683");
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _connection.Open();
            DataSet dataSetFirst = new DataSet();
            DataSet dataSetSecond = new DataSet();
            Npgsql.NpgsqlDataAdapter npgsqlDataAdapterFirst = new Npgsql.NpgsqlDataAdapter("select id, image, manager, name, number_of_teachers, faculty_id from net.department", _connection);
            Npgsql.NpgsqlDataAdapter npgsqlDataAdapterSecond = new Npgsql.NpgsqlDataAdapter("select id, dean, name, number_of_students from net.faculty", _connection);
            npgsqlDataAdapterFirst.Fill(dataSetFirst);
            npgsqlDataAdapterSecond.Fill(dataSetSecond);
            _connection.Close();
            dataGridView1.DataSource = dataSetFirst.Tables[0];
            dataGridView2.DataSource = dataSetSecond.Tables[0];
            DataView dataView = new DataView(dataSetSecond.Tables[0]);
            dataView.RowFilter = "id is not null";
            comboBox1.DataSource = dataView.ToTable(true, "id");
            comboBox1.DisplayMember = "id";
            comboBox1.ValueMember = "id";
            toolStripStatusLabel1.Text = "Загрузка - ок";
        }

        private void addDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                toolStripStatusLabel1.Text = "Добавить кафедру - поле \"заведующий\" не заполнено - ошибка";
            }
            else if (textBox2.Text == string.Empty)
            {
                toolStripStatusLabel1.Text = "Добавить кафедру - поле \"наименование\" не заполнено - ошибка";
            }
            else if (comboBox1.Text == string.Empty)
            {
                toolStripStatusLabel1.Text = "Добавить кафедру - поле \"id факультета\" не заполнено - ошибка";
            }
            else
            {
                _connection.Open();
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand("insert into net.department(image, manager, name, number_of_teachers, faculty_id) values(@image, @manager, @name, @number_of_teachers, @faculty_id)", _connection);
                Image image = pictureBox1.Image;
                if (image is not null)
                {
                    MemoryStream memoryStream = new MemoryStream();
                    image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    command.Parameters.AddWithValue("@image", NpgsqlTypes.NpgsqlDbType.Bytea, memoryStream.ToArray());
                }
                else
                {
                    command.Parameters.AddWithValue("@image", DBNull.Value);
                }
                command.Parameters.AddWithValue("@manager", textBox1.Text);
                command.Parameters.AddWithValue("@name", textBox2.Text);
                command.Parameters.AddWithValue("@number_of_teachers", numericUpDown1.Value);
                command.Parameters.AddWithValue("@faculty_id", int.Parse(comboBox1.Text));
                command.ExecuteNonQuery();
                command.Dispose();
                _connection.Close();
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                numericUpDown1.Value = 0;
                toolStripStatusLabel1.Text = "Добавить кафедру - ок";
            }
        }

        private void addFacultyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == string.Empty)
            {
                toolStripStatusLabel1.Text = "Добавить факультет - поле \"декан\" не заполнено - ошибка";
            }
            else if (textBox4.Text == string.Empty)
            {
                toolStripStatusLabel1.Text = "Добавить факультет - поле \"наименование\" не заполнено - ошибка";
            }
            else
            {
                _connection.Open();
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand("insert into net.faculty(dean, name, number_of_students) values(@dean, @name, @number_of_students)", _connection);
                command.Parameters.AddWithValue("@dean", textBox3.Text);
                command.Parameters.AddWithValue("@name", textBox4.Text);
                command.Parameters.AddWithValue("@number_of_students", numericUpDown2.Value);
                command.ExecuteNonQuery();
                command.Dispose();
                _connection.Close();
                textBox3.Text = string.Empty;
                textBox4.Text = string.Empty;
                numericUpDown2.Value = 0;
                toolStripStatusLabel1.Text = "Добавить факультет - ок";
            }
        }

        private void updateDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow dataGridViewRow = dataGridView1.Rows[index];
                string value = dataGridViewRow.Cells["id"].Value.ToString();
                if (textBox1.Text == string.Empty)
                {
                    toolStripStatusLabel1.Text = "Обновить кафедру - поле \"заведующий\" не заполнено - ошибка";
                }
                else if (textBox2.Text == string.Empty)
                {
                    toolStripStatusLabel1.Text = "Обновить кафедру - поле \"наименование\" не заполнено - ошибка";
                }
                else if (comboBox1.Text == string.Empty)
                {
                    toolStripStatusLabel1.Text = "Обновить кафедру - поле \"id факультета\" не заполнено - ошибка";
                }
                else if (value == string.Empty)
                {
                    toolStripStatusLabel1.Text = "Обновить кафедру - поле не выбрано - ошибка";
                }
                else
                {
                    int id = int.Parse(value);
                    _connection.Open();
                    Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand("update net.department set image = @image, manager = @manager, name = @name, number_of_teachers = @number_of_teachers, faculty_id = @faculty_id where id = @id", _connection);
                    Image image = pictureBox1.Image;
                    if (image is not null)
                    {
                        MemoryStream memoryStream = new MemoryStream();
                        image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                        command.Parameters.AddWithValue("@image", NpgsqlTypes.NpgsqlDbType.Bytea, memoryStream.ToArray());
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@image", DBNull.Value);
                    }
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@manager", textBox1.Text);
                    command.Parameters.AddWithValue("@name", textBox2.Text);
                    command.Parameters.AddWithValue("@number_of_teachers", numericUpDown1.Value);
                    command.Parameters.AddWithValue("@faculty_id", int.Parse(comboBox1.Text));
                    command.ExecuteNonQuery();
                    command.Dispose();
                    _connection.Close();
                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                    numericUpDown1.Value = 0;
                    toolStripStatusLabel1.Text = "Обновить кафедру - ок";
                }
            }
            catch
            {
                toolStripStatusLabel1.Text = "Обновить кафедру - поле не выбрано - ошибка";
            }
        }

        private void updateFacultyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView2.SelectedCells[0].RowIndex;
                DataGridViewRow dataGridViewRow = dataGridView2.Rows[index];
                string value = dataGridViewRow.Cells["id"].Value.ToString();
                if (textBox3.Text == string.Empty)
                {
                    toolStripStatusLabel1.Text = "Обновить факультет - поле \"декан\" не заполнено - ошибка";
                }
                else if (textBox4.Text == string.Empty)
                {
                    toolStripStatusLabel1.Text = "Обновить факультет - поле \"наименование\" не заполнено - ошибка";
                }
                else if (value == string.Empty)
                {
                    toolStripStatusLabel1.Text = "Обновить факультет - поле не выбрано - ошибка";
                }
                else
                {
                    int id = int.Parse(value);
                    _connection.Open();
                    Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand("update net.faculty set dean = @dean, name = @name, number_of_students = @number_of_students where id = @id", _connection);
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@dean", textBox3.Text);
                    command.Parameters.AddWithValue("@name", textBox4.Text);
                    command.Parameters.AddWithValue("@number_of_students", numericUpDown2.Value);
                    command.ExecuteNonQuery();
                    command.Dispose();
                    _connection.Close();
                    textBox3.Text = string.Empty;
                    textBox4.Text = string.Empty;
                    numericUpDown2.Value = 0;
                    toolStripStatusLabel1.Text = "Обновить факультет - ок";
                }
            }
            catch
            {
                toolStripStatusLabel1.Text = "Обновить факультет - поле не выбрано - ошибка";
            }
        }

        private void removeDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow dataGridViewRow = dataGridView1.Rows[index];
                string value = dataGridViewRow.Cells["id"].Value.ToString();
                if (value == string.Empty)
                {
                    toolStripStatusLabel1.Text = "Удалить кафедру - поле не выбрано - ошибка";
                }
                else
                {
                    int id = int.Parse(value);
                    _connection.Open();
                    Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand("delete from net.department where id = @id", _connection);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                    command.Dispose();
                    _connection.Close();
                    toolStripStatusLabel1.Text = "Удалить кафедру - ок";
                }
            }
            catch
            {
                toolStripStatusLabel1.Text = "Удалить кафедру - поле не выбрано - ошибка";
            }
        }

        private void removeFacultyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView2.SelectedCells[0].RowIndex;
                DataGridViewRow dataGridViewRow = dataGridView2.Rows[index];
                string value = dataGridViewRow.Cells["id"].Value.ToString();
                if (value == string.Empty)
                {
                    toolStripStatusLabel1.Text = "Удалить факультет - поле не выбрано - ошибка";
                }
                else
                {
                    int id = int.Parse(value);
                    _connection.Open();
                    Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand("delete from net.faculty where id = @id", _connection);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                    command.Dispose();
                    _connection.Close();
                    toolStripStatusLabel1.Text = "Удалить факультет - ок";
                }
            }
            catch
            {
                toolStripStatusLabel1.Text = "Удалить факультет - поле не выбрано - ошибка";
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow dataGridViewRow = dataGridView1.Rows[index];
            var image = dataGridView1.SelectedRows[0].Cells["image"];
            if (image.Value != null && image.Value != DBNull.Value)
            {
                byte[] bytes = (byte[])image.Value;
                MemoryStream memoryStream = new MemoryStream(bytes);
                pictureBox1.Image = Image.FromStream(memoryStream);
            }
            else
            {
                pictureBox1.Image = null;
            }
            textBox1.Text = dataGridViewRow.Cells["manager"].Value.ToString();
            textBox2.Text = dataGridViewRow.Cells["name"].Value.ToString();
            string value = dataGridViewRow.Cells["number_of_teachers"].Value.ToString();
            comboBox1.Text = dataGridViewRow.Cells["faculty_id"].Value.ToString();
            numericUpDown1.Value = int.Parse(value);
        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = dataGridView2.SelectedCells[0].RowIndex;
            DataGridViewRow dataGridViewRow = dataGridView2.Rows[index];
            textBox3.Text = dataGridViewRow.Cells["dean"].Value.ToString();
            textBox4.Text = dataGridViewRow.Cells["name"].Value.ToString();
            string value = dataGridViewRow.Cells["number_of_students"].Value.ToString();
            numericUpDown2.Value = int.Parse(value);
        }

        private void propertyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProperty formProperty = new FormProperty(pictureBox1);
            if (formProperty.ShowDialog() == DialogResult.OK)
            {
                toolStripStatusLabel1.Text = "Свойство";
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (pictureBox1.Image != null)
                {
                    FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate);
                    pictureBox1.Image.Save(fileStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    fileStream.Close();
                    toolStripStatusLabel1.Text = "Фотография сохранена";
                }
                else
                {
                    toolStripStatusLabel1.Text = "Фотография не сохранена";
                }
            }
        }

        private void loadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                toolStripStatusLabel1.Text = "Фотография загружена";
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                toolStripStatusLabel1.Text = "Печать - поле не выбрано - ошибка";
                return;
            }
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
                toolStripStatusLabel1.Text = "Печать - ок";
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Brush brush = Brushes.Black;
            Font font = new Font("Arial", 12);
            int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
            DataGridViewRow dataGridViewRow = dataGridView1.Rows[selectedRowIndex];
            string id = dataGridViewRow.Cells["id"].Value.ToString();
            string manager = dataGridViewRow.Cells["manager"].Value.ToString();
            string name = dataGridViewRow.Cells["name"].Value.ToString();
            string numberOfTeachers = dataGridViewRow.Cells["number_of_teachers"].Value.ToString();
            string facultyId = dataGridViewRow.Cells["faculty_id"].Value.ToString();
            e.Graphics.DrawString("Id:", font, brush, new PointF(10, 10));
            e.Graphics.DrawString(id, font, brush, new PointF(100, 10));
            e.Graphics.DrawString("Manager:", font, brush, new PointF(10, 50));
            e.Graphics.DrawString(manager, font, brush, new PointF(100, 50));
            e.Graphics.DrawString("Name:", font, brush, new PointF(10, 100));
            e.Graphics.DrawString(name, font, brush, new PointF(100, 100));
            e.Graphics.DrawString("NumberOfTeachers:", font, brush, new PointF(10, 150));
            e.Graphics.DrawString(numberOfTeachers, font, brush, new PointF(200, 150));
            e.Graphics.DrawString("FacultyId:", font, brush, new PointF(10, 200));
            e.Graphics.DrawString(facultyId, font, brush, new PointF(100, 200));
            if (dataGridViewRow.Cells["image"].Value is byte[] bytes)
            {
                MemoryStream memoryStream = new MemoryStream(bytes);
                Image photo = Image.FromStream(memoryStream);
                e.Graphics.DrawImage(photo, new PointF(10, 250));
            }
        }

        private void textBox3_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (textBox3.Text.Length <= 0)
            {
                errorProvider1.SetError(textBox3, "Не указан декан");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox4_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (textBox4.Text.Length <= 0)
            {
                errorProvider2.SetError(textBox4, "Не указано наименование");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void previewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                toolStripStatusLabel1.Text = "Предпросмотр печати - поле не выбрано - ошибка";
                return;
            }
            PrintDocument printDocument = new PrintDocument();
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printDocument.PrintPage += PrintDocument_PrintPage;
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.ShowDialog();
        }
    }
}