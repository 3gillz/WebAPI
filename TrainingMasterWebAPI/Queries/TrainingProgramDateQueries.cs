using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainingMasterWebAPI.Models.DTO;
using TrainingMasterWebAPI.Models.EF;

namespace TrainingMasterWebAPI.Queries
{
    public class TrainingProgramDateQueries
    {
        private TMEntities db;
        public TrainingProgramDateQueries()
        {
            db = new TMEntities();
        }

        public IEnumerable<trainingProgramDateDTO> GetAll()
        {
            var trainingDate = (from x in db.trainingProgramDate
                            select new trainingProgramDateDTO
                            {
                                TDID = x.TDID,
                                customer_CID = x.customer_CID,
                                trainingProgram_TPID = x.trainingProgram_TPID,
                                date = x.date
                            });
            return trainingDate;
        }

    }
}