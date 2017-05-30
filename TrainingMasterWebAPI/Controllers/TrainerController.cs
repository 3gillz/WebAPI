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
    [RoutePrefix("api/Trainer")]
    public class TrainerController : ApiController
    {
        readonly private TrainerQueries tq;
        public TrainerController()
        {
            tq = new TrainerQueries();
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<TrainerDTO> GetAllTrainers()
        {
            return tq.GetAllTrainers();
        }

        [HttpGet]
        [Route("GetById")]
        public TrainerDTO GetTrainerById(int id)
        {
            return tq.GetTrainerById(id);
        }

        [HttpGet]
        [Route("GetCurrentTrainer")]
        public TrainerDTO GetCurrentTrainer()
        {
            var user = User.Identity.GetUserId();
            return tq.GetCurrentTrainer(user);
        }


        [HttpPut]
        [Route("Add")]
        public bool AddTrainer(TrainerDTO Trainer)
        {
            return tq.AddTrainer(Trainer);
        }

        [HttpPost]
        [Route("Update")]
        public bool UpdateTrainer(TrainerDTO Trainer)
        {
            return tq.UpdateTrainer(Trainer);
        }
    }


}