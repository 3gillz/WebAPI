using System;
using System.Collections.Generic;
using System.Linq;
using TrainingMasterWebAPI.Models.DTO;
using TrainingMasterWebAPI.Models.EF;

namespace TrainingMasterWebAPI.Queries
{
    public class TrainingQueries
    {
        private TMEntities db;

        public TrainingQueries()
        {
            db = new TMEntities();
        }

        public TrainingDTO GetTrainingById(int id)
        {
            var t = (from x in db.training
                     where x.TID == id
                     select new TrainingDTO
                     {
                         TID = x.TID,
                         numberOfSets = x.numberOfSets,
                         numberOfReps = x.numberOfReps,
                         exercise_EID = x.exercise_EID,
                         durationMin = x.durationMin,
                         restBetweenMin = x.restBetweenMin,
                         weekday = x.weekday,
                         timeOfday = x.timeOfday
                     }).SingleOrDefault();
            return t;
        }

        public IEnumerable<TrainingDTO> GetAllTrainings()
        {
            var t = (from x in db.training
                     select new TrainingDTO
                     {
                         TID = x.TID,
                         numberOfSets = x.numberOfSets,
                         numberOfReps = x.numberOfReps,
                         exercise_EID = x.exercise_EID,
                         durationMin = x.durationMin,
                         restBetweenMin = x.restBetweenMin,
                         weekday = x.weekday,
                         timeOfday = x.timeOfday
                     });
            return t;
        }

        public bool AddTraining(TrainingDTO x)
        {
            try
            {
                var t = new training
                {
                    TID = x.TID,
                    numberOfSets = x.numberOfSets,
                    numberOfReps = x.numberOfReps,
                    exercise_EID = x.exercise_EID,
                    durationMin = x.durationMin,
                    restBetweenMin = x.restBetweenMin,
                    weekday = x.weekday,
                    timeOfday = x.timeOfday
                };

                db.training.Add(t);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateTraining(TrainingDTO x)
        {
            try
            {
                var t = (from y in db.training
                         where x.TID == y.TID
                         select y).SingleOrDefault();

                t.TID = x.TID;
                t.numberOfSets = x.numberOfSets;
                t.numberOfReps = x.numberOfReps;
                t.exercise_EID = x.exercise_EID;
                t.durationMin = x.durationMin;
                t.restBetweenMin = x.restBetweenMin;
                t.weekday = x.weekday;
                t.timeOfday = x.timeOfday;

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