using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingMasterWebAPI.Models.DTO;
using TrainingMasterWebAPI.Queries;

namespace TrainingMasterWebAPI.Controllers
{
    public class FoodProgramController : Controller
    {
        readonly private FoodProgramQueries fpq;
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
        [Route("GetById")]
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
    }


}