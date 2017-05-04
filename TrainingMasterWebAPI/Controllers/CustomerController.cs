using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrainingMasterWebAPI.Queries;
using TrainingMasterWebAPI.Models.DTO;
using Microsoft.AspNet.Identity;

namespace TrainingMasterWebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Customer")]
    public class CustomerController : ApiController
    {
        readonly private CustomerQueries cq;
        public CustomerController()
        {
            cq = new CustomerQueries();
        }

        [HttpGet]
        [Route("{id}")]
        public CustomerDTO GetCustomer(string id)
        {
            return cq.GetCustomerById(id);
        }

        [HttpGet]
        [Route("GetCurrentUser")]
        public CustomerDTO GetCurrentUser()
        {
            var user = User.Identity.GetUserId();
            return cq.GetCustomerById(user);
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<CustomerDTO> GetAllCustomers()
        {
            return cq.GetAllCustomers();
        }

        [HttpPost]
        [Route("Add")]
        public bool AddCustomer(CustomerDTO customer)
        {
            return cq.AddCustomer(customer);
        }

        [HttpPut]
        [Route("Update")]
        public bool UpdateCustomer(CustomerDTO customer)
        {
            return cq.UpdateCustomer(customer);
        }

    }
}
