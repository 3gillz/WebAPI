using Microsoft.AspNet.Identity;
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
    [RoutePrefix("api/Goals")]
    public class GoalsController : ApiController
    {
        readonly private GoalsQueries gq;
        private string userId;
        protected string UserId
        {
            get { return userId = User.Identity.GetUserId(); }
            set { userId = value; }
        }
        public GoalsController()
        {
            gq = new GoalsQueries();
        }


        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<GoalsDTO> GetAllGoals()
        {
            return gq.GetAllGoals();
        }

        [HttpGet]
        [Route("GetAllByCID")]
        public IEnumerable<GoalsDTO> GetAllGoalsByCID()
        {
            return gq.GetAllGoalsByCID(UserId);
        }
        [HttpGet]
        [Route("{id}")]
        public GoalsDTO GetCurrentGoalByCID(int id)
        {
            return gq.GetCurrentGoalByCID(id);
        }

        [HttpGet]
        [Route("GetById")]
        public GoalsDTO GetGoalById(int id)
        {
            return gq.GetGoalById(id);
        }

        [HttpPost]
        [Route("Add")]
        public bool Add(GoalsDTO Goals)
        {
            return gq.AddGoal(Goals);
        }

        [HttpPut]
        [Route("Update")]
        public bool Update(GoalsDTO Goals)
        {
            return gq.UpdateGoal(Goals);
        }
    }


}