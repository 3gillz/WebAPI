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
        private string userId;
        protected string UserId
        {
            get { return userId = User.Identity.GetUserId(); }
            set { userId = value; }
        }

        public TrainingProgramController()
        {
            tpq = new TrainingProgramQueries();
        }


        [HttpGet]
        [Route("{tpid}")]
        public TrainingProgramDTO GetTrainingProgramByTPID(int tpid)
        {
            return tpq.GetTrainingProgramByTPID(tpid, UserId);
        }

        [HttpGet]
        [Route("GetByTRID")]
        public IEnumerable<TrainingProgramDTO> GetTrainingProgramsByTRID()
        {
            return tpq.GetTrainingProgramsByTRID(UserId);
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<TrainingProgramDTO> GetAllTrainingPrograms()
        {
            return tpq.GetAllTrainingPrograms();
        }

        [HttpPost]
        [Route("Add")]
        public int AddTrainingProgram(TrainingProgramDTO TP)
        {
            var UserId = User.Identity.GetUserId();
            return tpq.AddTrainingProgram(UserId, TP);
        }

        [HttpPut]
        [Route("Update")]
        public bool UpdateTrainingProgram(TrainingProgramDTO TP)
        {
            return tpq.UpdateTrainingProgram(TP);
        }
    }
}