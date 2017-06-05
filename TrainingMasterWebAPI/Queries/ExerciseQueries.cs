using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainingMasterWebAPI.Models.DTO;
using TrainingMasterWebAPI.Models.EF;

namespace TrainingMasterWebAPI.Queries
{
    public class ExerciseQueries
    {
        private TMEntities db;
        public ExerciseQueries()
        {
            db = new TMEntities();
        }

        public IEnumerable<ExerciseDTO> GetAllExercises()
        {
            var e = (from x in db.exercise
                            select new ExerciseDTO
                            {
                                EID = x.EID,
                                name = x.name,
                                description = x.description,
                                link = x.link,
                                type = x.type,
                                trainer_TRID = x.trainer_TRID
                            });
            return e;
        }

        public IEnumerable<ExerciseDTO> GetAllExercisesByTRID(string userId)
        {
            var trainer = (from x in db.trainer
                           where x.ID == userId
                           select x).FirstOrDefault();

            var e = (from x in db.exercise
                     where x.trainer_TRID == trainer.TRID || x.trainer_TRID == null
                     select new ExerciseDTO
                     {
                         EID = x.EID,
                         name = x.name,
                         description = x.description,
                         link = x.link,
                         type = x.type,
                         trainer_TRID = x.trainer_TRID,
                         madeBy = x.trainer_TRID == null ? "TrainingMaster" : trainer.name
                     });
            return e;
        }

        public ExerciseDTO GetExerciseByID(int id)
        {
            var exercise = (from x in db.exercise
                            where x.EID == id
                            select new ExerciseDTO
                            {
                                EID = x.EID,
                                name = x.name,
                                description = x.description,
                                link = x.link,
                                type = x.type

                            }).SingleOrDefault();
            return exercise;
        }

        public bool UpdateExercise(ExerciseDTO exercise)
        {
            try
            {
                var e = (from x in db.exercise
                         where exercise.EID == x.EID
                         select x).SingleOrDefault();

                e.name = exercise.name;
                e.description = exercise.description;
                e.link = exercise.link;
                e.type = exercise.type;

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateExerciseWithTRID(string userId,ExerciseDTO exercise)
        {
            try
            {
                var trainer = (from x in db.trainer
                               where x.ID == userId
                               select x).FirstOrDefault();

                var e = (from x in db.exercise
                         where exercise.EID == x.EID & trainer.TRID == x.trainer_TRID
                         select x).SingleOrDefault();

                e.name = exercise.name;
                e.description = exercise.description;
                e.link = exercise.link;
                e.type = exercise.type;

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AddExercise(ExerciseDTO exercise)
        {
            try
            {
                var e = new exercise
                {
                    EID = exercise.EID,
                    name = exercise.name,
                    description = exercise.description,
                    link = exercise.link,
                    type = exercise.type
                };

                db.exercise.Add(e);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool TrainerAddExercise(string userId, ExerciseDTO exercise)
        {
            var trainer = (from x in db.trainer
                           where x.ID == userId
                           select x).FirstOrDefault();
            try
            {
                var e = new exercise
                {
                    name = exercise.name,
                    description = exercise.description,
                    link = exercise.link,
                    type = exercise.type,
                    trainer_TRID = trainer.TRID 
                };

                db.exercise.Add(e);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        //TODO: Bæta við delete falli. ATH það þarf að bæta við TRID foreign key í töflu og DTO
    }
}