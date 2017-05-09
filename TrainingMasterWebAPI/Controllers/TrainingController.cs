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
        [Route("Add")]
        public bool AddTraining(TrainingDTO t)
        {
            return tq.AddTraining(t);
        }

        [HttpPut]
        [Route("Update")]
        public bool UpdateTraining(TrainingDTO t)
        {
            return tq.UpdateTraining(t);
        }
    }
}