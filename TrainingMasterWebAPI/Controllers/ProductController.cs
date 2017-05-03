using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrainingMasterWebAPI.Queries;

namespace TrainingMasterWebAPI.Controllers
{
    public class ProductController : ApiController
    {
        readonly private ProductQueries pq;
        public ProductController()
        {
            pq = new ProductQueries();
        }
    }
}