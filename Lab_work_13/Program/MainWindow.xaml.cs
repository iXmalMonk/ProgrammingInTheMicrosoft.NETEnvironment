using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using Npgsql;
using NpgsqlTypes;

namespace Program
{
    public partial class MainWindow : Window
    {
        private readonly NpgsqlConnection _connection;
        private NpgsqlCommand _firstCommand;
        private NpgsqlCommand _secondCommand;
        private NpgsqlDataAdapter _firstAdapter;
        private NpgsqlDataAdapter _secondAdapter;
        private DataTable _firstDataTable;
        private DataTable _secondDataTable;
        private readonly string _firstQuery = "select id, image, manager, name, number_of_teachers, faculty_id from net.department";
        private readonly string _secondQuery = "select id, dean, name, number_of_students from net.faculty";

        public MainWindow()
        {
            InitializeComponent();
            _connection = new NpgsqlConnection("Server=localhost;Port=5432;Database=net;User Id = postgres;Password=5683");
            _firstCommand = new NpgsqlCommand(_firstQuery, _connection);
            _secondCommand = new NpgsqlCommand(_secondQuery, _connection);
            _firstAdapter = new NpgsqlDataAdapter(_firstCommand);
            _secondAdapter = new NpgsqlDataAdapter(_secondCommand);
            _firstDataTable = new DataTable();
            _secondDataTable = new DataTable();
            _firstAdapter.Fill(_firstDataTable);
            _secondAdapter.Fill(_secondDataTable);
            firstDataGrid.ItemsSource = _firstDataTable.DefaultView;
            secondDataGrid.ItemsSource = _secondDataTable.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NpgsqlCommandBuilder commandBuilder = new NpgsqlCommandBuilder(_firstAdapter);
                _firstAdapter.UpdateCommand = commandBuilder.GetUpdateCommand();
                _firstAdapter.Update(_firstDataTable);
                _firstDataTable.Clear();
                _firstAdapter.Fill(_firstDataTable);
                firstDataGrid.ItemsSource = _firstDataTable.DefaultView;
            }
            catch
            {
                return;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataRow dataRow = _firstDataTable.NewRow();
            _firstDataTable.Rows.Add(dataRow);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItems = firstDataGrid.SelectedItems.Cast<DataRowView>().ToList();
                foreach (DataRowView dataRowView in selectedItems)
                {
                    DataRow dataRow = dataRowView.Row;
                    dataRow.Delete();
                }
                _firstAdapter.DeleteCommand = FirstCreateDeleteCommand();
                _firstAdapter.Update(_firstDataTable);
            }
            catch
            {
                return;
            }
        }

        private NpgsqlCommand FirstCreateDeleteCommand()
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = _connection;
            command.CommandText = "delete from net.department where id = @id";
            command.Parameters.Add("@id", NpgsqlDbType.Integer);
            command.Parameters["@id"].SourceColumn = "id";
            return command;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                NpgsqlCommandBuilder commandBuilder = new NpgsqlCommandBuilder(_secondAdapter);
                _secondAdapter.UpdateCommand = commandBuilder.GetUpdateCommand();
                _secondAdapter.Update(_secondDataTable);
                _secondDataTable.Clear();
                _secondAdapter.Fill(_secondDataTable);
                secondDataGrid.ItemsSource = _secondDataTable.DefaultView;
            }
            catch
            {
                return;
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            DataRow dataRow = _secondDataTable.NewRow();
            _secondDataTable.Rows.Add(dataRow);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItems = secondDataGrid.SelectedItems.Cast<DataRowView>().ToList();
                foreach (DataRowView dataRowView in selectedItems)
                {
                    DataRow dataRow = dataRowView.Row;
                    dataRow.Delete();
                }
                _secondAdapter.DeleteCommand = SecondCreateDeleteCommand();
                _secondAdapter.Update(_secondDataTable);
            }
            catch
            {
                return;
            }
        }

        private NpgsqlCommand SecondCreateDeleteCommand()
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = _connection;
            command.CommandText = "delete from net.faculty where id = @id";
            command.Parameters.Add("@id", NpgsqlDbType.Integer);
            command.Parameters["@id"].SourceColumn = "id";
            return command;
        }

        private void firstDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedItems = firstDataGrid.SelectedItems.Cast<DataRowView>().ToList();
                foreach (DataRowView dataRowView in selectedItems)
                {
                    DataRow dataRow = dataRowView.Row;
                    if (dataRow["image"] != DBNull.Value && dataRow["image"] is byte[])
                    {
                        byte[] bytes = (byte[])dataRow["image"];
                        using (MemoryStream memoryStream = new MemoryStream(bytes))
                        {
                            BitmapImage bitmapImage = new BitmapImage();
                            bitmapImage.BeginInit();
                            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                            bitmapImage.StreamSource = memoryStream;
                            bitmapImage.EndInit();
                            image.Source = bitmapImage;
                        }
                    }
                    else
                    {
                        image.Source = null;
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            if (openFileDialog.ShowDialog() == true)
            {
                string path = openFileDialog.FileName;
                BitmapImage bitmapImage = new BitmapImage();
                using (FileStream fileStream = File.OpenRead(path))
                {
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.StreamSource = fileStream;
                    bitmapImage.EndInit();
                }
                image.Source = bitmapImage;
            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            BitmapImage bitmapImage = image.Source as BitmapImage;
            if (bitmapImage != null)
            {
                byte[] bytes;
                JpegBitmapEncoder jpegBitmapEncoder = new JpegBitmapEncoder();
                jpegBitmapEncoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    jpegBitmapEncoder.Save(memoryStream);
                    bytes = memoryStream.ToArray();
                }
                UpdateImageToDatabase(bytes);
            }
        }

        private void UpdateImageToDatabase(byte[] bytes)
        {
            int id = 0;
            var selectedItems = firstDataGrid.SelectedItems.Cast<DataRowView>().ToList();
            foreach (DataRowView dataRowView in selectedItems)
            {
                DataRow dataRow = dataRowView.Row;
                if ((int)dataRow["id"] > 0)
                {
                    id = (int)dataRow["id"];
                }
            }
            try
            {
                if (id != 0)
                {
                    _connection.Open();
                    NpgsqlCommand command = new NpgsqlCommand();
                    command.Connection = _connection;
                    command.CommandText = "update net.department set image = @image where id = @id";
                    command.Parameters.AddWithValue("@image", NpgsqlDbType.Bytea, bytes);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                    _firstDataTable.Clear();
                    _firstAdapter.Fill(_firstDataTable);
                    firstDataGrid.ItemsSource = _firstDataTable.DefaultView;
                    _connection.Close();
                }
            }
            catch
            {
                return;
            }
        }
    }
}