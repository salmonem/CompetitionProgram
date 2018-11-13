//using CompetitionProgram3.Models;
//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;

//namespace CompetitionProgram3.DAL
//{
//    public class CompetitionCompetitorsDAL : ICompetitionCompetitorsDAL
//    {
//        private readonly string connectionString;

//        public CompetitionCompetitorsDAL(string connectionString)
//        {
//            this.connectionString = connectionString;
//        }
//        public IList<CompetitionCompetitors> GetCompetitors(int id)
//        {

//            List<CompetitionCompetitors> output = new List<CompetitionCompetitors>();

//            try
//            {
//                // Create a new connection object
//                using (SqlConnection conn = new SqlConnection(connectionString))
//                {
//                    // Open the connection
//                    conn.Open();

//                    string sql = @"SELECT * 
//                                    FROM competitions_competitors cc, competitions a, competitors b
//                                    WHERE a.competition_id = cc.competition_id 
//                                    AND b.competitor_id = cc.competitor_id
//                                    AND a.competition_id = @competition_id
//                                    ORDER BY gender, belt_rank, nogi_rank, weight, first_name, team_name";
//                    SqlCommand cmd = new SqlCommand(sql, conn);
//                    cmd.Parameters.AddWithValue("@competition_id",id);
//                    // Execute the command
//                    SqlDataReader reader = cmd.ExecuteReader();

//                    // Loop through each row
//                    while (reader.Read())
//                    {
//                        // Create a competitor
//                        CompetitionCompetitors competitor = new CompetitionCompetitors
//                        {
//                            Id = Convert.ToInt32(reader["competition_id"]),
//                            FirstName = Convert.ToString(reader["first_name"]),
//                            LastName = Convert.ToString(reader["last_name"]),
//                            TeamName = Convert.ToString(reader["team_name"]),
//                            Gender = Convert.ToString(reader["gender"]),
//                            Weight = Convert.ToString(reader["weight"]),
//                            BeltRank = Convert.ToString(reader["belt_rank"]),
//                            NogiRank = Convert.ToString(reader["nogi_rank"])
//                        };

//                        output.Add(competitor);
//                    }
//                }
//            }
//            catch (SqlException ex)
//            {
//                throw;
//            }

//            return output;
//        }
//        public int SaveCompetitor(Competitors newCompetitor)
//        {
//            int saveCompetitor = 0;

//            try
//            {
//                using (SqlConnection conn = new SqlConnection(connectionString))
//                {
//                    conn.Open();

//                    string sql = "INSERT INTO competitors VALUES (@first_name,@last_name,@team_name,@birth_date,@gender,@weight,@belt_rank,@nogi_rank,@registration_date);";
//                    SqlCommand cmd = new SqlCommand(sql, conn);
//                    cmd.Parameters.AddWithValue("@first_name", newCompetitor.FirstName);
//                    cmd.Parameters.AddWithValue("@last_name", newCompetitor.LastName);
//                    cmd.Parameters.AddWithValue("@team_name", newCompetitor.TeamName);
//                    cmd.Parameters.AddWithValue("@birth_date", newCompetitor.BirthDate);
//                    cmd.Parameters.AddWithValue("@gender", newCompetitor.Gender);
//                    cmd.Parameters.AddWithValue("@weight", newCompetitor.Weight);
//                    cmd.Parameters.AddWithValue("@belt_rank", newCompetitor.BeltRank);
//                    cmd.Parameters.AddWithValue("@nogi_rank", newCompetitor.NogiRank);
//                    cmd.Parameters.AddWithValue("@registration_date", newCompetitor.RegistrationDate);
//                    cmd.ExecuteNonQuery();
//                }
//            }
//            catch (SqlException ex)
//            {
//                throw ex;
//            }
//            return saveCompetitor;
//        }
//    }
//}
