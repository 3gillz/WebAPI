using System;
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
                                foodPortion_FPID = x.foodPortion_FPID,
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
                                foodPortion_FPID = x.foodPortion_FPID,
                                trainer_TRID = x.trainer_TRID
                            }).SingleOrDefault();
            return f;
        }

        public bool AddFoodProgram(FoodProgramDTO FoodProgram)
        {
            try
            {
                var f = new foodProgram
                {
                    FPMID = FoodProgram.FPMID,
                    foodPortion_FPID = FoodProgram.foodPortion_FPID,
                    trainer_TRID = FoodProgram.trainer_TRID
                };
                db.foodProgram.Add(f);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateFoodProgram(FoodProgramDTO FoodProgram)
        {
            try
            {
                var f = (from x in db.foodProgram
                         where x.FPMID == FoodProgram.FPMID
                         select x).SingleOrDefault();

                f.FPMID = FoodProgram.FPMID;
                f.foodPortion_FPID = FoodProgram.foodPortion_FPID;
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
                          foodPortion_FPID = x.foodPortion_FPID,
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
                          foodPortion_FPID = x.foodPortion_FPID,
                          trainer_TRID = x.trainer_TRID
                      }).FirstOrDefault();

            return fp;
        }

    }
}