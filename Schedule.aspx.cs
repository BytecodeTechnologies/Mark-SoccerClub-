using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Schedule : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Server=speedwell.arvixe.com;Database=canadiansoccerclub;User Id=mijamal;Password=2014db!@#$");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            string[] controls = { "Tuesday Soccer", "Sunday Soccer", "Thursday Soccer", "Friday Soccer" };
            rbtnl.DataSource = controls;
            rbtnl.DataBind();
            rbtnl.SelectedIndex = 1;
            BindAllUsers();
        }

    }

    protected void rbtnl_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtnl.SelectedIndex == 1)
        {
            BindAllUsers();
        }
        else if (rbtnl.SelectedIndex == 0)
        {
            BindAllUsers1();
        }
        else if (rbtnl.SelectedIndex == 2)
        {
            BindAllUsersThursday();
        }
        else if (rbtnl.SelectedIndex == 3)
        {
            BindAllUsersFriday();
        }
    }
    public void BindAllUsersThursday()
    {
        SqlDataAdapter adp = new SqlDataAdapter();
        adp = new SqlDataAdapter("select id, Game,Dates as Date,times as Time from tblScheduleThursday", con);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        grdUM.DataSource = ds;
        grdUM.DataBind();
    }
    public void BindAllUsersFriday()
    {
        SqlDataAdapter adp = new SqlDataAdapter();
        adp = new SqlDataAdapter("select id, Game,Dates as Date,times as Time from tblScheduleSaturday", con);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        grdUM.DataSource = ds;
        grdUM.DataBind();
    }
    public void BindAllUsers()
    {
        SqlDataAdapter adp = new SqlDataAdapter();
        adp = new SqlDataAdapter("select id, Game,Dates as Date,times as Time from tblSchedule", con);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        grdUM.DataSource = ds;
        grdUM.DataBind();
    }
    public void BindAllUsers1()
    {
        SqlDataAdapter adp = new SqlDataAdapter();
        adp = new SqlDataAdapter("select ID, Game,Dates as Date,times as Time from tblSchedule1 order by ID", con);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        grdUM.DataSource = ds;
        grdUM.DataBind();
    }
    protected void grdUM_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //if (((Label)e.Row.FindControl("lblIsActive")).Text == "True")
            //{
            //    ((Label)e.Row.FindControl("lblstatuss")).Text = "Inactive";
            //    ((LinkButton)e.Row.FindControl("lbtnBlock")).Text = "Unblock";
            //    ((Label)e.Row.FindControl("lblstatuss")).ForeColor = System.Drawing.Color.Red;
            //}
            //else
            //{
            //    ((Label)e.Row.FindControl("lblstatuss")).Text = "Active";
            //    ((LinkButton)e.Row.FindControl("lbtnBlock")).Text = "Block";
            //    ((Label)e.Row.FindControl("lblstatuss")).ForeColor = System.Drawing.Color.Green;
            //}
        }
    }
}