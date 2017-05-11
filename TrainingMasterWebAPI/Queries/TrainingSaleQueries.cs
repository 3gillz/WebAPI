using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TrainingMasterWebAPI.Models.DTO;
using TrainingMasterWebAPI.Models.EF;
using TrainingMasterWebAPI.Models;

namespace TrainingMasterWebAPI.Queries
{
    public class TrainingSaleQueries
    {
        private TMEntities db;

        public TrainingSaleQueries()
        {
            db = new TMEntities();
        }

        public IEnumerable<TrainingSaleDTO> GetAllTrainingSales()
        {
            var ts = from x in db.trainingSale
                     select new TrainingSaleDTO()
                     {
                         TSID = x.TSID,
                         customer_CID = x.customer_CID,
                         paymentMethod_PMID = x.paymentMethod_PMID,
                         trainer_TRID = x.trainer_TRID,
                         date = DateTime.Now
                     };

            return ts;
        }

        public TrainingSaleDTO GetTrainingSaleByTRID(int TRID) 
        {
            var ts = (from x in db.trainingSale
                          where x.trainer_TRID == TRID
                          select new TrainingSaleDTO
                          {
                              TSID = x.TSID,
                              customer_CID = x.customer_CID,
                              paymentMethod_PMID = x.paymentMethod_PMID,
                              trainer_TRID = x.trainer_TRID,
                              date = DateTime.Now

                          }).SingleOrDefault();

            return ts;
        }

        public bool AddTrainingSale(TrainingSaleDTO TrainingSale)
        {
            try
            {
                var ts = new trainingSale
                {
                    TSID = TrainingSale.TSID,
                    customer_CID = TrainingSale.customer_CID,
                    paymentMethod_PMID = TrainingSale.paymentMethod_PMID,
                    trainer_TRID = TrainingSale.trainer_TRID,
                    date = DateTime.Now
                };

                db.trainingSale.Add(ts);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateTrainingSale(TrainingSaleDTO TrainingSale)
        {
            try
            {
                var ts = (from x in db.trainingSale
                         where TrainingSale.TSID == x.TSID
                         select x).SingleOrDefault();

                ts.TSID = TrainingSale.TSID;
                ts.customer_CID = TrainingSale.customer_CID;
                ts.paymentMethod_PMID = TrainingSale.paymentMethod_PMID;
                ts.trainer_TRID = TrainingSale.trainer_TRID;
                ts.date = TrainingSale.date; //Spurning með hvort eigi að gera Datetime.Now hér eða hafa þetta svona
                
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