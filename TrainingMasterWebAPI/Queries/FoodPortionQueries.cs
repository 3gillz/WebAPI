using Newtonsoft.Json;
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

        public bool AddFoodPortion(string userId, string portions, int FPID)
        {
            trainer trainer = db.trainer.FirstOrDefault(x => x.ID == userId);
            foodProgram foodProgram = db.foodProgram.FirstOrDefault(x => x.FPMID == FPID);
            if (trainer.TRID != foodProgram.trainer_TRID)
            {
                return false;
            }
            else try
                {
                    List<int> FPIDList = new List<int>();
                    var portionArray = JsonConvert.DeserializeObject<List<FoodPortionDTO>>(portions);
                    foreach (FoodPortionDTO x in portionArray)
                    {
                        var t = new foodPortion
                        {
                            FPID = x.FPID,
                            foodItem_FIID = x.foodItem_FIID,
                            timeOfDay = x.timeOfDay,
                            quantity = x.quantity,
                            sunday = x.sunday,
                            monday = x.monday,
                            tuesday = x.tuesday,
                            wednesday = x.wednesday,
                            thursday = x.thursday,
                            friday = x.friday,
                            saturday = x.saturday,
                            className = x.className,
                        };
                        db.foodPortion.Add(t);
                        db.SaveChanges();
                        FPIDList.Add(t.FPID);
                    }
                    foreach (int x in FPIDList)
                    {
                        db.foodProgramPortion.Add(new foodProgramPortion { foodProgram_FPMID = FPID, foodPortion_FPID = x });
                    }
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
        }

        public IEnumerable<FoodPortionDTO> GetFoodPortions(int FPMID, string userId, bool trainer)
        {
            IEnumerable<foodProgramPortion> tp = null;
            if (trainer)
            {
                trainer tr = db.trainer.FirstOrDefault(x => x.ID == userId);
                tp = db.foodProgramPortion.Where(x => x.foodProgram_FPMID == FPMID && x.foodProgram.trainer_TRID == tr.TRID);
            }
            else
            {
                customer c = db.customer.FirstOrDefault(x => x.ID == userId);
                foodProgramDate tpd = db.foodProgramDate.OrderByDescending(x => x.date).FirstOrDefault(x => x.customer_CID == c.CID);
                if (tpd != null)
                {
                    tp = db.foodProgramPortion.Where(x => x.foodProgram_FPMID == FPMID && tpd.foodProgram_FPMID == FPMID);
                }
            }

            List<FoodPortionDTO> trainingList = new List<FoodPortionDTO>();

            if (tp != null)
            {
                foreach (foodProgramPortion x in tp)
                {
                    var portion = (from p in db.foodPortion
                                    where p.FPID == x.foodPortion_FPID
                                    select new FoodPortionDTO
                                    {
                                        FPID = p.FPID,
                                        quantity = p.quantity,
                                        foodItem_FIID = p.foodItem_FIID,
                                        sunday = p.sunday,
                                        monday = p.monday,
                                        tuesday = p.tuesday,
                                        wednesday = p.wednesday,
                                        thursday = p.thursday,
                                        friday = p.friday,
                                        saturday = p.saturday,
                                        timeOfDay = p.timeOfDay,
                                        className = p.className
                                    }).FirstOrDefault();
                    var name = GetFoodItemName(portion.foodItem_FIID);
                    portion.name = name;
                    trainingList.Add(portion);
                }
            }

            return trainingList;

        }

        public string GetFoodItemName(int FIID)
        {
            var x = (from t in db.foodItem
                     where t.FIID == FIID
                     select t).SingleOrDefault();
            return x.name;
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