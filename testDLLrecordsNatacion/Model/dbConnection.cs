using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testDLLrecordsNatacion.Model.Entities;

namespace testDLLrecordsNatacion.Model
{
    public class dbConnection
    {
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=recordsNatacion;Integrated Security=True";

        #region Athlete 
        /// <summary>
        /// Searches if an athlete exists in the DB by its full name.
        /// </summary>
        /// <param name="athleteFullName">Full name of the athlete</param>
        /// <returns>The athelete or null if no matches were found</returns>
        public Athlete SearchAthleteByName(string athleteFullName)
        {
            string query = "SELECT * FROM Athlete WHERE FullName = @FullName";
            Athlete athlete = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FullName", athleteFullName);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        athlete = new Athlete();
                        athlete.Id = (int)reader["Id"];
                        athlete.FullName = reader["FullName"].ToString();
                        athlete.Birthdate = DateTime.Parse(reader["Birthdate"].ToString());
                        athlete.Gender = reader["Gender"].ToString();
                        athlete.Nation = reader["Nation"].ToString();
                        athlete.License = reader["License"].ToString();
                        athlete.ClubName = reader["ClubName"].ToString();
                        athlete.ClubShortName = reader["ClubShortName"].ToString();
                        athlete.ClubCode = (int)reader["ClubCode"];
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "\n\n" + ex.StackTrace);
                }
                finally
                {
                    reader.Close();
                }
            }
            return athlete;
        }

        /// <summary>
        /// Gets athlete info by its ID if it exists in the DB
        /// </summary>
        /// <param name="athleteId">Id of the athlete</param>
        /// <returns>The athelete or null if no matches were found</returns>
        public Athlete SelectAthleteById(int athleteId)
        {
            string query = "SELECT * FROM Athlete WHERE id = @id";
            Athlete athlete = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", athleteId);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        athlete = new Athlete();
                        athlete.Id = (int)reader["Id"];
                        athlete.FullName = reader["FullName"].ToString();
                        athlete.Birthdate = DateTime.Parse(reader["Birthdate"].ToString());
                        athlete.Gender = reader["Gender"].ToString();
                        athlete.Nation = reader["Nation"].ToString();
                        athlete.License = reader["License"].ToString();
                        athlete.ClubName = reader["ClubName"].ToString();
                        athlete.ClubShortName = reader["ClubShortName"].ToString();
                        athlete.ClubCode = (int)reader["ClubCode"];
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "\n\n" + ex.StackTrace);
                }
                finally
                {
                    reader.Close();
                }
            }
            return athlete; 
        }

        /// <summary>
        /// Gets all the existing athletes in the DB
        /// </summary>
        /// <returns>List of existing athletes</returns>
        public List<Athlete> SelectAllAthletes()
        {
            string query = "SELECT * FROM Athlete";
            List<Athlete> atletas = new List<Athlete>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        Athlete atleta = new Athlete();
                        atleta.Id = (int) reader["Id"];
                        atleta.FullName = reader["FullName"].ToString();
                        atleta.Birthdate = DateTime.Parse(reader["Birthdate"].ToString());
                        atleta.Gender = reader["Gender"].ToString();
                        atleta.Nation = reader["Nation"].ToString();
                        atleta.License = reader["License"].ToString();
                        atleta.ClubName = reader["ClubName"].ToString();
                        atleta.ClubShortName = reader["ClubShortName"].ToString();
                        atleta.ClubCode = (int) reader["ClubCode"];

                        atletas.Add(atleta);
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message + "\n\n" + ex.StackTrace);
                }
                finally
                {
                    reader.Close();
                }
            }

            return atletas;
        }

        /// <summary>
        /// Adds a new athlete into the DB.
        /// NOTE: this function does not check if the athlete already exists before adding it.
        /// </summary>
        /// <param name="athlete"></param>
        /// <returns>0 if success, -1 if insert failed</returns>
        public int InsertAthlete(Athlete athlete)
        {
            string query = "INSERT INTO Athlete (FullName,Birthdate,Gender,Nation,License,ClubCode,ClubName,ClubShortName) VALUES (@fullName,@birthdate,@gender,@nation,@license,@clubCode,@clubName,@clubShortName)";
            List<Athlete> atletas = new List<Athlete>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@fullName", athlete.FullName);
                    command.Parameters.AddWithValue("@birthdate", athlete.Birthdate);
                    command.Parameters.AddWithValue("@gender", athlete.Gender);
                    command.Parameters.AddWithValue("@nation", athlete.Nation);
                    command.Parameters.AddWithValue("@license", athlete.License);
                    command.Parameters.AddWithValue("@clubCode", athlete.ClubCode);
                    command.Parameters.AddWithValue("@clubName", athlete.ClubName);
                    command.Parameters.AddWithValue("@clubShortName", athlete.ClubShortName);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                    {
                        Console.WriteLine("Error inserting data into Database!");
                        return -1;
                    }   
                }
            }

            return 0;
        }

        //TODO: update athlete (when already existed on BD due to Excel import but is lacking data, update it with the new data provided by XML)
        #endregion
    }
}
