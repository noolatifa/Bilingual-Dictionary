using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet
{
    class Dictionnaire
    {
        static string connstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

       

        public string username { get; set; }
        public string password { get; set; }

        public Dictionnaire(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        private List<Traduction> traductions = new List<Traduction>(); //liste des traduction dans le dictionnaire

        public IReadOnlyList<Traduction> Traductions => traductions.AsReadOnly(); 

        public List<Traduction> Traduction
        {
            get { return traductions; }
            set { traductions = value; }
        }






        public void AjouterTraduction(Traduction t)
        {
            traductions.Add(t);
        }

        public void SupprimerTraduction(Traduction t)
        {
            traductions.Remove(t);
        }


        public bool VerifyCredentials(string enteredUsername, string enteredPassword, string conString)
        {
            // Define the SELECT statement
            string sql = "SELECT password FROM administrateurs WHERE username = @username";

            // Create a new SqlConnection and SqlCommand objects
            using (SqlConnection connection = new SqlConnection(connstring))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                // Add a parameter for the username value
                command.Parameters.AddWithValue("@username", enteredUsername);

                // Open the connection
                connection.Open();

                // Execute the SELECT statement and retrieve the password value
                string password = (string)command.ExecuteScalar();

                // Compare the password value with the entered password
                if (enteredPassword == password)
                {
                    // The username and password match
                    return true;
                }
                else
                {
                    // The password is incorrect
                    return false;
                }
            }
        }
    






}
}
