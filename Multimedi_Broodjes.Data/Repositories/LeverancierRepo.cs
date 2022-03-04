using Multimedi_Broodjes.Data.Entities;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Multimedi_Broodjes.Data.Repositories
{
    public class LeverancierRepo
    {
        private const string CONNECTION =
            @"Server=.\SQLEXPRESS;Database=Database_Oefeningen;Trusted_Connection=True;";

        public Leverancier GetLeverancierById(int id)
        {
            // SQL Parameters sanitize user input
            string query = "SELECT * FROM Leveranciers WHERE [LeverancierID] = @Id";
            Leverancier leverancier = null;

            using SqlConnection connection = new SqlConnection(CONNECTION);
            SqlCommand command = new SqlCommand(query, connection);

            // Set up SQL Parameters 
            command.Parameters.Add("@Id", SqlDbType.Int);
            command.Parameters["@Id"].Value = id;

            // Alternative way to add Parameter
            command.Parameters.AddWithValue("@Id", id);

            connection.Open();
            SqlDataReader result = command.ExecuteReader();

            while (result.Read())
            {
                leverancier = new Leverancier
                {
                    LeverancierID = (int)result.GetValue(0),
                    LeverancierNaam = result.GetValue(1).ToString()
                };
            }

            return leverancier;
        }

        public List<Leverancier> GetLeveranciers()
        {
            string query = "SELECT * FROM Leveranciers";
            List<Leverancier> leveranciers = new List<Leverancier>();

            using SqlConnection connection = new SqlConnection(CONNECTION);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader result = command.ExecuteReader();

            while (result.Read())
            {
                Leverancier leverancier = new Leverancier
                {
                    LeverancierID = (int)result.GetValue(0),
                    LeverancierNaam = result.GetValue(1).ToString()
                };

                leveranciers.Add(leverancier);
            }

            connection.Close();

            return leveranciers;
        }

        public void AddLeverancier(Leverancier leverancier)
        {
            string query = "INSERT INTO [Leveranciers] VALUES (@name);";

            using SqlConnection connection = new SqlConnection(CONNECTION);
            SqlCommand command = new SqlCommand(query, connection);

            // Set up SQL Parameters 
            command.Parameters.Add("@name", SqlDbType.Text);
            command.Parameters["@name"].Value = leverancier.LeverancierNaam;

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void UpdateLeverancier(int id, Leverancier leverancier)
        {
            string query = "UPDATE [Leveranciers] SET LeverancierNaam = @name WHERE LeverancierID = @id";

            using SqlConnection connection = new SqlConnection(CONNECTION);
            SqlCommand command = new SqlCommand(query, connection);

            // Set up SQL Parameters 
            command.Parameters.Add("@id", SqlDbType.Int);
            command.Parameters["@id"].Value = id;

            command.Parameters.Add("@name", SqlDbType.Text);
            command.Parameters["@name"].Value = leverancier.LeverancierNaam;

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}