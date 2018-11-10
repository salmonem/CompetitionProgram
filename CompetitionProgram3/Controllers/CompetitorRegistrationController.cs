using System;
using Microsoft.AspNetCore.Mvc;
using CompetitionProgram3.DAL;
using CompetitionProgram3.Models;
using System.Diagnostics;

namespace CompetitionProgram3.Controllers
{
    public class CompetitorRegistrationController : Controller
    {
        private readonly ICompetitorRegistrationDAL _dal;

        public CompetitorRegistrationController(ICompetitorRegistrationDAL competitorDal)
        {
            _dal = competitorDal;
        }
        public IActionResult Index()
        {
            // Get all of the competitors
            var competitors = _dal.GetAllCompetitors();

            // Return the Index view
            return View(competitors);
        }

        // GET review/new
        /// <summary>
        /// Represents an empty new copmetitor action.
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult NewCompetitor()
        {
            // Return the empty view
            return View("NewCompetitor");
        }

        /// <summary>
        /// Represents a save review action.
        /// </summary>
        /// <param name="review"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewCompetitor(CompetitorsModel newCompetitor)
        {
            CompetitorsModel competitor = new CompetitorsModel();
            competitor.FirstName = newCompetitor.FirstName;
            competitor.LastName = newCompetitor.LastName;
            competitor.TeamName = newCompetitor.TeamName;
            competitor.BirthDate = newCompetitor.BirthDate;
            competitor.Gender = newCompetitor.Gender;
            competitor.Weight = newCompetitor.Weight;
            competitor.BeltRank = newCompetitor.BeltRank;
            competitor.NogiRank = newCompetitor.NogiRank;
            competitor.RegistrationDate = DateTime.Now;
            competitor.CompetitionId = newCompetitor.CompetitionId;
            // Save the Review
            _dal.SaveCompetitor(competitor);

            // Redirect the user to Review/Index Action
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
