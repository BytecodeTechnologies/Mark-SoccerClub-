using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManageHersheyUser : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Server=speedwell.arvixe.com;Database=canadiansoccerclub;User Id=mijamal;Password=2014db!@#$");
    protected void Page_Load(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void BindGrid()
    {
        try
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select UserId,FName,SName,Email,Phone from tblUser where isher=1 and IsDeleted=1", con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            gridview.DataSource = table;
            gridview.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lblRetain_Click(object sender, EventArgs e)
    {
        try
        {
            string query = "update tblUser set IsDeleted=0 where UserId=" + ((LinkButton)sender).CommandArgument;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            lblMsgDisplay.Text = "Image Retain Successfully..!!";
            BindGrid();
            
            con.Close();
        }
        catch (Exception)
        {

            throw;
        }
    }

    protected void gridview_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        lblMsgDisplay.Text = "";
        BindGrid();
        gridview.PageIndex = e.NewPageIndex;
        gridview.DataBind();
    }
}