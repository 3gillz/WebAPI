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
    [RoutePrefix("api/TrainingProgramDate")]
    public class TrainingProgramDateController : ApiController
    {
        readonly private TrainingProgramDateQueries tpdq;
        private string userId;
        protected string UserId
        {
            get { return userId = User.Identity.GetUserId(); }
            set { userId = value; }
        }
        public TrainingProgramDateController()
        {
            tpdq = new TrainingProgramDateQueries();
        }
        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<TrainingProgramDateDTO> GetAll()
        {
            return tpdq.GetAll();
        }
        [HttpGet]
        [Route("GetById")]
        public TrainingProgramDateDTO GetById(int id)
        {
            return tpdq.GetSingleById(id);
        }

        [HttpPost]
        [Route("Add")]
        public bool Add(TrainingProgramDateDTO TrainingProgramDate)
        {
            return tpdq.AddTrainingProgramDate(TrainingProgramDate);
        }

        [HttpGet]
        [Route("GetAllByTRID")]
        public IEnumerable<TrainingProgramDateDTO> GetByTRID(int id)
        {
            return tpdq.GetAllByTRID(UserId);
        }
        [HttpGet]
        [Route("GetByTRID")]
        public TrainingProgramDateDTO GetSingleByTRID(int id)
        {
            var UserId = User.Identity.GetUserId();
            return tpdq.GetSingleByTRID(UserId);
        }

        [HttpGet]
        [Route("GetCurrentTrainingProgram")]
        public TrainingProgramDTO GetTrainingProgramByUserId()
        {
            return tpdq.GetCurrentTrainingProgram(UserId);
        }

        [HttpGet]
        [Route("GetCurrentByCID/{id}")]
        public TrainingProgramDTO GetTrainingProgramByCid(int id)
        {
            return tpdq.GetCurrentTrainingProgramByCid(id);
        }
    }
}