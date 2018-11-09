using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CompetitionProgram3.DAL;
using CompetitionProgram3.Models;
using System.Diagnostics;

namespace CompetitionProgram3.Controllers
{
    public class CompetitionController : Controller
    {
        private readonly ICompetitionDAL _dal;

        public CompetitionController()
        {
            _dal = new CompetitionDAL(@"Data Source=.\SQLEXPRESS;Initial Catalog=CompetitorRegistration;Integrated Security=True");
        }
        public IActionResult Index()
        {
            // Get all of the competitors
            var competition = _dal.GetAllCompetitions();

            // Return the Index view
            return View(competition);
        }

        // GET review/new
        /// <summary>
        /// Represents an empty new copmetitor action.
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult NewCompetition()
        {
            // Return the empty view
            return View("NewCompetition");
        }

        /// <summary>
        /// Represents a save review action.
        /// </summary>
        /// <param name="review"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewCompetition(CompetitionModel newCompetition)
        {
            CompetitionModel competition = new CompetitionModel();
            competition.Name = newCompetition.Name;
            competition.CompetitionDate = newCompetition.CompetitionDate;
            competition.StreetAddress = newCompetition.StreetAddress;
            competition.City = newCompetition.City;
            competition.Zipcode = newCompetition.Zipcode;
            competition.State = newCompetition.State;
            competition.CountryCode = newCompetition.CountryCode;
            competition.CreationDate = DateTime.Now;
            // Save the Review
            _dal.SaveCompetition(competition);

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
