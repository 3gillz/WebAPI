using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Web.Http;
using TrainingMasterWebAPI.Models.DTO;
using TrainingMasterWebAPI.Queries;

namespace TrainingMasterWebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/ProgressImage")]
    public class ProgressImageController : ApiController
    {
        readonly private ProgressImageQueries piq;
        private string userId;
        protected string UserId
        {
            get { return userId = User.Identity.GetUserId(); }
            set { userId = value; }
        }
        public ProgressImageController()
        {
            piq = new ProgressImageQueries();
        }

        [HttpGet]
        [Route("{id}")]
        public ProgressImageDTO GetProgressImage(int id)
        {
            return piq.GetProgressImageById(id);
        }

        [HttpGet]
        [Route("GetAllByCID")]
        public IEnumerable<ProgressImageDTO> GetProgressImagesByCID()
        {
            return piq.GetAllProgressImagesByCID(UserId);
        }


        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<ProgressImageDTO> GetAllProgressImages()
        {
            return piq.GetAllProgressImages();
        }

        [HttpPost]
        [Route("Add")]
        public bool AddProgressImage(ProgressImageDTO PGI)
        {
            return piq.AddProgressImage(PGI);
        }

        [HttpPut]
        [Route("Update")]
        public bool UpdateProgressImage(ProgressImageDTO PGI)
        {
            return piq.UpdateProgressImage(PGI);
        }
    }
}