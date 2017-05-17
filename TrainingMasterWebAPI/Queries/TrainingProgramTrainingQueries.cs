using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainingMasterWebAPI.Models.EF;
using TrainingMasterWebAPI.Models.DTO;

namespace TrainingMasterWebAPI.Queries
{
    public class TrainingProgramTrainingQueries
    {
        private TMEntities db;

        public TrainingProgramTrainingQueries()
        {
            db = new TMEntities();
        }

        public IEnumerable<TrainingProgramTrainingDTO> GetTrainingProgramTrainingByTPID(int TPID)
        {
            var tpt = (from x in db.trainingProgramTraining
                      where x.trainingProgram_TPID == TPID
                      select new TrainingProgramTrainingDTO
                      {
                          trainingProgram_TPID = x.trainingProgram_TPID,
                          training_TID = x.training_TID,
                          weekDay = x.weekday,
                          timeOfDay = x.timeOfDay
                      });
            return tpt;
        }

        public bool AddTrainingProgramTraining(TrainingProgramTrainingDTO x)
        {
            try
            {
                var tpt = new trainingProgramTraining
                {
                    trainingProgram_TPID = x.trainingProgram_TPID,
                    training_TID = x.training_TID,
                    weekday = x.weekDay,
                    timeOfDay = x.timeOfDay
                };

                db.trainingProgramTraining.Add(tpt);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}