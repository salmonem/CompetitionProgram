using CompetitionProgram3.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CompetitionProgram3.DAL
{
    public class CompetitorDAL : ICompetitorDAL
    {
        private readonly string connectionString;

        public CompetitorDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public IList<Competitors> GetCompetitors(int id)
        {

            List<Competitors> output = new List<Competitors>();

            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql = @"SELECT * 
                                    FROM competitions_competitors cc, competitions a, competitors b
                                    WHERE a.competition_id = cc.competition_id 
                                    AND b.competitor_id = cc.competitor_id
                                    AND a.competition_id = @competition_id
                                    ORDER BY gender, belt_rank, nogi_rank, weight, first_name, team_name";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@competition_id", id);
                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {
                        // Create a competitor
                        Competitors competitor = new Competitors
                        {
                            //Id = Convert.ToInt32(reader["competition_id"]),
                            FirstName = Convert.ToString(reader["first_name"]),
                            LastName = Convert.ToString(reader["last_name"]),
                            TeamName = Convert.ToString(reader["team_name"]),
                            Gender = Convert.ToString(reader["gender"]),
                            Weight = Convert.ToString(reader["weight"]),
                            BeltRank = Convert.ToString(reader["belt_rank"]),
                            NogiRank = Convert.ToString(reader["nogi_rank"])
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
        public int SaveCompetitor(Competitors newCompetitor)
        {
            int saveCompetitor = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = " DECLARE @competitionid int;" +
                                   "INSERT INTO competitors (first_name, last_name, team_name, birth_date," +
                                    "gender, weight, belt_rank, nogi_rank, register_date) " +
                                    "SELECT @firstname, @lastname, @teamname, @birthdate, " +
                                    "@gender, @weight, @beltrank, @nogirank, @registerdate " +
                                    "FROM competitors a " +
                                    "JOIN competitions_competitors cc ON a.competitor_id = cc.competitor_id " +
                                    "JOIN competitions b ON cc.competition_id = b.competition_id;" +
                                    "SELECT @competitionid = scope_identity();";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@firstname", newCompetitor.FirstName);
                    cmd.Parameters.AddWithValue("@lastname", newCompetitor.LastName);
                    cmd.Parameters.AddWithValue("@teamname", newCompetitor.TeamName);
                    cmd.Parameters.AddWithValue("@birthdate", newCompetitor.BirthDate);
                    cmd.Parameters.AddWithValue("@gender", newCompetitor.Gender);
                    cmd.Parameters.AddWithValue("@weight", newCompetitor.Weight);
                    cmd.Parameters.AddWithValue("@beltrank", newCompetitor.BeltRank);
                    cmd.Parameters.AddWithValue("@nogirank", newCompetitor.NogiRank);
                    cmd.Parameters.AddWithValue("@registerdate", newCompetitor.RegistrationDate);
                    //cmd.Parameters.AddWithValue("@competitionid", newCompetitor.Id);
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
