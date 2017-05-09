using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrainingMasterWebAPI.Queries;
using TrainingMasterWebAPI.Models.DTO;

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
        [Route("GetAll")]
        public IEnumerable<ExerciseDTO> GetAllExercises()
        {
            return eq.GetAllExercises();
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

        [HttpPut]
        [Route("Update")]
        public bool UpdateExercise(ExerciseDTO exercise)
        {
            return eq.UpdateExercise(exercise);
        }

        //TODO: Bæta við delete falli
    }
}
