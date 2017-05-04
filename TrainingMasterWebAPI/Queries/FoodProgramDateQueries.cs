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

        public IEnumerable<FoodProgramDateDTO> GetAll()
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
    }
}