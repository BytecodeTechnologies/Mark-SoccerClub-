using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CyberSource.Clients.SoapWebReference;
using CyberSource.Clients;

public partial class PaymentProsessor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ProcessPayment();
    }
    public void ProcessPayment()
    {
        ModelClass obj = new ModelClass();
        obj = (ModelClass)Session["data"];

        RequestMessage request = new RequestMessage();
        request.ccAuthService = new CCAuthService();
        request.ccAuthService.run = "true";

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

            lbl.Text = "Transaction Status: " + reply.decision + "<br/>" + "Request ID: " + reply.requestID;
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