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
    
    public partial class tblCharity
    {
        public int charityTypeId { get; set; }
        public int eventId { get; set; }
        public string charityName { get; set; }
        public string charityIdentificationNumber { get; set; }
        public string charityPersonOfContact { get; set; }
        public string charityPhoneNumber { get; set; }
        public string charityEmailId { get; set; }
        public int charityCountryId { get; set; }
        public int charityStateId { get; set; }
        public int charityCityId { get; set; }
        public string charityAddress { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<System.DateTime> createdDate { get; set; }
        public string createdBy { get; set; }
        public Nullable<System.DateTime> updatedDate { get; set; }
        public string updatedBy { get; set; }
    
        public virtual tblCountry tblCountry { get; set; }
        public virtual tblState tblState { get; set; }
        public virtual tblCity tblCity { get; set; }
        public virtual tblEvent tblEvent { get; set; }
    }
}