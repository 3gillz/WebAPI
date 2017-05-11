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
        [HttpGet]
        [Route("GetByTRID")]
        public TrainingProgramDateDTO GetByTRID(int id)
        {
            var UserId = User.Identity.GetUserId();
            return tpdq.GetSingleByTRID(UserId);
        }
    }
}