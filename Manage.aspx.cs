using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Net.Mail;

public partial class Manage : System.Web.UI.Page
{
    public double DLHour = 0.0;
    public static string table = "";
    SqlConnection con = new SqlConnection("Server=speedwell.arvixe.com;Database=canadiansoccerclub;User Id=mijamal;Password=2014db!@#$");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["ds"] != null)
            {
                DataSet ds = (DataSet)Session["ds"];
            }
            else
            {
                Response.Redirect("default.aspx");
            }

            string[] controls = { "Tuesday Soccer", "Sunday Soccer", "Thursday Soccer", "Friday Soccer" };
            rb.DataSource = controls;
            rb.DataBind();
            //rbl1.Items[1].Text = "Sunday Soccer";
            rb.SelectedIndex = 1;

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

            bindgrid();
        }

    }
    public void bindgrid()
    {
        Session["sun"] = "true";
        SqlDataAdapter adp = new SqlDataAdapter("select id, Fname +' '+Sname +' ('+ PlayerID+ ')' as PName, CDate,ispaid from tblPracticeConfirmation where IsAttending=1 and IsDeleted=0 and NextPDate='" + getNextPDate() + "'  order by CDate", con);

        DataSet ds2 = new DataSet();
        adp.Fill(ds2);
        grd.DataSource = ds2; grd.DataBind();
        Session["sun"] = null;
    }

    protected void rb_SelectedIndexChanged(object sender, EventArgs e)
    {

        SqlDataAdapter adp = new SqlDataAdapter();

        if (rb.SelectedIndex == 0)
        {
            Session["thu"] = "true";
            adp = new SqlDataAdapter("select id, Fname +' '+Sname +' ('+ PlayerID+ ')' as PName, CDate,IsPaid from tblPracticeConfirmation1 where IsAttending=1 and IsDeleted=0  and NextPDate='" + getNextPDate() + "'  order by CDate", con);
            table = "tblPracticeConfirmation1";
            Session["thu"] = null;

        }
        if (rb.SelectedIndex == 2)
        {
            Session["thursday"] = "true";
            adp = new SqlDataAdapter("select id, Fname +' '+Sname +' ('+ PlayerID+ ')' as PName, CDate,IsPaid from tblPracticeConfirmation2 where IsAttending=1 and IsDeleted=0  and NextPDate='" + getNextPDate() + "'  order by CDate", con);
            table = "tblPracticeConfirmation2";
            Session["thursday"] = null;
        }
        if (rb.SelectedIndex == 1)
        {
            Session["sun"] = "true";
            adp = new SqlDataAdapter("select id, Fname +' '+Sname +' ('+ PlayerID+ ')' as PName, CDate,IsPaid from tblPracticeConfirmation where IsAttending=1 and IsDeleted=0  and NextPDate='" + getNextPDate() + "'  order by CDate", con);
            table = "tblPracticeConfirmation";
            Session["sun"] = null;
        }//adp = new SqlDataAdapter("select  Fname +' '+Sname +' ('+ PlayerID+ ')' as PName, CDate from tblPracticeConfirmation where IsDeleted=0 and NextPDate='" + getNextPDate() + "' and isOthers=0 and IsAttending=1 ", con);

        if (rb.SelectedIndex == 3)
        {
            Session["fri"] = "true";
            adp = new SqlDataAdapter("select id, Fname +' '+Sname +' ('+ PlayerID+ ')' as PName, CDate,IsPaid from tblPracticeConfirmSaturday where IsAttending=1 and IsDeleted=0 and NextPDate='" + getNextPDate() + "'  order by CDate", con);
            table = "tblPracticeConfirmSaturday";
            Session["fri"] = null;
        }

        DataSet ds = new DataSet();
        adp.Fill(ds);

        grd.DataSource = ds;
        grd.DataBind();
    }

    public string getNextPDate()
    {
        double days = 0.0;
        string day = DateTime.UtcNow.AddHours(-4.0).AddHours(DLHour).DayOfWeek.ToString();
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
            return DateTime.UtcNow.AddHours(-4.0).AddHours(DLHour).AddDays(days).ToShortDateString();
        }
        if (Session["thursday"] != null)//thursday
        {
            if (day == "Monday")
            {
                days = 3.0;
            }
            if (day == "Tuesday")
            {
                days = 2.0;
            }
            if (day == "Wednesday")
            {
                days = 1.0;
            }
            if (day == "Thursday")
            {
                days = 0.0;
            }
            if (day == "Friday")
            {
                days = 6.0;
            }
            if (day == "Saturday")
            {
                days = 5.0;
            }
            if (day == "Sunday")
            {
                days = 4.0;
            }
            return DateTime.UtcNow.AddHours(-4.0).AddHours(DLHour).AddDays(days).ToShortDateString();
        }
        if (Session["sun"] != null)//Sunday
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
            return DateTime.UtcNow.AddHours(-4.0).AddHours(DLHour).AddDays(days).ToShortDateString();
        }

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
            return DateTime.UtcNow.AddHours(-4.0).AddHours(DLHour).AddDays(days).ToShortDateString();
        }

        return DateTime.UtcNow.AddHours(-4.0).AddHours(DLHour).AddDays(days).ToShortDateString();
    }

    protected void delete_Click(object sender, EventArgs e)
    {
        Int32 id = Convert.ToInt32(((LinkButton)sender).CommandArgument);
        SqlCommand cmd = new SqlCommand();

        cmd.CommandText = "update "+ table+" set isdeleted=1 where Id=" + id;
               
        cmd.Connection = con;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

            rb.SelectedIndexChanged += rb_SelectedIndexChanged;
    }
}