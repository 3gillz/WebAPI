using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainingMasterWebAPI.Models.DTO;
using TrainingMasterWebAPI.Models.EF;

namespace TrainingMasterWebAPI.Queries
{
    public class FoodPortionQueries
    {
        private TMEntities db;
        public FoodPortionQueries()
        {
            db = new TMEntities();
        }

        public IEnumerable<FoodPortionDTO> GetAllFoodPortions()
        {
            var f = (from x in db.foodPortion
                     select new FoodPortionDTO
                     {
                         FPID = x.FPID,
                         quantity = x.quantity,
                         foodItem_FIID = x.foodItem_FIID

                     });
            return f;
        }

        public FoodPortionDTO GetFoodPortionByID(int id)
        {
            var f = (from x in db.foodPortion
                     where x.FPID == id
                     select new FoodPortionDTO
                     {
                         FPID = x.FPID,
                         quantity = x.quantity,
                         foodItem_FIID = x.foodItem_FIID

                     }).SingleOrDefault();
            return f;
        }
        public bool UpdateFoodPortion(FoodPortionDTO foodPortion)
        {
            try
            {
                var f = (from x in db.foodPortion
                         where foodPortion.FPID == x.FPID
                         select x).SingleOrDefault();

                f.quantity = foodPortion.quantity;
                f.foodItem_FIID = foodPortion.foodItem_FIID;

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool AddFoodPortion(FoodPortionDTO foodPortion)
        {
            try
            {
                var f = new foodPortion
                {
                    FPID = foodPortion.FPID,
                    quantity = foodPortion.quantity,
                    foodItem_FIID = foodPortion.foodItem_FIID
                };

                db.foodPortion.Add(f);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void DeleteFoodPortion(int id)
        {
            var f = (from x in db.foodPortion
                     where x.FPID == id
                     select x).SingleOrDefault();
            db.foodPortion.Remove(f);
            db.SaveChanges();
        }

    }
}