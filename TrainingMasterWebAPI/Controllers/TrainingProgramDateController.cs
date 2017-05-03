using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrainingMasterWebAPI.Queries;

namespace TrainingMasterWebAPI.Controllers
{
    public class TrainingProgramDateController : ApiController
    {
        readonly private TrainingProgramDateQueries tpdq;
        public TrainingProgramDateController()
        {
            tpdq = new TrainingProgramDateQueries();
        }
    }
}