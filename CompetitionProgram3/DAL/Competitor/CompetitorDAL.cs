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

                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open();

                    string sql = @"SELECT * 
                                    FROM competitions_competitors cc, competitions a, competitors b
                                    WHERE a.competition_id = cc.competition_id 
                                    AND b.competitor_id = cc.competitor_id
                                    AND a.competition_id = @competition_id
                                    ORDER BY gender, belt_rank, nogi_rank, weight, first_name, team_name";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@competition_id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Competitors competitor = new Competitors
                        {
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
        public int SaveCompetitor(Competitors newCompetitor, int id)
        {
            int saveCompetitor = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = "BEGIN " +
                                 "INSERT INTO competitors VALUES (@first_name,@last_name,@team_name," +
                                 "@birth_date,@gender, @weight,@belt_rank,@nogi_rank,@register_date) " +
                                 //"END " +
                                 //"BEGIN " +
                                 "SELECT competitor_id = scope_identity();" +
                                 "INSERT INTO competitions_competitors (competition_id,competitor_id) " +
                                 "VALUES(@competition_id, (SELECT competitor_id FROM competitors c WHERE c.first_name = '@first_name')) " +
                                 "END;";

                    //string sql = "BEGIN" +
                    //            " DECLARE @competitionid int;" +
                    //            "INSERT INTO competitors VALUES (@first_name,@last_name,@team_name," +
                    //             "@birth_date,@gender, @weight,@belt_rank,@nogi_rank,@register_date) " +
                    //            "JOIN competitions_competitors cc" +
                    //            "ON a.competitor_id = cc.competitor_id " +
                    //            "JOIN competition b ON cc.competition_id = b.competition_id;" +
                    //            "SELECT @competitionid = scope_identity();COMMIT; ";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@first_name", newCompetitor.FirstName);
                    cmd.Parameters.AddWithValue("@last_name", newCompetitor.LastName);
                    cmd.Parameters.AddWithValue("@team_name", newCompetitor.TeamName);
                    cmd.Parameters.AddWithValue("@birth_date", newCompetitor.BirthDate);
                    cmd.Parameters.AddWithValue("@gender", newCompetitor.Gender);
                    cmd.Parameters.AddWithValue("@weight", newCompetitor.Weight);
                    cmd.Parameters.AddWithValue("@belt_rank", newCompetitor.BeltRank);
                    cmd.Parameters.AddWithValue("@nogi_rank", newCompetitor.NogiRank);
                    cmd.Parameters.AddWithValue("@register_date", newCompetitor.RegistrationDate);
                    cmd.Parameters.AddWithValue("@competition_id", id);
                    cmd.ExecuteScalar();
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
