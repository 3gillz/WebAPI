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
        [Route("GetAllByCurrentUser")]
        public IEnumerable<ProgressImageDTO> GetProgressImagesByCurrentUser()
        {
            return piq.GetAllProgressImagesByCurrentUser(UserId);
        }

        [HttpGet]
        [Route("GetAllByCID/{CID}")]
        public IEnumerable<ProgressImageDTO> GetProgressImagesByCID(int CID)
        {
            return piq.GetAllProgressImagesByCID(CID);
        }


        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<ProgressImageDTO> GetAllProgressImages()
        {
            return piq.GetAllProgressImages();
        }

        [HttpPost]
        [Route("Add")]
        public ProgressImageDTO AddProgressImage([FromBody] string imageBase64)
        {
            return piq.AddProgressImage(UserId, imageBase64);
        }

        [HttpPut]
        [Route("Update")]
        public bool UpdateProgressImage(ProgressImageDTO PGI)
        {
            return piq.UpdateProgressImage(PGI);
        }
    }
}