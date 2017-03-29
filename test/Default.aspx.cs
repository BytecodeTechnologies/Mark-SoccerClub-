using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CyberSource;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write(Request.PhysicalApplicationPath.ToString());
    }

    protected void btnpay_Click(object sender, EventArgs e)
    {
        SoapRequest obj = new SoapRequest();
        ModelClass objModel = new ModelClass();
        objModel.firstName = firstname.Value;
        objModel.lastName = lastname.Value;
        objModel.email = email.Value;
        objModel.phoneNumber = phone.Value;
        objModel.street1 = address.Value;
        objModel.city = city.Value;
        objModel.state = state.Value;
        objModel.postalCode = postcode.Value;
        objModel.country = country.Value;
        objModel.cardNumber = cardnumber.Value;
        objModel.expirationMonth = expmonth.Value;
        objModel.expirationYear = expyear.Value;
        objModel.cardType = cardtype.Value;
        objModel.cvn = secure.Value;       
        objModel.merchantID = merchantID.Value;
        objModel.merchantReferenceCode = Guid.NewGuid().ToString();
        objModel = obj.SendSoapRequest(objModel);
        Session["data"] = objModel;

        if (objModel.errorCode == "0")
        {
            if (objModel.acsURL != null)
            {
                Response.Redirect("3DSecureAuthentication.aspx");
            }
            else
            {
                Response.Redirect("PaymentProcessor.aspx");
            }
        }
        else
        {
            lblresult.Text = objModel.response;
        }

    }
}