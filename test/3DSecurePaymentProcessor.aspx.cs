using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CyberSource.Clients.SoapWebReference;
using System.Text;
using CyberSource.Clients;

public partial class _3DSecurePaymentProcessor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Result = VarifyResponseData();
        if (Result != "")
        {
            string[] ArrayData = Result.Split(',');
            ProcessPayment(ArrayData);
        }
        else
        {
            //error;
        }
    }

    public string VarifyResponseData()
    {
        ModelClass obj = new ModelClass();
        obj = (ModelClass)Session["data"];

        string msg = Request["PARes"].ToString();
        RequestMessage request = new RequestMessage();
        request.payerAuthValidateService = new PayerAuthValidateService();
        request.payerAuthValidateService.run = "true";
        request.merchantID = obj.merchantID;


        // add required fields
        request.merchantReferenceCode = obj.merchantReferenceCode;
        string s = msg;
        StringBuilder output = new StringBuilder(s.Length);
        for (int index = 0; index < s.Length; index++)
        {
            if (!Char.IsWhiteSpace(s, index))
            {
                output.Append(s[index]);
            }
        }
        s = output.ToString();
        request.payerAuthValidateService.signedPARes = msg;       

        try
        {
            ReplyMessage reply = SoapClient.RunTransaction(request);

            return reply.payerAuthValidateReply.paresStatus + "," + reply.payerAuthValidateReply.xid + "," + reply.payerAuthValidateReply.commerceIndicator + "," + reply.payerAuthValidateReply.eciRaw + "," + reply.payerAuthValidateReply.cavv + "," + reply.payerAuthValidateReply.ucafAuthenticationData + "," + reply.payerAuthValidateReply.ucafCollectionIndicator+"," + reply.payerAuthValidateReply.ucafAuthenticationData;

        }
        catch (Exception ex)
        {
            return "";
        }
    }

    public void ProcessPayment( string[] ArrayData)
        //string paresStatus0, string xid1, string commerceIndicator2, string eciRaw3, string cavv4, string cavvAlgorithm5, string collectionIndicator6, string ucafAuthenticationData7)
    {
       
        RequestMessage request = new RequestMessage();
        request.ccAuthService = new CCAuthService();
        request.ccAuthService.run = "true";

        request.ccAuthService.paresStatus = ArrayData[0].ToString();
        request.ccAuthService.xid = ArrayData[1].ToString();
        request.ccAuthService.commerceIndicator = ArrayData[2].ToString();      

        request.ccAuthService.eciRaw = ArrayData[3].ToString();
        request.ccAuthService.cavv = ArrayData[4].ToString();
        request.ccAuthService.cavvAlgorithm = ArrayData[5].ToString();

        request.ucaf = new UCAF();
        request.ucaf.collectionIndicator = ArrayData[6].ToString();
        request.ucaf.authenticationData = ArrayData[7].ToString();

        ModelClass obj = new ModelClass();
        obj = (ModelClass)Session["data"];
        request.merchantReferenceCode = obj.merchantReferenceCode;

        BillTo billTo = new BillTo();
        billTo.firstName = obj.firstName;
        billTo.lastName = obj.lastName;
        billTo.street1 = obj.street1;
        billTo.city = obj.city;
        billTo.state = obj.state;
        billTo.postalCode = obj.postalCode;
        billTo.country = obj.country;
        billTo.email = obj.email;
        billTo.phoneNumber = obj.phoneNumber;
        billTo.ipAddress = GetUserIP().Trim();
        request.billTo = billTo;

        Card card = new Card();
        card.accountNumber = obj.cardNumber;
        card.expirationMonth = obj.expirationMonth;
        card.expirationYear = obj.expirationYear;
        card.cvNumber = obj.cvn;
        card.cardType = obj.cardType;
        request.card = card;

        PurchaseTotals purchaseTotals = new PurchaseTotals();
        purchaseTotals.currency = "USD";
        purchaseTotals.grandTotalAmount = "1";
        request.purchaseTotals = purchaseTotals;

    
        request.item = new Item[1];
        Item item = new Item();
        item.id = "0";
        item.productName = "Test Product for testing on production";
        item.unitPrice = "1.00";
        request.item[0] = item;

        try
        {
            ReplyMessage reply = SoapClient.RunTransaction(request);
            lbl.Text = "Transaction Status: " + reply.decision + "<br/>" + "Request ID: " + reply.requestID  ;
            // return reply.payerAuthValidateReply.paresStatus + "," + reply.payerAuthValidateReply.xid + "," + reply.payerAuthValidateReply.commerceIndicator + "," + reply.payerAuthValidateReply.eciRaw + "," + reply.payerAuthValidateReply.cavv + "," + reply.payerAuthValidateReply.ucafAuthenticationData + "," + reply.payerAuthValidateReply.commerceIndicator;

        }
        catch (Exception ex)
        {

        }
    }

    protected string GetUserIP()
    {
        string VisitorsIPAddr = string.Empty;
        if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
        {
            VisitorsIPAddr = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
        }
        else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
        {
            VisitorsIPAddr = HttpContext.Current.Request.UserHostAddress;
        }
        return VisitorsIPAddr;
    }
}