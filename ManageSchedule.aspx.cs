using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class ManageSchedule : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Server=speedwell.arvixe.com;Database=canadiansoccerclub;User Id=mijamal;Password=2014db!@#$");
    SqlCommand cmd = new SqlCommand();

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
            BindAllUsersThursDay();
        }
        else if (rbtnl.SelectedIndex == 3)
        {
            BindAllUsersSaturday();
        }
        lblmsg.Text = "";
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            string[] controls = { "Tuesday Soccer", "Sunday Soccer","Thursday Soccer", "Friday Soccer" };
            rbtnl.DataSource = controls;
            rbtnl.DataBind();
            rbtnl.SelectedIndex = 1;
            if (Session["ds"] != null)
            {
                DataSet ds = (DataSet)Session["ds"];
                if (ds.Tables[0].Rows[0]["RoleID"].ToString() == "2")
                {
                    Session.Abandon();
                    Response.Redirect("Default.aspx");
                }
            }
            BindAllUsers();
            adminMenu.Style.Add(HtmlTextWriterStyle.Width, "909px");
        }
    }
    public void BindAllUsers()
    {
        SqlDataAdapter adp = new SqlDataAdapter();
        adp = new SqlDataAdapter("select ID, Game,Dates as Date,times as Time from tblSchedule  order by ID", con);
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
    public void BindAllUsersThursDay()
    {
        SqlDataAdapter adp = new SqlDataAdapter();
        adp = new SqlDataAdapter("select ID, Game,Dates as Date,times as Time from tblScheduleThursday order by ID", con);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        grdUM.DataSource = ds;
        grdUM.DataBind();
    }
    public void BindAllUsersSaturday()
    {
        SqlDataAdapter adp = new SqlDataAdapter();
        adp = new SqlDataAdapter("select ID, Game,Dates as Date,times as Time from tblScheduleSaturday order by ID", con);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        grdUM.DataSource = ds;
        grdUM.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        if (rbtnl.SelectedIndex == 1)
        {
            cmd.CommandText = "insert into tblSchedule (Game,Dates,times)values('" + txtGame.Text + "','" + txtDate.Text + "','" + txtTime.Text + "')";
        }
        if (rbtnl.SelectedIndex == 0)
        {
            cmd.CommandText = "insert into tblSchedule1 (Game,Dates,times)values('" + txtGame.Text + "','" + txtDate.Text + "','" + txtTime.Text + "')";
        }
        if (rbtnl.SelectedIndex == 2)
        {
            cmd.CommandText = "insert into tblScheduleThursday (Game,Dates,times)values('" + txtGame.Text + "','" + txtDate.Text + "','" + txtTime.Text + "')";
        }
        if (rbtnl.SelectedIndex == 3)
        {
            cmd.CommandText = "insert into tblScheduleSaturday (Game,Dates,times)values('" + txtGame.Text + "','" + txtDate.Text + "','" + txtTime.Text + "')";
        }

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
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
            BindAllUsersThursDay();
        }
        else if (rbtnl.SelectedIndex == 3)
        {
            BindAllUsersSaturday();
        }

        lblmsg.Text = "Data saved successfully.";
        txtDate.Text = "";
        txtGame.Text = "";
        txtTime.Text = "";
    }

    protected void grdUM_RowEditing(object sender, GridViewEditEventArgs e)
    {
        lblmsg.Text = "";
        grdUM.EditIndex = e.NewEditIndex;
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
            BindAllUsersThursDay();
        }
        else if (rbtnl.SelectedIndex == 3)
        {
            BindAllUsersSaturday();
        }
    }
    protected void grdUM_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int userid = Convert.ToInt32(grdUM.DataKeys[e.RowIndex].Values["Id"].ToString());
        con.Open();
        SqlCommand cmd = new SqlCommand();
        if (rbtnl.SelectedIndex == 1)
        {
            cmd = new SqlCommand("delete from tblSchedule where Id=" + userid, con);
        }
        else if (rbtnl.SelectedIndex == 0)
        {
            cmd = new SqlCommand("delete from tblSchedule1 where Id=" + userid, con);
        }
        else if (rbtnl.SelectedIndex == 2)
        {
            cmd = new SqlCommand("delete from tblScheduleThursday where Id=" + userid, con);
        }
        else if (rbtnl.SelectedIndex == 3)
        {
            cmd = new SqlCommand("delete from tblScheduleSaturday where Id=" + userid, con);
        }
        int result = cmd.ExecuteNonQuery();
        con.Close();
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
            BindAllUsersThursDay();
        }
        else if (rbtnl.SelectedIndex == 3)
        {
            BindAllUsersSaturday();
        }
        lblmsg.Text = "Data deleted successfully";
    }
    protected void grdUM_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int userid = Convert.ToInt32(grdUM.DataKeys[e.RowIndex].Value.ToString());
        TextBox username = (TextBox)grdUM.Rows[e.RowIndex].FindControl("TextBox1");
        TextBox txtcity = (TextBox)grdUM.Rows[e.RowIndex].FindControl("TextBox2");
        TextBox txtDesignation = (TextBox)grdUM.Rows[e.RowIndex].FindControl("TextBox3");
        con.Open();
        SqlCommand cmd=new SqlCommand();
        if (rbtnl.SelectedIndex == 1)
        {
            cmd = new SqlCommand("update tblSchedule set Game='" + username.Text + "',Dates='" + txtcity.Text + "',Times='" + txtDesignation.Text + "' where Id=" + userid, con);

        }
        else if (rbtnl.SelectedIndex == 0)        
        {
            cmd = new SqlCommand("update tblSchedule1 set Game='" + username.Text + "',Dates='" + txtcity.Text + "',Times='" + txtDesignation.Text + "' where Id=" + userid, con);

        }
        else if (rbtnl.SelectedIndex == 2)
        {
            cmd = new SqlCommand("update tblScheduleThursday set Game='" + username.Text + "',Dates='" + txtcity.Text + "',Times='" + txtDesignation.Text + "' where Id=" + userid, con);

        }
        else if (rbtnl.SelectedIndex == 3)
        {
            cmd = new SqlCommand("update tblScheduleSaturday set Game='" + username.Text + "',Dates='" + txtcity.Text + "',Times='" + txtDesignation.Text + "' where Id=" + userid, con);

        }


        cmd.ExecuteNonQuery();
        con.Close();
        grdUM.EditIndex = -1;
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
            BindAllUsersThursDay();
        }
        else if (rbtnl.SelectedIndex == 3)
        {
            BindAllUsersSaturday();
        }
        lblmsg.Text = "Data updated successfully";
       
       
    }
    protected void grdUM_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        lblmsg.Text = "";
        grdUM.EditIndex = -1;
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
            BindAllUsersThursDay();
        }
        else if (rbtnl.SelectedIndex == 3)
        {
            BindAllUsersSaturday();
        }
    }
}