using System;
using System.Collections.Generic;
using System.Linq;
using TrainingMasterWebAPI.Models.DTO;
using TrainingMasterWebAPI.Models.EF;

namespace TrainingMasterWebAPI.Queries
{
    public class TrainingProgramQueries
    {
        private TMEntities db;

        public TrainingProgramQueries()
        {
            db = new TMEntities();
        }

        public TrainingProgramDTO GetTrainingProgramById(int id)
        {
            var tp = (from x in db.trainingProgram
                      where id == x.TPID
                      select new TrainingProgramDTO
                      {
                          TPID = x.TPID,
                          training_TID = x.training_TID,
                          trainer_TRID = x.trainer_TRID
                      }).SingleOrDefault();
            return tp;
        }

        public IEnumerable<TrainingProgramDTO> GetAllTrainingPrograms()
        {
            var tp = (from x in db.trainingProgram
                      select new TrainingProgramDTO
                      {
                          TPID = x.TPID,
                          training_TID = x.training_TID,
                          trainer_TRID = x.trainer_TRID
                      });
            return tp;
        }

        public bool AddTrainingProgram(TrainingProgramDTO x)
        {
            try
            {
                var tp = new trainingProgram
                {
                    TPID = x.TPID,
                    training_TID = x.training_TID,
                    trainer_TRID = x.trainer_TRID
                };

                db.trainingProgram.Add(tp);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateTrainingProgram(TrainingProgramDTO x)
        {
            try
            {
                var tp = (from y in db.trainingProgram
                          where x.TPID == y.TPID
                          select y).SingleOrDefault();

                tp.TPID = x.TPID;
                tp.training_TID = x.training_TID;
                tp.trainer_TRID = x.trainer_TRID;

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