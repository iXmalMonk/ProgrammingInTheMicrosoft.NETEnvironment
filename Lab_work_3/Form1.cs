namespace Lab_work_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            for (int i = (int)numericUpDown1.Minimum; i <= numericUpDown1.Value; i++)
            {
                textBox1.Text += i.ToString() + " ";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Add(textBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Text = comboBox1.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (float.TryParse(textBox4.Text, out float value1) &&
                float.TryParse(textBox5.Text, out float value2))
            {
                textBox6.Text = (value1 + value2).ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (float.TryParse(textBox4.Text, out float value1) &&
                float.TryParse(textBox5.Text, out float value2))
            {
                textBox6.Text = (value1 - value2).ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (float.TryParse(textBox4.Text, out float value1) &&
                float.TryParse(textBox5.Text, out float value2))
            {
                textBox6.Text = (value1 * value2).ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (float.TryParse(textBox4.Text, out float value1) &&
                float.TryParse(textBox5.Text, out float value2) &&
                value2 != 0)
            {
                textBox6.Text = (value1 / value2).ToString();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            foreach (var text in textBox7.Lines)
            {
                if (float.TryParse(text, out float value))
                {
                    comboBox2.Items.Add(value.ToString());
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox8.Text = string.Empty;
            decimal value;
            decimal x = 1;
            decimal sum = 0;
            string text = string.Empty;
            do
            {
                value = 1 / x;
                x++;
                sum += value;
                text += $"{sum}\r\n";
            } while (Math.Abs(value) >= numericUpDown2.Value);
            textBox8.Text = text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox10.Text = string.Empty;
            foreach (var t in textBox9.Lines)
            {
                if (!float.TryParse(t, out float value))
                {
                    textBox10.Text = $"{t}\r\n" + textBox10.Text;
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox14.Text = string.Empty;
            if (double.TryParse(textBox11.Text, out double value1) &&
                double.TryParse(textBox12.Text, out double value2) &&
                double.TryParse(textBox13.Text, out double value3))
            {
                for (double a = value1; a <= value2; a += value3)
                {
                    textBox14.Text += $"x = {a}; f(x) = {Math.Sin(a) / (Math.Abs(a) + 1)}\r\n";
                }
            }
        }
    }
}