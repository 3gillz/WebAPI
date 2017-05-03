using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrainingMasterWebAPI.Queries;

namespace TrainingMasterWebAPI.Controllers
{
    public class TrainerController : ApiController
    {
        readonly private TrainerQueries tq;
        public TrainerController()
        {
            tq = new TrainerQueries();
        }
    }
}