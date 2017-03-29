using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
public partial class Saturday : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Server=speedwell.arvixe.com;Database=canadiansoccerclub;User Id=mijamal;Password=2014db!@#$");
    SqlCommand cmd = new SqlCommand();

    int NoOFPlayerReq = 0;

    public const string DateFormat = "dddd, MMMM dd, yyyy";

    public double DLHour = 0.0;
    protected void Page_Load(object sender, EventArgs e)
    {
        GetReqPlayers();
        if (Session["thu"] == null && Session["thursday"] == null && Session["sun"] == null && Session["fri"] == null)
        {
            Response.Redirect("option.aspx");
        }
        SqlDataAdapter adpd = new SqlDataAdapter("select PortNumber from mijamal.tblSetting", con);
        DataSet dsd = new DataSet();
        adpd.Fill(dsd);
        if (dsd.Tables[0].Rows[0][0].ToString().Trim() == "1")
        {          
            DLHour = -1.0;
        }
        else
        {           
            DLHour = 0;
        }

        DataSet ds = new DataSet();
        ds = (DataSet)Session["ds"];
        if (!IsPostBack)
        {
            if (ds.Tables[0].Rows[0]["RoleID"].ToString() == "2")
            {
                Session["email"] = "no";
                SqlDataAdapter adp = new SqlDataAdapter("select * from tblSetting", con);
                DataSet ds2 = new DataSet();
                adp.Fill(ds2);

                Int32 NoOfPalayerReq = Convert.ToInt32(ds2.Tables[0].Rows[0]["NoOfPalayerReq"]);
                adp = null;
                ds2 = null;

                adp = new SqlDataAdapter("select ID,UserId, Fname +' '+Sname +' ('+ PlayerID+ ')' as PName, CDate,IsPaid from tblPracticeConfirmSaturday where IsAttending=1 and IsDeleted=0 and IsOthers=0 and NextPDate='" + getNextPDate() + "'  order by CDate", con);

                ds2 = new DataSet();
                adp.Fill(ds2);

                lbPlayersAccepted.DataSource = ds2;
                lbPlayersAccepted.DataTextField = "PName";
                lbPlayersAccepted.DataValueField = "ID";
                lbPlayersAccepted.DataBind();


                adp = new SqlDataAdapter();

                Label41.Text = "Players that have confirmed attendance (after Thursday 12:00 PM)";
                adp = new SqlDataAdapter("select ID,UserId, Fname +' '+Sname +' ('+ PlayerID+ ')' as PName, CDate,IsPaid from tblPracticeConfirmSaturday where IsAttending=1 and IsDeleted=0 and isOthers=1 and NextPDate='" + getNextPDate() + "'  order by CDate", con);

                ds = new DataSet();
                adp.Fill(ds);

                lbOthersPlayersAccepted.DataSource = ds;
                lbOthersPlayersAccepted.DataTextField = "PName";
                lbOthersPlayersAccepted.DataValueField = "ID";
                lbOthersPlayersAccepted.DataBind();

                adp = null;
                ds2 = null;
                //string auery3 = "; select ID,UserId, Fname +' '+Sname +' ('+ PlayerID+ ')'+' - '+ convert(varchar(19),CDate) as PName, CDate from tblPracticeConfirmation  where IsDeleted=0 and NextPDate='" + getNextPDate() + "' and IsAttending =0";
                adp = new SqlDataAdapter();

                adp = new SqlDataAdapter("select ID,UserId, Fname +' '+Sname +' ('+ PlayerID+ ')'+' - '+ convert(varchar(19),CDate) as PName, CDate,IsPaid from tblPracticeConfirmSaturday where IsAttending=0 and IsConfirmed=1 and IsDeleted=0 and NextPDate='" + getNextPDate() + "'  order by CDate", con);

                ds = new DataSet();
                adp.Fill(ds);

                lbOthersPlayersRejected.DataSource = ds;
                lbOthersPlayersRejected.DataTextField = "PName";
                lbOthersPlayersRejected.DataValueField = "ID";
                lbOthersPlayersRejected.DataBind();



                Int32 totp = lbPlayersAccepted.Items.Count + lbOthersPlayersAccepted.Items.Count;

                lblTot2.Text = "Total Confirmed Players: " + (lbPlayersAccepted.Items.Count + lbOthersPlayersAccepted.Items.Count).ToString();
                string playername = ((DataSet)Session["ds"]).Tables[0].Rows[0]["Fname"].ToString() + " " + ((DataSet)Session["ds"]).Tables[0].Rows[0]["Sname"].ToString() + " (" + ((DataSet)Session["ds"]).Tables[0].Rows[0]["PlayerID"].ToString() + ")";



                if (NoOFPlayerReq > totp)
                {
                    string day = DateTime.UtcNow.AddHours(-4.0).AddHours(DLHour).DayOfWeek.ToString();


                    if ((day == "Thursday" && DateTime.UtcNow.AddHours(-4.0).AddHours(DLHour).Hour >= 12) || day == "Friday")
                    {
                        rbYes.Enabled = true;
                        rbNo.Enabled = true;
                        lbInvitationStatus.Text = playername + " , the next practice will be on the " + Convert.ToDateTime(getNextPDate()).ToLongDateString() + ". Will you be attending?";
                    }
                    else
                    {
                        if (Convert.ToBoolean(((DataSet)Session["ds"]).Tables[0].Rows[0]["ispaidsat"]) == false)
                        {
                            rbYes.Enabled = false;
                            rbNo.Enabled = false;
                            lbInvitationStatus.Text = "Thank you for your interest in playing with us on " + Convert.ToDateTime(getNextPDate()).ToLongDateString() + ". Please allow the Paid Players to confirm attendance until Thursday Noon 12:00 PM. Login anytime after that to confirm and if there are free places you can confirm then if you want to attend..";
                            lbInvitationStatus.ForeColor = System.Drawing.Color.Red;

                            string st = "Thank you for your interest in playing with us. Please login on " + Convert.ToDateTime(getNextPDate()).AddDays(1.0).ToLongDateString() + " to confirm if you want to attend.";

                        }
                        else
                        {
                            rbYes.Enabled = true;
                            rbNo.Enabled = true;
                            lbInvitationStatus.Text = playername + " , the next practice will be on the " + Convert.ToDateTime(getNextPDate()).ToLongDateString() + ". Will you be attending?";
                        }

                    }
                }
                else
                {
                    rbYes.Enabled = false;
                    rbYes.Visible = false;
                    lbInvitationStatus.Text = "Thank you for your interest in playing with us. We have reached the maximum number of players for this Friday. If you are a paid player, please log in earlier (before Thursday 12:00 PM) If you are a non-paid player log in anytime  after Thursday 12:00 PM and a spot will be reserved for you based on availability.";

                }

            }
            



        }

    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        lblTime.Text = DateTime.UtcNow.AddHours(-4.00).AddHours(DLHour).ToLongDateString() + " " + DateTime.UtcNow.AddHours(-4.00).AddHours(DLHour).ToLongTimeString();
    }
    protected void rbYes_CheckedChanged(object sender, EventArgs e)
    {
        DataSet ds = (DataSet)Session["ds"];
        string emailmsg = "";
        Int32 ispaidm = 0;

        if (Convert.ToBoolean(ds.Tables[0].Rows[0]["ispaidsat"]))
        {
            ispaidm = 1;
        }
        else
        {
            ispaidm = 0;
        }
        string table = "tblPracticeConfirmSaturday";
       
        SqlDataAdapter adp1 = new SqlDataAdapter("select * from " + table + @" where IsDeleted=0 and UserId='" + ds.Tables[0].Rows[0]["UserId"].ToString() + "' and NextPDate='" + getNextPDate() + "'", con);
        DataSet ds2 = new DataSet();
        adp1.Fill(ds2);        
      
         string day = DateTime.UtcNow.AddHours(-4.0).AddHours(DLHour).DayOfWeek.ToString();
         string IsOthers = "";

         if ((day == "Thursday" && DateTime.UtcNow.AddHours(-4.0).AddHours(DLHour).Hour >= 12) || day == "Friday")
         {
             IsOthers = "1";
           //  cmd.CommandText = @"update " + table + @" set  IsAttending =1,IsOthers=1 where NextPDate='" + getNextPDate() + "' and UserId=" + ds.Tables[0].Rows[0]["UserId"].ToString();
         }
         else
         {
             IsOthers = "0";
           //  cmd.CommandText = @"update " + table + @" set  IsAttending =1,IsOthers=0 where NextPDate='" + getNextPDate() + "' and UserId=" + ds.Tables[0].Rows[0]["UserId"].ToString();
         }
            
        SqlDataAdapter adp = new SqlDataAdapter("select * from tblSetting", con);
        DataSet ds22 = new DataSet();
        adp.Fill(ds22);

        Int32 NoOfPalayerReq = Convert.ToInt32(ds22.Tables[0].Rows[0]["NoOfPalayerReq"]);
        adp = null;
        ds22 = null;

        //adp = new SqlDataAdapter("select Count(*) from " + table + " where IsAttending=1 and IsDeleted=0 and IsOthers=0 and NextPDate='" + getNextPDate() + "'", con);
        adp = new SqlDataAdapter("select Count(*) from " + table + " where IsAttending=1 and IsDeleted=0 and NextPDate='" + getNextPDate() + "'", con);
        DataSet ds222 = new DataSet();
        adp.Fill(ds222);

        if (NoOfPalayerReq > Convert.ToInt32(ds222.Tables[0].Rows[0][0]))
        {
            //cmd.Connection = con;
            //con.Open();
            //cmd.ExecuteNonQuery();
            //con.Close();    
            string s = "delete from " + table + " where userid=" + ds.Tables[0].Rows[0]["UserId"].ToString() + " and NextPDate='" + getNextPDate() + "'";
            cmd.CommandText = s + @"; insert into " + table + @" (UserId,NextPDate,IsAttending,IsConfirmed,
CDate,Fname,Sname,PlayerID,IsPaid,IsOthers,IsDeleted)
values ('" + ds.Tables[0].Rows[0]["UserId"].ToString() + "','" + getNextPDate() + "','" + 1 + "','" + 1 + "','" +
           DateTime.UtcNow.AddHours(-4.0).AddHours(DLHour) + "','" + ds.Tables[0].Rows[0]["Fname"].ToString() + "','" +
           ds.Tables[0].Rows[0]["Sname"].ToString() + "','" + ds.Tables[0].Rows[0]["PlayerID"].ToString() + "'," + ispaidm + "," + IsOthers + ",0)";

            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


            lblmsginv.Text = "Attendence confirmation status is updated";


            SqlDataAdapter adp3 = new SqlDataAdapter("select * from tblSetting", con);
            DataSet ds3 = new DataSet();
            adp3.Fill(ds3);

            emailmsg = ds3.Tables[0].Rows[0]["CETempletSat"].ToString();

            emailmsg = emailmsg.Replace("{PlayerName}", ((DataSet)Session["ds"]).Tables[0].Rows[0]["FName"].ToString());
            emailmsg = emailmsg.Replace("{ConfirmedDate}", DateTime.UtcNow.AddHours(-4.0).AddHours(DLHour).ToLongDateString());
            emailmsg = emailmsg.Replace("{PracticeDate}", Convert.ToDateTime(getNextPDate()).ToLongDateString());

            if (Session["email"].ToString() == "no")
            {
                MailMessage ms = new MailMessage("admin@canadiansoccerclub.com", ((DataSet)Session["ds"]).Tables[0].Rows[0]["Email"].ToString(), "Canadian Soccer Practice Attendance Confirmation", emailmsg);
                SmtpClient smtp = new SmtpClient("canadiansoccerclub.com");
                smtp.Credentials = new System.Net.NetworkCredential("admin@canadiansoccerclub.com", "&#24Service");
                smtp.EnableSsl = false;
                ms.IsBodyHtml = true;
                smtp.Send(ms);
                Session["email"] = "yes";
            }
            Response.Redirect("option.aspx?done=sat");
        }
        else
        {
            Response.Redirect("option.aspx?done=no");
        }
        
        }
  

    protected void rbNo_CheckedChanged(object sender, EventArgs e)
    {

        DataSet ds = (DataSet)Session["ds"];
        string table = string.Empty;

        table = "tblPracticeConfirmSaturday";
      
        SqlDataAdapter adp1 = new SqlDataAdapter("select * from " + table + " where IsDeleted=0 and UserId=" + ds.Tables[0].Rows[0]["UserId"].ToString() + " and NextPDate='" + getNextPDate() + "'", con);
        DataSet ds2 = new DataSet();
        adp1.Fill(ds2);
        if (ds2.Tables[0].Rows.Count > 0)
        {
            cmd.CommandText = @"update " + table + " set IsAttending=0, Cdate='" + DateTime.UtcNow.AddHours(-4.0).AddHours(DLHour) + "' where IsDeleted=0 and NextPDate='" + getNextPDate() + "' and UserId=" + ds.Tables[0].Rows[0]["UserId"].ToString();
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        else
        {
            Int32 ispaidm1 = 0;
           
                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["ispaidsat"]))
                {
                    ispaidm1 = 1;
                }
                else
                {
                    ispaidm1 = 0;
                }

             //   string s = "delete from " + table + " where userid=" + ds.Tables[0].Rows[0]["UserId"].ToString() + " and NextPDate='" + getNextPDate() + "'";
            cmd.CommandText = @"; insert into " + table + @" (UserId,NextPDate,IsAttending,IsConfirmed,
CDate,Fname,Sname,PlayerID,IsPaid,IsDeleted)
values ('" + ds.Tables[0].Rows[0]["UserId"].ToString() + "','" + getNextPDate() + "','" + 0 + "','" + 1 + "','" +
           DateTime.UtcNow.AddHours(-4.0).AddHours(DLHour) + "','" + ds.Tables[0].Rows[0]["Fname"].ToString() + "','" +
           ds.Tables[0].Rows[0]["Sname"].ToString() + "','" + ds.Tables[0].Rows[0]["PlayerID"].ToString() + "'," + ispaidm1 + ",0)";

            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        lblmsginv.Text = "Attendence confirmation status is updated";


        SqlDataAdapter adp3 = new SqlDataAdapter("select * from tblSetting", con);
        DataSet ds3 = new DataSet();
        adp3.Fill(ds3);
        String emailmsg = ds3.Tables[0].Rows[0]["DETemplet"].ToString();
        emailmsg = emailmsg.Replace("{PlayerName}", ((DataSet)Session["ds"]).Tables[0].Rows[0]["FName"].ToString());
        emailmsg = emailmsg.Replace("{ConfirmedDate}", DateTime.UtcNow.AddHours(-4.0).AddHours(DLHour).ToLongDateString());
        emailmsg = emailmsg.Replace("{PracticeDate}", Convert.ToDateTime(getNextPDate()).ToLongDateString());

        if (Session["email"].ToString() == "no")
        {

            MailMessage ms = new MailMessage("admin@canadiansoccerclub.com", ((DataSet)Session["ds"]).Tables[0].Rows[0]["Email"].ToString(), "Canadian Soccer Practice Attendance Confirmation", emailmsg);
            SmtpClient smtp = new SmtpClient("canadiansoccerclub.com");
            smtp.Credentials = new System.Net.NetworkCredential("admin@canadiansoccerclub.com", "&#24Service");
            smtp.EnableSsl = false;
            ms.IsBodyHtml = true;
            smtp.Send(ms);
            Session["email"] = "yes";
        }

        Response.Redirect("option.aspx?done=sat");

    }
   
    public string getNextPDate()
    {
        double days = 0.0;
        string day = DateTime.UtcNow.AddHours(-4.0).AddHours(DLHour).DayOfWeek.ToString();
        if (Session["fri"] != null)
        {
            if (day == "Monday")
            {
                days = 4.0;// 3.0;
            }
            if (day == "Tuesday")
            {
                days = 3.0;// 2.0;
            }
            if (day == "Wednesday")
            {
                days = 2.0;// 1.0;
            }
            if (day == "Thursday")
            {
                days = 1.0;// 0.0;
            }
            if (day == "Friday")
            {
                days = 0.0;// 6.0;
            }
            if (day == "Saturday")
            {
                days = 6.0;// 5.0;
            }
            if (day == "Sunday")
            {
                days = 5.0;// 4.0;
            }       
        
        }

       // if ((day == "Thursday" && DateTime.UtcNow.AddHours(-4.0).AddHours(DLHour).Hour >= 12) || day == "Friday")
       // {
           // return DateTime.UtcNow.AddHours(-4.0).AddHours(DLHour).ToShortDateString();
      //  }
        //else
        //{
            return DateTime.UtcNow.AddHours(-4.0).AddHours(DLHour).AddDays(days).ToShortDateString();
        //}

        
    }


    public void GetReqPlayers()
    {
        try
        {

            SqlCommand cmd = new SqlCommand("Select NoOfPalayerReq from mijamal.tblSetting", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    NoOFPlayerReq = Convert.ToInt32(dr["NoOfPalayerReq"].ToString());
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