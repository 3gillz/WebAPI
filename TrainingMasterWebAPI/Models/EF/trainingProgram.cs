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
    
    public partial class trainingProgram
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public trainingProgram()
        {
            this.trainingProgramDate = new HashSet<trainingProgramDate>();
        }
    
        public int TPID { get; set; }
        public Nullable<int> training_TID { get; set; }
        public Nullable<int> trainer_TRID { get; set; }
    
        public virtual trainer trainer { get; set; }
        public virtual training training { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<trainingProgramDate> trainingProgramDate { get; set; }
    }
}
