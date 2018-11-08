using CompetitionProgram3.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CompetitionProgram3.DAL
{
    public class CompetitorRegistrationDAL : ICompetitorRegistrationDAL
    {
        private readonly string connectionString;

        public CompetitorRegistrationDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Returns a list of all competitors
        /// </summary>
        /// <returns></returns>
        public IList<CompetitorsModel> GetAllCompetitors()
        {
            List<CompetitorsModel> output = new List<CompetitorsModel>();

            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql = "SELECT * FROM competitors";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {
                        // Create a competitor
                        CompetitorsModel competitor = new CompetitorsModel
                        {
                            FirstName = Convert.ToString(reader["first_name"]),
                            LastName = Convert.ToString(reader["last_name"]),
                            BirthDate = Convert.ToDateTime(reader["birth_date"]),
                            Gender = Convert.ToString(reader["gender"]),
                            Weight = Convert.ToInt32(reader["weight"]),
                            BeltRank = Convert.ToString(reader["belt_rank"]),
                            NogiRank = Convert.ToString(reader["nogi_rank"]),
                            RegistrationDate = Convert.ToDateTime(reader["register_date"])
                        };

                        output.Add(competitor);
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
        public int SaveCompetitor(CompetitorsModel newCompetitor)
        {
            int saveCompetitor = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = "INSERT INTO competitors VALUES (@first_name,@last_name,@team_name,@birth_date,@gender,@weight,@belt_rank,@nogi_rank,@registration_date);";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@first_name", newCompetitor.FirstName);
                    cmd.Parameters.AddWithValue("@last_name", newCompetitor.LastName);
                    cmd.Parameters.AddWithValue("@team_name", newCompetitor.TeamName);
                    cmd.Parameters.AddWithValue("@birth_date", newCompetitor.BirthDate);
                    cmd.Parameters.AddWithValue("@gender", newCompetitor.Gender);
                    cmd.Parameters.AddWithValue("@weight", newCompetitor.Weight);
                    cmd.Parameters.AddWithValue("@belt_rank", newCompetitor.BeltRank);
                    cmd.Parameters.AddWithValue("@nogi_rank", newCompetitor.NogiRank);
                    cmd.Parameters.AddWithValue("@registration_date", newCompetitor.RegistrationDate);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return saveCompetitor;
        }
    }
}
