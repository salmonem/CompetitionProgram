using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetitionProgram3.Models
{
    public class DisplayCompetitorsViewModel
    {
        public Dictionary<(string, string, string, string), List<(string, string, string)>> Competitors { get; set; }
    }
}
