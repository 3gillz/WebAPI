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
    [RoutePrefix("api/TrainingProgramDate")]
    public class TrainingProgramDateController : ApiController
    {
        readonly private TrainingProgramDateQueries tpdq;
        public TrainingProgramDateController()
        {
            tpdq = new TrainingProgramDateQueries();
        }
        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<trainingProgramDateDTO> GetAll()
        {
            return tpdq.GetAll();
        }
    }
}