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
    [RoutePrefix("api/TrainingSale")]
    public class TrainingSaleController : ApiController
    {
        readonly private TrainingSaleQueries tsq;
        public TrainingSaleController()
        {
            tsq = new TrainingSaleQueries();
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<TrainingSaleDTO> GetAllTrainingSales()
        {
            return tsq.GetAllTrainingSales();
        }

        [HttpGet]
        [Route("{trid}")]
        public TrainingSaleDTO GetTrainingSale(int trid)
        {
            return tsq.GetTrainingSaleByTRID(trid);
        }
        
        [HttpPost]
        [Route("Add")]
        public bool AddTrainingSale(TrainingSaleDTO trainingSale)
        {
            return tsq.AddTrainingSale(trainingSale);
        }

        [HttpPut]
        [Route("Update")]
        public bool UpdateTrainingSale(TrainingSaleDTO trainingSale)
        {
            return tsq.UpdateTrainingSale(trainingSale);
        }
    }
}