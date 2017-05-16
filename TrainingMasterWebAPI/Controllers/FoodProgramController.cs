using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingMasterWebAPI.Models.DTO;
using TrainingMasterWebAPI.Queries;

namespace TrainingMasterWebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/FoodProgram")]
    public class FoodProgramController : Controller
    {
        readonly private FoodProgramQueries fpq;
        private string userId;
        protected string UserId
        {
            get { return userId = User.Identity.GetUserId(); }
            set { userId = value; }
        }
        public FoodProgramController()
        {
            fpq = new FoodProgramQueries();
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<FoodProgramDTO> GetAllFoodPrograms()
        {
            return fpq.GetAllFoodPrograms();
        }

        [HttpGet]
        [Route("{id}")]
        public FoodProgramDTO GetFoodProgramById(int id)
        {
            return fpq.GetFoodProgramById(id);
        }

        [HttpPut]
        [Route("Add")]
        public bool AddFoodProgram(FoodProgramDTO FoodProgram)
        {
            return fpq.AddFoodProgram(FoodProgram);
        }

        [HttpPost]
        [Route("Update")]
        public bool UpdateFoodProgram(FoodProgramDTO FoodProgram)
        {
            return fpq.UpdateFoodProgram(FoodProgram);
        }

        [HttpGet]
        [Route("GetAllByTRID")]
        public IEnumerable<FoodProgramDTO> GetAllFoodProgramByTRID()
        {
            return fpq.GetAllFoodProgramByTRID(UserId);
        }

        [HttpGet]
        [Route("GetSingleByTRID")]
        public FoodProgramDTO GetSingleFoodProgramByTRID()
        {
            return fpq.GetSingleFoodProgramByTRID(UserId);
        }
    }


}