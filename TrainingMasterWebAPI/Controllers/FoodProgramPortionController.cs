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
    [RoutePrefix("api/FoodProgramPortion")]
    public class FoodProgramPortionController : ApiController
    {
        readonly private FoodProgramPortionQueries fppq;

        public FoodProgramPortionController()
        {
            fppq = new FoodProgramPortionQueries();
        }

        [HttpGet]
        [Route("{id}")]
        public FoodProgramPortionDTO GetFoodProgramPortionByFPMID(int id)
        {
            return fppq.GetFoodProgramPortionByFPMID(id);
        }

        [HttpPut]
        [Route("Add")]
        public bool AddFoodProgramPortion(FoodProgramPortionDTO FoodProgramPortion)
        {
            return fppq.AddFoodProgramPortion(FoodProgramPortion);
        }
    }
}
