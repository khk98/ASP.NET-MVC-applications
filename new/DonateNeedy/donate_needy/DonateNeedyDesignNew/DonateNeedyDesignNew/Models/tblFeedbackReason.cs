//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DonateNeedyDesignNew.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblFeedbackReason
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblFeedbackReason()
        {
            this.tblFeedbacks = new HashSet<tblFeedback>();
        }
    
        public int feedbackReasonID { get; set; }
        public string feedbackReason { get; set; }
        public Nullable<bool> isActive { get; set; }
        public string createdBy { get; set; }
        public Nullable<System.DateTime> createdDate { get; set; }
        public string updatedBy { get; set; }
        public Nullable<System.DateTime> updatedDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblFeedback> tblFeedbacks { get; set; }
    }
}
