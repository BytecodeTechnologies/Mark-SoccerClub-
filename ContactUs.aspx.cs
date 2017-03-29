using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class ContactUs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection("Server=speedwell.arvixe.com;Database=canadiansoccerclub;User Id=mijamal;Password=2014db!@#$");
        SqlDataAdapter adp = new SqlDataAdapter("select * from tblSetting", con);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        lblContactus.Text = ds.Tables[0].Rows[0]["ContactUsTemplet"].ToString();
    }
}