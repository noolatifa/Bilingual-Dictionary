using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;


namespace projet
{
    public partial class InterfaceUtilisateur : Form
    {

        static string connstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
        //interfaceClient form2 = new interfaceClient();
        //creation d'un dataset historique
        DataSet dataSet = new DataSet();
        DataTable dataTable = new DataTable("Historique");


        public InterfaceUtilisateur()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            login form = new login();
            form.Show();
            Application.Exit();

        }

        private void InterfaceUtilisateur_Load(object sender, EventArgs e)
        {
            textBoxSearch.Enabled = false;
            this.AutoScrollMinSize = new Size(this.ClientSize.Width, this.ClientSize.Height);


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

        private void buttonAjouter_Click(object sender, EventArgs e)
        {

            label7.Text = "";
            label8.Text = "";
            string motL1 = textBoxMotFr.Text;
            string motL2 = textBoxMotAng.Text;
            string type = textBoxType.Text;
            string exp1 = textBoxExpFr.Text;
            string exp2 = textBoxExpAng.Text;
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            Traduction t = new Traduction(motL1, motL2, exp1, exp2, type);
            try
            {

                if (textBoxMotAng.Text.Length < 1 || textBoxMotFr.Text.Length < 1 || textBoxType.Text.Length < 1 || textBoxExpAng.Text.Length < 1 || textBoxExpFr.Text.Length < 1)
                {
                    if (radioButtonFr.Checked)
                    { MessageBox.Show("Veuillez tapez tous les champs s'il vous plait"); }
                    else { MessageBox.Show("please fill all the textboxes"); }

                }
                else
                {
                    string req = "select * from traductions where motl1 = @mota and motl2 = @mote";
                    SqlCommand cmd = new SqlCommand(req, conn);
                    cmd.Parameters.AddWithValue("@mota", motL1);
                    cmd.Parameters.AddWithValue("@mote", motL2);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)

                    {
                        //done = true;
                        if (radioButtonFr.Checked)
                        { MessageBox.Show("Traduction existe déjà !"); }
                        else { MessageBox.Show("Translation already exists !"); }
                      
                    }
                    else
                    {
                        bool ajout = t.Ajouter();
                        if (ajout)
                        {
                           
                            if (radioButtonFr.Checked)
                            { MessageBox.Show("Traduction ajoutée avec succès"); }
                            else { MessageBox.Show("Translation has been successfully added"); }

                        }
                        else
                        {
                            if (radioButtonFr.Checked)
                            { MessageBox.Show("Erreur lors de l'ajout de la traduction"); }
                            else { MessageBox.Show("Error while adding the new translation "); }
                            
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la connexion à la base de données : " + ex.Message);
            }
            finally
            {
                conn.Close();
            }





        }

        private void bouttonModifier_Click(object sender, EventArgs e) //lazem l un des boutton radio est checked 
        {
            label7.Text = "";
            label8.Text = "";
            if (textBoxMotAng.Text.Length < 1 || textBoxMotFr.Text.Length < 1 || textBoxType.Text.Length < 1 || textBoxExpAng.Text.Length < 1 || textBoxExpFr.Text.Length < 1)
            {
                if (radioButtonFr.Checked)
                { MessageBox.Show("Veuillez tapez tous les champs s'il vous plait"); }
                else { MessageBox.Show("please fill all the textboxes"); }

            }
            else
            {
                int id = 0;
                if (radioButtonFr.Checked)
                    id = Traduction.IdParMot(textBoxSearch.Text, "Français");
                else if (radioButtonAng.Checked)
                    id = Traduction.IdParMot(textBoxSearch.Text, "English");

                string motL1 = textBoxMotFr.Text;
                string motL2 = textBoxMotAng.Text;
                string type = textBoxType.Text;
                string exp1 = textBoxExpFr.Text;
                string exp2 = textBoxExpAng.Text;

                if (id != 0)
                {
                    Traduction t = new Traduction(id, motL1, motL2, exp1, exp2, type);

                    bool modifier = t.Modifier();
                    if (modifier)
                    {
                        if (radioButtonFr.Checked) { MessageBox.Show("Traduction modifiée avec succées"); }
                        else MessageBox.Show("Translation has been successfully modified");
                    }
                }
                else
                {
                    if (radioButtonFr.Checked) { MessageBox.Show("Mot introuvable"); }
                    else MessageBox.Show("Word not found to modify ");

                }
            }


        }

        private void buttonImporter_Click(object sender, EventArgs e)
        {
            label7.Text = "";
            label8.Text = "";
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
            label8.Text = "";
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

        private void bouttonSupprimer_Click(object sender, EventArgs e)
        {
            label7.Text = "";
            label8.Text = "";

            int id;
            if (radioButtonFr.Checked)
                id = Traduction.IdParMot(textBoxSearch.Text, "Français");
            else
                id = Traduction.IdParMot(textBoxSearch.Text, "English");

            string wordToDelete = textBoxSearch.Text; // the word to be deleted
            if (id != 0)
            {
                string message = $"Attention!! Vous venez de supprimer le mot du dictionnaire : '{wordToDelete}'. Êtes-vous sûr de vouloir continuer ?";

                DialogResult result = MessageBox.Show(message, "Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    string motL1 = textBoxMotFr.Text;
                    string motL2 = textBoxMotAng.Text;
                    string type = textBoxType.Text;
                    string exp1 = textBoxExpFr.Text;
                    string exp2 = textBoxExpAng.Text;

                    Traduction t = new Traduction(id, motL1, motL2, exp1, exp2, type);
                    bool supp = t.Supprimer();
                    if (supp)
                        MessageBox.Show("Traduction du mot " + wordToDelete + " supprimée!");
                }
                else
                {
                    // user clicked Cancel, do not delete the word
                    MessageBox.Show($"Suppression du mot '{wordToDelete}' est annulée.", "Annulée", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Le mot " + wordToDelete + " n'existe pas dans le dictionnaire");

        }

        private void button4_Click(object sender, EventArgs e) 
        {

            if (textBoxSearch.Enabled && textBoxSearch.Text.Length <= 0 && radioButtonFr.Checked)
            { MessageBox.Show("Veuillez tapez un mot"); }

            if (textBoxSearch.Enabled && textBoxSearch.Text.Length <= 0 && radioButtonAng.Checked)
            { MessageBox.Show("Please write a word to search"); }
            if (textBoxSearch.Enabled == false)
            { MessageBox.Show("Veuillez sélectionner une langue / please choose a language mode"); }

            label7.Text = "";
            label8.Text = "";
            string recherche = textBoxSearch.Text;
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
                    else if (traductions.Count > 1)
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
                        label8.Text = "Explorez d'autres synonymes ci-dessous";
                    }
                    else
                    {
                        label7.Text = "Discover the most popular translation";
                        label8.Text = "Explore other synonyms below";
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
                if (radioButtonFr.Checked && textBoxSearch.Text.Length > 0)
                {
                    MessageBox.Show("Ce mot n'existe pas dans le dictionnaire !");

                }
                else if (radioButtonAng.Checked && textBoxSearch.Text.Length > 0)
                { MessageBox.Show("This word does not exist in the dictionnary !"); }

               
            }




            }

            private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            textBoxSearch.Enabled = true;

        }

        private void radioButtonFr_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonAng.ForeColor = Color.White;
            radioButtonFr.ForeColor = Color.Black;
            textBoxSearch.Enabled = true;

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
            textBoxSearch.AutoCompleteCustomSource = myCollection;
            conn.Close();

            if (radioButtonFr.Checked)
            {
                radioButtonAng.Checked = false;
                label1.Text = "Mot en français";
                label2.Text = "Mot en anglais";
                label3.Text = "Type";
                label4.Text = "Exemple en français";
                label5.Text = "Exemple en anglais";
                bouttonAjouter.Text = "Ajouter une Traduction";
                bouttonModifier.Text = "Modifier une Traduction";
                bouttonSupprimer.Text = "Supprimer une Traduction";
                buttonVoirTout.Text = "Voir Traductions";
                buttonImporter.Text = "Importer Dictionnaire";
                button2.Text = "Exporter Dictionnaire";
                button4.Text = "Voir Historique";
            }


        }

        private void radioButtonAng_CheckedChanged(object sender, EventArgs e)
        {
            textBoxSearch.Enabled = true;
            radioButtonAng.ForeColor = Color.Black;
            radioButtonFr.ForeColor = Color.White;
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
            textBoxSearch.AutoCompleteCustomSource = myCollection;
            conn.Close();

           

            if (radioButtonAng.Checked)
            {
                radioButtonFr.Checked = false;
                label1.Text = "Word in french";
                label2.Text = "Word in english";
                label3.Text = "Type";
                label4.Text = "Example in french";
                label5.Text = "Example in english";
                bouttonAjouter.Text = "Add Translation";
                bouttonModifier.Text = "Modify Translation";
                bouttonSupprimer.Text = "Delete Translation";
                buttonVoirTout.Text = "All Translations";
                buttonImporter.Text = "Import Dictionnary";
                button2.Text = "Export Dictionnary";
                button4.Text = "Search History";

            }
        }

        private void buttonVoirTout_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Traduction.SelectionnerTout();
            label7.Text = "";
            if (radioButtonFr.Checked)
                label8.Text = "Explorez toutes les traductions";
            else if (radioButtonAng.Checked)
                label8.Text = "Explore all translations";
            else
                label8.Text = "Explore all translations / Explorez toutes les traductions";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            radioButtonAng.Checked = false;
            radioButtonFr.Checked = false;
            textBoxSearch.Text = "";
            textBoxSearch.Enabled = false;
            textBoxMotFr.Text = "";
            textBoxMotAng.Text = "";
            textBoxExpAng.Text = "";
            textBoxExpFr.Text = "";
            textBoxType.Text = "";
            label7.Text = "";
            label8.Text = "";
            dataGridView1.DataSource = null;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            interfaceClient form2 = new interfaceClient();
            form2.Show();
            // this.Hide();
        }

        private void textBoxMotFr_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBoxExpAng_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBoxExpFr_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBoxMotAng_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            // Set the AutoScroll property to true on the form or panel that contains the control
            //this.AutoScroll = true;

            // Set the AutoScrollMinSize property to the size of the form or panel to enable scrolling
            // this.AutoScrollMinSize = new Size(this.ClientSize.Width, this.ClientSize.Height);

            // Enable the vertical scrollbar for the control
            //myControl.VerticalScroll.Enabled = true;

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dataSet.Tables["Historique"];
            label7.Text = "";
            if (radioButtonFr.Checked)
                label8.Text = "Historique de recherche";
            else if (radioButtonAng.Checked)
                label8.Text = "Search History";
            else
                label8.Text = "Search History / Historique de recherche";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            login form1 = new login();
            form1.Show();
            this.Close();
        }

        private void textBoxExpAng_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }

}
