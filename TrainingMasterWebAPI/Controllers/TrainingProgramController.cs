using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Web.Http;
using TrainingMasterWebAPI.Models.DTO;
using TrainingMasterWebAPI.Queries;

namespace TrainingMasterWebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/TrainingProgram")]
    public class TrainingProgramController : ApiController
    {
        readonly private TrainingProgramQueries tpq;

        public TrainingProgramController()
        {
            tpq = new TrainingProgramQueries();
        }

        [HttpGet]
        [Route("{tpid}")]
        public IEnumerable<TrainingProgramDTO> GetTrainingProgramByTPID(int tpid)
        {
            return tpq.GetTrainingProgramByTPID(tpid);
        }

        [HttpGet]
        [Route("{UserId}")]
        public IEnumerable<TrainingProgramDTO> GetTrainingProgramByTRID()
        {
            var UserId = User.Identity.GetUserId();
            return tpq.GetTrainingProgramByTRID(UserId);


        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<TrainingProgramDTO> GetAllTrainingPrograms()
        {
            return tpq.GetAllTrainingPrograms();
        }

        [HttpPost]
        [Route("Add")]
        public bool AddTrainingProgram(TrainingProgramDTO TP)
        {
            return tpq.AddTrainingProgram(TP);
        }

        [HttpPut]
        [Route("Update")]
        public bool UpdateTrainingProgram(TrainingProgramDTO TP)
        {
            return tpq.UpdateTrainingProgram(TP);
        }
    }
}