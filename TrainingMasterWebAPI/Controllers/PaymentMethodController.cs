using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrainingMasterWebAPI.Models.DTO;
using TrainingMasterWebAPI.Queries;

namespace TrainingMasterWebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/PaymentMethod")]
    public class PaymentMethodController : ApiController
    {
        readonly private PaymentMethodQueries pmq;
        public PaymentMethodController()
        {
            pmq = new PaymentMethodQueries();
        }
        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<PaymentMethodDTO> GetAllPaymentMethods()
        {
            return pmq.GetAllPaymentMethods();
        }

        [HttpGet]
        [Route("GetById")]
        public PaymentMethodDTO GetPaymentMethodById(int id)
        {
            return pmq.GetPaymentMethodById(id);
        }

        [HttpPut]
        [Route("Add")]
        public bool AddPaymentMethod(PaymentMethodDTO PaymentMethod)
        {
            return pmq.AddPaymentMethod(PaymentMethod);
        }

        [HttpPost]
        [Route("Update")]
        public bool UpdatePaymentMethod(PaymentMethodDTO PaymentMethod)
        {
            return pmq.UpdatePaymentMethod(PaymentMethod);
        }
    }


}