using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoLavoratori2
{
    class DbHelperLavoratori
    {
        private static SqlConnection connection;
        private static SqlConnection GetConnection() 
        {
            if(connection == null)
            {
                string connectionString = ConfigurationManager.AppSettings.Get("connectionString");
                connection = new SqlConnection(connectionString);
            }
            return connection;
        }

        public static int DeletePerson(Lavoratore l) 
        {
            int result = 0;

            string deleteQuery =
                "Delete from Lavoratori " +
                "WHERE ID = @Persona_ID";

            SqlCommand cmd = new SqlCommand
            {
                Connection = GetConnection(),
                CommandType = CommandType.Text,
                CommandText = deleteQuery
            };

            cmd.Parameters.AddWithValue("Persona_ID", l.Persona_ID);

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            return result;
        }

        public static int UpdatePerson(Lavoratore l) 
        {
            int result = 0;
            string updateQuery = "UPDATE Lavoratori SET " +
                "Nome = @Nome, " +
                "Cognome = @Cognome, " +
                "Genere = @Genere, " +
                "DataDiNascita = @DataDiNascita, " +
                "Retribuzione = @Retribuzione, " +
                "DataAssunzione = @DataAssunzione, " +
                "Tipo = @Tipo, " +
                "Persona_ID = @Persona_ID";

            SqlCommand cmd = new SqlCommand
            {
                Connection = GetConnection(),
                CommandType = CommandType.Text,
                CommandText = updateQuery
            };

            cmd.Parameters.Add("@Nome", SqlDbType.NVarChar, 255).Value = l.Nome;
            cmd.Parameters.Add("@Cognome", SqlDbType.NVarChar, 255).Value = l.Cognome;
            cmd.Parameters.Add("@Genere", SqlDbType.Char).Value = l.Genere;
            cmd.Parameters.Add("@DataDiNascita", SqlDbType.DateTime).Value = l.DataDiNascita;
            cmd.Parameters.Add("@Retribuzione", SqlDbType.Float).Value = l.Retribuzione;
            cmd.Parameters.Add("@DataAssunzione", SqlDbType.DateTime).Value = l.DataAssunzione;
            cmd.Parameters.Add("Tipo", SqlDbType.Int).Value = l.Tipo;
            cmd.Parameters.AddWithValue("Persona_ID", l.Persona_ID);

            cmd.Connection.Open();
            result = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return result;
        }

        public static void InsertPerson(Lavoratore l) 
        {
            SqlCommand cmd = new SqlCommand()
            {
                

                CommandText = "INSERT INTO ProgettoLavoratori" +
                "(ID, Nome, Cognome, Genere, [Data di nascita], Retribuzione, [Data assunzione], Tipo) "
                + "VALUES"
                + "(@ID, @Nome, @Cognome, @Genere, @DataDiNascita, @Retribuzione, @DataAssunzione, @Tipo)"
            };

            cmd.Connection = GetConnection();

            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = l.Persone_ID;
            cmd.Parameters.Add("@Nome", SqlDbType.NVarChar, 255).Value = l.Nome;
            cmd.Parameters.Add("@Cognome", SqlDbType.NVarChar, 255).Value = l.Cognome;
            cmd.Parameters.Add("@Genere", SqlDbType.Char, 1).Value = l.Genere;
            cmd.Parameters.Add("@DataDiNascita", SqlDbType.DateTime).Value = l.DataDiNascita;
            cmd.Parameters.Add("Retribuzione", SqlDbType.Float).Value = l.Retribuzione;
            cmd.Parameters.Add("DataAssunzione", SqlDbType.DateTime).Value = l.DataAssunzione;
            cmd.Parameters.Add("Tipo", SqlDbType.Int).Value = l.Tipo;

            cmd.Connection.Open();

            int result = cmd.ExecuteNonQuery();

            cmd.Connection.Close();

            Console.WriteLine("{0} rows affected!", result);
        }

        public static DataSet GetPersone() 
        {
            DataSet result = new DataSet();
            string selectQuery = "SELECT ID, Nome, Cognome, Genere, DataDiNascita," +
                "Retribuzione, DataAssunzione, Tipo FROM Lavoratore";

            SqlCommand cmd = new SqlCommand(selectQuery, GetConnection());

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(result);

            return result;
        }
    }
}
