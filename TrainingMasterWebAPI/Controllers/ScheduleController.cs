using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrainingMasterWebAPI.Queries.Schedules;
using TrainingMasterWebAPI.Models.DTO;
using Microsoft.AspNet.Identity;

namespace TrainingMasterWebAPI.Controllers
{
    [RoutePrefix("api/Schedule")]
    public class ScheduleController : ApiController
    {
        readonly private ScheduleQueries sq;
        public ScheduleController()
        {
            sq = new ScheduleQueries();
        }
         [Route("")]
         public Schedule getSchedule()
        {
            var user = User.Identity.GetUserId();
            return sq.getScheduleForTrainee(user);
        }
        [Route("{Days}")]
        public TrainingSchedule getTrainingProgram(int[] days)
        {
            var user = User.Identity.GetUserId();
            return sq.getUserid(user,days);
        }
    }
}
