using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainingMasterWebAPI.Models.DTO;
using TrainingMasterWebAPI.Models.EF;

namespace TrainingMasterWebAPI.Queries
{
    public class FoodProgramPortionQueries
    {
        private TMEntities db;
        public FoodProgramPortionQueries()
        {
            db = new TMEntities();
        }

        public FoodProgramPortionDTO GetFoodProgramPortionByFPMID(int FPMID)
        {
            var fpp = (from x in db.foodProgramPortion
                     where x.foodProgram_FPMID == FPMID
                     select new FoodProgramPortionDTO
                     {
                         foodProgram_FPMID = x.foodProgram_FPMID,
                         foodPortion_FPID = x.foodPortion_FPID,
                         weekDay = x.weekday,
                         timeOfDay = x.timeOfDay

                     }).SingleOrDefault();

            return fpp;
        }

        public bool AddFoodProgramPortion(FoodProgramPortionDTO FoodProgramPortion)
        {
            try
            {
                var fpp = new foodProgramPortion
                {
                    foodProgram_FPMID = FoodProgramPortion.foodProgram_FPMID,
                    foodPortion_FPID = FoodProgramPortion.foodPortion_FPID,
                    weekday = FoodProgramPortion.weekDay,
                    timeOfDay = FoodProgramPortion.timeOfDay
                };
                db.foodProgramPortion.Add(fpp);
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