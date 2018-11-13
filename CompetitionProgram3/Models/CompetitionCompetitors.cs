using System;
using System.ComponentModel.DataAnnotations;

namespace CompetitionProgram3.Models
{
    public class CompetitionCompetitors
    {
        [Key]
        public int Id { get; set; }
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
    }
}
