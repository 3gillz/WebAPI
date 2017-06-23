using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            try
            {
                var img = (from x in db.progressImage
                           where x.customer_CID == customer.CID
                           select new ProgressImageDTO
                           {
                               PIID = x.PIID,
                               date = x.date,
                               image = x.image,
                               customer_CID = x.customer_CID
                           });
                return img;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public ProgressImageDTO AddProgressImage(string UserId, string imageBase64)
        {
            try
            {
                imageBase64 = imageBase64.Replace(' ', '+');
                byte[] imageBytes = Convert.FromBase64String(imageBase64);

                customer c = db.customer.FirstOrDefault(x => x.ID == UserId);

                progressImage pI = new progressImage
                {
                    date = DateTime.Now,
                    image = imageBytes,
                    customer_CID = c.CID
                };

                db.progressImage.Add(pI);
                db.SaveChanges();
                return new ProgressImageDTO
                {
                    date = pI.date,
                    image = pI.image,
                    customer_CID = pI.customer_CID,
                    PIID = pI.PIID
                };
            }
            catch (Exception)
            {
                throw;
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