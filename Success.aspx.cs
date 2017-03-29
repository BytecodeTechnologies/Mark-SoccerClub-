using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Success : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["reg"] != null)
        {
            lblContactus.Text = "You are already registered with us. Please <a href='Default.aspx' style='color:Red'><b>Click Here<b/></a> to login.";
        }
    }
}