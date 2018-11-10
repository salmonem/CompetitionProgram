using CompetitionProgram3.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CompetitionProgram3.DAL
{
    public class CompetitionDAL : ICompetitionDAL
    {
        private readonly string connectionString;

        public CompetitionDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Returns a list of all competitors
        /// </summary>
        /// <returns></returns>
        public IList<CompetitionModel> GetAllCompetitions()
        {
            List<CompetitionModel> output = new List<CompetitionModel>();

            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql = "SELECT * FROM competitions ORDER BY date ASC";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {
                        // Create a competitor
                        CompetitionModel competition = new CompetitionModel
                        {
                            Name = Convert.ToString(reader["name"]),
                            CompetitionDate = Convert.ToString(reader["date"]),
                            StreetAddress = Convert.ToString(reader["streetaddress"]),
                            City = Convert.ToString(reader["city"]),
                            Zipcode = Convert.ToString(reader["zipcode"]),
                            State = Convert.ToString(reader["state"]),
                            CountryCode = Convert.ToString(reader["countrycode"]),
                            CreationDate = Convert.ToDateTime(reader["creation_date"])
                        };

                        output.Add(competition);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return output;
        }

        /// <summary>
        /// Saves a new review to the system.
        /// </summary>
        /// <param name="newReview"></param>
        /// <returns></returns>
        public int SaveCompetition(CompetitionModel newCompetition)
        {
            int saveCompetition = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = "INSERT INTO competitions VALUES (@name,@date,@streetaddress,@city,@zipcode,@state,@countrycode,@creation_date);";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@name", newCompetition.Name);
                    cmd.Parameters.AddWithValue("@date", newCompetition.CompetitionDate);
                    cmd.Parameters.AddWithValue("@streetaddress", newCompetition.StreetAddress);
                    cmd.Parameters.AddWithValue("@city", newCompetition.City);
                    cmd.Parameters.AddWithValue("@zipcode", newCompetition.Zipcode);
                    cmd.Parameters.AddWithValue("@state", newCompetition.State);
                    cmd.Parameters.AddWithValue("@countrycode", newCompetition.CountryCode);
                    cmd.Parameters.AddWithValue("@creation_date", newCompetition.CreationDate);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return saveCompetition;
        }
    }
}
