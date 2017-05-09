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
        [Route("{id}")]
        public TrainingProgramDTO GetTrainingProgram(int id)
        {
            return tpq.GetTrainingProgramById(id);
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