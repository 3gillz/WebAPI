using System;
using System.Collections.Generic;
using System.Linq;
using TrainingMasterWebAPI.Models.DTO;
using TrainingMasterWebAPI.Models.EF;

namespace TrainingMasterWebAPI.Queries
{
    public class MeasurmentCMQueries
    {
        private TMEntities db;

        public MeasurmentCMQueries()
        {
            db = new TMEntities();
        }

        public MeasurmentCMDTO GetMeasurmentCMById(int id)
        {
            var m = (from x in db.measurementCM
                     where x.MCMID == id
                     select new MeasurmentCMDTO
                     {
                         MCMID = x.MCMID,
                         customer_CID = x.customer_CID,
                         date = x.date,
                         butt = x.butt,
                         waist = x.waist,
                         hip = x.hip,
                         thigh = x.thigh,
                         armLoose = x.armLoose,
                         armFlexed = x.armFlexed,
                         shoulders = x.shoulders,
                         performedByTrainer = x.performedByTrainer
                     }).SingleOrDefault();
            return m;
        }

        public IEnumerable<MeasurmentCMDTO> GetAllMeasurmentCMs()
        {
            var m = (from x in db.measurementCM
                     select new MeasurmentCMDTO
                     {
                         MCMID = x.MCMID,
                         customer_CID = x.customer_CID,
                         date = x.date,
                         butt = x.butt,
                         waist = x.waist,
                         hip = x.hip,
                         thigh = x.thigh,
                         armLoose = x.armLoose,
                         armFlexed = x.armFlexed,
                         shoulders = x.shoulders,
                         performedByTrainer = x.performedByTrainer
                     });
            return m;
        }

        public bool AddMeasurmentCM(MeasurmentCMDTO x)
        {
            try
            {
                var m = new measurementCM
                {
                    MCMID = x.MCMID,
                    customer_CID = x.customer_CID,
                    date = x.date,
                    butt = x.butt,
                    waist = x.waist,
                    hip = x.hip,
                    thigh = x.thigh,
                    armLoose = x.armLoose,
                    armFlexed = x.armFlexed,
                    shoulders = x.shoulders,
                    performedByTrainer = x.performedByTrainer
                };

                db.measurementCM.Add(m);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateMeasurmentCM(MeasurmentCMDTO mm)
        {
            try
            {
                var m = (from x in db.measurementCM
                         where mm.MCMID == x.MCMID
                         select x).SingleOrDefault();

                m.MCMID = mm.MCMID;
                m.customer_CID = mm.customer_CID;
                m.date = mm.date;
                m.butt = mm.butt;
                m.waist = mm.waist;
                m.hip = mm.hip;
                m.thigh = mm.thigh;
                m.armLoose = mm.armLoose;
                m.armFlexed = mm.armFlexed;
                m.shoulders = mm.shoulders;
                m.performedByTrainer = mm.performedByTrainer;
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