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
    
    public partial class usp_CRUDtblEvent_Result
    {
        public int EventID { get; set; }
        public int registrationID { get; set; }
        public string Title { get; set; }
        public int categoryID { get; set; }
        public string categoryName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Venue { get; set; }
        public Nullable<bool> confirmed { get; set; }
        public string targetAmount { get; set; }
        public Nullable<System.DateTime> updateddate { get; set; }
        public string collectedAmount { get; set; }
        public string reasonForRejecting { get; set; }
        public Nullable<bool> Approval { get; set; }
        public string organiserName { get; set; }
    }
}
