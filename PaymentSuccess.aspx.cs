using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class PaymentSuccess : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["umail"] != null)
        {
            UpdateUserPayment(Request.QueryString["umail"]);
        }
    }

    public void UpdateUserPayment(string email)
    {
        SqlConnection con = new SqlConnection("Server=speedwell.arvixe.com;Database=canadiansoccerclub;User Id=mijamal;Password=2014db!@#$");
        SqlCommand cmd = new SqlCommand();

        string query = @"Update tblUser Set isPaidher=1 where Email='" + email + "'";

        cmd.CommandText = query;// "drop table tblUser";
        cmd.Connection = con;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        con.Dispose();
    }


}