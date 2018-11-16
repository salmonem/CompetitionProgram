using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CompetitionProgram3.DAL;
using CompetitionProgram3.Models;
using System.Diagnostics;

namespace CompetitionProgram3.Controllers
{
    public class CompetitionController : Controller
    {
        private readonly ICompetitionDAL _dal;

        public CompetitionController(ICompetitionDAL dal)
        {
            _dal = dal;
        }

        public IActionResult Index(DisplayCompetitionsViewModel model)
        {
            // Get all of the competitors
            IList<Competition> competitions = _dal.GetAllCompetitions();

            model.Competitions = competitions;
            // Return the Index view
            return View(model);
        }

        public IActionResult Detail(int id)
        {
            Competition competition = _dal.GetCompetition(id);

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
            return View();
        }

        /// <summary>
        /// Represents a save competition action.
        /// </summary>
        /// <param name="review"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewCompetition(Competition newCompetition)
        {
            Competition competition = new Competition();
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
