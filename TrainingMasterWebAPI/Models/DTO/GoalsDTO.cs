using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainingMasterWebAPI.Models.EF;

namespace TrainingMasterWebAPI.Models.DTO
{
    public class GoalsDTO
    {
        public int GID { get; set; }
        public int customer_CID { get; set; }
        public decimal kg { get; set; }
        public decimal percentage { get; set; }
        public string description { get; set; }
        public decimal diameter { get; set; }
        public DateTime startDate { get; set; }
        public DateTime dueDate { get; set; }
    }
}