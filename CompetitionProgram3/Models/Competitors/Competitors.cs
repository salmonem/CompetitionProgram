using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CompetitionProgram3.Models
{
    public class Competitors
    {
        [Key]
        public int CompetitorId { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TeamName { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Weight { get; set; }
        public string BeltRank { get; set; }
        public string NogiRank { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int CompetitionId { get; set; }

        public Dictionary<(string, string, string, string), (string, string, string)> CompetitorDictionary = new Dictionary<(string, string, string, string), (string, string, string)>();

        public static List<SelectListItem> GenderChoice = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Male", Value = "Male" },
            new SelectListItem() { Text = "Female", Value = "Female" }
        };

        public static List<SelectListItem> BeltRankChoice = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "White", Value = "White" },
            new SelectListItem() { Text = "Blue", Value = "Blue" },
            new SelectListItem() { Text = "Purple", Value = "Purple" },
            new SelectListItem() { Text = "Brown", Value = "Brown" },
            new SelectListItem() { Text = "Black", Value = "Black" },
        };

        public static List<SelectListItem> WeightChoice = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Light-Feather", Value = "Light-Feather" },
            new SelectListItem() { Text = "Feather", Value = "Feather" },
            new SelectListItem() { Text = "Light", Value = "Light" },
            new SelectListItem() { Text = "Middle", Value = "Middle" },
            new SelectListItem() { Text = "Medium-Heavy", Value = "Medium-Heavy"},
            new SelectListItem() { Text = "Heavy", Value = "Heavy" },
            new SelectListItem() { Text = "Super-Heavy", Value = "Super-Heavy" },
        };

        public static List<SelectListItem> NogiExpChoice = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Beginner", Value = "Beginner" },
            new SelectListItem() { Text = "Intermediate", Value = "Indtermediate" },
            new SelectListItem() { Text = "Expert", Value = "Expert" }
        };

        public static List<SelectListItem> CompetitionChoice = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Columbus", Value = "1" },
            new SelectListItem() { Text = "Cleveland", Value = "2" }
        };

        //do this in the controller to generate a list from the table
        //ViewBag.planetList = CompetitionChoice; return View(); 
        //put this in the view to pull from the above list ^^^
        //ViewData["Title"] = "Alien Weight"; List<SelectListItem> planetList = ViewBag.planetList as List<SelectListItem>; 
    }
}
