using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CompetitionProgram3.DAL;
using CompetitionProgram3.Models;
using System.Diagnostics;

namespace CompetitionProgram.Controllers
{
    public class CompetitorRegistrationController : Controller
    {
        ICompetitorRegistrationDAL _dal = new CompetitorRegistrationDAL(@"Data Source=.\SQLEXPRESS;Initial Catalog=CompetitorRegistration;Integrated Security=True");

        public IActionResult Index()
        {
            // Get all of the cities
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
