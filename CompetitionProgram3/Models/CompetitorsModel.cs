using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompetitionProgram3.Models
{
    public class CompetitorsModel
    {
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

    }
}
