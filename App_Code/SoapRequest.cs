using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Security;
using CyberSource.Clients;
using CyberSource.Clients.SoapWebReference;
using System.Security.Cryptography;
using System.Web;
using System.Text.RegularExpressions;
using System.Text;

namespace CyberSource
{
    public class SoapRequest
    {
        public ModelClass SendSoapRequest(ModelClass obj)
        {
            RequestMessage request = new RequestMessage();
            request.payerAuthEnrollService = new PayerAuthEnrollService();
            request.payerAuthEnrollService.run = "true";
            request.payerAuthEnrollService.httpAccept = "Accept";
            request.merchantID = obj.merchantID;// "cybersource_anil1";
            request.merchantReferenceCode = Guid.NewGuid().ToString();

            Card card = new Card();
            card.accountNumber = obj.cardNumber.Trim();// "4000000000000002";
            card.expirationMonth = obj.expirationMonth.Trim();// "12";
            card.expirationYear = obj.expirationYear.Trim();// "2020";
            card.cvNumber = obj.cvn.Trim();
            card.cardType = obj.cardType.Trim();
            request.card = card;

            PurchaseTotals purchaseTotals = new PurchaseTotals();
            purchaseTotals.currency = "USD";
            purchaseTotals.grandTotalAmount = "1";
            request.purchaseTotals = purchaseTotals;

           //  there are two static items in this sample
            request.item = new Item[2];

            Item item = new Item();
            item.id = obj.itemid1 = "0";
            item.productName = obj.productName1 = "Test Product for testing on production";
            item.unitPrice = obj.unitPrice1 = "1.00";
            request.item[0] = item;

            try
            {
                ReplyMessage reply = SoapClient.RunTransaction(request);
                obj.acsURL = reply.payerAuthEnrollReply.acsURL;  
                obj.PaReq = reply.payerAuthEnrollReply.paReq;
                obj.xid = reply.payerAuthEnrollReply.xid;
                obj.errorCode ="0";
              //obj.response =ProcessReply(reply);
              return obj;
            }
         
           //System.ServiceModel Exception examples.
            catch (EndpointNotFoundException e)
            {
                // This is thrown when a remote endpoint could not be found or reached.  
                // The remote endpoint is down, the client network connection is down, 
                // the remote endpoint is unreachable, or because the remote network is unreachable.

              //  SaveOrderState();
                obj.errorCode = "1";
                obj.response = e.InnerException.Message;
               return obj;
            }
            catch (ChannelTerminatedException e)
            {
                // This is typically thrown on the client when a channel is terminated due to the server closing the connection.
               // SaveOrderState();
                obj.errorCode = "2";
                obj.response = HandleException(e);
               return obj ;
            }
            //System.ServiceModel.Security Exception example.
            catch (MessageSecurityException e)
            {
                //Represents an exception that occurred when there is something wrong with the security applied on a message. Possibly a bad signature.
                obj.errorCode = "3";
                obj.response = HandleSecurityException(e);
                return obj;
              //  return HandleSecurityException(e);
            }
            //System.Security.Cryptography exception    
            catch (CryptographicException ce)
            {
                //Represents a problem with your X509 certificate (.p12 file) or a problem creating a signature from the certificate.
                obj.errorCode = "4";
                obj.response = HandleCryptoException(ce);
                return obj;
              //  return HandleCryptoException(ce);
            }
            //System.Net exception    
            catch (WebException we)
            {
                //The WebException class is thrown by classes descended from WebRequest and WebResponse that implement pluggable protocols for accessing the Internet.
                obj.errorCode = "5";
                obj.response = HandleWebException(we);
                return obj;
               // return HandleWebException(we);
            }
            //Any other exception!
            catch (Exception e)
            {
                obj.errorCode = "6";
                obj.response = HandleException(e);
                return obj;
               // return HandleException(e);
            }

           
        }

        private static void SaveOrderState()
        {
            /*
             * This is where you store the order state in your system for
             * post-transaction analysis.  Information to store include the
             * invoice, the values of the reply fields, or the details of the
             * exception that occurred, if any.
             */
        }

        private static string ProcessReply(ReplyMessage reply)
        {
            string template = GetTemplate(reply.decision.ToUpper());
            string content = GetContent(reply , template);

            /*
             * Display result of transaction.  Being a console application,
             * this sample simply prints out some text on the screen.  Use
             * what is appropriate for your system (e.g. ASP.NET pages).
             */
            return content;
        }

        private static string GetTemplate(string decision)
        {
            /*
             * This is where you retrieve the HTML template that corresponds
             * to the decision.  This template has 'boiler-plate' wording and
             * can be stored in files or a database.  This is just one way to
             * retrieve feedback pages.  Use what is appropriate for your
             * system (e.g. ASP.NET pages).
             */

            if ("ACCEPT".Equals(decision))
            {
                return ("The transaction succeeded.{0}");
            }

            if ("REJECT".Equals(decision))
            {
                return ("Your order was not approved.{0}");
            }

            // ERROR
            return (
                "Your order could not be completed at this time.{0}" +
                "\nPlease try again later.");
        }

