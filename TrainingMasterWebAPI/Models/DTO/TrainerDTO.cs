using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingMasterWebAPI.Models.DTO
{
    public class TrainerDTO
    {
        public int TRID { get; set; }
        public string ID { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string kennitala { get; set; }
        public short gender { get; set; }
        public string address { get; set; }
        public string profileImagePath { get; set; }
        public string location { get; set; }
        public bool? hidden { get; set; }
    }
}