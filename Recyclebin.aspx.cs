using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Recyclebin : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Server=speedwell.arvixe.com;Database=canadiansoccerclub;User Id=mijamal;Password=2014db!@#$");
    SqlCommand cmd = new SqlCommand();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ds"] != null)
        {
            adminMenu.Style.Add(HtmlTextWriterStyle.Width, "909px");
            //  this.Master.FindControl("header").Visible = true;
            if (!IsPostBack)
            {
                BindAllUsers();
                BindGridForHersheyUsers();
            }

        }
        else
        {
            Response.Redirect("Default.aspx");
        }

    }
    public void BindGridForHersheyUsers()
    {
        SqlDataAdapter adp = new SqlDataAdapter();
        adp = new SqlDataAdapter("select * from tblUser where isher=1 and isdeleted=0 ", con);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        string squery = "delete from tblUser where UserId=" + ((LinkButton)sender).CommandArgument;
        squery = squery + ";" + "delete from tblPracticeConfirmation where UserId=" + ((LinkButton)sender).CommandArgument;
        cmd.CommandText = squery;
        cmd.Connection = con;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        BindAllUsers();
        BindGridForHersheyUsers();
        lbldelete.Text = "Player deleted successfully.";

    }
    protected void lbtnBlock_Click(object sender, EventArgs e)
    {
        string isactive = ((Label)((LinkButton)sender).NamingContainer.FindControl("lbluserids")).Text;
       
        String query = "update tblUser set IsDeleted=0 where UserId=" + ((LinkButton)sender).CommandArgument;
        query = query + "; update tblPracticeConfirmation set IsDeleted=0 where UserId=" + ((LinkButton)sender).CommandArgument ;
        cmd.CommandText = query;
        cmd.Connection = con;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        BindAllUsers();
        lbldelete.Text = "Staus updated successfully.";

    }
    public void BindAllUsers()
    {
        SqlDataAdapter adp = new SqlDataAdapter();
        adp = new SqlDataAdapter("select * from tblUser where RoleId=2 and IsDeleted=1", con);
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