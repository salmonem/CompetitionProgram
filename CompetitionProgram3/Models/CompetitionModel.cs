using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompetitionProgram3.Models
{
    public class CompetitionModel
    {
        //public int CompetitionId { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public string CompetitionDate { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string State { get; set; }
        public string CountryCode { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
