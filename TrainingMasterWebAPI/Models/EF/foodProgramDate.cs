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
    
    public partial class foodProgramDate
    {
        public int FPDID { get; set; }
        public Nullable<int> customer_CID { get; set; }
        public Nullable<int> foodProgram_FPMID { get; set; }
        public System.DateTime date { get; set; }
    
        public virtual foodProgram foodProgram { get; set; }
        public virtual customer customer { get; set; }
    }
}
