using CompetitionProgram3.Models;
using System.Collections.Generic;

namespace CompetitionProgram3.DAL
{
    public interface ICompetitorDAL
    {
        Dictionary<(string,string,string,string),(string,string,string)> GetCompetitors(int id);

        int SaveCompetitor(Competitors newCompetitor);

        int JoinCompetitionCompetition(Competitors competitor);
    }
}