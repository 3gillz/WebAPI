//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrainingMasterWebAPI.Models.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class measurementCM
    {
        public int MCMID { get; set; }
        public Nullable<int> customer_CID { get; set; }
        public System.DateTime date { get; set; }
        public Nullable<decimal> butt { get; set; }
        public Nullable<decimal> waist { get; set; }
        public Nullable<decimal> hip { get; set; }
        public Nullable<decimal> thigh { get; set; }
        public Nullable<decimal> armLoose { get; set; }
        public Nullable<decimal> armFlexed { get; set; }
        public Nullable<decimal> shoulders { get; set; }
        public Nullable<bool> performedByTrainer { get; set; }
    
        public virtual customer customer { get; set; }
    }
}
