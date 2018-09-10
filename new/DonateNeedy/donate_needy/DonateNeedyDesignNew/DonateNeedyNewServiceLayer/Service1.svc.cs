using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DonateNeedyNewServiceLayer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        DonateNeedyNewEntitiesServiceLayer donateneedyservicelayer = new DonateNeedyNewEntitiesServiceLayer();

        public List<usp_CRUDtblDonations_Result> donation(int? donationid, int? donationTypeID, int? eventID, int? statusID, string donationAmount, string emailID, string phoneNUmber, string comments,
                                                                 string transactionCharges, string receivedAmount, string transActionID, string currency, bool? emailNotification, bool? anonymusDonar, bool? anonymusName, int? registrationID, int? mode)
        {
            List<usp_CRUDtblDonations_Result> lst;
            try
            {
                lst = donateneedyservicelayer.usp_CRUDtblDonations(donationid, donationTypeID, eventID, statusID, donationAmount, emailID, phoneNUmber, comments, transactionCharges, receivedAmount, transActionID, currency, emailNotification, anonymusDonar, anonymusName, registrationID, mode).ToList();
            }
            catch (Exception ex)
            {
                error(ex.Message.ToString(), ex.GetType().ToString(), "donation - servicelayer", registrationID);
                lst = null;
            }
            return lst;
        }

        public List<usp_CreateErrorLog_Result> error(string errorType, string errorMessage, string errorPage, int? registrationId)
        {
            List<usp_CreateErrorLog_Result> lst;
            try
            {
                lst = donateneedyservicelayer.usp_CreateErrorLog(errorType, errorMessage, errorPage, registrationId).ToList();
            }
            catch (Exception ex)
            {
                lst = donateneedyservicelayer.usp_CreateErrorLog(ex.Message.ToString(), ex.GetType().ToString(), "error - servicelayer", registrationId).ToList();
            }
            return lst;
        }
       
    }
}
