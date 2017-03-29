using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection("Server=speedwell.arvixe.com;Database=canadiansoccerclub;User Id=mijamal;Password=&#24Service");
        if (Request.QueryString["id"] != null)
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from " + Request.QueryString["id"].ToString(), con);
            //SqlDataAdapter adp = new SqlDataAdapter("select * from tblUser", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            gv.DataSource = ds;
            gv.DataBind();
        }
        else
        {
            MailMessage mail = new MailMessage();
            mail.To.Add("ask@spaceonelr.com");
            mail.From = new MailAddress("ask@spaceonelr.com");
            mail.Subject = "Test email. Email Date: " + DateTime.Now.ToString();
            mail.Body = "hi anil how are you. thank deepak";

            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "mail.spaceonelr.com";
            smtp.Credentials = new System.Net.NetworkCredential("ask@spaceonelr.com", "deep@33");
            // smtp.EnableSsl = true;

            smtp.Send(mail);
        }

    }
}