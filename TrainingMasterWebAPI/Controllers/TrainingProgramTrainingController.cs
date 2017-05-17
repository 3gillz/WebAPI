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
    [RoutePrefix("api/TrainingProgramTraining")]
    public class TrainingProgramTrainingController : ApiController
    {
        readonly private TrainingProgramTrainingQueries tptq;

        public TrainingProgramTrainingController()
        {
            tptq = new TrainingProgramTrainingQueries();
        }

        [HttpGet]
        [Route("{tpid}")]
        public IEnumerable<TrainingProgramTrainingDTO> GetTrainingProgramByTPID(int tpid)
        {
            return tptq.GetTrainingProgramTrainingByTPID(tpid);
        }

        [HttpPost]
        [Route("Add")]
        public bool AddTrainingProgramTraining(TrainingProgramTrainingDTO tpt)
        {
            return tptq.AddTrainingProgramTraining(tpt);
        }

    }
}
