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
        [Route("GetById")]
        public GoalsDTO GetGoalById(int id)
        {
            return gq.GetGoalById(id);
        }

        [HttpPut]
        [Route("Add")]
        public bool Add(GoalsDTO Goals)
        {
            return gq.AddGoal(Goals);
        }

        [HttpPost]
        [Route("Update")]
        public bool Update(GoalsDTO Goals)
        {
            return gq.UpdateGoal(Goals);
        }
    }


}