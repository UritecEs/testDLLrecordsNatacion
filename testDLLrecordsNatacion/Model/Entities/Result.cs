using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testDLLrecordsNatacion.Model.Entities
{
    public class Result : DbEntity
    {
        public int Id;
        public int SplitDistance { get; set; }
        public string SwimTime { get; set; } //save as string but process as DateTime formatted
        public int Points { get; set; } //default -1 (if split)
        public int IsWaScoring { get; set; }
        public string EntryTime { get; set; }//splits dont have entry time //save as string but process as DateTime formatted
        public string Comment { get; set; }
        public int AgeGroupMaxAge { get; set; }
        public int AgeGroupMinAge { get; set; }
        public int EventId { get; set; }
        public int AthleteId { get; set; }

        public Event Event; //{ get; set; }
        public Athlete Athlete; //{ get; set; }

        public Result GetResultWithEventAndAthlete()
        {
            //TODO
            return null;
        }
    }
}
