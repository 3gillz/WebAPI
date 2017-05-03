using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrainingMasterWebAPI.Queries;

namespace TrainingMasterWebAPI.Controllers
{
    public class ZipcodesController : ApiController
    {
        readonly private ZipcodesQueries zcq;
        public ZipcodesController()
        {
            zcq = new ZipcodesQueries();
        }
    }
}