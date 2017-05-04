using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TrainingMasterWebAPI.Models.DTO;
using TrainingMasterWebAPI.Models.EF;
using TrainingMasterWebAPI.Models;

namespace TrainingMasterWebAPI.Queries
{
    public class ZipcodesQueries
    {
        private TMEntities db;

        public ZipcodesQueries()
        {
            db = new TMEntities();
        }

        public IEnumerable<ZipcodesDTO> GetAllZipcodes()
        {
            var zips = from x in db.zipcodes
                       select new ZipcodesDTO()
                       {
                           ZIP = x.ZIP,
                           place = x.place
                       };

            return zips;
        }

        public ZipcodesDTO GetZipcode(int id) 
        {
            var z = (from x in db.zipcodes
                       where x.ZIP == id
                       select new ZipcodesDTO
                       {
                           ZIP = x.ZIP,
                           place = x.place,

                       }).SingleOrDefault();

            return z;
        }

    }
}