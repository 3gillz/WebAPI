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
    [RoutePrefix("api/MeasurmentMM")]
    public class MeasurmentMMController : ApiController
    {
        readonly private MeasurmentMMQueries mmmq;
        public MeasurmentMMController()
        {
            mmmq = new MeasurmentMMQueries();
        }


        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<MeasurmentMMDTO> GetAllMeasurmentMM()
        {
            return mmmq.GetAllMeasurmentMM();
        }

        [HttpGet]
        [Route("GetById")]
        public MeasurmentMMDTO GetMeasurmentMMById(int id)
        {
            return mmmq.GetMeasurmentMMById(id);
        }

        [HttpPut]
        [Route("Add")]
        public bool AddMeasurmentMM(MeasurmentMMDTO MeasurmentMM)
        {
            return mmmq.AddMeasurmentMM(MeasurmentMM);
        }

        [HttpPost]
        [Route("Update")]
        public bool UpdateMeasurmentMM(MeasurmentMMDTO MeasurmentMM)
        {
            return mmmq.UpdateMeasurmentMM(MeasurmentMM);
        }
    
    }
}