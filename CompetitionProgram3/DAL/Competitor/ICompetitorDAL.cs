using CompetitionProgram3.Models;
using System.Collections.Generic;

namespace CompetitionProgram3.DAL
{
    public interface ICompetitorDAL
    {
        /// <summary> 
        /// Returns a list of all copmetitors
        /// </summary>
        /// <returns></returns>
        IList<Competitors> GetCompetitors(int id);

        /// <summary>
        /// Saves a new competitor to the system.
        /// </summary>
        /// <param name="newReview"></param>
        /// <returns></returns>
        int SaveCompetitor(Competitors newCompetitor, int id);
    }
}
