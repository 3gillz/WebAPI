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
    [RoutePrefix("api/Zipcodes")]
    public class ZipcodesController : ApiController
    {
        readonly private ZipcodesQueries zcq;

        public ZipcodesController()
        {
            zcq = new ZipcodesQueries();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<ZipcodesDTO> GetAllZipcodes()
        {
            return zcq.GetAllZipcodes();
        }

        [HttpGet]
        [Route("{id}")]
        public ZipcodesDTO GetZipcode(int id)
        {
            return zcq.GetZipcode(id);
        }
    }
}