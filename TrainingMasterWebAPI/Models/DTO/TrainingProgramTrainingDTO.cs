using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingMasterWebAPI.Models.DTO
{
    public class TrainingProgramTrainingDTO
    {
        public int trainingProgram_TPID { get; set; }
        public int training_TID { get; set; }
        public short weekDay { get; set; }
        public short timeOfDay { get; set; }
    }
}