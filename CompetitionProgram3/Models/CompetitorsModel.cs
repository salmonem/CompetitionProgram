using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetitionProgram3.Models
{
    public class CompetitorsModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TeamName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public int Weight { get; set; }
        public string BeltRank { get; set; }
        public string NogiRank { get; set; }
        public DateTime RegistrationDate { get; set; }


        public static List<SelectListItem> GenderChoice = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Male", Value = "Gender" },
            new SelectListItem() { Text = "Female", Value = "Gender" }
        };
    }
}
