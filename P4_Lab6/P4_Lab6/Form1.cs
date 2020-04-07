using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P4_Lab6
{
    public partial class Form1 : Form
    {
        BindingList<Number> numbers = new BindingList<Number>();
        int counter = 0;
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = numbers;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            var path = openFileDialog1.FileName;
            var content = File.ReadAllText(path);
            var numbers = content.Split(new[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach(var item in numbers)
            {
                flowLayoutPanel1.Controls.Add(GenerateTextBox(item.ToString()));
            }
            textBox1.Visible = true;
            button2.Visible = true;
        }
        private TextBox GenerateTextBox(string text)
        {
            return new TextBox()
            {
                Text = text,
                Width = 25
            };

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var rand = new Random();
            var number = rand.Next(100);
            textBox1.Text = number.ToString();
            counter++;
            if(counter%10==0)
            {
                numbers.Add(new Number() { Value= number.ToString()});
            }
            if(counter==60)
            {
                timer1.Stop();
            }
        }
    }
}
