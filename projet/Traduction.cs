using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace projet
{
    public class Traduction
    {
        int id;
        string mot1;
        string mot2;
        string exple1;
        string exple2;
        string type;


        static string connstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        public Traduction(int id, string motf, string mota, string explef, string explea, string type)
        {
            this.id = id;
            this.type = type;
            this.mot1 = motf;//1 pour fr  2 pour anglais
            this.mot2 = mota;
            this.exple1 = explef;
            this.exple2 = explea;
        }

        public Traduction(string motf, string mota, string explef, string explea, string type)
        {

            this.type = type;
            this.mot1 = motf;//1 pour fr  2 pour anglais
            this.mot2 = mota;
            this.exple1 = explef;
            this.exple2 = explea;
        }

        public bool Ajouter() //methode d'objet t.Ajouter()
        {
            bool done = false;

            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string req = "INSERT INTO Traductions(MotL1,MotL2,Type,ExempleL1,ExempleL2) " +
                "VALUES(@motL1,@motL2,@type,@exple1,@exple2)";
            SqlCommand cmd = new SqlCommand(req, conn); // creation de la commande sql
            cmd.Parameters.AddWithValue("@motL1", this.mot1);
            cmd.Parameters.AddWithValue("@motL2", this.mot2);
            cmd.Parameters.AddWithValue("@exple1", this.exple1);
            cmd.Parameters.AddWithValue("@exple2", this.exple2);
            cmd.Parameters.AddWithValue("@type", this.type);

            int rows = cmd.ExecuteNonQuery();  //returns the number of rows affected 
            if (rows > 0)
                done = true;

            return done;
        }


        public bool Ajouter_historique(DataSet ds) //methode d'objet t.Ajouter()
        {
            bool done = false;
            // ajout des données dans la table "Historique"
            DataRow newRow = ds.Tables["Historique"].NewRow();
            newRow["MotL1"] = this.mot1;
            newRow["MotL2"] = this.mot2;
            newRow["ExempleL1"] = this.exple1;
            newRow["ExempleL2"] = this.exple2;
            newRow["Type"] = this.type;
            ds.Tables["Historique"].Rows.Add(newRow);

            if (ds.HasChanges())
                done = true;

            return done;
        }

        public static void Importer_traductions(string connstring, string chemin_fichier)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(chemin_fichier);

                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    conn.Open();

                    foreach (DataRow colonne in ds.Tables[0].Rows)
                    {
                        string req = "INSERT INTO traductions (MotL1,MotL2,Type,ExempleL1,ExempleL2) " +
                            "VALUES ( @MotL1, @MotL2, @Type, @ExpleL1, @ExpleL2)";
                        SqlCommand cmd = new SqlCommand(req, conn);

                        cmd.Parameters.AddWithValue("@MotL1", colonne["MotL1"]);
                        cmd.Parameters.AddWithValue("@MotL2", colonne["MotL2"]);
                        cmd.Parameters.AddWithValue("@Type", colonne["Type"]);
                        cmd.Parameters.AddWithValue("@ExpleL1", colonne["ExempleL1"]);
                        cmd.Parameters.AddWithValue("@ExpleL2", colonne["ExempleL2"]);

                        cmd.ExecuteNonQuery();
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Une erreur est survenue lors de l'importation des données: " + ex.Message);
                throw;
            }
        }



        public static int IdParMot(string m, string langue) { 
            int n = 0;
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string req = "";
            if (langue == "Français")
                req = "SELECT id_traduction FROM traductions WHERE UPPER(motL1)=@m";
            else
                req = "SELECT id_traduction FROM traductions WHERE UPPER(motL2)=@m";
            SqlCommand cmd = new SqlCommand(req, conn);
            cmd.Parameters.AddWithValue("@m", m.ToUpper());
            object res = cmd.ExecuteScalar();
            if (res != null)
                n = int.Parse(res.ToString());
            return n;
        }

        public bool Modifier() //methode d'objet t.Modifier()
        {
            bool done = false;

            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string req = "UPDATE TRADUCTIONS SET   MotL1=@motL1, " +
                                                   "MotL2=@motL2," +
                                                   "ExempleL1=@exple1, " +
                                                   "ExempleL2=@exple2, " +
                                                   "Type=@type " +
                                                   "WHERE id_traduction=@id_traduction";

            SqlCommand cmd = new SqlCommand(req, conn); // creation de la commande sql
            cmd.Parameters.AddWithValue("@id_traduction", this.id);
            cmd.Parameters.AddWithValue("@motL1", this.mot1);
            cmd.Parameters.AddWithValue("@motL2", this.mot2);
            cmd.Parameters.AddWithValue("@exple1", this.exple1);
            cmd.Parameters.AddWithValue("@exple2", this.exple2);
            cmd.Parameters.AddWithValue("@type", this.type);

            int rows = cmd.ExecuteNonQuery();  //returns the number of rows affected 
            if (rows > 0)
                done = true;

            return done;

        }

        public static DataTable SelectionnerTout() //c'est une methode de classe "Traduction.SelectionnerTout()"
        {
            SqlConnection conn = new SqlConnection(connstring); //chaine de connexion
            DataTable l = new DataTable(); //creation de l'objet a retouner

            conn.Open(); //ouverture de la connexion


            string req = "SELECT * FROM TRADUCTIONS"; // requete a executer
            SqlCommand cmd = new SqlCommand(req, conn); //execution de la cmd sql 
            SqlDataAdapter adapter = new SqlDataAdapter(cmd); //remplir le DataTable a partir de la commande

            adapter.Fill(l); //recuperation du DataTable resultant                                

            conn.Close(); //fermer la connexion

            return l;
        }



        public static Traduction SelectionnerParId(int id) //c'est une methode de classe "Traduction.SelectionnerParId(int id)"
        {
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string req = "SELECT * FROM TRADUCTIONS WHERE id_traduction=@id";

            SqlCommand cmd = new SqlCommand(req, conn);
            cmd.Parameters.AddWithValue("@id", id); //ajout des parametres de la cmd

            var reader = cmd.ExecuteReader(); //le retour de la req 
            if (reader.Read())
            {
                string motL1 = reader.GetString(reader.GetOrdinal("motL1")); //traja3 l valeur mtaa column "mot_l1" fel ligne courante mtaa reader comme string
                string motL2 = reader.GetString(reader.GetOrdinal("motL2"));
                string type = reader.GetString(reader.GetOrdinal("type"));
                string exempleL1 = reader.GetString(reader.GetOrdinal("expleL1"));
                string exempleL2 = reader.GetString(reader.GetOrdinal("expleL2"));
                return new Traduction(id, motL1, motL2, exempleL1, exempleL2, type);
            }
            return null; // en cas ou on n'a pas trouver une traduction avec cet id                                                                                                          
        }


        /*   public static Traduction SelectionnerParMotFr(string mot)
           {
               try
               {
                   SqlConnection conn = new SqlConnection(connstring);
                   conn.Open();
                   string req = "SELECT * FROM TRADUCTIONS WHERE MotL1=@mot";

                   SqlCommand cmd = new SqlCommand(req, conn);

                   cmd.Parameters.AddWithValue("@mot", mot);

                   SqlDataReader reader = cmd.ExecuteReader();

                   if (reader.Read())
                   {
                       int id = reader.GetInt32(reader.GetOrdinal("id_traduction"));
                       string motL1 = reader.GetString(reader.GetOrdinal("motL1"));
                       string motL2 = reader.GetString(reader.GetOrdinal("motL2"));
                       string type = reader.GetString(reader.GetOrdinal("type"));
                       string exempleL1 = reader.GetString(reader.GetOrdinal("exempleL1"));
                       string exempleL2 = reader.GetString(reader.GetOrdinal("exempleL2"));
                       return new Traduction(id, motL1, motL2, exempleL1, exempleL2, type);
                   }
               }
               catch (Exception ex)
               {
                   Console.WriteLine("An error occurred while selecting data: " + ex.Message);
               }

               return null;

           }*/


        public static List<Traduction> SelectionnerParMotFr(string mot)
        {
            List<Traduction> traductions = new List<Traduction>();

            try
            {
                SqlConnection conn = new SqlConnection(connstring);
                conn.Open();
                string req = "SELECT * FROM TRADUCTIONS WHERE MotL1=@mot";

                SqlCommand cmd = new SqlCommand(req, conn);

                cmd.Parameters.AddWithValue("@mot", mot);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(reader.GetOrdinal("id_traduction"));
                    string motL1 = reader.GetString(reader.GetOrdinal("motL1"));
                    string motL2 = reader.GetString(reader.GetOrdinal("motL2"));
                    string type = reader.GetString(reader.GetOrdinal("type"));
                    string exempleL1 = reader.GetString(reader.GetOrdinal("exempleL1"));
                    string exempleL2 = reader.GetString(reader.GetOrdinal("exempleL2"));

                    Traduction t = new Traduction(id, motL1, motL2, exempleL1, exempleL2, type);
                    traductions.Add(t);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while selecting data: " + ex.Message);
            }

            return traductions;
        }





        public static List<Traduction> SelectionnerParMotEng(string mot)
        {
            List<Traduction> traductions = new List<Traduction>();

            try
            {
                SqlConnection conn = new SqlConnection(connstring);
                conn.Open();
                string req = "SELECT * FROM TRADUCTIONS WHERE MotL2=@mot";

                SqlCommand cmd = new SqlCommand(req, conn);

                cmd.Parameters.AddWithValue("@mot", mot);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(reader.GetOrdinal("id_traduction"));
                    string motL1 = reader.GetString(reader.GetOrdinal("motL1"));
                    string motL2 = reader.GetString(reader.GetOrdinal("motL2"));
                    string type = reader.GetString(reader.GetOrdinal("type"));
                    string exempleL1 = reader.GetString(reader.GetOrdinal("exempleL1"));
                    string exempleL2 = reader.GetString(reader.GetOrdinal("exempleL2"));

                    Traduction t = new Traduction(id, motL1, motL2, exempleL1, exempleL2, type);
                    traductions.Add(t);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while selecting data: " + ex.Message);
            }

            return traductions;
        }



        public bool Supprimer() //methode d'objet t.Supprimer
        {
            bool done = false;

            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string req = "DELETE FROM traductions WHERE id_traduction = @id_traduction";
            SqlCommand cmd = new SqlCommand(req, conn); // creation de la commande sql
            cmd.Parameters.AddWithValue("@id_traduction", this.id);
            int rows = cmd.ExecuteNonQuery();  //returns the number of rows affected 
            if (rows > 0)
                done = true;

            return done;
        }



        public static void Exporter_traductions(string connstring, string chemin_fichier)//chemin fichier on doit le définir lors de l'appel de la meth w on peut traiter la meth dans un bloc try catch 
        {
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                conn.Open();

                string req = "SELECT * FROM traductions";
                SqlCommand cmd = new SqlCommand(req, conn);


                //creation d'un data adapter pour remplir un dataset avec les données de la table (traductions) de la base
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //creation d'un dataset pour stocker les données de la table traductions dans ce dataset
                DataSet ds = new DataSet();

                //remplissage du dataset avec les données de la table traductions 
                adapter.Fill(ds, "traductions");

                using (XmlTextWriter writer = new XmlTextWriter(chemin_fichier, System.Text.Encoding.UTF8))
                {
                    writer.Formatting = Formatting.Indented; //structuration de contenu du fichier XML pour le rendre facile à lire et bien structuré et compréhensible


                    ds.WriteXml(writer); // ecriture des données du dataset dans un fichier xml en utilisant l'output fourni par l'objet writer (XmlTextWriter)

                    conn.Close();//fermeture de la connexion bd

                }


            }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Mot1
        {
            get { return mot1; }
            set { mot1 = value; }
        }

        public string Mot2
        {
            get { return mot2; }
            set { mot2 = value; }
        }

        public string Exple1
        {
            get { return exple1; }
            set { exple1 = value; }
        }

        public string Exple2
        {
            get { return exple2; }
            set { exple2 = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Traduire_en_fr()
        {
            return "Type: " + type + " Traduction: " + mot1 + " Exemple " + exple1;
        }

        public string Traduire_en_ang()
        {
            return "Type: " + type + " Traduction: " + mot2 + " Exemple " + exple2;
        }








    }
}
