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
    
    public partial class tblContactU
    {
        public int ContactUsID { get; set; }
        public string Name { get; set; }
        public string EmailID { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<int> registrationid { get; set; }
    
        public virtual tblRegistration tblRegistration { get; set; }
    }
}
