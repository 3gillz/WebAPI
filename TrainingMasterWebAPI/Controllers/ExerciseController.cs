using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrainingMasterWebAPI.Queries;
using TrainingMasterWebAPI.Models.DTO;
using Microsoft.AspNet.Identity;

namespace TrainingMasterWebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Exercise")]
    public class ExerciseController : ApiController
    {
        readonly private ExerciseQueries eq;
        public ExerciseController()
        {
            eq = new ExerciseQueries();
        }

        [HttpGet]
        [Authorize(Roles = "superadmin")]
        [Route("GetAll")]
        public IEnumerable<ExerciseDTO> GetAllExercises()
        {
            return eq.GetAllExercises();
        }

        [HttpGet]
        [Authorize(Roles = "trainer")]
        [Route("GetAllByTrid")]
        public IEnumerable<ExerciseDTO> GetAllExercisesByTRID()
        {
            var userId = User.Identity.GetUserId();
            return eq.GetAllExercisesByTRID(userId);
        }

        [HttpGet]
        [Route("{id}")]
        public ExerciseDTO GetExercise(int id)
        {
            return eq.GetExerciseByID(id);
        }

        [HttpPost]
        [Route("Add")]
        public bool AddExercise(ExerciseDTO exercise)
        {
            return eq.AddExercise(exercise);
        }

        [HttpPost]
        [Route("TrainerAdd")]
        public bool TrainerAddExercise(ExerciseDTO exercise)
        {
            var userId = User.Identity.GetUserId();
            return eq.TrainerAddExercise(userId, exercise);
        }


        [HttpPut]
        [Authorize(Roles = "superadmin")]
        [Route("Update")]
        public bool UpdateExercise(ExerciseDTO exercise)
        {
            return eq.UpdateExercise(exercise);
        }

        [HttpPut]
        [Authorize(Roles = "trainer")]
        [Route("UpdateWithTRID")]
        public bool UpdateExerciseWithTRID(ExerciseDTO exercise)
        {
            var userId = User.Identity.GetUserId();
            return eq.UpdateExerciseWithTRID(userId, exercise);
        }
        //TODO: Bæta við delete falli
    }
}
