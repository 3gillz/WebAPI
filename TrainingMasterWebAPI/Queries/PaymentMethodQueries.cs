using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainingMasterWebAPI.Models.DTO;
using TrainingMasterWebAPI.Models.EF;

namespace TrainingMasterWebAPI.Queries
{
    public class PaymentMethodQueries
    {
        private TMEntities db;
        public PaymentMethodQueries()
        {
            db = new TMEntities();
        }

        public IEnumerable<PaymentMethodDTO> GetAllPaymentMethods()
        {
            var p = (from x in db.paymentMethod
                             select new PaymentMethodDTO
                             {
                                 PMID = x.PMID,
                                 name = x.name
                             });
            return p;
        }

        public PaymentMethodDTO GetPaymentMethodById(int id)
        {
            var p = (from x in db.paymentMethod
                            where x.PMID == id
                            select new PaymentMethodDTO
                            {
                                PMID = x.PMID,
                                name = x.name
                            }).SingleOrDefault();
            return p;
        }
        public bool AddPaymentMethod(PaymentMethodDTO PaymentMethod)
        {
            try
            {
                var p = new paymentMethod
                {
                    PMID = PaymentMethod.PMID,
                    name = PaymentMethod.name
                };

                db.paymentMethod.Add(p);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdatePaymentMethod(PaymentMethodDTO paymentMethod)
        {
            try
            {
                var p = (from x in db.paymentMethod
                         where paymentMethod.PMID == x.PMID
                         select x).SingleOrDefault();

                paymentMethod.PMID = p.PMID;
                paymentMethod.name = p.name;

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