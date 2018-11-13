using System;
using System.ComponentModel.DataAnnotations;

namespace CompetitionProgram3.Models
{
    public class Competition
    {
        //[Key]
        public int Id { get; set; }
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
