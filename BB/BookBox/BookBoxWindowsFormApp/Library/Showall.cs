using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookBox.Model;
using BookBox.Controller;
using BookBoxWindowsFormApp.Library;

namespace BookBoxWindowsFormApp.Library
{
    public partial class Showall : Form
    {
        private BookControllers bookControllers;
        public Showall()
        {
            InitializeComponent();
            bookControllers = new BookControllers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = "Colorless Tsukuru Tazaki";
            var book1 = bookControllers.GetName(name);
            if (book1 == null)
            {
                pictureBox1.Visible = false;

            }
            string name2 = "Killing Commendatore";
            var book2 = bookControllers.GetName(name2);
            if (book2 == null)
            {
                pictureBox2.Visible = false;

            }
            string name3 = "Wind/Pinball";
            var book3 = bookControllers.GetName(name3);
            if (book3 == null)
            {
                pictureBox3.Visible = false;

            }
            string name4 = "Billy Summers";
            var book4 = bookControllers.GetName(name4);
            if (book4 == null)
            {
                pictureBox4.Visible = false;

            }
            string name5 = "The Iron Candle";
            var book5 = bookControllers.GetName(name5);
            if (book5 == null)
            {
                pictureBox5.Visible = false;

            }
            string name6 = "Turtles all the way down";
            var book6 = bookControllers.GetName(name6);
            if (book6 == null)
            {
                pictureBox6.Visible = false;

            }
            var books = bookControllers.GetAllbooks();
            foreach (var book in books)
            {
                    if (book.Name == null)
                {
                    listBox2.Items.Add($"{book.Id} - Taken");
                }
                    else listBox2.Items.Add($"{book.Id} - {book.Name}, {book.Author}");
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Menuto newForm = new Menuto();
            newForm.Show();
            this.Hide();
        }
    }
}
