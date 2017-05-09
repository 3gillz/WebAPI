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
    [RoutePrefix("api/TrainingSaleProduct")]
    public class TrainingProductSaleController : ApiController
    {
        readonly private TrainingProductSaleQueries tpsq;
        public TrainingProductSaleController()
        {
            tpsq = new TrainingProductSaleQueries();
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<TrainingSaleProductDTO> GetAllTrainingSaleProducts()
        {
            return tpsq.GetAllTrainingSaleProducts();
        }

        [HttpGet]
        [Route("{pid,tsid}")] //Þurfum að skoða hvernig best er að gera þetta, held þetta sé ekki rétt svona
        public TrainingSaleProductDTO GetTrainingSale(int pid, int tsid)
        {
            return tpsq.GetTrainingSaleProductByPIDAndTSID(pid, tsid);
        }

        [HttpPost]
        [Route("Add")]
        public bool AddTrainingSale(TrainingSaleProductDTO trainingSaleProduct)
        {
            return tpsq.AddTrainingSaleProduct(trainingSaleProduct);
        }

        [HttpPut]
        [Route("Update")]
        public bool UpdateTrainingSaleProduct(TrainingSaleProductDTO trainingSaleProduct)
        {
            return tpsq.UpdateTrainingSaleProduct(trainingSaleProduct);
        }
    }
}