using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainingMasterWebAPI.Models.DTO;
using TrainingMasterWebAPI.Models.EF;

namespace TrainingMasterWebAPI.Queries
{
    public class MeasurmentMMQueries
    {
        private TMEntities db;
        public MeasurmentMMQueries()
        {
            db = new TMEntities();
        }

        public IEnumerable<MeasurmentMMDTO> GetAllMeasurmentMM()
        {
            var m = (from x in db.measureMM
                     select new MeasurmentMMDTO
                     {
                        
                         MMMID = x.MMMID,
                         customer_CID = x. customer_CID,
                         date = x.date,
                         chest = x.chest,
                         abdominal = x.abdominal,
                         thigh = x.thigh,
                         tricep = x.tricep,
                         subscapular = x.subscapular,
                         suprailiac = x.suprailiac,
                         axilliary = x.axilliary,
                         bmi = x.bmi,
                         lbm = x.lbm,
                         fatPercentage = x.fatPercentage,
                         kg = x.kg
                     });
            return m;
        }

        public MeasurmentMMDTO GetMeasurmentMMById(int id)
        {
            var m = (from x in db.measureMM
                     where x.MMMID == id
                     select new MeasurmentMMDTO
                     {
                         MMMID = x.MMMID,
                         customer_CID = x.customer_CID,
                         date = x.date,
                         chest = x.chest,
                         abdominal = x.abdominal,
                         thigh = x.thigh,
                         tricep = x.tricep,
                         subscapular = x.subscapular,
                         suprailiac = x.suprailiac,
                         axilliary = x.axilliary,
                         bmi = x.bmi,
                         lbm = x.lbm,
                         fatPercentage = x.fatPercentage,
                         kg = x.kg
                     }).SingleOrDefault();
            return m;
        }

        public bool AddMeasurmentMM(MeasurmentMMDTO MeasureMM)
        {
            try
            {
                var m = new measureMM
                {
                    MMMID = MeasureMM.MMMID,
                    customer_CID = MeasureMM.customer_CID,
                    date = MeasureMM.date,
                    chest = MeasureMM.chest,
                    abdominal = MeasureMM.abdominal,
                    thigh = MeasureMM.thigh,
                    tricep = MeasureMM.tricep,
                    subscapular = MeasureMM.subscapular,
                    suprailiac = MeasureMM.suprailiac,
                    axilliary = MeasureMM.axilliary,
                    bmi = MeasureMM.bmi,
                    lbm = MeasureMM.lbm,
                    fatPercentage = MeasureMM.fatPercentage,
                    kg = MeasureMM.kg
                };
                db.measureMM.Add(m);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public bool UpdateMeasurmentMM(MeasurmentMMDTO MeasureMM)
        {
            try
            {
                var m = (from x in db.measureMM
                         where x.MMMID == MeasureMM.MMMID
                         select x).SingleOrDefault();

                m.MMMID = MeasureMM.MMMID;
                m.customer_CID = MeasureMM.customer_CID;
                m.date = MeasureMM.date;
                m.chest = MeasureMM.chest;
                m.abdominal = MeasureMM.abdominal;
                m.thigh = MeasureMM.thigh;
                m.tricep = MeasureMM.tricep;
                m.subscapular = MeasureMM.subscapular;
                m.suprailiac = MeasureMM.suprailiac;
                m.axilliary = MeasureMM.axilliary;
                m.bmi = MeasureMM.bmi;
                m.lbm = MeasureMM.lbm;
                m.fatPercentage = MeasureMM.fatPercentage;
                m.kg = MeasureMM.kg;

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<MeasurmentMMDTO> GetAllMeasurementMMByCID(string UserId)
        {
            var customer = (from x in db.customer
                            where x.ID == UserId
                            select x).FirstOrDefault();

            var m = (from x in db.measureMM
                     where x.customer_CID == customer.CID
                     select new MeasurmentMMDTO
                     {

                         MMMID = x.MMMID,
                         customer_CID = x.customer_CID,
                         date = x.date,
                         chest = x.chest,
                         abdominal = x.abdominal,
                         thigh = x.thigh,
                         tricep = x.tricep,
                         subscapular = x.subscapular,
                         suprailiac = x.suprailiac,
                         axilliary = x.axilliary,
                         bmi = x.bmi,
                         lbm = x.lbm,
                         fatPercentage = x.fatPercentage,
                         kg = x.kg
                     });
            return m;
        }

        public MeasurmentMMDTO GetSingleMeasurementMMByCID(string UserId)
        {
            var customer = (from x in db.customer
                            where x.ID == UserId
                            select x).FirstOrDefault();

            var m = (from x in db.measureMM
                     where x.customer_CID == customer.CID
                     select new MeasurmentMMDTO
                     {

                         MMMID = x.MMMID,
                         customer_CID = x.customer_CID,
                         date = x.date,
                         chest = x.chest,
                         abdominal = x.abdominal,
                         thigh = x.thigh,
                         tricep = x.tricep,
                         subscapular = x.subscapular,
                         suprailiac = x.suprailiac,
                         axilliary = x.axilliary,
                         bmi = x.bmi,
                         lbm = x.lbm,
                         fatPercentage = x.fatPercentage,
                         kg = x.kg
                     }).FirstOrDefault();
            return m;
        }

    }
}