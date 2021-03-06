﻿using Microsoft.AspNet.Identity;
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
        private string userId;
        protected string UserId
        {
            get { return userId = User.Identity.GetUserId(); }
            set { userId = value; }
        }
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

        [HttpPost]
        [Route("Add")]
        public bool AddMeasurmentMM(MeasurmentMMDTO MeasurmentMM)
        {
            return mmmq.AddMeasurmentMM(MeasurmentMM);
        }

        [HttpPut]
        [Route("Update")]
        public bool UpdateMeasurmentMM(MeasurmentMMDTO MeasurmentMM)
        {
            return mmmq.UpdateMeasurmentMM(MeasurmentMM);
        }

        [HttpGet]
        [Route("GetAllByCID/{CID}")]
        public IEnumerable<MeasurmentMMDTO> GetAllMeasurementMMByCID(int CID)
        {
            return mmmq.GetAllMeasurementMMByCID(CID);
        }

        [HttpGet]
        [Route("GetSingleByCID")]
        public MeasurmentMMDTO GetSingleMeasurementMMByCID()
        {
            return mmmq.GetSingleMeasurementMMByCID(UserId);
        }


    }
}