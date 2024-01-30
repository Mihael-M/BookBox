using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookBoxWindowsFormApp.Library;
using BookBox.Model;
using BookBox.Controller;

namespace BookBoxWindowsFormApp
{
    public partial class Form3 : Form
    {
        private BookControllers bookControllers;
        public Form3()
        {
            InitializeComponent();
            bookControllers = new BookControllers();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label2.Visible = false;
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label3.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Menuto newForm = new Menuto();
            newForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Book book = new Book();
            book.Name=textBox1.Text;
            book.Author=textBox2.Text;
            textBox1.Clear();
            textBox2.Clear();
           

            bookControllers.Add(book);
            label4.Text = $"Done";

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Visible= false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox3.Text);
            textBox3.Clear();
            bookControllers.Delete(id);
            label4.Text = $"Done";
        }
    }
}
