using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainingMasterWebAPI.Models.DTO;
using TrainingMasterWebAPI.Models.EF;

namespace TrainingMasterWebAPI.Queries
{
    public class FoodProgramDateQueries
    {
        private TMEntities db;
        public FoodProgramDateQueries()
        {
            db = new TMEntities();
        }

        public IEnumerable<FoodProgramDateDTO> GetAllFoodProgramDate()
        {
            var foodDate = (from x in db.foodProgramDate
                     select new FoodProgramDateDTO
                     {
                        FPDID = x.FPDID,
                        customer_CID = x.customer_CID,
                        foodProgram_FPMID = x.foodProgram_FPMID,
                        date = x.date
                     });
            return foodDate;
        }

        public FoodProgramDateDTO GetFoodProgramDateById(int id)
        {
            var foodDate = (from x in db.foodProgramDate
                            where x.FPDID == id
                            select new FoodProgramDateDTO
                            {
                                FPDID = x.FPDID,
                                customer_CID = x.customer_CID,
                                foodProgram_FPMID = x.foodProgram_FPMID,
                                date = x.date
                            }).SingleOrDefault();
            return foodDate;
        }

        public bool AddFoodProgramDate(FoodProgramDateDTO FoodProgramDate)
        {
            try
            {
                DateTime d = DateTime.Now;
                var g = new foodProgramDate
                {
                    customer_CID = FoodProgramDate.customer_CID,
                    foodProgram_FPMID = FoodProgramDate.foodProgram_FPMID,
                    date = d
                };
                db.foodProgramDate.Add(g);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateFoodProgramDate(FoodProgramDateDTO FoodProgramDate)
        {
            try
            {
                var foodDate = (from x in db.foodProgramDate
                                where x.FPDID == FoodProgramDate.FPDID
                                select x).SingleOrDefault();

                foodDate.FPDID = FoodProgramDate.FPDID;
                foodDate.customer_CID = FoodProgramDate.customer_CID;
                foodDate.foodProgram_FPMID = FoodProgramDate.foodProgram_FPMID;
                foodDate.date = FoodProgramDate.date;

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<FoodProgramDateDTO> GetAllFoodProgramDatesByCID(string UserId)
        {
            var customer = (from x in db.customer
                            where x.ID == UserId
                            select x).FirstOrDefault();

            var fpd = (from x in db.foodProgramDate
                       where x.customer_CID == customer.CID
                       select new FoodProgramDateDTO
                       {
                           FPDID = x.FPDID,
                           customer_CID = x.customer_CID,
                           foodProgram_FPMID = x.foodProgram_FPMID,
                           date = x.date
                       });
            return fpd;
        }

        public FoodProgramDTO GetCurrentFoodProgramDateByCID(int CID)
        {
            foodProgram f = new foodProgram();
            var currentFp = db.foodProgramDate.OrderByDescending(x => x.date).FirstOrDefault(x => x.customer_CID == CID);

            if (currentFp != null)
            {
                f = db.foodProgram.FirstOrDefault(x => x.FPMID == currentFp.foodProgram_FPMID);
            }
            var fp = new FoodProgramDTO
            {
                FPMID = f.FPMID,
                name = f.name         
            };

            return fp;
        }
        public FoodProgramDTO GetCurrentFoodProgramDateByUserID(string UserId)
        {
            foodProgram f = new foodProgram();
            customer c = db.customer.FirstOrDefault(x => x.ID == UserId);
            var currentFp = db.foodProgramDate.OrderByDescending(x => x.date).FirstOrDefault(x => x.customer_CID == c.CID);

            if (currentFp != null)
            {
                f = db.foodProgram.FirstOrDefault(x => x.FPMID == currentFp.foodProgram_FPMID);
            }
            var fp = new FoodProgramDTO
            {
                FPMID = f.FPMID,
                name = f.name,

            };

            return fp;
        }


    }
}