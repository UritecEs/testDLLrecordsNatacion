using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testDLLrecordsNatacion.Model.Entities
{
    public class Result
    {
        public int Id;
        public int SplitDistance { get; set; }
        public DateTime SwimTime { get; set; } //correct datatype?
        public int Points { get; set; }
        public int IsWaScoring { get; set; }
        public DateTime EntryTime { get; set; }
        public string Comment { get; set; }
        public int EventId { get; set; }
        public int AthleteId { get; set; }

        public Event Event { get; set; }
        public Athlete Athlete { get; set; }
    }
}
