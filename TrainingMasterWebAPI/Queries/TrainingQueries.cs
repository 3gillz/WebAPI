using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        public bool AddTrainings(string userId, string trainings, int TPID)
        {
            var trainer = (from x in db.trainer
                           where x.ID == userId
                           select x).FirstOrDefault();
            var trainingProgram = (from x in db.trainingProgram
                                   where x.TPID == TPID
                                   select x).FirstOrDefault();
            if(trainer.TRID != trainingProgram.trainer_TRID)
            {
                return false;
            }
            try
            {
                List<int> TIDList = new List<int>();
                var trainingArray = JsonConvert.DeserializeObject<List<TrainingDTO>>(trainings);
                foreach (TrainingDTO x in trainingArray)
                {
                    var t = new training
                    {
                        exercise_EID = x.exercise_EID,
                        numberOfSets = x.numberOfSets == null ? null : x.numberOfSets,
                        numberOfReps = x.numberOfReps == null ? null : x.numberOfReps,
                        durationMin = x.durationMin == null ? null : x.durationMin,
                        restBetweenMin = x.restBetweenMin == null ? null : x.restBetweenMin,
                        sunday = x.sunday,
                        monday = x.monday, 
                        tuesday = x.tuesday,
                        wednesday = x.wednesday,
                        thursday = x.thursday,
                        friday = x.friday,
                        saturday = x.saturday,
                        className = x.className,
                        timeOfDay = x.timeOfDay
                    };
                    db.training.Add(t);
                    db.SaveChanges();
                    TIDList.Add(t.TID);
                }
                foreach(int x in TIDList)
                {
                    var tpt = new trainingProgramTraining
                    {
                        trainingProgram_TPID = TPID,
                        training_TID = x
                    };
                    db.trainingProgramTraining.Add(tpt);
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<TrainingDTO> GetTrainings(int TPID, string userId)
        {
            List<TrainingDTO> trainingList = new List<TrainingDTO>();
            var trainer = (from x in db.trainer
                           where x.ID == userId
                           select x).FirstOrDefault();
            var tp = (from x in db.trainingProgramTraining
                      where x.trainingProgram_TPID == TPID && x.trainingProgram.trainer_TRID == trainer.TRID
                      select x);
            foreach(trainingProgramTraining x in tp)
            {
                var training = (from t in db.training
                                where t.TID == x.training_TID
                                select new TrainingDTO
                                {
                                    TID = t.TID,
                                    className = t.className,
                                    numberOfSets = t.numberOfSets,
                                    numberOfReps = t.numberOfReps,
                                    exercise_EID = t.exercise_EID,
                                    durationMin = t.durationMin, 
                                    restBetweenMin = t.restBetweenMin,
                                    sunday = t.sunday,
                                    monday = t.monday,
                                    tuesday = t.tuesday,
                                    wednesday = t.wednesday,
                                    thursday = t.thursday,
                                    friday = t.friday,
                                    saturday = t.saturday,
                                    timeOfDay = t.timeOfDay
                                }).FirstOrDefault();
                var name = GetExerciseName(training.exercise_EID);
                training.name = name;
                trainingList.Add(training);
            }
            return trainingList;
        }

        public string GetExerciseName(int EID)
        {
            var x = (from t in db.exercise
                        where t.EID == EID
                        select t).SingleOrDefault();
            return x.name;
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

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
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
                         restBetweenMin = x.restBetweenMin
                     });
            return t;
        }

    }
}