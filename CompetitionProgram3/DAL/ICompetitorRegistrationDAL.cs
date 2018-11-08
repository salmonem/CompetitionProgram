using CompetitionProgram3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetitionProgram3.DAL
{
    public interface ICompetitorRegistrationDAL
    {
        /// <summary>
        /// Returns a list of all reviews
        /// </summary>
        /// <returns></returns>
        IList<CompetitorsModel> GetAllCompetitors();

        /// <summary>
        /// Saves a new review to the system.
        /// </summary>
        /// <param name="newReview"></param>
        /// <returns></returns>
        int SaveCompetitor(CompetitorsModel newCompetitor);
    }
}
