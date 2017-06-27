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


        public int ageFromKt(string kt)
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

        public decimal? calculatedPercentage;
    
        public bool AddMeasurmentMM(MeasurmentMMDTO MeasureMM)
        {
            var customer = (from x in db.customer
                            where x.CID == MeasureMM.customer_CID
                            select x).SingleOrDefault();

            var customerHeight = customer.height;

            var age = ageFromKt(customer.kennitala);
            var heightf = (decimal)customerHeight / 100;

            if (MeasureMM.chest == 0 || MeasureMM.chest == null) //Four Point Measurment
            {
                decimal? total4 = MeasureMM.tricep + MeasureMM.suprailiac + MeasureMM.abdominal + MeasureMM.thigh;
                decimal squaredTotal = (decimal)Math.Pow((double)total4, 2);

                if(customer.gender == 1)   //Male
                {
                    calculatedPercentage = (0.29288M * total4) - (0.0005M * squaredTotal) + (0.15845M * age) - 5.76377M;
                }
                else if(customer.gender == 2)   //Female
                {
                    calculatedPercentage = (0.29669M * total4) - (0.00043M * squaredTotal) + (0.02963M * age) + 1.4072M;
                }

            }
            else //Seven Point Measurment
            {
                decimal? total7 = MeasureMM.chest + MeasureMM.axilliary + MeasureMM.suprailiac + MeasureMM.abdominal + MeasureMM.thigh + MeasureMM.tricep + MeasureMM.subscapular;

                if (customer.gender == 1)   //Male
                {
                    calculatedPercentage = 495M / (1.112M - (0.00043499M * total7) + (0.00000055M * total7 * total7) - (0.00028826M * age)) - 450M;
                }
                else if (customer.gender == 2) //Female
                {
                    calculatedPercentage =  495M / (1.097M - (0.00046971M * total7) + (0.00000056M * total7 * total7) - (0.00012828M * age)) - 450M;
                }
            }

            var m = new measureMM
            {
                MMMID = MeasureMM.MMMID,
                customer_CID = MeasureMM.customer_CID,
                date = DateTime.Now,
                chest = MeasureMM.chest,
                abdominal = MeasureMM.abdominal,
                thigh = MeasureMM.thigh,
                tricep = MeasureMM.tricep,
                subscapular = MeasureMM.subscapular,
                suprailiac = MeasureMM.suprailiac,
                axilliary = MeasureMM.axilliary,
                bmi = MeasureMM.kg / heightf / heightf,
                lbm = ((0.32810M * MeasureMM.kg.Value) + (0.33929M * customer.height)) - 29.5336M,
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

        public IEnumerable<MeasurmentMMDTO> GetAllMeasurementMMByCID(int CID)
        {
            var m = (from x in db.measureMM
                     where x.customer_CID == CID
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