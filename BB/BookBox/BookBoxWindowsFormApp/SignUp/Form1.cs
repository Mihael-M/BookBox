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


namespace BookBoxWindowsFormApp
{
    public partial class Form1 : Form
    {
        private BookControllers userControllers ;
       
        public Form1()
        {
            InitializeComponent();
           userControllers = new BookControllers();
    }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
       
            
            
        

        private void button1_Click(object sender, EventArgs e)
        {
          
            string username=textBox1.Text;
            string password=textBox2.Text;
            string secondpassword=textBox3.Text;
            string mail = textBox4.Text;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            User user = new User(username, password, mail);
            if (password == secondpassword && checkBox1.Checked == true)
             
            { userControllers.AddUser(user);
                Form2 newForm = new Form2();
                newForm.Show();
                this.Hide();
            }
            if(password != secondpassword)
            {
                MessageBox.Show($"Passwords don't match");
            }
            if (checkBox1.Checked != true) { MessageBox.Show($"Agree with the terms and conditions to proceed"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
            this.Hide();
        }

        private void panelRight_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
