using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Web.Http;
using TrainingMasterWebAPI.Models.DTO;
using TrainingMasterWebAPI.Queries;

namespace TrainingMasterWebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Training")]
    public class TrainingController : ApiController
    {
        readonly private TrainingQueries tq;

        private string userId;
        protected string UserId
        {
            get { return userId = User.Identity.GetUserId(); }
            set { userId = value; }
        }

        public TrainingController()
        {
            tq = new TrainingQueries();
        }

        [HttpGet]
        [Route("{id}")]
        public TrainingDTO GetTraining(int id)
        {
            return tq.GetTrainingById(id);
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<TrainingDTO> GetAllTrainings()
        {
            return tq.GetAllTrainings();
        }

        [HttpPost]
        [Route("Add/{TPID}")]
        public bool AddTrainings([FromBody] string trainings, int TPID)
        {
            return tq.AddTrainings(UserId, trainings, TPID);
        }

        [HttpGet]
        [Route("Get/{TPID}")]
        public IEnumerable<TrainingDTO>  GetTrainings(int TPID)
        {
            bool trainer = User.IsInRole("trainer");
            return tq.GetTrainings(TPID, UserId, trainer);
        }

        [HttpPut]
        [Route("Update")]
        public bool UpdateTraining(TrainingDTO t)
        {
            return tq.UpdateTraining(t);
        }
    }
}