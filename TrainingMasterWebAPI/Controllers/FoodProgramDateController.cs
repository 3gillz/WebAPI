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
    [RoutePrefix("api/FoodProgramDate")]
    public class FoodProgramDateController : ApiController
    {
        readonly private FoodProgramDateQueries fpdq;
        public FoodProgramDateController()
        {
            fpdq = new FoodProgramDateQueries();
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<FoodProgramDateDTO> GetAll()
        {
            return fpdq.GetAll();
        }
    }
}