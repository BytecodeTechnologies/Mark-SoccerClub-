using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Security;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;

public partial class HersheysCentre : System.Web.UI.Page
{
    string PaymentAmount = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        GetPayments();
        BindGridForHersheyUsers();
    }
    public void BindGridForHersheyUsers()
    {
        SqlConnection con = new SqlConnection("Server=speedwell.arvixe.com;Database=canadiansoccerclub;User Id=mijamal;Password=2014db!@#$");

        SqlDataAdapter adp = new SqlDataAdapter();
        adp = new SqlDataAdapter("select * from tblUser where isher=1 and IsDeleted!=1", con);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        GridView2.DataSource = ds;
        GridView2.DataBind();
    }

    protected void btnRegSubmit_Click(object sender, ImageClickEventArgs e)
    {

        var CaptchaVerified = hidden.Value;
        if (CaptchaVerified != "")
        {
            try
            {
                SqlConnection con = new SqlConnection("Server=speedwell.arvixe.com;Database=canadiansoccerclub;User Id=mijamal;Password=2014db!@#$");
                SqlCommand cmd = new SqlCommand("Select PlayerID from tblUser where Email='" + tbRegEmail.Text + "' and isher=1 and IsDeleted=0", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        lblmsg.Text = "User with this Email is already exists. Please choose another Email.";
                    }
                }
                else
                {
                    SaveUser();
                }
                con.Close();
                cmd.Dispose();
            }
            catch (Exception cc)
            {
                Response.Write(cc.Message);
            }
        }
        else
        {
            lblmsg.Text = "Please verifiy the captcha.";
        }
    }

 

    public void SaveUser()
    {
        try
        {

            SqlConnection con = new SqlConnection("Server=speedwell.arvixe.com;Database=canadiansoccerclub;User Id=mijamal;Password=2014db!@#$");
            SqlCommand cmd = new SqlCommand();

            string query = @"insert into tblUser (PlayerID,Password,Fname,Sname,Email,Phone,Position,RoleID,isPaid,IsActive,IsDeleted,isPaid1,isher)
            values(" + "'" + "" + "','" + "" + "','" +
                                        tbFirstName.Text + "','" +
                                        tbSurname.Text + "','" +
                                        tbRegEmail.Text + "','" +
                                        tbRegPhoneNumber.Text + "','" +
                                        "" + "',2,0,0,0,0,1 )";

            cmd.CommandText = query;// "drop table tblUser";
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            lblRegMsg.Text = "Your Registration for Hershey Centre is still pending. Please pay $" + PaymentAmount + " fee to confirm your Registration.";
            BindGridForHersheyUsers();
            ClientScript.RegisterStartupScript(GetType(), "Javascript", "document.getElementById('abc').style.display = 'block'", true);

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    
    protected void btnPay_Click(object sender, EventArgs e)
    {
        string redirecturl = "";

        //Mention URL to redirect content to paypal site
        redirecturl += "https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_xclick&business=" + "mjamal@k12-solutions.com";


        redirecturl += "&first_name=" + tbFirstName.Text;

        redirecturl += "&item_name=" + "Hershey Centre";

        redirecturl += "&amount=" + "$" + PaymentAmount;

        redirecturl += "&quantity=1";

        redirecturl += "&return=http://canadiansoccerclub.com/PaymentSuccess.aspx?umail=" + tbRegEmail.Text;

        //Failed return page url
        redirecturl += "&cancel_return=http://canadiansoccerclub.com/PaymentError.aspx";

        Response.Redirect(redirecturl);
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(GetType(), "Javascript", "document.getElementById('abc').style.display = 'none'", true);

        string redirecturl = "";
        string amount = "$" + PaymentAmount;
        redirecturl += "https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_xclick&business=" + "mjamal@k12-solutions.com";
        redirecturl += "&first_name=" + tbFirstName.Text;
        redirecturl += "&item_name=HersheyCentre";
        redirecturl += "&amount=" + amount;
        redirecturl += "&quantity=1";
        redirecturl += "&return=http://canadiansoccerclub.com/PaymentSuccess.aspx?umail=" + tbRegEmail.Text;
        redirecturl += "&cancel_return=http://canadiansoccerclub.com/PaymentError.aspx";

        string senderID = "canadiansoccerclub@gmail.com";
        const string senderPassword = "Qwerty12345!";
        string subject = "Registration confirmation for Hershey Centre";
        string body = "Your Registration for Hershey Centre is still pending. Please pay $" + PaymentAmount + " fee to confirm your Registration.By clicking here   " + redirecturl;
        string toAddress = tbRegEmail.Text;
        try
        {
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new System.Net.NetworkCredential(senderID, senderPassword),
                Timeout = 30000,
            };
            MailMessage message = new MailMessage(senderID, toAddress, subject, body);
            smtp.Send(message);
            lblmsg.Text = "Your registration is still not completed. Please check your Email for complete registration.";
        }
        catch (Exception ex)
        {
            //result = "Error sending email.!!!";
        }
        //return result;

        tbFirstName.Text = "";
        tbSurname.Text = "";
        tbRegEmail.Text = "";
        tbRegPhoneNumber.Text = "";
    }


    public void GetPayments()
    {
        try
        {
            SqlConnection con = new SqlConnection("Server=speedwell.arvixe.com;Database=canadiansoccerclub;User Id=mijamal;Password=2014db!@#$");
            SqlCommand cmd = new SqlCommand("Select payment from tblSetting", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    PaymentAmount = dr["payment"].ToString();
                }
            }

            con.Close();
            cmd.Dispose();
        }
        catch (Exception cc)
        {
            Response.Write(cc.Message);
        }
    }
}