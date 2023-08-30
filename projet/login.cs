using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projet
{
    public partial class login : Form
    {

        static string connstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        public login()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dictionnaire dictionnaire = new Dictionnaire(user.Text, pass.Text);

            bool isValid = dictionnaire.VerifyCredentials(user.Text, pass.Text, connstring);

            if (isValid)
            {
                // The username and password match
                MessageBox.Show("Login successful!");
                InterfaceUtilisateur form= new InterfaceUtilisateur();
                form.Show();
                this.Hide();
            }
            else
            {
                // The password is incorrect
                MessageBox.Show("Invalid username or password.");
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            interfaceClient form3 = new interfaceClient();
            login mainform = new login();
            form3.Show();

            this.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
              
            
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void user_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
