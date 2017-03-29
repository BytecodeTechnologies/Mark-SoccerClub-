using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;

public partial class confirmplayer : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Server=speedwell.arvixe.com;Database=canadiansoccerclub;User Id=mijamal;Password=2014db!@#$");
    SqlCommand cmd = new SqlCommand();

    public const string DateFormat = "dddd, MMMM dd, yyyy";


    #region Handlers

    protected void cldrPracticeDate_DayRender(object sender, DayRenderEventArgs e)
    {
        e.Day.IsSelectable = false;
    }
    protected void bindProfile()
    {
        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter("select * from tblUser where UserId=" + ((DataSet)Session["ds"]).Tables[0].Rows[0]["UserId"].ToString(), con);
        adp.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lbRegistrationNo.Text = ds.Tables[0].Rows[0][0].ToString();
            tbUserId.Text = ds.Tables[0].Rows[0][1].ToString();
            tbPassword.Text = ds.Tables[0].Rows[0][2].ToString();
            tbFirstName.Text = ds.Tables[0].Rows[0][3].ToString();
            tbSurname.Text = ds.Tables[0].Rows[0][4].ToString();
            tbEMailAddress.Text = ds.Tables[0].Rows[0][5].ToString();
            tbPhoneNumber.Text = ds.Tables[0].Rows[0][6].ToString();
            chkThu.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["tuesday"]);
            chksun.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Sunday"]);

            ddlPosition.Items.FindByText(ds.Tables[0].Rows[0][7].ToString()).Selected = true;
            if (Convert.ToBoolean(ds.Tables[0].Rows[0]["IsPaid"]))
            {
                lbLevel.Text = "Paid Player";
            }
            else
            {
                lbLevel.Text = "Registered Player";
            }
        }
    }
    protected void rbtnSunday_CheckedChanged(object sender, EventArgs e)
    {
        mvMain.ActiveViewIndex = 3;
        // Response.Redirect("Main.aspx?action=confirmation");
        // mvMain.ActiveViewIndex = 3;
        //  Response.Redirect("main.aspx?match=s");
    }
    protected void rbtnThursday_CheckedChanged(object sender, EventArgs e)
    {
        mvMain.ActiveViewIndex = 3;
        Session["thu"] = "true";

    }
    protected void rbl1_SelectedIndexChanged(object sender, EventArgs e)
    {


        mvMain.ActiveViewIndex = 4;
        SqlDataAdapter adp = new SqlDataAdapter();

        if (rbl1.SelectedIndex == 0)
        {
            adp = new SqlDataAdapter(@"select distinct top 50 convert(varchar(20), convert(datetime, NextPDate, 110),101)as
                NextPDate ,
                RIGHT('0'+ LTRIM(STR(MONTH(NextPDate))), 2) as months,
                LTRIM(STR(YEAR(NextPDate))) as years
                from tblPracticeConfirmation1 group by NextPDate order by years desc, months desc, NextPDate desc ", con);
        }
        if (rbl1.SelectedIndex == 1)
        {
            adp = new SqlDataAdapter(@"select distinct top 50 convert(varchar(20), convert(datetime, NextPDate, 110),101)as
                NextPDate ,
                RIGHT('0'+ LTRIM(STR(MONTH(NextPDate))), 2) as months,
                LTRIM(STR(YEAR(NextPDate))) as years
                from tblPracticeConfirmation group by NextPDate order by years desc, months desc, NextPDate desc ", con);

        }
        if (rbl1.SelectedIndex == 2)
        {
            adp = new SqlDataAdapter(@"select distinct top 50 convert(varchar(20), convert(datetime, NextPDate, 110),101)as
                NextPDate ,
                RIGHT('0'+ LTRIM(STR(MONTH(NextPDate))), 2) as months,
                LTRIM(STR(YEAR(NextPDate))) as years
                from tblPracticeConfirmation2 group by NextPDate order by years desc, months desc, NextPDate desc ", con);

        }

        DataSet ds = new DataSet();
        adp.Fill(ds);


        lbPastConfirmedUsers.DataBind();
        lbPastFixtureDates.DataSource = ds;
        lbPastFixtureDates.DataTextField = "NextPDate";
        lbPastFixtureDates.DataValueField = "NextPDate";
        lbPastFixtureDates.DataBind();
    }

    protected void rb_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rb.SelectedIndex == 2)
        {
            rbThu_SelectedIndexChanged();
        }
        else
        {
            bindUser(); bindUser1();
        }
    }
    protected void rbThu_SelectedIndexChanged()
    {
        SqlDataAdapter adp;
        SqlDataAdapter adp1;
        SqlDataAdapter adp2;


        adp = new SqlDataAdapter("select UserId,isnew, Fname+' '+Sname+' ('+PlayerID+')' as PlayerName from tblUser where isNew=0 and IsDeleted=0 and RoleID=2 and thursday=1 and isPaid2=0 order by isnew desc", con);
        DataSet ds1 = new DataSet();
        adp.Fill(ds1);
        lbUnselectedUsers.DataSource = ds1;
        lbUnselectedUsers.DataValueField = "UserId";
        lbUnselectedUsers.DataTextField = "PlayerName";
        lbUnselectedUsers.DataBind();

        adp1 = new SqlDataAdapter("select UserId,isnew, Fname+' '+Sname+' ('+PlayerID+')' as PlayerName from tblUser where isNew=1 and thursday=1  and IsDeleted=0 and RoleID=2  order by isnew desc", con);
        DataSet ds2 = new DataSet();
        adp1.Fill(ds2);
        lbUnselectedUsers1.DataSource = ds2;
        lbUnselectedUsers1.DataValueField = "UserId";
        lbUnselectedUsers1.DataTextField = "PlayerName";
        lbUnselectedUsers1.DataBind();


        adp2 = new SqlDataAdapter("select UserId,isnew, Fname+' '+Sname+' ('+PlayerID+')' as PlayerName from tblUser where thursday=1 and IsDeleted=0 and isPaid2=1 order by isnew desc", con);
        DataSet ds3 = new DataSet();
        adp2.Fill(ds3);
        lbPlayers.DataSource = ds3;
        lbPlayers.DataValueField = "UserId";
        lbPlayers.DataTextField = "PlayerName";
        lbPlayers.DataBind();


    }
    protected void rbtnOLDNEW_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindUser(); bindUser1();
    }


    protected void rbl2_SelectedIndexChanged(object sender, EventArgs e)
    {
        mvMain.ActiveViewIndex = 5;
        //lbPlayersConfirmingAttendance

        SqlDataAdapter adp = new SqlDataAdapter();

        if (rbl2.SelectedIndex == 0)
        {
            Session["thu"] = "true";
            adp = new SqlDataAdapter("select ID,UserId, Fname +' '+Sname +' ('+ PlayerID+ ')' as PName, CDate,IsPaid from tblPracticeConfirmation1 where IsAttending=1 and IsDeleted=0 and IsOthers=0 and NextPDate='" + getNextPDate() + "'  order by CDate", con);
            Session["thu"] = null;
        }
        if (rbl2.SelectedIndex == 1)
        {
            adp = new SqlDataAdapter("select ID,UserId, Fname +' '+Sname +' ('+ PlayerID+ ')' as PName, CDate,IsPaid from tblPracticeConfirmation where IsAttending=1 and IsDeleted=0 and IsOthers=0 and NextPDate='" + getNextPDate() + "'  order by CDate", con);

        }
        if (rbl2.SelectedIndex == 2)
        {
            adp = new SqlDataAdapter("select ID,UserId, Fname +' '+Sname +' ('+ PlayerID+ ')' as PName, CDate,IsPaid from tblPracticeConfirmation2 where IsAttending=1 and IsDeleted=0 and IsOthers=0 and NextPDate='" + getNextPDate() + "'  order by CDate", con);

        }

        DataSet ds = new DataSet();
        adp.Fill(ds);

        lbPlayersConfirmingAttendance.DataSource = ds;
        lbPlayersConfirmingAttendance.DataTextField = "PName";
        lbPlayersConfirmingAttendance.DataValueField = "ID";
        lbPlayersConfirmingAttendance.DataBind();
        adp = null;


        if (rbl2.SelectedIndex == 0)
        {
            Session["thu"] = "true";
            adp = new SqlDataAdapter("select ID,UserId, Fname +' '+Sname +' ('+ PlayerID+ ')'+' - '+ convert(varchar(19),CDate) as PName, CDate,IsPaid from tblPracticeConfirmation1 where IsAttending=0 and IsDeleted=0 and NextPDate='" + getNextPDate() + "'  order by CDate", con);
            Session["thu"] = null;
        }
        if (rbl2.SelectedIndex == 1)
        {
            adp = new SqlDataAdapter("select ID,UserId, Fname +' '+Sname +' ('+ PlayerID+ ')'+' - '+ convert(varchar(19),CDate) as PName, CDate,IsPaid from tblPracticeConfirmation where IsAttending=0 and IsDeleted=0 and NextPDate='" + getNextPDate() + "'  order by CDate", con);
        }
        if (rbl2.SelectedIndex == 2)
        {
            adp = new SqlDataAdapter("select ID,UserId, Fname +' '+Sname +' ('+ PlayerID+ ')'+' - '+ convert(varchar(19),CDate) as PName, CDate,IsPaid from tblPracticeConfirmation2 where IsAttending=0 and IsDeleted=0 and NextPDate='" + getNextPDate() + "'  order by CDate", con);
        }

        DataSet ds1 = new DataSet();
        adp.Fill(ds1);

        lbPlayersRejectingAttendance.DataSource = ds1;
        lbPlayersRejectingAttendance.DataTextField = "PName";
        lbPlayersRejectingAttendance.DataValueField = "ID";
        lbPlayersRejectingAttendance.DataBind();


        adp = null;

        adp = new SqlDataAdapter();
        if (rbl2.SelectedIndex == 0)
        {
            Session["thu"] = "true";
            adp = new SqlDataAdapter("select ID,UserId, Fname +' '+Sname +' ('+ PlayerID+ ')' as PName, CDate,IsPaid from tblPracticeConfirmation1 where IsAttending=1 and IsDeleted=0 and IsOthers=1 and NextPDate='" + getNextPDate() + "'  order by CDate", con);
            Session["thu"] = null;
        }
        if (rbl2.SelectedIndex == 1)
        {
            adp = new SqlDataAdapter("select ID,UserId, Fname +' '+Sname +' ('+ PlayerID+ ')' as PName, CDate,IsPaid from tblPracticeConfirmation where IsAttending=1 and IsDeleted=0 and IsOthers=1 and NextPDate='" + getNextPDate() + "'  order by CDate", con);
        }
        if (rbl2.SelectedIndex == 2)
        {
            adp = new SqlDataAdapter("select ID,UserId, Fname +' '+Sname +' ('+ PlayerID+ ')' as PName, CDate,IsPaid from tblPracticeConfirmation2 where IsAttending=1 and IsDeleted=0 and IsOthers=1 and NextPDate='" + getNextPDate() + "'  order by CDate", con);
        }

        //adp = new SqlDataAdapter("select ID,UserId, Fname +' '+Sname +' ('+ PlayerID+ ')' as PName, CDate from tblPracticeConfirmation where IsDeleted=0 and NextPDate='" + getNextPDate() + "' and isOthers=1 and IsAttending=1", con);
        DataSet ds2 = new DataSet();
        adp.Fill(ds2);

        lbOtherUsersConfirmingAttendance.DataSource = ds2;
        lbOtherUsersConfirmingAttendance.DataTextField = "PName";
        lbOtherUsersConfirmingAttendance.DataValueField = "ID";
        lbOtherUsersConfirmingAttendance.DataBind();
        lblTotPlayer.Text = "Total Players: " + (lbPlayersConfirmingAttendance.Items.Count + lbOtherUsersConfirmingAttendance.Items.Count).ToString();


    }


    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        if (!IsPostBack)
        {
            Session["email"] = "no";
            Session["emails"] = "no";
            if (Session["ds"] != null)
            {
                ds = (DataSet)Session["ds"];
                ListItem lstitem = new ListItem();
                lstitem.Text = "";
                lstitem.Value = "";
                // ddlPosition.Items.Add(new ListItem("Select Position", "0"));
                ddlPosition.Items.Add(new ListItem("Defender", "1"));
                ddlPosition.Items.Add(new ListItem("Forward", "2"));
                ddlPosition.Items.Add(new ListItem("Goalie", "3"));
                ddlPosition.Items.Add(new ListItem("Midfielder", "4"));
                ddlPosition.Items.Add(new ListItem("Striker", "5"));
                ddlPosition.Items.Add(new ListItem("Sweeper", "6"));

                string[] controls = { "Tuesday Soccer", "Sunday Soccer", "Thursday Soccer" };
                rbl1.DataSource = controls;
                rbl1.DataBind();
                //rbl1.Items[1].Text = "Sunday Soccer";
                rbl1.SelectedIndex = 1;

                string[] controls1 = { "Tuesday Soccer", "Sunday Soccer", "Thursday Soccer" };
                rbl2.DataSource = controls1;
                rbl2.DataBind();
                rbl2.SelectedIndex = 1;

                string[] controls2 = { "Tuesday Soccer", "Sunday Soccer", "Thursday Soccer" };
                rb.DataSource = controls2;
                rb.DataBind();
                rb.SelectedIndex = 1;

            }
            else
            {
                Session["ds"] = null;
                Response.Redirect("Default.aspx");
            }
            if (ds.Tables[0].Rows[0]["RoleID"].ToString() == "1")
            {
                adminMenuPanel.Visible = true;
                userMenuPanel.Visible = false;
                mvMain.ActiveViewIndex = 0;
                bindPage();
                adminMenu.Style.Add(HtmlTextWriterStyle.Width, "909px");
            }
            else
            {
                userMenuPanel.Visible = true;
                adminMenuPanel.Visible = false;
                if (Request.QueryString["match"] != null)
                {
                    mvMain.ActiveViewIndex = 7;
                }
                else
                {
                    mvMain.ActiveViewIndex = 3;
                }

                menuid.Style.Add(HtmlTextWriterStyle.Width, "908px");

            }
            if (Request.QueryString["reg"] != null)
            {

            }
            if (Request.QueryString["action"] != null && Request.QueryString["action"].ToString() == "edit")
            {

                mvMain.ActiveViewIndex = 2;
                bindProfile();

            }
            if (Request.QueryString["action"] != null && Request.QueryString["action"].ToString() == "logout")
            {
                Session.Abandon();
                Session["ds"] = null;
                Response.Redirect("Default.aspx");

            }

            if (Request.QueryString["action"] != null && Request.QueryString["action"].ToString() == "confirmation")
            {


                SqlDataAdapter adp = new SqlDataAdapter("select * from tblSetting", con);
                DataSet ds2 = new DataSet();
                adp.Fill(ds2);

                Int32 NoOfPalayerReq = Convert.ToInt32(ds2.Tables[0].Rows[0]["NoOfPalayerReq"]);
                adp = null;
                ds2 = null;
                if (Session["thu"] != null)
                {
                    adp = new SqlDataAdapter("select ID,UserId, Fname +' '+Sname +' ('+ PlayerID+ ')' as PName, CDate,IsPaid from tblPracticeConfirmation1 where IsAttending=1 and IsDeleted=0 and IsOthers=0 and NextPDate='" + getNextPDate() + "'  order by CDate", con);
                }
                else
                {
                    adp = new SqlDataAdapter("select ID,UserId, Fname +' '+Sname +' ('+ PlayerID+ ')' as PName, CDate,IsPaid from tblPracticeConfirmation where IsAttending=1 and IsDeleted=0 and IsOthers=0 and NextPDate='" + getNextPDate() + "'  order by CDate", con);
                }

                ds2 = new DataSet();
                adp.Fill(ds2);

                lbPlayersAccepted.DataSource = ds2;
                lbPlayersAccepted.DataTextField = "PName";
                lbPlayersAccepted.DataValueField = "ID";
                lbPlayersAccepted.DataBind();


                adp = new SqlDataAdapter();
                if (Session["thu"] != null)
                {
                    Label41.Text = "Players that have confirmed attendance (after Monday 12:00 PM)";

                    adp = new SqlDataAdapter("select ID,UserId, Fname +' '+Sname +' ('+ PlayerID+ ')' as PName, CDate,IsPaid from tblPracticeConfirmation1 where IsAttending=1 and IsDeleted=0 and isOthers=1 and NextPDate='" + getNextPDate() + "'  order by CDate", con);
                }
                else
                {
                    Label41.Text = "Players that have confirmed attendance (after Friday 12:00 PM)";
                    adp = new SqlDataAdapter("select ID,UserId, Fname +' '+Sname +' ('+ PlayerID+ ')' as PName, CDate,IsPaid from tblPracticeConfirmation where IsAttending=1 and IsDeleted=0 and isOthers=1 and NextPDate='" + getNextPDate() + "'  order by CDate", con);
                }
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

                if (Session["thu"] != null)
                {
                    adp = new SqlDataAdapter("select ID,UserId, Fname +' '+Sname +' ('+ PlayerID+ ')'+' - '+ convert(varchar(19),CDate) as PName, CDate,IsPaid from tblPracticeConfirmation1 where IsAttending=0 and IsDeleted=0 and NextPDate='" + getNextPDate() + "'  order by CDate", con);
                }
                else
                {
                    adp = new SqlDataAdapter("select ID,UserId, Fname +' '+Sname +' ('+ PlayerID+ ')'+' - '+ convert(varchar(19),CDate) as PName, CDate,IsPaid from tblPracticeConfirmation where IsAttending=0 and IsDeleted=0 and NextPDate='" + getNextPDate() + "'  order by CDate", con);
                }

                ds = new DataSet();
                adp.Fill(ds);

                lbOthersPlayersRejected.DataSource = ds;
                lbOthersPlayersRejected.DataTextField = "PName";
                lbOthersPlayersRejected.DataValueField = "ID";
                lbOthersPlayersRejected.DataBind();



                Int32 totp = lbPlayersAccepted.Items.Count + lbOthersPlayersAccepted.Items.Count;

                lblTot2.Text = "Total Confirmed Players: " + (lbPlayersAccepted.Items.Count + lbOthersPlayersAccepted.Items.Count).ToString();
                string playername = ((DataSet)Session["ds"]).Tables[0].Rows[0]["Fname"].ToString() + " " + ((DataSet)Session["ds"]).Tables[0].Rows[0]["Sname"].ToString() + " (" + ((DataSet)Session["ds"]).Tables[0].Rows[0]["PlayerID"].ToString() + ")";

                if (NoOfPalayerReq > totp)
                {
                    string day = DateTime.UtcNow.AddHours(-5.0).DayOfWeek.ToString();

                    if (Session["thu"] != null)
                    {
                        // if ((day == "Sunday" && DateTime.UtcNow.AddHours(-5.0).Hour >= 12) || day == "Monday" || day == "Tuesday")
                        if ((day == "Monday" && DateTime.UtcNow.AddHours(-5.0).Hour >= 12) || day == "Tuesday")
                        {
                            rbYes.Enabled = true;
                            rbNo.Enabled = true;
                            lbInvitationStatus.Text = playername + " , the next practice will be on the " + Convert.ToDateTime(getNextPDate()).ToLongDateString() + ". Will you be attending?";
                        }
                        else
                        {
                            if (Convert.ToBoolean(((DataSet)Session["ds"]).Tables[0].Rows[0]["isPaid1"]) == false)
                            {
                                rbYes.Enabled = false;
                                rbNo.Enabled = false;
                                lbInvitationStatus.Text = "Thank you for your interest in playing with us on " + Convert.ToDateTime(getNextPDate()).ToLongDateString() + ". Please allow the Paid Players to confirm attendance until Monday Noon 12:00 PM. Login anytime after that to confirm and if there are free places you can confirm then if you want to attend..";
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
                        if ((day == "Friday" && DateTime.UtcNow.AddHours(-5.0).Hour >= 12) || day == "Saturday" || day == "Sunday")
                        {
                            rbYes.Enabled = true;
                            rbNo.Enabled = true;
                            lbInvitationStatus.Text = playername + " , the next practice will be on the " + Convert.ToDateTime(getNextPDate()).ToLongDateString() + ". Will you be attending?";
                        }
                        else
                        {
                            if (Convert.ToBoolean(((DataSet)Session["ds"]).Tables[0].Rows[0]["isPaid"]) == false)
                            {
                                rbYes.Enabled = false;
                                rbNo.Enabled = false;
                                lbInvitationStatus.Text = "Thank you for your interest in playing with us on " + Convert.ToDateTime(getNextPDate()).ToLongDateString() + ". Please allow the Paid Players to confirm attendance until Friday Noon 12:00 PM. Login anytime after that to confirm and if there are free places you can confirm then if you want to attend..";
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



                }
                else
                {
                    rbYes.Enabled = false;
                    //rbNo.Enabled = false;
                    if (Session["thu"] != null)
                    {
                        lbInvitationStatus.Text = "Thank you for your interest in playing with us. We have reached the maximum number of players for this Tuesday. If you are a paid player, please log in earlier (before Monday 12:00 PM) If you are a non-paid player log in anytime  after Monday 12:00 PM and a spot will be reserved for you based on availability.";
                    }
                    else
                    {
                        lbInvitationStatus.Text = "Thank you for your interest in playing with us. We have reached the maximum number of players for this Sunday. If you are a paid player, please log in earlier (before Friday 12:00 PM) If you are a non-paid player log in anytime  after Friday 12:00 PM and a spot will be reserved for you based on availability.";
                    }
                    //lbInvitationStatus.Text = "Thank you for your interest in playing with us. Please login on " + Convert.ToDateTime(getNextPDate()).AddDays(7.0).ToLongDateString() + " to confirm if you want to attend..";
                }
            }

            if (Request.QueryString["action"] != null && Request.QueryString["action"].ToString() == "cancel")
            {
                DataSet d1 = (DataSet)Session["ds"];
                string playername = ((DataSet)Session["ds"]).Tables[0].Rows[0]["Fname"].ToString() + " " + ((DataSet)Session["ds"]).Tables[0].Rows[0]["Sname"].ToString() + " (" + ((DataSet)Session["ds"]).Tables[0].Rows[0]["PlayerID"].ToString() + ")";
                if (d1.Tables[0].Rows[0]["RoleID"].ToString() == "1")
                {

                    mvMain.ActiveViewIndex = 0;
                }
                else
                {
                    mvMain.ActiveViewIndex = 3;

                    if (Session["thu"] != null)
                    {

                        if (Convert.ToBoolean(((DataSet)Session["ds"]).Tables[0].Rows[0]["isPaid1"]) == false)
                        {
                            rbYes.Enabled = false;
                            rbNo.Enabled = false;
                            if (Session["thu"] != null)
                            {
                                lbInvitationStatus.Text = "Thank you for your interest in playing with us on " + Convert.ToDateTime(getNextPDate()).ToLongDateString() + ". Please allow the Paid Players to confirm attendance until Monday Noon 12:00 PM. Login anytime after that to confirm and if there are free places you can confirm then if you want to attend..";
                            }
                            else
                            {
                                lbInvitationStatus.Text = "Thank you for your interest in playing with us on " + Convert.ToDateTime(getNextPDate()).ToLongDateString() + ". Please allow the Paid Players to confirm attendance until Friday Noon 12:00 PM. Login anytime after that to confirm and if there are free places you can confirm then if you want to attend..";
                            }
                            lbInvitationStatus.ForeColor = System.Drawing.Color.Red;

                        }
                        else
                        {
                            rbYes.Enabled = true;
                            rbNo.Enabled = true;
                            lbInvitationStatus.ForeColor = System.Drawing.Color.White;

                            lbInvitationStatus.Text = playername + " , the next practice will be on the " + Convert.ToDateTime(getNextPDate()).ToLongDateString() + ". Will you be attending?";
                        }
                    }
                    else
                    {
                        if (Convert.ToBoolean(((DataSet)Session["ds"]).Tables[0].Rows[0]["isPaid"]) == false)
                        {
                            rbYes.Enabled = false;
                            rbNo.Enabled = false;
                            if (Session["thu"] != null)
                            {
                                lbInvitationStatus.Text = "Thank you for your interest in playing with us on " + Convert.ToDateTime(getNextPDate()).ToLongDateString() + ". Please allow the Paid Players to confirm attendance until Monday Noon 12:00 PM. Login anytime after that to confirm and if there are free places you can confirm then if you want to attend..";
                            }
                            else
                            {
                                lbInvitationStatus.Text = "Thank you for your interest in playing with us on " + Convert.ToDateTime(getNextPDate()).ToLongDateString() + ". Please allow the Paid Players to confirm attendance until Friday Noon 12:00 PM. Login anytime after that to confirm and if there are free places you can confirm then if you want to attend..";
                            }
                            lbInvitationStatus.ForeColor = System.Drawing.Color.Red;

                        }
                        else
                        {
                            rbYes.Enabled = true;
                            rbNo.Enabled = true;
                            lbInvitationStatus.ForeColor = System.Drawing.Color.White;

                            lbInvitationStatus.Text = playername + " , the next practice will be on the " + Convert.ToDateTime(getNextPDate()).ToLongDateString() + ". Will you be attending?";
                        }

                    }

                    string day = DateTime.UtcNow.AddHours(-5.0).DayOfWeek.ToString();

                    if (Session["thu"] != null)
                    {
                        //if ((day == "Sunday" && DateTime.UtcNow.AddHours(-5.0).Hour >= 12) || day == "Monday" || day == "Tuesday")
                        if ((day == "Monday" && DateTime.UtcNow.AddHours(-5.0).Hour >= 12) || day == "Tuesday")
                        {
                            rbYes.Enabled = true;
                            rbNo.Enabled = true;
                            lbInvitationStatus.Text = playername + " , the next practice will be on the " + Convert.ToDateTime(getNextPDate()).ToLongDateString() + ". Will you be attending?";
                        }
                        else
                        {
                            if (Convert.ToBoolean(((DataSet)Session["ds"]).Tables[0].Rows[0]["isPaid1"]) == false)
                            {
                                rbYes.Enabled = false;
                                rbNo.Enabled = false;
                                lbInvitationStatus.Text = "Thank you for your interest in playing with us on " + Convert.ToDateTime(getNextPDate()).ToLongDateString() + ". Please allow the Paid Players to confirm attendance until Monday Noon 12:00 PM. Login anytime after that to confirm and if there are free places you can confirm then if you want to attend..";
                                lbInvitationStatus.ForeColor = System.Drawing.Color.Red;

                                string st = "Thank you for your interest in playing with us. Please login on " + Convert.ToDateTime(getNextPDate()).AddDays(1.0).ToLongDateString() + " to confirm if you want to attend..";

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

                        if ((day == "Friday" && DateTime.UtcNow.AddHours(-5.0).Hour >= 12) || day == "Saturday" || day == "Sunday")
                        {
                            rbYes.Enabled = true;
                            rbNo.Enabled = true;
                            lbInvitationStatus.Text = playername + " , the next practice will be on the " + Convert.ToDateTime(getNextPDate()).ToLongDateString() + ". Will you be attending?";
                        }
                        else
                        {
                            if (Convert.ToBoolean(((DataSet)Session["ds"]).Tables[0].Rows[0]["isPaid"]) == false)
                            {
                                rbYes.Enabled = false;
                                rbNo.Enabled = false;
                                lbInvitationStatus.Text = "Thank you for your interest in playing with us on " + Convert.ToDateTime(getNextPDate()).ToLongDateString() + ". Please allow the Paid Players to confirm attendance until Friday Noon 12:00 PM. Login anytime after that to confirm and if there are free places you can confirm then if you want to attend..";
                                lbInvitationStatus.ForeColor = System.Drawing.Color.Red;

                                string st = "Thank you for your interest in playing with us. Please login on " + Convert.ToDateTime(getNextPDate()).AddDays(1.0).ToLongDateString() + " to confirm if you want to attend..";

                            }
                            else
                            {
                                rbYes.Enabled = true;
                                rbNo.Enabled = true;
                                lbInvitationStatus.Text = playername + " , the next practice will be on the " + Convert.ToDateTime(getNextPDate()).ToLongDateString() + ". Will you be attending?";
                            }

                        }

                    }

                }
            }
            if (Request.QueryString["action"] != null && Request.QueryString["action"].ToString() == "selection")
            {
                mvMain.ActiveViewIndex = 1;
                bindUser(); bindUser1();
            }
            if (Request.QueryString["action"] != null && Request.QueryString["action"].ToString() == "usermanagement")
            {
                mvMain.ActiveViewIndex = 6;
                BindAllUsers();

            }
            if (Request.QueryString["action"] != null && Request.QueryString["action"].ToString() == "confirmed")
            {
                mvMain.ActiveViewIndex = 5;
                //lbPlayersConfirmingAttendance

                SqlDataAdapter adp = new SqlDataAdapter();

                //if (Session["thu"] != null)
                //{
                //    adp = new SqlDataAdapter("select ID,UserId, Fname +' '+Sname +' ('+ PlayerID+ ')' as PName, CDate,IsPaid from tblPracticeConfirmation1 where IsAttending=1 and IsDeleted=0 and IsOthers=0 and NextPDate='" + getNextPDate() + "'  order by CDate", con);

                //}
                //else
                //{
                adp = new SqlDataAdapter("select ID,UserId, Fname +' '+Sname +' ('+ PlayerID+ ')' as PName, CDate,IsPaid from tblPracticeConfirmation where IsAttending=1 and IsDeleted=0 and IsOthers=0 and NextPDate='" + getNextPDate() + "'  order by CDate", con);

                // }//adp = new SqlDataAdapter("select ID,UserId, Fname +' '+Sname +' ('+ PlayerID+ ')' as PName, CDate from tblPracticeConfirmation where IsDeleted=0 and NextPDate='" + getNextPDate() + "' and isOthers=0 and IsAttending=1 ", con);
                ds = new DataSet();
                adp.Fill(ds);

                lbPlayersConfirmingAttendance.DataSource = ds;
                lbPlayersConfirmingAttendance.DataTextField = "PName";
                lbPlayersConfirmingAttendance.DataValueField = "ID";
                lbPlayersConfirmingAttendance.DataBind();
                adp = null;

                //if (Session["thu"] != null)
                //{
                //    adp = new SqlDataAdapter("select ID,UserId, Fname +' '+Sname +' ('+ PlayerID+ ')'+' - '+ convert(varchar(19),CDate) as PName, CDate,IsPaid from tblPracticeConfirmation1 where IsAttending=0 and IsDeleted=0 and NextPDate='" + getNextPDate() + "'  order by CDate", con);
                //}
                //else
                //{
                adp = new SqlDataAdapter("select ID,UserId, Fname +' '+Sname +' ('+ PlayerID+ ')'+' - '+ convert(varchar(19),CDate) as PName, CDate,IsPaid from tblPracticeConfirmation where IsAttending=0 and IsDeleted=0 and NextPDate='" + getNextPDate() + "'  order by CDate", con);
                //}
                ds = new DataSet();
                adp.Fill(ds);

                lbPlayersRejectingAttendance.DataSource = ds;
                lbPlayersRejectingAttendance.DataTextField = "PName";
                lbPlayersRejectingAttendance.DataValueField = "ID";
                lbPlayersRejectingAttendance.DataBind();


                adp = null;

                adp = new SqlDataAdapter();
                //if (Session["thu"] != null)
                //{
                //    adp = new SqlDataAdapter("select ID,UserId, Fname +' '+Sname +' ('+ PlayerID+ ')' as PName, CDate,IsPaid from tblPracticeConfirmation1 where IsAttending=1 and IsDeleted=0 and IsOthers=1 and NextPDate='" + getNextPDate() + "'  order by CDate", con);
                //}
                //else
                //{
                adp = new SqlDataAdapter("select ID,UserId, Fname +' '+Sname +' ('+ PlayerID+ ')' as PName, CDate,IsPaid from tblPracticeConfirmation where IsAttending=1 and IsDeleted=0 and IsOthers=1 and NextPDate='" + getNextPDate() + "'  order by CDate", con);
                // }

                //adp = new SqlDataAdapter("select ID,UserId, Fname +' '+Sname +' ('+ PlayerID+ ')' as PName, CDate from tblPracticeConfirmation where IsDeleted=0 and NextPDate='" + getNextPDate() + "' and isOthers=1 and IsAttending=1", con);
                ds = new DataSet();
                adp.Fill(ds);

                lbOtherUsersConfirmingAttendance.DataSource = ds;
                lbOtherUsersConfirmingAttendance.DataTextField = "PName";
                lbOtherUsersConfirmingAttendance.DataValueField = "ID";
                lbOtherUsersConfirmingAttendance.DataBind();
                lblTotPlayer.Text = "Total Players: " + (lbPlayersConfirmingAttendance.Items.Count + lbOtherUsersConfirmingAttendance.Items.Count).ToString();

            }
            if (Request.QueryString["action"] != null && Request.QueryString["action"].ToString() == "history")
            {
                mvMain.ActiveViewIndex = 4;
                SqlDataAdapter adp = new SqlDataAdapter();

                adp = new SqlDataAdapter(@"select distinct top 50 convert(varchar(20), convert(datetime, NextPDate, 110),101)as
                NextPDate ,
                RIGHT('0'+ LTRIM(STR(MONTH(NextPDate))), 2) as months,
                LTRIM(STR(YEAR(NextPDate))) as years
                from tblPracticeConfirmation group by NextPDate order by years desc, months desc, NextPDate desc ", con);
                ds = new DataSet();
                adp.Fill(ds);

                lbPastFixtureDates.DataSource = ds;
                lbPastFixtureDates.DataTextField = "NextPDate";
                lbPastFixtureDates.DataValueField = "NextPDate";
                lbPastFixtureDates.DataBind();

            }


        }

    }
    public string getNextPDate()
    {
        double days = 0.0;
        string day = DateTime.UtcNow.AddHours(-5.0).DayOfWeek.ToString();
        if (Session["thu"] != null)//Tuesday
        {
            if (day == "Monday")
            {
                days = 1.0;// 3.0;
            }
            if (day == "Tuesday")
            {
                days = 0.0;// 2.0;
            }
            if (day == "Wednesday")
            {
                days = 6.0;// 1.0;
            }
            if (day == "Thursday")
            {
                days = 5.0;// 0.0;
            }
            if (day == "Friday")
            {
                days = 4.0;// 6.0;
            }
            if (day == "Saturday")
            {
                days = 3.0;// 5.0;
            }
            if (day == "Sunday")
            {
                days = 2.0;// 4.0;
            }
        }
        else //Sunday
        {

            if (day == "Monday")
            {
                days = 6.0;
            }
            if (day == "Tuesday")
            {
                days = 5.0;
            }
            if (day == "Wednesday")
            {
                days = 4.0;
            }
            if (day == "Thursday")
            {
                days = 3.0;
            }
            if (day == "Friday")
            {
                days = 2.0;
            }
            if (day == "Saturday")
            {
                days = 1.0;
            }
            if (day == "Sunday")
            {
                days = 0.0;
            }
        }
        return DateTime.UtcNow.AddHours(-5.0).AddDays(days).ToShortDateString();
    }

    protected void btnProfileSubmit_Click(object sender, EventArgs e)
    {
        string Userid = ((DataSet)Session["ds"]).Tables[0].Rows[0]["UserId"].ToString();
        cmd.CommandText = "update tblUser set PlayerID='" + tbUserId.Text + "',Password='" + tbPassword.Text + "',Fname='" + tbFirstName.Text + "',Sname='" + tbSurname.Text + "',Email='" + tbEMailAddress.Text + "',Sunday='" + chksun.Checked + "',tuesday='" + chkThu.Checked + "',Phone='" + tbPhoneNumber.Text + "',Position='" + ddlPosition.SelectedItem.Text + "' where UserId=" + Userid;
        cmd.Connection = con;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        bindProfile();
        lblmsgProfile.Text = "Data updated successfully.";

    }
    protected void bindPage()
    {

        SqlDataAdapter adp = new SqlDataAdapter("select * from tblSetting", con);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            // cldrPracticeDate.SelectedDate = Convert.ToDateTime(getNextPDate());// Convert.ToDateTime(ds.Tables[0].Rows[0][1].ToString());
            // lbPracticeDate.Text = Convert.ToDateTime(getNextPDate()).ToLongDateString(); // ds.Tables[0].Rows[0][1].ToString();
            tbPracticePlayersNumber.Text = ds.Tables[0].Rows[0][2].ToString();
            tbConfirmationDeadline.Text = ds.Tables[0].Rows[0][3].ToString();
            tbHomeVideoMarkUp.Text = ds.Tables[0].Rows[0][4].ToString();
            cbEnableEmail.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0][5].ToString());
            cbEnableSSL.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0][6].ToString());
            tbEmailFromAddress.Text = ds.Tables[0].Rows[0][7].ToString();
            tbEmailHostName.Text = ds.Tables[0].Rows[0][8].ToString();
            tbEmailPort.Text = ds.Tables[0].Rows[0][9].ToString();
            tbEmailServerUserId.Text = ds.Tables[0].Rows[0][10].ToString();
            tbEmailServerUserPassword.Text = ds.Tables[0].Rows[0][11].ToString();
            tbEMailConfirmationTemplate.Text = ds.Tables[0].Rows[0][12].ToString();
            tbEMailDeclinedTemplate.Text = ds.Tables[0].Rows[0][13].ToString();
            txtHomePageText.Text = ds.Tables[0].Rows[0][14].ToString();
            txtVideo.Text = ds.Tables[0].Rows[0][15].ToString();
            txtContactUsText.Text = ds.Tables[0].Rows[0][16].ToString();
            tbEMailConfirmationTemplate1.Text = ds.Tables[0].Rows[0][17].ToString();
        }

    }

    public void bindUser()
    {
        SqlDataAdapter adp;
        if (rb.SelectedIndex == 0)
        {
            //adp = new SqlDataAdapter("select UserId,Fname+' '+Sname+' ('+PlayerID+')' as PlayerName from tblUser where IsDeleted=0 and RoleID=2 and isPaid1=0", con);
            adp = new SqlDataAdapter("select UserId,isnew, Fname+' '+Sname+' ('+PlayerID+')' as PlayerName from tblUser where isNew=0 and IsDeleted=0 and RoleID=2 and tuesday=1 and isPaid1=0 order by isnew desc", con);
        }
        else
        {
            //adp = new SqlDataAdapter("select UserId,Fname+' '+Sname+' ('+PlayerID+')' as PlayerName from tblUser where IsDeleted=0 and RoleID=2 and isPaid=0", con);


            adp = new SqlDataAdapter("select UserId,isnew, Fname+' '+Sname+' ('+PlayerID+')' as PlayerName from tblUser where isNew=0 and IsDeleted=0 and RoleID=2 and sunday=1 and isPaid=0 order by isnew desc", con);
        }

        DataSet ds1 = new DataSet();
        adp.Fill(ds1);

        lbUnselectedUsers.DataSource = ds1;
        lbUnselectedUsers.DataValueField = "UserId";
        lbUnselectedUsers.DataTextField = "PlayerName";
        lbUnselectedUsers.DataBind();

        SqlDataAdapter adp1;
        if (rb.SelectedIndex == 0)
        {
            // adp1 = new SqlDataAdapter("select UserId,Fname+' '+Sname+' ('+PlayerID+')' as PlayerName from tblUser where IsDeleted=0 and isPaid1=1", con);
            adp1 = new SqlDataAdapter("select UserId,isnew, Fname+' '+Sname+' ('+PlayerID+')' as PlayerName from tblUser where tuesday=1 and IsDeleted=0 and isPaid1=1 order by isnew desc", con);
        }
        else
        {
            // adp1 = new SqlDataAdapter("select UserId,Fname+' '+Sname+' ('+PlayerID+')' as PlayerName from tblUser where IsDeleted=0 and isPaid=1", con);

            adp1 = new SqlDataAdapter("select UserId,isnew, Fname+' '+Sname+' ('+PlayerID+')' as PlayerName from tblUser where  sunday=1 and IsDeleted=0 and isPaid=1 order by isnew desc", con);
        }
        // SqlDataAdapter adp1 = new SqlDataAdapter("select UserId,Fname+' '+Sname+' ('+PlayerID+')' as PlayerName from tblUser where IsDeleted=0 and isPaid=1", con);


        DataSet ds2 = new DataSet();
        adp1.Fill(ds2);

        lbPlayers.DataSource = ds2;
        lbPlayers.DataValueField = "UserId";
        lbPlayers.DataTextField = "PlayerName";
        lbPlayers.DataBind();

        // con.Dispose();

    }

    public void bindUser1()
    {
        SqlDataAdapter adp;
        if (rb.SelectedIndex == 0)
        {
            //adp = new SqlDataAdapter("select UserId,Fname+' '+Sname+' ('+PlayerID+')' as PlayerName from tblUser where IsDeleted=0 and RoleID=2 and isPaid1=0", con);
            adp = new SqlDataAdapter("select UserId,isnew, Fname+' '+Sname+' ('+PlayerID+')' as PlayerName from tblUser where isNew=1 and tuesday=1  and IsDeleted=0 and RoleID=2  order by isnew desc", con);
        }
        else
        {
            //adp = new SqlDataAdapter("select UserId,Fname+' '+Sname+' ('+PlayerID+')' as PlayerName from tblUser where IsDeleted=0 and RoleID=2 and isPaid=0", con);


            adp = new SqlDataAdapter("select UserId,isnew, Fname+' '+Sname+' ('+PlayerID+')' as PlayerName from tblUser where isNew=1 and sunday=1  and IsDeleted=0 and RoleID=2 order by isnew desc", con);
        }

        DataSet ds1 = new DataSet();
        adp.Fill(ds1);

        lbUnselectedUsers1.DataSource = ds1;
        lbUnselectedUsers1.DataValueField = "UserId";
        lbUnselectedUsers1.DataTextField = "PlayerName";
        lbUnselectedUsers1.DataBind();

        SqlDataAdapter adp1;
        if (rb.SelectedIndex == 0)
        {
            // adp1 = new SqlDataAdapter("select UserId,Fname+' '+Sname+' ('+PlayerID+')' as PlayerName from tblUser where IsDeleted=0 and isPaid1=1", con);
            adp1 = new SqlDataAdapter("select UserId,isnew, Fname+' '+Sname+' ('+PlayerID+')' as PlayerName from tblUser where IsDeleted=0 and tuesday=1 and isPaid1=1  order by isnew desc", con);
        }
        else
        {
            // adp1 = new SqlDataAdapter("select UserId,Fname+' '+Sname+' ('+PlayerID+')' as PlayerName from tblUser where IsDeleted=0 and isPaid=1", con);

            adp1 = new SqlDataAdapter("select UserId,isnew, Fname+' '+Sname+' ('+PlayerID+')' as PlayerName from tblUser where  IsDeleted=0 and sunday=1 and isPaid=1 order by isnew desc", con);
        }
        // SqlDataAdapter adp1 = new SqlDataAdapter("select UserId,Fname+' '+Sname+' ('+PlayerID+')' as PlayerName from tblUser where IsDeleted=0 and isPaid=1", con);


        DataSet ds2 = new DataSet();
        adp1.Fill(ds2);

        lbPlayers.DataSource = ds2;
        lbPlayers.DataValueField = "UserId";
        lbPlayers.DataTextField = "PlayerName";
        lbPlayers.DataBind();

        // con.Dispose();

    }
    protected void btnSelectUser_Click(object sender, EventArgs e)
    {
        if (Session["id"] != null)
        {
            //Response.Write("update tblUser set isPaid1=1 where UserId=" + Session["id"].ToString());
            if (rb.SelectedIndex == 0)
            {
                cmd.CommandText = "update tblUser set isPaid1=1 where UserId=" + Session["id"].ToString();
            }
            else
            {
                cmd.CommandText = "update tblUser set isPaid=1 where UserId=" + Session["id"].ToString();
            }
            Session["id"] = null;
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            bindUser(); bindUser1();
            lblmsgPaidPlayers.Text = "Data updated successfully.";
        }
        else
        {
            lblmsgPaidPlayers.Text = "Please select any playerkkk.";
        }
        lblmsgPaidPlayers.ForeColor = System.Drawing.Color.Red;
    }

    protected void btnSelectUser1_Click(object sender, EventArgs e)
    {
        if (lbUnselectedUsers.SelectedValue != "")
        {
            if (rb.SelectedIndex == 0)
            {
                cmd.CommandText = "update tblUser set isNew=1 where  UserId=" + lbUnselectedUsers.SelectedValue;
            }
            else
            {
                cmd.CommandText = "update tblUser set isNew=1 where UserId=" + lbUnselectedUsers.SelectedValue;
            }

            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            bindUser();
            bindUser1();
            lblmsgPaidPlayers.Text = "Data updated successfully.";
        }
        else
        {
            lblmsgPaidPlayers.Text = "Please select any player.";
        }
        lblmsgPaidPlayers.ForeColor = System.Drawing.Color.Red;
    }

    protected void btnDeselectUser_Click(object sender, EventArgs e)
    {
        if (lbPlayers.SelectedValue != "")
        {

            if (rb.SelectedIndex == 0)
            {
                cmd.CommandText = "update tblUser set isPaid1=0 where UserId=" + lbPlayers.SelectedValue;
            }
            else
            {
                cmd.CommandText = "update tblUser set isPaid=0 where UserId=" + lbPlayers.SelectedValue;
            }
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            bindUser(); bindUser1();
            lblmsgPaidPlayers.Text = "Data updated successfully.";
        }
        else
        {
            lblmsgPaidPlayers.Text = "Please select any player.";
        }
        lblmsgPaidPlayers.ForeColor = System.Drawing.Color.Red;
    }

    protected void btnDeselectUser1_Click(object sender, EventArgs e)
    {
        if (lbUnselectedUsers1.SelectedValue != "")
        {

            if (rb.SelectedIndex == 0)
            {
                cmd.CommandText = "update tblUser set isNew=0 where UserId=" + lbUnselectedUsers1.SelectedValue;
            }
            else
            {
                cmd.CommandText = "update tblUser set isNew=0 where UserId=" + lbUnselectedUsers1.SelectedValue;
            }
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            bindUser();
            bindUser1();
            lblmsgPaidPlayers.Text = "Data updated successfully.";
        }
        else
        {
            lblmsgPaidPlayers.Text = "Please select any player.";
        }
        lblmsgPaidPlayers.ForeColor = System.Drawing.Color.Red;
    }

    private void AlphabeticalInsert(ListItemCollection listItemCollection, ListItem item)
    {

    }


    protected void btnSubmitSettings_Click(object sender, EventArgs e)
    {

        string query = @"truncate table tblSetting; insert into tblSetting (NextPDate,NoOfPalayerReq,DaysBeforPDate,YoutubeURL,
                            IsEmailEnable,  
                            IsSSLEnable,
                            FromAddress,
                            HostName,
                            PortNumber,
                            UserId,
                            Password,
                            CETemplet,
                            DETemplet,
                            HomePageTemplet,HomeVideoTemplet,
                            ContactUsTemplet,CETemplet1)
            values(" + "'" + DateTime.Now.ToString("dddd, MMMM dd, yyyy") + "','" +
                                    tbPracticePlayersNumber.Text + "','" +
                                    tbConfirmationDeadline.Text + "','" +
                                    tbHomeVideoMarkUp.Text + "','" +
                                    cbEnableEmail.Checked + "','" +
                                    cbEnableSSL.Checked + "','" +
                                    tbEmailFromAddress.Text + "','" +
                                    tbEmailHostName.Text + "','" +
                                    tbEmailPort.Text + "','" +
                                    tbEmailServerUserId.Text + "','" +
                                    tbEmailServerUserPassword.Text + "','" +
                                    tbEMailConfirmationTemplate.Text + "','" +
                                    tbEMailDeclinedTemplate.Text + "','" +
                                    txtHomePageText.Text + "','" +
                                    txtVideo.Text + "','" +
                                    txtContactUsText.Text + "','" + tbEMailConfirmationTemplate1.Text + "')";

        cmd.CommandText = query;// "drop table tblUser";
        cmd.Connection = con;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        con.Dispose();

        lbErrorMessage.Text = "Data updated successfully.";


    }

    protected void btnCancelSettings_Click(object sender, EventArgs e)
    {

    }

    protected void btnTeamSelectionSubmit_Click(object sender, EventArgs e)
    {

    }

    protected void btnTeamSelectionCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Main.aspx?action=cancel");
    }

    protected void cldrPracticeDate_SelectionChanged(object sender, EventArgs e)
    {
        lbPracticeDate.Text = cldrPracticeDate.SelectedDate.Date.ToString(DateFormat);
    }



    protected void btnProfileCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Main.aspx?action=cancel");
    }

    protected void rbYes_CheckedChanged(object sender, EventArgs e)
    {
        DataSet ds = (DataSet)Session["ds"];
        string table;
        if (Session["thu"] != null)
        {
            table = "tblPracticeConfirmation1";//tuesday
        }
        else
        {
            table = "tblPracticeConfirmation";//Sunday
        }
        SqlDataAdapter adp1 = new SqlDataAdapter("select * from " + table + @" where IsDeleted=0 and UserId='" + ds.Tables[0].Rows[0]["UserId"].ToString() + "' and NextPDate='" + getNextPDate() + "'", con);
        DataSet ds2 = new DataSet();
        adp1.Fill(ds2);
        string emailmsg = "";
        string emailmsg1 = "";

        if (ds2.Tables[0].Rows.Count > 0)
        {

            string day = DateTime.UtcNow.AddHours(-5.0).DayOfWeek.ToString();

            if (Session["thu"] != null)//Tuesday
            {
                //if ((day == "Tuesday" && DateTime.UtcNow.AddHours(-5.0).Hour >= 12) || day == "Wednesday" || day == "Thursday")
                if ((day == "Monday" && DateTime.UtcNow.AddHours(-5.0).Hour >= 12) || day == "Tuesday")
                {
                    cmd.CommandText = @"update " + table + @" set  IsAttending =1,IsOthers=1 where NextPDate='" + getNextPDate() + "' and UserId=" + ds.Tables[0].Rows[0]["UserId"].ToString();
                }
                else
                {
                    cmd.CommandText = @"update " + table + @" set  IsAttending =1,IsOthers=0 where NextPDate='" + getNextPDate() + "' and UserId=" + ds.Tables[0].Rows[0]["UserId"].ToString();
                }
            }
            else
            {
                if ((day == "Friday" && DateTime.UtcNow.AddHours(-5.0).Hour >= 12) || day == "Saturday" || day == "Sunday")
                {
                    cmd.CommandText = @"update " + table + @" set  IsAttending =1,IsOthers=1 where NextPDate='" + getNextPDate() + "' and UserId=" + ds.Tables[0].Rows[0]["UserId"].ToString();
                }
                else
                {
                    cmd.CommandText = @"update " + table + @" set  IsAttending =1,IsOthers=0 where NextPDate='" + getNextPDate() + "' and UserId=" + ds.Tables[0].Rows[0]["UserId"].ToString();
                }
            }

            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
        else
        {
            Int32 ispaidm;
            if (Session["thu"] != null)
            {
                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["IsPaid1"]))
                {
                    ispaidm = 1;
                }
                else
                {
                    ispaidm = 0;
                }
            }
            else
            {
                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["IsPaid"]))
                {
                    ispaidm = 1;
                }
                else
                {
                    ispaidm = 0;
                }

            }

            string day = DateTime.UtcNow.AddHours(-5.0).DayOfWeek.ToString();

            string IsOthers = "";

            if (Session["thu"] != null)
            {
                //if ((day == "Tuesday" && DateTime.UtcNow.AddHours(-5.0).Hour >= 12) || day == "Wednesday" || day == "Thursday")
                if ((day == "Monday" && DateTime.UtcNow.AddHours(-5.0).Hour >= 12) || day == "Tuesday")
                {
                    IsOthers = "1";
                }
                else
                {
                    IsOthers = "0";
                }
            }
            else
            {
                if ((day == "Friday" && DateTime.UtcNow.AddHours(-5.0).Hour >= 12) || day == "Saturday" || day == "Sunday")
                {
                    IsOthers = "1";
                }
                else
                {
                    IsOthers = "0";
                }
            }


            cmd.CommandText = @"insert into " + table + @" (UserId,NextPDate,IsAttending,IsConfirmed,
