using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainingMasterWebAPI.Models.DTO;
using TrainingMasterWebAPI.Models.EF;

namespace TrainingMasterWebAPI.Queries
{
    public class ProductQueries
    {
        private TMEntities db;
        public ProductQueries()
        {
            db = new TMEntities();
        }

        public IEnumerable<ProductDTO> GetProductsByTRID(string UserId)
        {
            var trainer = (from x in db.trainer
                           where x.ID == UserId
                           select x).FirstOrDefault();

            var products = (from x in db.product
                            where x.trainer_TRID == trainer.TRID
                            select new ProductDTO
                            {
                                PID = x.PID,
                                name = x.name,
                                durationInDays = x.durationInDays,
                                description = x.description,
                                trainer_TRID = x.trainer_TRID,
                                hidden = x.hidden,
                                price = x.price
                            });
            return products;
        }


    }
}