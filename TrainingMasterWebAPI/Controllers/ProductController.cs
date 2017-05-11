using Microsoft.AspNet.Identity;
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
    public class ProductController : ApiController
    {
        readonly private ProductQueries pq;
        private string UserId { get => User.Identity.GetUserId(); set => UserId = value; }

        public ProductController()
        {
            pq = new ProductQueries();
        }
        [HttpGet]
        [Route("GetByTRID")]
        public IEnumerable<ProductDTO> GetProductsByTRID()
        {
            return pq.GetProductsByTRID(UserId);
        }

    }
}