CDate,Fname,Sname,PlayerID,IsPaid,IsOthers,IsDeleted)
values ('" + ds.Tables[0].Rows[0]["UserId"].ToString() + "','" + getNextPDate() + "','" + 1 + "','" + 0 + "','" +
           DateTime.UtcNow.AddHours(-5.0) + "','" + ds.Tables[0].Rows[0]["Fname"].ToString() + "','" +
           ds.Tables[0].Rows[0]["Sname"].ToString() + "','" + ds.Tables[0].Rows[0]["PlayerID"].ToString() + "'," + ispaidm + "," + IsOthers + ",0)";

            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
        lblmsginv.Text = "Attendence confirmation status is updated";

        //SqlDataAdapter adp = new SqlDataAdapter();
        //string query1 = "select ID,UserId, Fname +' '+Sname +' ('+ PlayerID+ ')' as PName, CDate from tblPracticeConfirmation where IsDeleted=0 and IsOthers=0 and NextPDate='" + getNextPDate() + "' and IsAttending =1 and IsOthers=0 ";
        //string query2 = "; select ID,UserId, Fname +' '+Sname +' ('+ PlayerID+ ')' as PName, CDate from tblPracticeConfirmation where IsDeleted=0 and IsOthers=1 and NextPDate='" + getNextPDate() + "' and IsAttending =1 and IsOthers=1 ";
        //string auery3 = "; select ID,UserId, Fname +' '+Sname +' ('+ PlayerID+ ')'+' - '+ convert(varchar(19),CDate) as PName, CDate from tblPracticeConfirmation  where IsDeleted=0 and NextPDate='" + getNextPDate() + "' and IsAttending =0";
        //adp = new SqlDataAdapter(query1 + query2 + auery3, con);
        //ds2 = new DataSet();
        //adp.Fill(ds2);

        //lbPlayersAccepted.DataSource = ds2.Tables[0];
        //lbPlayersAccepted.DataTextField = "PName";
        //lbPlayersAccepted.DataValueField = "ID";
        //lbPlayersAccepted.DataBind();

        //lbOthersPlayersAccepted.DataSource = ds2.Tables[1];
        //lbOthersPlayersAccepted.DataTextField = "PName";
        //lbOthersPlayersAccepted.DataValueField = "ID";
        //lbOthersPlayersAccepted.DataBind();

        //lbOthersPlayersRejected.DataSource = ds2.Tables[2];
        //lbOthersPlayersRejected.DataTextField = "PName";
        //lbOthersPlayersRejected.DataValueField = "ID";
        //lbOthersPlayersRejected.DataBind();

        //lblTot2.Text = "Total Confirmed Players: " + (lbPlayersAccepted.Items.Count + lbOthersPlayersAccepted.Items.Count).ToString();

        SqlDataAdapter adp3 = new SqlDataAdapter("select * from tblSetting", con);
        DataSet ds3 = new DataSet();
        adp3.Fill(ds3);
        if (Session["thu"] != null)
        {
            emailmsg = ds3.Tables[0].Rows[0]["CETemplet1"].ToString();
        }
        else
        {
            emailmsg = ds3.Tables[0].Rows[0]["CETemplet"].ToString();
        }
        //emailmsg = ds3.Tables[0].Rows[0]["CETemplet"].ToString();
        //emailmsg1 = ds3.Tables[0].Rows[0]["CETemplet1"].ToString();

        emailmsg = emailmsg.Replace("{PlayerName}", ((DataSet)Session["ds"]).Tables[0].Rows[0]["FName"].ToString());
        emailmsg = emailmsg.Replace("{ConfirmedDate}", DateTime.UtcNow.AddHours(-5.0).ToLongDateString());
        emailmsg = emailmsg.Replace("{PracticeDate}", Convert.ToDateTime(getNextPDate()).ToLongDateString());

        if (Session["emails"].ToString() == "no")
        {
            MailMessage ms = new MailMessage("admin@canadiansoccerclub.com", ((DataSet)Session["ds"]).Tables[0].Rows[0]["Email"].ToString(), "Canadian Soccer Practice Attendance Confirmation", emailmsg);
            SmtpClient smtp = new SmtpClient("canadiansoccerclub.com");
            smtp.Credentials = new System.Net.NetworkCredential("admin@canadiansoccerclub.com", "2014db!@#$");
            smtp.EnableSsl = false;
            ms.IsBodyHtml = true;
            smtp.Send(ms);
            Session["emails"] = "yes";
        }
        if (Session["thu"] != null)
        {
            Response.Redirect("option.aspx?done=t");
            Session["thu"] = null;
        }
        else
        {
            Response.Redirect("option.aspx?done=s");
        }
    }

    protected void rbNo_CheckedChanged(object sender, EventArgs e)
    {

        DataSet ds = (DataSet)Session["ds"];
        string table;
        if (Session["thu"] != null)
        {
            table = "tblPracticeConfirmation1";
        }
        else
        {
            table = "tblPracticeConfirmation";
        }
        SqlDataAdapter adp1 = new SqlDataAdapter("select * from " + table + " where IsDeleted=0 and UserId=" + ds.Tables[0].Rows[0]["UserId"].ToString() + " and NextPDate='" + getNextPDate() + "'", con);
        DataSet ds2 = new DataSet();
        adp1.Fill(ds2);
        if (ds2.Tables[0].Rows.Count > 0)
        {
            cmd.CommandText = @"update " + table + " set IsAttending=0, Cdate='" + DateTime.UtcNow.AddHours(-5.0) + "' where IsDeleted=0 and NextPDate='" + getNextPDate() + "' and UserId=" + ds.Tables[0].Rows[0]["UserId"].ToString();
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        else
        {
            Int32 ispaidm1;
            if (Session["thu"] != null)
            {
                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["IsPaid1"]))
                {
                    ispaidm1 = 1;
                }
                else
                {
                    ispaidm1 = 0;
                }
            }
            else
            {
                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["IsPaid"]))
                {
                    ispaidm1 = 1;
                }
                else
                {
                    ispaidm1 = 0;
                }

            }
            cmd.CommandText = @"insert into " + table + @" (UserId,NextPDate,IsAttending,IsConfirmed,