        private static string GetContent(ReplyMessage reply,string template)
        {
            /*
             * This is where you retrieve the content that will be plugged
             * into the template.
             * 
             * The strings returned in this sample are mostly to demonstrate
             * how to retrieve the reply fields.  Your application should
             * display user-friendly messages.
             */

            int reasonCode = int.Parse(reply.reasonCode);
            switch (reasonCode)
            {
                // Success
                case 100:
                    return (
                        "\nRequest ID: " + reply.requestID +
                        "\nAuthorization Code: " +
                            reply.ccAuthReply.authorizationCode +
                        "\nCapture Request Time: " +
                            reply.ccCaptureReply.requestDateTime +
                        "\nCaptured Amount: " +
                            reply.ccCaptureReply.amount);

                // Missing field(s)
                case 101:
                    return (
                        "\nThe following required field(s) are missing: " +
                        EnumerateValues(reply.missingField));

                // Invalid field(s)
                case 102:
                    return (
                        "\nThe following field(s) are invalid: " +
                        EnumerateValues(reply.invalidField));

                // Incorrect credit card details
                case 203:
                    return (
                        "\nIncorrect credit card details.  Please use a " +
                        "different card or select another form of payment.");

                // Insufficient funds
                case 204:
                    return (
                        "\nInsufficient funds in the account.  Please use a " +
                        "different card or select another form of payment.");

                // add additional reason codes here that you need to handle
                // specifically.

                default:
                    // For all other reason codes, return an empty string,
                    // in which case, the template will be displayed with no
                    // specific content.
                    return (template);
            }

            
        }

        private static string HandleException(Exception e)
        {
            string template = GetTemplate("ERROR");

            /*
             * The string returned in this sample is mostly to demonstrate
             * how to retrieve the exception properties.  Your application
             * should display user-friendly messages.
             */
            string content = String.Format(
                "\nAn Exception was returned with Message: '{0}'\n and Stack Trace:" +
                "'{1}'.", e.Message, e.StackTrace);

            return content;
        }

        private static string HandleSecurityException(MessageSecurityException e)
        {
            string template = GetTemplate("ERROR");

            /*
             * The string returned in this sample is mostly to demonstrate
             * how to retrieve the exception properties.  Your application
             * should display user-friendly messages.
             */
            string content = String.Format(
                "\nA Security exception was returned with message '{1}'.", e.Message);

            return content;
        }

        private static string HandleCryptoException(Exception e)
        {
            string template = GetTemplate("ERROR");

            /*
             * The string returned in this sample is mostly to demonstrate
             * how to retrieve the exception properties.  Your application
             * should display user-friendly messages.
             */
            string content = String.Format(
                "\nA Cryptographic error occurred. Check to make sure that you have a certificate (.p12) file at the location supplied in the configuration file.  Error Message:'{0}'\n\nStack Trace:" +
                "'{1}'.", e.Message, e.StackTrace);

            return content;
        }

        private static string HandleWebException(WebException we)
        {
            string template = GetTemplate("ERROR");

            /*
             * The string returned in this sample is mostly to demonstrate
             * how to retrieve the exception properties.  Your application
             * should display user-friendly messages.
             */
            string content = String.Format(
                "\nFailed to get a response with status '{0}' and " +
                "message '{1}'", we.Status, we.Message);

            return content;

            /* if (IsCriticalError(we))
            {
               
                 * The transaction may have been completed by CyberSource.
                 * If your request included a payment service, you should
                 * notify the appropriate department in your company (e.g. by
                 * sending an email) so that they can confirm if the request
                 * did in fact complete by searching the CyberSource Support
                 * Screens using the value of the merchantReferenceCode in
                 * your request.
                 
            }*/
        }

        private static string EnumerateValues(string[] array)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (string val in array)
            {
                sb.Append(val + "\n");
            }

            return (sb.ToString());
        }

        private static bool IsCriticalError(WebException we)
        {
            switch (we.Status)
            {
                case WebExceptionStatus.ProtocolError:
                    if (we.Response != null)
                    {
                        HttpWebResponse response
                            = (HttpWebResponse)we.Response;

                        // GatewayTimeout may be returned if you are
                        // connecting through a proxy server.
                        return (response.StatusCode ==
                            HttpStatusCode.GatewayTimeout);

                    }

                    // In case of ProtocolError, the Response property
                    // should always be present.  In the unlikely case 
                    // that it is not, we assume something went wrong
                    // along the way and to be safe, treat it as a
                    // critical error.
                    return (true);

                case WebExceptionStatus.ConnectFailure:
                case WebExceptionStatus.NameResolutionFailure:
                case WebExceptionStatus.ProxyNameResolutionFailure:
                case WebExceptionStatus.SendFailure:
                    return (false);

                default:
                    return (true);
            }
        }

       
    }
}
