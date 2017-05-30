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

        public IEnumerable<TrainingProgramDTO> GetTrainingProgramByTPID(int TPID)
        {
            var tp = (from x in db.trainingProgram
                      where x.TPID == TPID
                      select new TrainingProgramDTO
                      {
                          TPID = x.TPID,
                          name = x.name,
                          trainer_TRID = x.trainer_TRID,
                          difficulty = x.difficulty
                      });
            return tp;
        }

        public IEnumerable<TrainingProgramDTO> GetTrainingProgramByTRID(string userId)
        {
            var trainer = (from x in db.trainer
                           where x.ID == userId
                           select x).FirstOrDefault();

            var tp = (from x in db.trainingProgram
                      where x.trainer_TRID == trainer.TRID
                      select new TrainingProgramDTO
                      {
                          TPID = x.TPID,
                          name = x.name,
                          trainer_TRID = x.trainer_TRID,
                          difficulty = x.difficulty
                      });
            return tp;
        }

        public IEnumerable<TrainingProgramDTO> GetAllTrainingPrograms()
        {
            var tp = (from x in db.trainingProgram
                      select new TrainingProgramDTO
                      {
                          TPID = x.TPID,
                          name = x.name,
                          trainer_TRID = x.trainer_TRID,
                          difficulty = x.difficulty
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
                    name = x.name,
                    trainer_TRID = x.trainer_TRID,
                    difficulty = x.difficulty
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
                tp.name = x.name;
                tp.trainer_TRID = x.trainer_TRID;
                tp.difficulty = x.difficulty;

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