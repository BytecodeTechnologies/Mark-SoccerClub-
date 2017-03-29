using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["data"] != null)
        {
            ModelClass obj = new ModelClass();
            obj = (ModelClass)Session["data"];
            PAEnrollForm.Action = obj.acsURL;
            PaReq.Value = obj.PaReq;
            xid.Value = obj.xid;
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }
 
}