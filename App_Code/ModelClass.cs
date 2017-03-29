using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ModelClass
/// </summary>
public class ModelClass
{
	public ModelClass()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string merchantReferenceCode { get; set; }
    public string merchantID { get; set; }

    public string firstName { get; set; }
    public string lastName { get; set; }
    public string street1 { get; set; }
    public string city { get; set; }
    public string state { get; set; }
    public string postalCode { get; set; }
    public string country { get; set; }
    public string email { get; set; }
    public string phoneNumber { get; set; }

    public string cardNumber { get; set; }
    public string expirationMonth { get; set; }
    public string expirationYear { get; set; }
    public string currency { get; set; }
    public string cardType { get; set; }

    public string cvn { get; set; }
    public string itemid1 { get; set; }
    public string unitPrice1 { get; set; }
    public string productName1 { get; set; }

    public string itemid2 { get; set; }
    public string unitPrice2 { get; set; }
    public string productName2 { get; set; }
    public string amount { get; set; }

    public string PaReq { get; set; }
    public string xid { get; set; }
    public string acsURL { get; set; }

    public string errorCode { get; set; }
    public string response { get; set; }


}