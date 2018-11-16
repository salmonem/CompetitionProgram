using System;
using Microsoft.AspNetCore.Mvc;
using CompetitionProgram3.DAL;
using CompetitionProgram3.Models;
using System.Diagnostics;
using System.Collections.Generic;

namespace CompetitionProgram3.Controllers
{
    public class CompetitorController : Controller
    {
        private readonly ICompetitorDAL _dal;

        public CompetitorController(ICompetitorDAL competitorDal)
        {
            _dal = competitorDal;
        }
        public IActionResult Index(DisplayCompetitorsViewModel model, int id)
        {
            // Get all of the competitors
            IList<Competitors> competitors = _dal.GetCompetitors(id);

            model.Competitors = competitors;
            // Return the Index view
            return View(model);
        }

        public IActionResult GetCompetitors(DisplayCompetitorsViewModel model, int id)
        {
            // Get all of the competitors
            IList<Competitors> competitors = _dal.GetCompetitors(id);

            model.Competitors = competitors;
            // Return the Index view
            return View(model);
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
            return View();
        }

        /// <summary>
        /// Represents a save review action.
        /// </summary>
        /// <param name="review"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewCompetitor(Competitors newCompetitor, int id)
        {
            Competitors competitor = new Competitors();
            competitor.FirstName = newCompetitor.FirstName;
            competitor.LastName = newCompetitor.LastName;
            competitor.TeamName = newCompetitor.TeamName;
            competitor.BirthDate = newCompetitor.BirthDate;
            competitor.Gender = newCompetitor.Gender;
            competitor.Weight = newCompetitor.Weight;
            competitor.BeltRank = newCompetitor.BeltRank;
            competitor.NogiRank = newCompetitor.NogiRank;
            competitor.RegistrationDate = DateTime.Now;
            competitor.Id = newCompetitor.Id;
            // Save the Review
            _dal.SaveCompetitor(competitor, id);

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
