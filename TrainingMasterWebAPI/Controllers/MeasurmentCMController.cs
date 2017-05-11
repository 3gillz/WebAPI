using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Web.Http;
using TrainingMasterWebAPI.Models.DTO;
using TrainingMasterWebAPI.Queries;

namespace TrainingMasterWebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/MeasurmentCM")]
    public class MeasurmentCMController : ApiController
    {
        readonly private MeasurmentCMQueries mcmq;
        private string userId;
        protected string UserId
        {
            get { return userId = User.Identity.GetUserId(); }
            set { userId = value; }
        }

        public MeasurmentCMController()
        {
            mcmq = new MeasurmentCMQueries();
        }

        [HttpGet]
        [Route("{id}")]
        public MeasurmentCMDTO GetMeasurmentCM(int id)
        {
            return mcmq.GetMeasurmentCMById(id);
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<MeasurmentCMDTO> GetAllMeasurmentCMs()
        {
            return mcmq.GetAllMeasurmentCMs();
        }

        [HttpPost]
        [Route("Add")]
        public bool AddMeasurmentCM(MeasurmentCMDTO CM)
        {
            return mcmq.AddMeasurmentCM(CM);
        }

        [HttpPut]
        [Route("Update")]
        public bool UpdateMeasurmentCM(MeasurmentCMDTO CM)
        {
            return mcmq.UpdateMeasurmentCM(CM);
        }

        [HttpGet]
        [Route("GetAllByCID")]
        public IEnumerable<MeasurmentCMDTO> GetAllMeasurementCMByCID()
        {
            return mcmq.GetAllMeasurementCMByCID(UserId);
        }

        [HttpGet]
        [Route("GetSingleByCID")]
        public MeasurmentCMDTO GetSingleMeasurementCMByCID()
        {
            return mcmq.GetSingleMeasurementCMByCID(UserId);
        }
    }
}