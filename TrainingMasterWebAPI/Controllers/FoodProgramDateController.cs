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
        public IEnumerable<FoodProgramDateDTO> GetAllFoodProgramDate()
        {
            return fpdq.GetAllFoodProgramDate();
        }

        [HttpGet]
        [Route("GetById")]
        public FoodProgramDateDTO GetFoodProgramDateById(int id)
        {
            return fpdq.GetFoodProgramDateById(id);
        }

        [HttpPut]
        [Route("Add")]
        public bool AddFoodProgramDate(FoodProgramDateDTO FoodProgramDate)
        {
            return fpdq.AddFoodProgramDate(FoodProgramDate);
        }

        [HttpPost]
        [Route("Update")]
        public bool UpdateFoodProgramDate(FoodProgramDateDTO FoodProgramDate)
        {
            return fpdq.UpdateFoodProgramDate(FoodProgramDate);
        }
    }
}