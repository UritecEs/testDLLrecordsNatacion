using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testDLLrecordsNatacion.Model.Entities
{
    public class Athlete
    {
        public int Id;
        public string FullName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public string Nation { get; set; }
        public string License { get; set; }
        public int ClubCode { get; set; }
        public string ClubName { get; set; }
        public string ClubShortName { get; set; }

        //public int IsHandicap { get; set; }
        
    }
}
