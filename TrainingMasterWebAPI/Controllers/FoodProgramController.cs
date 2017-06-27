using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Web.Http;
using TrainingMasterWebAPI.Models.DTO;
using TrainingMasterWebAPI.Queries;

namespace TrainingMasterWebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/FoodProgram")]
    public class FoodProgramController : ApiController
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

        [HttpPost]
        [Route("Add")]
        public int AddFoodProgram(FoodProgramDTO FoodProgram)
        {
            return fpq.AddFoodProgram(FoodProgram.name, UserId);
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