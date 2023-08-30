using MaterialSkin;
using projet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projet
{
    public partial class interfaceClient : Form
    {
        static string connstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
        // InterfaceUtilisateur form1 = new InterfaceUtilisateur();

        //creation d'un dataset historique
        DataSet dataSet = new DataSet();
        DataTable dataTable = new DataTable("Historique");


        public interfaceClient()
        {
            InitializeComponent();

            
        }

        private void textBoxExpAng_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           login form1 = new login();
            form1.Show();
            this.Close();
        }

        private void interfaceClient_Load(object sender, EventArgs e)
        {
            textBoxSearchfail.Enabled = false;

            //label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;


            //label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;

            //label3.Parent = pictureBox1;
            label3.BackColor = Color.Transparent;

            //label4.Parent = pictureBox1;
            label4.BackColor = Color.Transparent;

            //label5.Parent = pictureBox1;
            label5.BackColor = Color.Transparent;


            // radioButtonAng.Parent = pictureBox1;
            radioButtonAng.BackColor = Color.Transparent;

            //radioButtonFr.Parent = pictureBox1;
            radioButtonFr.BackColor = Color.Transparent;

            //SearchButton.Parent = pictureBox1;
           
            SearchButton.FlatStyle = FlatStyle.Flat;
            SearchButton.FlatAppearance.BorderSize = 0;
            SearchButton.BackColor = Color.Transparent;


           radioButtonAng.FlatStyle = FlatStyle.Flat;
            radioButtonAng.FlatAppearance.BorderSize = 0;
            radioButtonAng.BackColor = Color.Transparent;

            radioButtonFr.FlatStyle = FlatStyle.Flat;
            radioButtonFr.FlatAppearance.BorderSize = 0;
            radioButtonFr.BackColor = Color.Transparent;





        }

        private void textBoxExpFr_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonFr_CheckedChanged(object sender, EventArgs e)
        {



        }

        private void radioButtonAng_CheckedChanged(object sender, EventArgs e)
        {




        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }



        private void textBoxSearch_TextChanged_1(object sender, EventArgs e)
        {
            textBoxSearchfail.Enabled = true;
            

            
        }

         private void SearchButton_Click_1(object sender, EventArgs e)
          {

            if (textBoxSearchfail.Enabled && textBoxSearchfail.Text.Length <= 0 && radioButtonFr.Checked)
            { MessageBox.Show("Veuillez tapez un mot"); }

            if (textBoxSearchfail.Enabled && textBoxSearchfail.Text.Length <= 0 && radioButtonAng.Checked)
            { MessageBox.Show("Please write a word to search"); }
            if (textBoxSearchfail.Enabled == false)
            { MessageBox.Show("Veuillez sélectionner une langue / please choose a language mode"); }
            label7.Text = "";
            label6.Text = "";


            string recherche = textBoxSearchfail.Text;
        List<Traduction> traductions;

                if (radioButtonFr.Checked)
                    traductions = Traduction.SelectionnerParMotFr(recherche);
                else
                    traductions = Traduction.SelectionnerParMotEng(recherche);

                if (traductions.Count > 0)
                {
                    if (traductions.Count == 1)
                    {
                        // Affichez la première traduction dans les contrôles de l'interface utilisateur
                        Traduction t = traductions[0];
                        textBoxMotFr.Text = t.Mot1;
                        textBoxMotAng.Text = t.Mot2;
                        textBoxExpAng.Text = t.Exple2;
                        textBoxExpFr.Text = t.Exple1;
                        textBoxType.Text = t.Type;
                    }
                    else
                    {
                        Traduction t = traductions[0];
                        textBoxMotFr.Text = t.Mot1;
                        textBoxMotAng.Text = t.Mot2;
                        textBoxExpAng.Text = t.Exple2;
                        textBoxExpFr.Text = t.Exple1;
                        textBoxType.Text = t.Type;
                        dataGridView1.DataSource = traductions;
                    if (radioButtonFr.Checked)
                    {
                        label7.Text = "Découvrez  la traduction la plus populaire";
                        label6.Text = "Explorez d'autres synonymes ci-dessous";
                    }
                    else
                    {
                        label7.Text = "Discover the most popular translation";
                        label6.Text = "Explore other synonyms below";
                    }
                }

                if (!dataSet.Tables.Contains("Historique"))
                {
                    dataTable.Columns.Add("MotL1", typeof(string));
                    dataTable.Columns.Add("MotL2", typeof(string));
                    dataTable.Columns.Add("ExempleL1", typeof(string));
                    dataTable.Columns.Add("ExempleL2", typeof(string));
                    dataTable.Columns.Add("Type", typeof(string));
                    dataSet.Tables.Add(dataTable);
                }

                // Ajouter chaque traduction à l'historique
                foreach (Traduction tr in traductions)
                {
                    tr.Ajouter_historique(dataSet);
                }
                                }
                                else
                {
                    Console.WriteLine("Mot introuvable");
                if (radioButtonFr.Checked && textBoxSearchfail.Text.Length > 0)
                {
                    MessageBox.Show("Ce mot n'existe pas dans le dictionnaire !");

                }
                else if (radioButtonAng.Checked && textBoxSearchfail.Text.Length > 0)
                { MessageBox.Show("This word does not exist in the dictionnary !"); }
            }



        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            radioButtonAng.Checked = false;
            radioButtonFr.Checked = false;
            textBoxSearchfail.Text = "";
            textBoxSearchfail.Enabled = false;
            textBoxMotFr.Text = "";
            textBoxMotAng.Text = "";
            textBoxExpAng.Text = "";
            textBoxExpFr.Text = "";
            textBoxType.Text = "";
            dataGridView1.DataSource = null;
            label7.Text = "";
            label6.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonVoirTout_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Traduction.SelectionnerTout();
        }

        private void textBoxMotFr_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void radioButtonFr_CheckedChanged_2(object sender, EventArgs e)
        {
            textBoxSearchfail.Enabled = true;
            radioButtonFr.ForeColor = Color.Black;
            radioButtonAng.ForeColor = Color.White;
            SqlConnection conn = new SqlConnection(connstring);
            string req = "SELECT motL1 FROM Traductions";
            // string req2 = "SELECT motL2 FROM Traductions";

            conn.Open();
            SqlCommand cmd = new SqlCommand(req, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            AutoCompleteStringCollection myCollection = new AutoCompleteStringCollection();

            while (reader.Read())
            {
                myCollection.Add(reader.GetString(0));
            }
            textBoxSearchfail.AutoCompleteCustomSource = myCollection;
            conn.Close();


            if (radioButtonFr.Checked)
            {
                radioButtonAng.Checked = false;
                label1.Text = "Mot en français";
                label2.Text = "Mot en anglais";
                label3.Text = "Type";
                label4.Text = "Exemple en français";
                label5.Text = "Exemple en anglais";

                buttonVoirTout.Text = "Voir Traductions";
                buttonImporter.Text = "Importer Dictionnaire";
                button2.Text = "Exporter Dictionnaire";
                button4.Text = "Voir Historique";
                button1.Text = "Espace Administrateur";
            }
        }

        private void radioButtonAng_CheckedChanged_1(object sender, EventArgs e)
        {
            radioButtonAng.ForeColor = Color.Black;
            radioButtonFr.ForeColor = Color.White;
            textBoxSearchfail.Enabled = true;

            SqlConnection conn = new SqlConnection(connstring);
            //string req = "SELECT motL1 FROM Traductions";
            string req2 = "SELECT motL2 FROM Traductions";

            conn.Open();
            SqlCommand cmd = new SqlCommand(req2, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            AutoCompleteStringCollection myCollection = new AutoCompleteStringCollection();

            while (reader.Read())
            {
                myCollection.Add(reader.GetString(0));
            }
            textBoxSearchfail.AutoCompleteCustomSource = myCollection;
            conn.Close();


            if (radioButtonAng.Checked)
            {
                radioButtonFr.Checked = false;
                label1.Text = "Word in french";
                label2.Text = "Word in english";
                label3.Text = "Type";
                label4.Text = "Example in french";
                label5.Text = "Example in english";
                buttonVoirTout.Text = "All Translations";
                buttonImporter.Text = "Import Dictionnary";
                button2.Text = "Export Dictionnary";
                button4.Text = "Search History";
                button1.Text = "Administrator plateform";
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBoxType_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonMaskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBoxExpAng_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void buttonVoirTout_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Traduction.SelectionnerTout();
            label7.Text = "";
            if (radioButtonFr.Checked)
                label6.Text = "Explorez toutes les traductions";
            else if (radioButtonAng.Checked)
                label6.Text = "Explore all translations";
            else
                label6.Text = "Explore all translations / Explorez toutes les traductions";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dataSet.Tables["Historique"];
            label7.Text = "";
            if (radioButtonFr.Checked)
            label6.Text = "Historique de recherche";
            else if (radioButtonAng.Checked)
            label6.Text = "Search History";
            else
                label6.Text = "Search History / Historique de recherche";
        }

        private void buttonImporter_Click(object sender, EventArgs e)
        {
            label7.Text = "";
            label6.Text = "";
            string path = @"C:\Users\latif\Desktop\xml_db_dict.xml";

            try
            {
                Traduction.Importer_traductions(connstring, path);
                MessageBox.Show("Importation des traductions effectuées avec succès");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue lors de l'importation des données: " + ex.Message);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            label7.Text = "";
            label6.Text = "";
            try
            {
                string connstring = "Data Source=LAPTOP-UJSDFQRC;Initial Catalog=DB_DICTIONNAIRE;Integrated Security=True;";
                string chemin_fichier1 = @"C:\Users\latif\Desktop\test_exp.xml";


                Traduction.Exporter_traductions(connstring, chemin_fichier1);

                MessageBox.Show("Exportation terminée avec succès !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue lors de l'exportation : " + ex.Message);
            }
        }

        private void kryptonMaskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            login form1 = new login();
            form1.Show();
            this.Close();
        }
    }
}
