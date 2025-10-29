using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testDLLrecordsNatacion.Model.Entities
{
    public class Event
    {
        public int Id;
        public string MeetName { get; set; }
        public string Nation { get; set; }
        public string City { get; set; }
        public string Status { get; set; }
        public int PoolLength { get; set; }
        public int SessionNum { get; set; }
        public string SessionName { get; set; }
        public string GenderCategory { get; set; }
        public string EventRound { get; set; }
        public string EventCourse { get; set; }
        //public DateTime EventStartTime { get; set; }
        public int SwimDistance { get; set; }
        public string SwimStroke { get; set; }
        public string SwimRelayCount { get; set; }
        public int AgeMax { get; set; }
        public int AgeMin { get; set; }
        //public string Handicap { get; set; }
    }
}
