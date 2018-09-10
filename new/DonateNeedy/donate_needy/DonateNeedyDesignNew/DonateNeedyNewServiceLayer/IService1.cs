using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DonateNeedyNewServiceLayer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<usp_CRUDtblDonations_Result> donation(int? donationid, int? donationTypeID, int? eventID, 
            int? statusID, string donationAmount, string emailID, string phoneNUmber, string comments,
         string transactionCharges, string receivedAmount, string transActionID, string currency, 
         bool? emailNotification, bool? anonymusDonar, bool? anonymusName, int? registrationID, int? mode);

        [OperationContract]
        List<usp_CreateErrorLog_Result> error(string errorType, string errorMessage, string errorPage,
            int? registrationId);
    }
}
