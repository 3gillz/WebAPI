using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrainingMasterWebAPI.Queries;

namespace TrainingMasterWebAPI.Controllers
{
    public class TrainingSaleController : ApiController
    {
        readonly private TrainingSaleQueries tsq;
        public TrainingSaleController()
        {
            tsq = new TrainingSaleQueries();
        }
    }
}