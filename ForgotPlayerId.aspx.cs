using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net.Mail;
using System.Data.SqlClient;


public partial class forgotplayerid : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Server=speedwell.arvixe.com;Database=canadiansoccerclub;User Id=mijamal;Password=2014db!@#$");
    SqlCommand cmd = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSumbit_Click(object sender, EventArgs e)
    {
        try
        {
            SqlDataAdapter adp = new SqlDataAdapter();
            adp = new SqlDataAdapter("select PlayerId from tblUser where Email='" + tbUserLogInId.Text + "'", con);
           DataSet ds = new DataSet();
            adp.Fill(ds);

            MailMessage ms = new MailMessage("admin@canadiansoccerclub.com", tbUserLogInId.Text, "Your Player ID", "Hi,<br/><br/>Your Player ID is - " + ds.Tables[0].Rows[0]["PlayerId"].ToString() + "<br/><br/>Regards,<br/>Canadian Soccer Club");
            SmtpClient smtp = new SmtpClient("canadiansoccerclub.com");
            smtp.Credentials = new System.Net.NetworkCredential("admin@canadiansoccerclub.com", "2014db!@#$");
            smtp.EnableSsl = false;
            ms.IsBodyHtml = true;
            smtp.Send(ms);
            lblmsg.Text = "Player ID have been sent to "+tbUserLogInId.Text;
            tbUserLogInId.Text = "";
            lblmsg.ForeColor = System.Drawing.Color.Red;
            //txtTitle.Text = "";
            //txtname.Text = "";
            //txtemailid.Text = "";
            //txtDescription.Text = "";
        }
        catch (Exception ex)
        {

            Response.Write(ex.Message);
        }
    }
}