using System.Collections.Generic;
using System.Web.Http;
using TrainingMasterWebAPI.Models.DTO;
using TrainingMasterWebAPI.Queries;
using Microsoft.AspNet.Identity;

namespace TrainingMasterWebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/FoodItem")]
    public class FoodItemController : ApiController
    {
        readonly private FoodItemQueries fiq;

        public FoodItemController()
        {
            fiq = new FoodItemQueries();
        }

        [HttpGet]
        [Route("{id}")]
        public FoodItemDTO GetFoodItem(int id)
        {
            return fiq.GetFoodItemById(id);
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<FoodItemDTO> GetAllFoodItems()
        {
            return fiq.GetAllFoodItems();
        }

        [HttpPost]
        [Route("Add")]
        public bool AddFoodItem(FoodItemDTO fooditem)
        {
            return fiq.AddFoodItem(fooditem);
        }

        [HttpPut]
        [Route("Update")]
        public bool UpdateFoodItem(FoodItemDTO fooditem)
        {
            return fiq.UpdateFoodItem(fooditem);
        }

        [HttpGet]
        [Route("GetAllByTRID")]
        public IEnumerable<FoodItemDTO> GetAllFoodItemsByTRID()
        {
            var trainerUserID = User.Identity.GetUserId();
            return fiq.GetAllFoodItemsByTRID(trainerUserID);
        }
    }
}