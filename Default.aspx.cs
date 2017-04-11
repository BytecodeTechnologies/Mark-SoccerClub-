using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {       

        if (!IsPostBack)
        {
           // ddlRegPosition.Items.Add(new ListItem("Select Position", "0"));
            ddlRegPosition.Items.Add(new ListItem("Sweeper", "1"));
            ddlRegPosition.Items.Add(new ListItem("Defender", "1"));
            ddlRegPosition.Items.Add(new ListItem("Forward", "2"));
            ddlRegPosition.Items.Add(new ListItem("Goalie", "3"));
            ddlRegPosition.Items.Add(new ListItem("Midfielder", "4"));
            ddlRegPosition.Items.Add(new ListItem("Striker", "5"));
            ddlRegPosition.Items.Add(new ListItem("Sweeper", "6"));
          

            SqlConnection con = new SqlConnection("Server=speedwell.arvixe.com;Database=canadiansoccerclub;User Id=mijamal;Password=2014db!@#$");
            SqlDataAdapter adp = new SqlDataAdapter("select * from tblSetting", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                litVideoMarkUp.Text = ds.Tables[0].Rows[0]["youtubeurl"].ToString();// "<iframe width='420' height='315' src='http://www.youtube.com/embed/IBYXU7jUBHM' frameborder='0' allowfullscreen></iframe>";
                lblVideoText.Text = ds.Tables[0].Rows[0]["HomeVideoTemplet"].ToString();
                lblhometext.Text = ds.Tables[0].Rows[0]["HomePageTemplet"].ToString();
                con.Dispose();
            }
            else
            {
                Response.Write("error");
            }
        }


    }

    protected void btnLogIn_Click(object sender, ImageClickEventArgs e)
    
    {
        try
        {
            SqlConnection con = new SqlConnection("Server=speedwell.arvixe.com;Database=canadiansoccerclub;User Id=mijamal;Password=2014db!@#$");
            SqlDataAdapter adp = new SqlDataAdapter("select * from tblUser where PlayerID='" + tbUserLogInId.Text + "' and Password='" + tbUserLogInPassword.Text + "' and IsActive=0 and IsDeleted=0", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["ds"] = ds;
                con.Dispose();
                if (ds.Tables[0].Rows[0]["RoleID"].ToString() == "1")
                {
                     Response.Redirect("Main.aspx?action=confirmation");
                  
                }
                else
                { 
                    Response.Redirect("option.aspx");

                }
            }
            else
            {

                lblmsg.Text = "Wrong Player ID/ Password.";
            }
        }
        catch (Exception ex)
        {

        }
        if (!IsValid)
        {
            return;
        }
    }

    protected void btnRegSubmit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

            SqlConnection con = new SqlConnection("Server=speedwell.arvixe.com;Database=canadiansoccerclub;User Id=mijamal;Password=2014db!@#$");
            SqlCommand cmd = new SqlCommand();

            string query = @"insert into tblUser (PlayerID,Password,Fname,Sname,Email,Phone,Position,RoleID,isPaid,IsActive,IsDeleted,isPaid1)
            values(" + "'" + tbRegUserId.Text + "','" + tbRegPassword.Text + "','" +
                                        tbFirstName.Text + "','" +
                                        tbSurname.Text + "','" +
                                        tbRegEmail.Text + "','" +
                                        tbRegPhoneNumber.Text + "','" +
                                        ddlRegPosition.SelectedItem.Text + "',2,0,0,0,0 )";
            
            cmd.CommandText = query;// "drop table tblUser";
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            
            Response.Redirect("Success.aspx?reg=done");
            
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }

    }

    protected void cvLogIn_ServerValidate(object source, ServerValidateEventArgs args)
    {
       
    }

    protected void cvRegUniqueUserId_ServerValidate(object source, ServerValidateEventArgs args)
    {
        
    }
}