CDate,Fname,Sname,PlayerID,IsPaid,IsDeleted)
values ('" + ds.Tables[0].Rows[0]["UserId"].ToString() + "','" + getNextPDate() + "','" + 0 + "','" + 0 + "','" +
           DateTime.UtcNow.AddHours(-5.0) + "','" + ds.Tables[0].Rows[0]["Fname"].ToString() + "','" +
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
        emailmsg = emailmsg.Replace("{ConfirmedDate}", DateTime.UtcNow.AddHours(-5.0).ToLongDateString());
        emailmsg = emailmsg.Replace("{PracticeDate}", Convert.ToDateTime(getNextPDate()).ToLongDateString());

        if (Session["email"].ToString() == "no")
        {

            MailMessage ms = new MailMessage("admin@canadiansoccerclub.com", ((DataSet)Session["ds"]).Tables[0].Rows[0]["Email"].ToString(), "Canadian Soccer Practice Attendance Confirmation", emailmsg);
            SmtpClient smtp = new SmtpClient("canadiansoccerclub.com");
            smtp.Credentials = new System.Net.NetworkCredential("admin@canadiansoccerclub.com", "2014db!@#$");
            smtp.EnableSsl = false;
            ms.IsBodyHtml = true;
            smtp.Send(ms);
            Session["email"] = "yes";
        }

        if (Session["thu"] != null)
        {
            Response.Redirect("option.aspx?done=t");
            Session["thu"] = null;
        }
        else
        {
            Response.Redirect("option.aspx?done=s");
        }

    }

    protected void btnDeleteSelectedDates_Click(object sender, EventArgs e)
    {

    }

    protected void lbPastFixtureDates_SelectedIndexChanged(object sender, EventArgs e)
    {
        string[] strArray = lbPastFixtureDates.SelectedValue.Split('/');
        string sdate;
        if (Convert.ToInt32(strArray[0].ToString()) < 10)
        {
            sdate = strArray[0].Substring(1, 1);
        }
        else
        {
            sdate = strArray[0].ToString();
        }

        if (Convert.ToInt32(strArray[1].ToString()) < 10)
        {
            sdate = sdate + "/" + strArray[1].Substring(1, 1);
        }
        else
        {
            sdate = sdate + "/" + strArray[1].ToString();
        }
        sdate = sdate + "/" + strArray[2].ToString();
        SqlDataAdapter adp = new SqlDataAdapter();
        if (rbl1.SelectedIndex == 0)
        {

            adp = new SqlDataAdapter("select Fname +' '+Sname +' ('+ PlayerID+ ')' as PName from tblPracticeConfirmation1 where IsDeleted=0 and IsAttending=1 and nextPDate='" + sdate + "' order by nextPDate Desc", con);
        }
        else
        {
            adp = new SqlDataAdapter("select Fname +' '+Sname +' ('+ PlayerID+ ')' as PName from tblPracticeConfirmation where IsDeleted=0 and IsAttending=1 and nextPDate='" + sdate + "' order by nextPDate Desc", con);

        }
        // adp = new SqlDataAdapter("select Fname +' '+Sname +' ('+ PlayerID+ ')' as PName from tblPracticeConfirmation where IsDeleted=0 and IsAttending=1 and nextPDate='" + sdate + "' order by nextPDate Desc", con);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        lbPastConfirmedUsers.DataSource = ds;
        lbPastConfirmedUsers.DataTextField = "PName";
        lbPastConfirmedUsers.DataValueField = "PName";
        lbPastConfirmedUsers.DataBind();

    }

    #endregion

    protected void lbUnselectedUsers_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbPlayers.SelectedIndex = -1;
        lblmsgPaidPlayers.Text = "";
        SqlDataAdapter adp = new SqlDataAdapter();
        adp = new SqlDataAdapter("select * from tblUser where UserId='" + lbUnselectedUsers.SelectedValue + "' ", con);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        string s = "First Name: " + ds.Tables[0].Rows[0]["FName"].ToString() + "<br/>";
        s = s + "Surname: " + ds.Tables[0].Rows[0]["SName"].ToString() + "<br/>";
        s = s + "Email: " + ds.Tables[0].Rows[0]["EMail"].ToString() + "<br/>";
        s = s + "Phone: " + ds.Tables[0].Rows[0]["Phone"].ToString() + "<br/>";
        lblmsgPaidPlayers.Text = s;
        lblmsgPaidPlayers.ForeColor = System.Drawing.Color.White;
    }

    protected void lbUnselectedUsers1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["id"] = lbUnselectedUsers1.SelectedValue;
        lbPlayers1.SelectedIndex = -1;
        lblmsgPaidPlayers.Text = "";
        SqlDataAdapter adp = new SqlDataAdapter();
        adp = new SqlDataAdapter("select * from tblUser  where isNew=1 and UserId='" + lbUnselectedUsers1.SelectedValue + "' ", con);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        string s = "First Name: " + ds.Tables[0].Rows[0]["FName"].ToString() + "<br/>";
        s = s + "Surname: " + ds.Tables[0].Rows[0]["SName"].ToString() + "<br/>";
        s = s + "Email: " + ds.Tables[0].Rows[0]["EMail"].ToString() + "<br/>";
        s = s + "Phone: " + ds.Tables[0].Rows[0]["Phone"].ToString() + "<br/>";
        lblmsgPaidPlayers.Text = s;
        lblmsgPaidPlayers.ForeColor = System.Drawing.Color.White;
    }

    protected void lbPlayers_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbUnselectedUsers.SelectedIndex = -1;
        lblmsgPaidPlayers.Text = "";
        SqlDataAdapter adp = new SqlDataAdapter();
        adp = new SqlDataAdapter("select * from tblUser where UserId='" + lbPlayers.SelectedValue + "' ", con);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        string s = "First Name: " + ds.Tables[0].Rows[0]["FName"].ToString() + "<br/>";
        s = s + "Surname: " + ds.Tables[0].Rows[0]["SName"].ToString() + "<br/>";
        s = s + "Email: " + ds.Tables[0].Rows[0]["EMail"].ToString() + "<br/>";
        s = s + "Phone: " + ds.Tables[0].Rows[0]["Phone"].ToString() + "<br/>";
        lblmsgPaidPlayers.Text = s;
        lblmsgPaidPlayers.ForeColor = System.Drawing.Color.White;
    }

    protected void lbPlayers1_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbUnselectedUsers1.SelectedIndex = -1;
        lblmsgPaidPlayers.Text = "";
        SqlDataAdapter adp = new SqlDataAdapter();
        adp = new SqlDataAdapter("select * from tblUser where isNew=1 and UserId='" + lbPlayers1.SelectedValue + "' ", con);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        string s = "First Name: " + ds.Tables[0].Rows[0]["FName"].ToString() + "<br/>";
        s = s + "Surname: " + ds.Tables[0].Rows[0]["SName"].ToString() + "<br/>";
        s = s + "Email: " + ds.Tables[0].Rows[0]["EMail"].ToString() + "<br/>";
        s = s + "Phone: " + ds.Tables[0].Rows[0]["Phone"].ToString() + "<br/>";
        lblmsgPaidPlayers.Text = s;
        lblmsgPaidPlayers.ForeColor = System.Drawing.Color.White;
    }


    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        string query = @"update tblUser set IsDeleted=1 where UserId=" + ((LinkButton)sender).CommandArgument;
        query = query + ";update tblPracticeConfirmation set IsDeleted=1 where UserId=" + ((LinkButton)sender).CommandArgument;
        query = query + ";update tblPracticeConfirmation1 set IsDeleted=1 where UserId=" + ((LinkButton)sender).CommandArgument;
        cmd.CommandText = query;
        cmd.Connection = con;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        BindAllUsers();
        lbldelete.Text = "Player deleted successfully.";

    }
    protected void lbtnBlock_Click(object sender, EventArgs e)
    {
        string isactive = ((Label)((LinkButton)sender).NamingContainer.FindControl("lblIsActive")).Text;
        string cked = "0";
        if (isactive == "False")
        {
            cked = "1";
        }
        else
        {
            cked = "0";
        }
        cmd.CommandText = "update tblUser set IsActive=" + cked + " where UserId=" + ((LinkButton)sender).CommandArgument;
        cmd.Connection = con;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        BindAllUsers();
        lbldelete.Text = "Staus updated successfully.";

    }

    protected void chkBlock_OnCheckedChanged(object sender, EventArgs e)
    {

    }
    public void BindAllUsers()
    {
        SqlDataAdapter adp = new SqlDataAdapter();
        adp = new SqlDataAdapter("select * from tblUser where RoleId=2 and IsDeleted=0", con);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        grdUM.DataSource = ds;
        grdUM.DataBind();
    }
    protected void grdUM_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (((Label)e.Row.FindControl("lblIsActive")).Text == "True")
            {
                ((Label)e.Row.FindControl("lblstatuss")).Text = "Inactive";
                ((LinkButton)e.Row.FindControl("lbtnBlock")).Text = "Unblock";
                ((Label)e.Row.FindControl("lblstatuss")).ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                ((Label)e.Row.FindControl("lblstatuss")).Text = "Active";
                ((LinkButton)e.Row.FindControl("lbtnBlock")).Text = "Block";
                ((Label)e.Row.FindControl("lblstatuss")).ForeColor = System.Drawing.Color.Green;
            }
        }
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        lblTime.Text = DateTime.UtcNow.AddHours(-5.00).ToLongDateString() + " " + DateTime.UtcNow.AddHours(-5.00).ToLongTimeString();
    }
}