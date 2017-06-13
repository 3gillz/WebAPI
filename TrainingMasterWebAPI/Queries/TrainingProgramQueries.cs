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

        public TrainingProgramDTO GetTrainingProgramByTPID(int TPID, string userId)
        {
            var trainer = (from x in db.trainer
                           where x.ID == userId
                           select x).FirstOrDefault();
            var tp = (from x in db.trainingProgram
                      where x.TPID == TPID && x.trainer_TRID == trainer.TRID
                      select new TrainingProgramDTO
                      {
                          TPID = x.TPID,
                          name = x.name,
                          trainer_TRID = x.trainer_TRID,
                          difficulty = x.difficulty
                      }).FirstOrDefault();
            return tp;
        }

        public IEnumerable<TrainingProgramDTO> GetTrainingProgramsByTRID(string userId)
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

        public int AddTrainingProgram(string UserId, TrainingProgramDTO trainingProgram)
        {
            var trainer = (from x in db.trainer
                           where x.ID == UserId
                           select x).FirstOrDefault();
            var tp = new trainingProgram
            {
                name = trainingProgram.name,
                trainer_TRID = trainer.TRID,
                difficulty = trainingProgram.difficulty
            };

            db.trainingProgram.Add(tp);
            db.SaveChanges();
            return tp.TPID;
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