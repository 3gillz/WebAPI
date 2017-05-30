using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainingMasterWebAPI.Models.DTO;
using TrainingMasterWebAPI.Models.EF;

namespace TrainingMasterWebAPI.Queries
{
    public class TrainingProductSaleQueries
    {
        private TMEntities db;

        public TrainingProductSaleQueries()
        {
            db = new TMEntities();
        }

        public IEnumerable<TrainingSaleProductDTO> GetAllTrainingSaleProducts()
        {
            var tsp = from x in db.trainingSaleProduct
                     select new TrainingSaleProductDTO()
                     {
                         duration = x.duration,
                         price = x.price,
                         product_PID = x.product_PID,
                         endDate = x.endDate,
                         trainingSale_TSID = x.trainingSale_TSID
                     };

            return tsp;
        }

        public TrainingSaleProductDTO GetTrainingSaleProductByPIDAndTSID(int pid, int tsid) 
        {
            var tsp = (from x in db.trainingSaleProduct
                       where x.product_PID == pid && x.trainingSale_TSID == tsid
                       select new TrainingSaleProductDTO
                       {
                           duration = x.duration,
                           price = x.price,
                           product_PID = x.product_PID,
                           endDate = x.endDate,
                           trainingSale_TSID = x.trainingSale_TSID

                       }).SingleOrDefault();

            return tsp;
        }

        public bool AddTrainingSaleProduct(TrainingSaleProductDTO TrainingSaleProduct)
        {
            try
            {
                var tsp = new trainingSaleProduct
                {
                    duration = TrainingSaleProduct.duration,
                    price = TrainingSaleProduct.price,
                    product_PID = TrainingSaleProduct.product_PID,
                    endDate = TrainingSaleProduct.endDate,
                    trainingSale_TSID = TrainingSaleProduct.trainingSale_TSID
                };

                db.trainingSaleProduct.Add(tsp);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateTrainingSaleProduct(TrainingSaleProductDTO TrainingSaleProduct)
        {
            try
            {
                var tsp = (from x in db.trainingSaleProduct
                          where TrainingSaleProduct.product_PID == x.product_PID && TrainingSaleProduct.trainingSale_TSID == x.trainingSale_TSID
                          select x).SingleOrDefault();

                tsp.duration = TrainingSaleProduct.duration;
                tsp.price = TrainingSaleProduct.price;
                tsp.product_PID = TrainingSaleProduct.product_PID;
                tsp.endDate = TrainingSaleProduct.endDate;
                tsp.trainingSale_TSID = TrainingSaleProduct.trainingSale_TSID;

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