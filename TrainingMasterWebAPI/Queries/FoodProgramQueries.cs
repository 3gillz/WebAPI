﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainingMasterWebAPI.Models.DTO;
using TrainingMasterWebAPI.Models.EF;

namespace TrainingMasterWebAPI.Queries
{
	public class FoodProgramQueries
    {
        private TMEntities db;
        public FoodProgramQueries()
        {
            db = new TMEntities();
        }

        public IEnumerable<FoodProgramDTO> GetAllFoodPrograms()
        {
            var f = (from x in db.foodProgram
                            select new FoodProgramDTO
                            {
                                FPMID = x.FPMID,
                                name = x.name,
                                trainer_TRID = x.trainer_TRID
                            });
            return f;
        }

        public FoodProgramDTO GetFoodProgramById(int id)
        {
            var f = (from x in db.foodProgram
                            where x.FPMID == id
                            select new FoodProgramDTO
                            {
                                FPMID = x.FPMID,
                                name = x.name,
                                trainer_TRID = x.trainer_TRID
                            }).SingleOrDefault();
            return f;
        }

        public int AddFoodProgram(string name, string userId)
        {
            trainer t = db.trainer.FirstOrDefault(x => x.ID == userId);

            var f = new foodProgram
            {
                name = name,
                trainer_TRID = t.TRID
            };
            db.foodProgram.Add(f);
            db.SaveChanges();

            return f.FPMID;
        }

        public bool UpdateFoodProgram(FoodProgramDTO FoodProgram)
        {
            try
            {
                var f = (from x in db.foodProgram
                         where x.FPMID == FoodProgram.FPMID
                         select x).SingleOrDefault();

                f.FPMID = FoodProgram.FPMID;
                f.name = FoodProgram.name;
                f.trainer_TRID = FoodProgram.trainer_TRID;

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<FoodProgramDTO> GetAllFoodProgramByTRID(string UserId)
        {
            var trainer = (from x in db.trainer
                           where x.ID == UserId
                           select x).FirstOrDefault();

            var fp = (from x in db.foodProgram
                      where x.trainer_TRID == trainer.TRID
                      select new FoodProgramDTO
                      {
                          FPMID = x.FPMID,
                          name = x.name,
                          trainer_TRID = x.trainer_TRID
                      });

            return fp;
        }

        public FoodProgramDTO GetSingleFoodProgramByTRID(string UserId)
        {
            var trainer = (from x in db.trainer
                           where x.ID == UserId
                           select x).FirstOrDefault();

            var fp = (from x in db.foodProgram
                      where x.trainer_TRID == trainer.TRID
                      select new FoodProgramDTO
                      {
                          FPMID = x.FPMID,
                          name = x.name,
                          trainer_TRID = x.trainer_TRID
                      }).FirstOrDefault();

            return fp;
        }

    }
}