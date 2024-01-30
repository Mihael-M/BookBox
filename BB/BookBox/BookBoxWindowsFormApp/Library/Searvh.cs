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

namespace BookBoxWindowsFormApp.Library
{
    public partial class Searvh : Form
    {
        private BookControllers bookControllers;
        public Searvh()
        {
            InitializeComponent();
            bookControllers = new BookControllers();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Menuto newForm = new Menuto();
            newForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text;
            textBox2.Clear();
                 var book = bookControllers.GetName(name);
            if (book != null)
            {
                listBox2.Items.Add(book.Id);
                listBox2.Items.Add(book.Name);
                listBox2.Items.Add(book.Author);
            }
            else
            {
               MessageBox.Show("Book not found!");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string author = textBox1.Text;
            textBox1.Clear();
            var book = bookControllers.GetAuthor(author);
            if (book != null)
            {
                listBox2.Items.Add(book.Id);
                listBox2.Items.Add(book.Name);
                listBox2.Items.Add(book.Author);
            }
            else
            {
                MessageBox.Show("Book not found!");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label2.Visible = false;
        }
    }
}
