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



namespace BookBoxWindowsFormApp
{
    public partial class Form2 : Form
    {
        private BookControllers userControllers;
        public Form2()
        {
            InitializeComponent();
            userControllers = new BookControllers();
        }

        private void button1_Click(object sender, EventArgs e) //if the information that is entered exists in the table, the user is connected
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string mail = textBox4.Text;
            var user = userControllers.GetUsername(username);
            var pass = userControllers.GetPassword(password);
            var email = userControllers.GetMail(mail);
            if (user != null && pass!=null && email!=null && checkBox1.Checked == true)
            {
                Menuto newForm = new Menuto();
                newForm.Show();
                this.Hide();
            }
           if(user==null) { MessageBox.Show($"Username is incorrect"); }
            if (pass == null) { MessageBox.Show($"Password is incorrect"); }
            if (email == null) { MessageBox.Show($"E-mail is incorrect"); }
            if(checkBox1.Checked != true) { MessageBox.Show($"Agree with the terms and conditions to proceed"); }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
