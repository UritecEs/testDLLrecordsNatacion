using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testDLLrecordsNatacion.Model.Entities
{
    public class Record: DbEntity
    {
        public int Id;
        public int Position { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string ageCategory { get; set; }
        //public int ResultId { get; set; }
        //public int AthleteId { get; set; }
        //public int EventId { get; set; }

        public Result Result { get; set; }
        //public Athlete Athlete { get; set; }
        //public Event Event { get; set; }

        public Record GetRecord(int id) {
            //TODO
            return null;
        }

    }
}
