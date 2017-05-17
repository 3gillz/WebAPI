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
    [RoutePrefix("api/FoodPortion")]
    public class FoodPortionController : ApiController
    {
        readonly private FoodPortionQueries fpq;

        public FoodPortionController()
        {
            fpq = new FoodPortionQueries();
        }

        [HttpGet]
        [Route("{id}")]
        public FoodPortionDTO GetFoodPortionById(int id)
        {
            return fpq.GetFoodPortionByID(id);
        }

        [HttpPut]
        [Route("Add")]
        public bool AddFoodPortion(FoodPortionDTO FoodPortion)
        {
            return fpq.AddFoodPortion(FoodPortion);
        }

    }
}
