using System;
using System.Collections.Generic;
using System.Linq;
using TrainingMasterWebAPI.Models.DTO;
using TrainingMasterWebAPI.Models.EF;

namespace TrainingMasterWebAPI.Queries
{
    public class ProgressImageQueries
    {
        private TMEntities db;

        public ProgressImageQueries()
        {
            db = new TMEntities();
        }

        public ProgressImageDTO GetProgressImageById(int id)
        {
            var img = (from x in db.progressImage
                       where x.PIID == id
                       select new ProgressImageDTO
                       {
                           PIID = x.PIID,
                           date = x.date,
                           customer_CID = x.customer_CID
                       }).SingleOrDefault();
            return img;
        }

        public IEnumerable<ProgressImageDTO> GetAllProgressImages()
        {
            var img = (from x in db.progressImage
                       select new ProgressImageDTO
                       {
                           PIID = x.PIID,
                           date = x.date,
                           customer_CID = x.customer_CID
                       });
            return img;
        }

        public IEnumerable<ProgressImageDTO> GetAllProgressImagesByCID(string userId)
        {
            var customer = (from x in db.customer
                            where x.ID == userId
                            select x).FirstOrDefault();

            var img = (from x in db.progressImage
                       where x.customer_CID == customer.CID
                       select new ProgressImageDTO
                       {
                           PIID = x.PIID,
                           date = x.date,
                           customer_CID = x.customer_CID
                       });
            return img;
        }

        public bool AddProgressImage(ProgressImageDTO x)
        {
            try
            {
                var img = new progressImage
                {
                    PIID = x.PIID,
                    date = x.date,
                    customer_CID = x.customer_CID
                };

                db.progressImage.Add(img);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateProgressImage(ProgressImageDTO img)
        {
            try
            {
                var p = (from x in db.progressImage
                         where img.PIID == x.PIID
                         select x).SingleOrDefault();

                p.PIID = img.PIID;
                p.date = img.date;
                p.customer_CID = img.customer_CID;

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