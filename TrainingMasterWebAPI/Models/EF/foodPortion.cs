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
    
    public partial class foodPortion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public foodPortion()
        {
            this.foodProgramPortion = new HashSet<foodProgramPortion>();
        }
    
        public int FPID { get; set; }
        public int quantity { get; set; }
        public int foodItem_FIID { get; set; }
    
        public virtual foodItem foodItem { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<foodProgramPortion> foodProgramPortion { get; set; }
    }
}
