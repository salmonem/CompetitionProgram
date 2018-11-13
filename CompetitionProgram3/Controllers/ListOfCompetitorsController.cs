//using System;
//using System.Collections.Generic;
//using Microsoft.AspNetCore.Mvc;
//using CompetitionProgram3.DAL;
//using CompetitionProgram3.Models;
//using System.Diagnostics;

//namespace CompetitionProgram3.Controllers
//{
//    public class ListOfCompetitorsController : Controller
//    {
//        private readonly ICompetitionCompetitorsDAL _dal;

//        public ListOfCompetitorsController(ICompetitionCompetitorsDAL dal)
//        {
//            _dal = dal;
//        }

//        public IActionResult Index(CompetitionCompetitorsListViewModel model, int id)
//        {
//            // Get all of the competitors
//            IList<CompetitionCompetitors> competitors = _dal.GetCompetitors(id);

//            model.Competitors = competitors;
//            // Return the Index view
//            return View(model);
//        }

//    }
//}