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
        public IActionResult Index(int id)
        {
            Dictionary<(string, string, string, string), List<string[]>> competitors = _dal.GetCompetitors(id);

            return View(competitors);
        }

        public IActionResult GetCompetitors(Competitors model, int id)
        {
            Dictionary<(string, string, string, string), List<string[]>> competitors = _dal.GetCompetitors(id);

            model.CompetitorDictionary = competitors;

            return View(model);
        }

        [HttpGet]
        public IActionResult NewCompetitor()
        {
            Competitors competitor = new Competitors();

            return View(competitor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewCompetitor(Competitors newCompetitor)
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
            competitor.CompetitionId = newCompetitor.CompetitionId;

            _dal.SaveCompetitor(competitor);

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
