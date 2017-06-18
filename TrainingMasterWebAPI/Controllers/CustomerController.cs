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
        [Route("GetCurrentCustomer")]
        public CustomerDTO GetCurrentCustomer()
        {
            var user = User.Identity.GetUserId();
            return cq.GetCustomerById(user);
        }

        [HttpGet]
        [Authorize(Roles = "superadmin")]
        [Route("GetAllCustomers")]
        public IEnumerable<CustomerDTO> GetAllCustomers()
        {
            return cq.GetAllCustomers();
        }

        [HttpGet]
        [Authorize(Roles = "trainer")]
        [Route("GetAllCustomersByTRID")]
        public IEnumerable<CustomerDTO> GetAllCustomersByTRID()
        {
            var userID = User.Identity.GetUserId();
            return cq.GetAllCustomersByTRID(userID);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public bool RegisterCustomer(CustomerDTO customer)
        {
            return cq.RegisterCustomer(customer);
        }

        [HttpPost]
        [Route("AddCustomer")]
        public bool AddCustomer(CustomerDTO customer)
        {
            var userId = User.Identity.GetUserId();
            return cq.AddCustomer(customer, userId);
        }

        [HttpPut]
        [Route("UpdateCustomer")]
        public CustomerDTO UpdateCustomer(CustomerDTO customer)
        {
            var userId = User.Identity.GetUserId();
            return cq.UpdateCustomer(userId, customer);
        }

        [HttpPut]
        [Route("UpdateProfileImage")]
        public string UpdateProfileImage(CustomerDTO customer)
        {
            var userId = User.Identity.GetUserId();
            return cq.UpdateProfileImage(userId, customer);
        }
    }
}