using Microsoft.AspNet.Identity;
using System.Collections.Generic;
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

        private string userId;
        protected string UserId
        {
            get { return userId = User.Identity.GetUserId(); }
            set { userId = value; }
        }

        public FoodPortionController()
        {
            fpq = new FoodPortionQueries();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("test")]
        public string Test()
        {
            return "Testing works";
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("test2")]
        public string Test2(string input)
        {
            return "Testing works";
        }

        [HttpGet]
        [Route("{id}")]
        public FoodPortionDTO GetFoodPortionById(int id)
        {
            return fpq.GetFoodPortionByID(id);
        }

        [HttpGet]
        [Route("Get/{TPMID}")]
        public IEnumerable<FoodPortionDTO> AddFoodPortion(int TPMID)
        {
            var t = true;
            return fpq.GetFoodPortions(TPMID, UserId, t);
        }

        [HttpPost]
        [Route("Get/{TPID}")]
        public bool AddFoodPortion([FromBody] string portions, int TPID)
        {
            return fpq.AddFoodPortion(UserId, portions, TPID);
        }
    }
}
