using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrainingMasterWebAPI.Queries;

namespace TrainingMasterWebAPI.Controllers
{
    public class ExerciseController : ApiController
    {
        readonly private ExerciseQueries cq;
        public ExerciseController()
        {
            cq = new ExerciseQueries();
        }
    }
}
