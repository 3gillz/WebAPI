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

        public IEnumerable<TrainingProgramDateDTO> GetAll()
        {
            var trainingDate = (from x in db.trainingProgramDate
                            select new TrainingProgramDateDTO
                            {
                                TDID = x.TDID,
                                customer_CID = x.customer_CID,
                                trainingProgram_TPID = x.trainingProgram_TPID,
                                date = x.date
                            });
            return trainingDate;
        }


        public TrainingProgramDateDTO GetSingleById(int id)
        {
            var trainingDate = (from x in db.trainingProgramDate
                                where x.TDID == id
                                select new TrainingProgramDateDTO
                                {
                                    TDID = x.TDID,
                                    customer_CID = x.customer_CID,
                                    trainingProgram_TPID = x.trainingProgram_TPID,
                                    date = x.date
                                }).FirstOrDefault();
            return trainingDate;
        }

        public TrainingProgramDateDTO GetSingleByTRID(string UserID)
        {
            var trainer = (from x in db.trainer
                           where x.ID == UserID
                           select x).FirstOrDefault();

            var trainingDate = (from x in db.trainingProgramDate
                                where x.trainer_TRID == trainer.TRID
                                select new TrainingProgramDateDTO
                                {
                                    TDID = x.TDID,
                                    customer_CID = x.customer_CID,
                                    trainingProgram_TPID = x.trainingProgram_TPID,
                                    date = x.date,
                                    trainer_TRID = x.trainer_TRID
                                }).FirstOrDefault();
            return trainingDate;
        }


    }
}