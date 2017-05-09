using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingMasterWebAPI.Models.DTO
{
    public class TrainingDTO
    {
        public int TID { get; set; }
        public int? numberOfSets { get; set; }
        public int? numberOfReps { get; set; }
        public int? exercise_EID { get; set; }
        public int? durationMin { get; set; }
        public int? restBetweenMin { get; set; }
        public short weekday { get; set; }
        public DateTime? timeOfday { get; set; }
    }
}