using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainingMasterWebAPI.Models.DTO;
using TrainingMasterWebAPI.Models.EF;

namespace TrainingMasterWebAPI.Queries
{
    public class ProductQueries
    {
        private TMEntities db;
        public ProductQueries()
        {
            db = new TMEntities();
        }

        //public IEnumerable<ProductDTO> GetProductsByTRID(string UserId)
        //{
        //    trainer = 
        //}


    }
}