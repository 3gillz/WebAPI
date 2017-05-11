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
                var f = new foodProgramDate
                {
                    FPDID = FoodProgramDate.FPDID,
                    customer_CID = FoodProgramDate.customer_CID,
                    foodProgram_FPMID = FoodProgramDate.foodProgram_FPMID,
                    date = FoodProgramDate.date
                };
                db.foodProgramDate.Add(f);
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

        public FoodProgramDateDTO GetCurrentFoodProgramDateByCID(string UserId)
        {
            var customer = (from x in db.customer
                            where x.ID == UserId
                            select x).FirstOrDefault();

            var datenow = DateTime.Now;

            var fpd = (from x in db.foodProgramDate.OrderBy(x => x.date) //Spurning hvort þetta þurfi? Cool ef það virkar
                       where x.customer_CID == customer.CID
                       select new FoodProgramDateDTO
                       {
                           FPDID = x.FPDID,
                           customer_CID = x.customer_CID,
                           foodProgram_FPMID = x.foodProgram_FPMID,
                           date = x.date
                       }).FirstOrDefault();
            return fpd;
        }


    }
}