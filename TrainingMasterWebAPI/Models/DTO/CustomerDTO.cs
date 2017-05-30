using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingMasterWebAPI.Models.DTO
{
    public class CustomerDTO
    {
        public int CID { get; set; }
        public string ID { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public short gender { get; set; }
        public string kennitala { get; set; }
        public string address { get; set; }
        public string country { get; set; }
        public string foodPref { get; set; }
        public string injury { get; set; }
        public string allergy { get; set; }
        public int? zipcodes_ZIP { get; set; }
        public string profileImagePath { get; set; }
        public int height { get; set; }
        public int? trainer_TRID { get; set; }
        public bool? hidden { get; set; }
        public short jobDifficulty { get; set; }
    }
}