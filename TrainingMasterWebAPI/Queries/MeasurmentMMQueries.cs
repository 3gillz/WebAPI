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
        public decimal calculatedPercentage;

        public int aldur(string kt)
        {
            char[] c = kt.ToCharArray();
            int i = int.Parse((c[4].ToString() + c[5].ToString()));
            DateTime d = DateTime.Now;
            c = d.Year.ToString().ToCharArray();
            int b = int.Parse((c[2].ToString() + c[3].ToString()));
            if (((b - i)) < 0)
            {
                return 100 + (b - i);
            }
            return (b - i);
        }

    
        public bool AddMeasurmentMM(MeasurmentMMDTO MeasureMM)
        {
            var customer = (from x in db.customer
                            where x.CID == MeasureMM.customer_CID
                            select x).SingleOrDefault();

            var age = aldur(customer.kennitala);

            if (MeasureMM.chest != 0 || MeasureMM.chest != null)
            {
                if (customer.gender == 1)
                {
                    var total = MeasureMM.chest + MeasureMM.axilliary + MeasureMM.suprailiac + MeasureMM.abdominal + MeasureMM.thigh + MeasureMM.tricep + MeasureMM.subscapular;
                    calculatedPercentage = 495M / (1.112M - (0.00043499M * (decimal)total) + (0.00000055M * (decimal)total * (decimal)total) - (0.00028826M * age)) - 450M;
                }
                else
                {
                    var total = MeasureMM.chest + MeasureMM.axilliary + MeasureMM.suprailiac + MeasureMM.abdominal + MeasureMM.thigh + MeasureMM.tricep + MeasureMM.subscapular;
                    calculatedPercentage =  495M / (1.097M - (0.00046971M * (decimal)total) + (0.00000056M * (decimal)total * (decimal)total) - (0.00012828M * age)) - 450M;
                }
            }

            var heightf = customer.height / 100;
    
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
                    bmi = MeasureMM.kg / heightf / heightf,
                    lbm = (( 0.32810M * MeasureMM.kg.Value) + (0.33929M * customer.height)) - 29.5336M,
                    fatPercentage = calculatedPercentage,
                    kg = MeasureMM.kg
                };
           
            db.measureMM.Add(m);
            db.SaveChanges();
            return true;     
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