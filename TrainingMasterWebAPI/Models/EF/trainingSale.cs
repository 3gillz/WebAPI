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
    
    public partial class trainingSale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public trainingSale()
        {
            this.trainingSaleProduct = new HashSet<trainingSaleProduct>();
        }
    
        public int TSID { get; set; }
        public Nullable<int> customer_CID { get; set; }
        public Nullable<int> trainer_TRID { get; set; }
        public System.DateTime date { get; set; }
        public Nullable<int> paymentMethod_PMID { get; set; }
    
        public virtual customer customer { get; set; }
        public virtual paymentMethod paymentMethod { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<trainingSaleProduct> trainingSaleProduct { get; set; }
        public virtual trainer trainer { get; set; }
    }
}
