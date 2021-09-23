using StudentiMVC_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentiMVC_CRUD.Services
{
    public class StudentService
    {
        private readonly string connectionString;
        private readonly SqlConnection conn;
        private readonly SqlCommand cmd;
        private string strSQL;
        private string strRisultato;

        /// <summary>
        /// costruttore che inizializza
        /// tutte le variabili di classe
        /// </summary>
        public StudentService()
        {
            connectionString = ConfigurationManager.ConnectionStrings[""].ConnectionString;
            conn = new SqlConnection(connectionString);
            cmd = conn.CreateCommand();
            strSQL = string.Empty;
            strRisultato = string.Empty;
        }


        public List<Studente> GetAll()
        {
            List<Studente> studenti = new List<Studente>();

            strSQL = "SELECT * FROM Students";

            try
            {
                using (conn)
                {
                    cmd.CommandText = strSQL;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            return studenti;
        }


        public Studente GetStudente(int id)
        {
            if (id > 0 && id <= GetAll().Count)
            {
                Studente studente = GetAll().FirstOrDefault(s => id.Equals(s.Id));

                return studente;
            }
            else
            {
                return null;
            }
        }


        public string CreateStudente(Studente s)
        {
            strSQL = "INSERT INTO Students (FirstName, LastName, DOB) VALUES (@nome, @cognome, @data_nascita)";

            try
            {
                using (conn)
                {
                    cmd.CommandText = strSQL;

                    cmd.Parameters.AddWithValue("@nome", s.Nome);
                    cmd.Parameters.AddWithValue("@cognome", s.Cognome);
                    cmd.Parameters.AddWithValue("@data_nascita", s.DataNascita);

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    strRisultato = $"Studente inserito con successo!";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }            

            return strRisultato;
        }


        public string UpdateStudente(Studente s)
        {
            strSQL = $"UPDATE Students SET FirstName=@nome, LastName=@cognome, DOB=@data_nascita WHERE Id=@id";

            try
            {
                using (conn)
                {
                    cmd.CommandText = strSQL;

                    cmd.Parameters.AddWithValue("@id", s.Id);
                    cmd.Parameters.AddWithValue("@nome", s.Nome);
                    cmd.Parameters.AddWithValue("@cognome", s.Cognome);
                    cmd.Parameters.AddWithValue("@data_nascita", s.DataNascita);

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    strRisultato = $"Studente modificato con successo!";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            return strRisultato;
        }


        public string DeleteStudente(int id)
        {
            strSQL = "DELETE FROM Students WHERE Id = @id";

            try
            {
                using (conn)
                {
                    cmd.CommandText = strSQL;

                    cmd.Parameters.AddWithValue("@id", id);                    

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    strRisultato = $"Studente eliminato con successo!";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            return strRisultato;
        }
    }
}