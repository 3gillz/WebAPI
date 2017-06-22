using System;
using System.Collections.Generic;
using System.Linq;
using TrainingMasterWebAPI.Models.DTO;
using TrainingMasterWebAPI.Models.EF;

namespace TrainingMasterWebAPI.Queries
{
    public class FoodItemQueries
    {
        private TMEntities db;

        public FoodItemQueries()
        {
            db = new TMEntities();
        }

        public FoodItemDTO GetFoodItemById(int id)
        {
            var f = (from x in db.foodItem
                     where x.FIID == id
                     select new FoodItemDTO
                     {
                         FIID = x.FIID,
                         name = x.name,
                         kcal = x.kcal,
                         fat = x.fat,
                         saturatedFat = x.saturatedFat,
                         unsaturatedFat = x.unsaturatedFat,
                         colestrol = x.colestrol,
                         carbohydrate = x.carbohydrate,
                         addedSugar = x.addedSugar,
                         fiber = x.fiber,
                         water = x.water,
                         protein = x.protein,
                         suppliment = x.suppliment,
                         trainer_TRID = x.trainer_TRID
                     }).SingleOrDefault();
            return f;
        }

        public IEnumerable<FoodItemDTO> GetAllFoodItems()
        {
            var f = (from x in db.foodItem
                     select new FoodItemDTO
                     {
                         FIID = x.FIID,
                         name = x.name,
                         kcal = x.kcal,
                         fat = x.fat,
                         saturatedFat = x.saturatedFat,
                         unsaturatedFat = x.unsaturatedFat,
                         colestrol = x.colestrol,
                         carbohydrate = x.carbohydrate,
                         addedSugar = x.addedSugar,
                         fiber = x.fiber,
                         water = x.water,
                         protein = x.protein,
                         suppliment = x.suppliment,
                         trainer_TRID = x.trainer_TRID
                     });
            return f;
        }

        public bool AddFoodItem(FoodItemDTO x)
        {
            try
            {
                var f = new foodItem
                {
                    FIID = x.FIID,
                    name = x.name,
                    kcal = x.kcal,
                    fat = x.fat,
                    saturatedFat = x.saturatedFat,
                    unsaturatedFat = x.unsaturatedFat,
                    colestrol = x.colestrol,
                    carbohydrate = x.carbohydrate,
                    addedSugar = x.addedSugar,
                    fiber = x.fiber,
                    water = x.water,
                    protein = x.protein,
                    suppliment = x.suppliment,
                    trainer_TRID = x.trainer_TRID
                };

                db.foodItem.Add(f);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool TrainerAddFoodItem(string userId, FoodItemDTO foodItem)
        {
            var trainer = (from x in db.trainer
                           where x.ID == userId
                           select x).FirstOrDefault();
            try
            {
                var f = new foodItem
                {
                    name = foodItem.name,
                    category = foodItem.category,
                    kcal = foodItem.kcal,
                    fat = foodItem.fat,
                    saturatedFat = foodItem.saturatedFat,
                    unsaturatedFat = foodItem.unsaturatedFat,
                    colestrol = foodItem.colestrol,
                    carbohydrate = foodItem.carbohydrate,
                    addedSugar = foodItem.addedSugar,
                    fiber = foodItem.fiber,
                    water = foodItem.water,
                    protein = foodItem.protein,
                    suppliment = foodItem.suppliment,
                    trainer_TRID = trainer.TRID
                };

                db.foodItem.Add(f);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool UpdateFoodItem(FoodItemDTO fooditem)
        {
            try
            {
                var f = (from x in db.foodItem
                         where x.FIID == fooditem.FIID
                         select x
                        ).SingleOrDefault();
                f.FIID = fooditem.FIID;
                f.name = fooditem.name;
                f.kcal = fooditem.kcal;
                f.fat = fooditem.fat;
                f.saturatedFat = fooditem.saturatedFat;
                f.unsaturatedFat = fooditem.unsaturatedFat;
                f.colestrol = fooditem.colestrol;
                f.carbohydrate = fooditem.carbohydrate;
                f.addedSugar = fooditem.addedSugar;
                f.fiber = fooditem.fiber;
                f.water = fooditem.water;
                f.protein = fooditem.protein;
                f.suppliment = fooditem.suppliment;
                f.trainer_TRID = fooditem.trainer_TRID;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<FoodItemDTO> GetAllFoodItemsByTRID(string id)
        {
            var trainer = (from x in db.trainer
                           where x.ID == id
                           select x).FirstOrDefault();

            var f = (from x in db.foodItem
                     where x.trainer_TRID == trainer.TRID
                     select new FoodItemDTO
                     {
                         FIID = x.FIID,
                         name = x.name,
                         kcal = x.kcal,
                         fat = x.fat,
                         saturatedFat = x.saturatedFat,
                         unsaturatedFat = x.unsaturatedFat,
                         colestrol = x.colestrol,
                         carbohydrate = x.carbohydrate,
                         addedSugar = x.addedSugar,
                         fiber = x.fiber,
                         water = x.water,
                         protein = x.protein,
                         suppliment = x.suppliment,
                         trainer_TRID = x.trainer_TRID
                     });
            return f;
        }

    }
}