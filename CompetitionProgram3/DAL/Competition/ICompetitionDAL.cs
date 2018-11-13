using CompetitionProgram3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetitionProgram3.DAL
{
    public interface ICompetitionDAL
    {
        /// <summary>
        /// Returns a list of all copmetitors
        /// </summary>
        /// <returns></returns>
        IList<Competition> GetAllCompetitions();

        /// <summary>
        /// Saves a new competitor to the system.
        /// </summary>
        /// <param name="newReview"></param>
        /// <returns></returns>
        int SaveCompetition(Competition newCompetitor);
    }
}
