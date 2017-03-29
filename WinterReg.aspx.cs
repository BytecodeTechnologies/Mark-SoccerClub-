using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class WinterReg : System.Web.UI.Page
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
                //lblhometext.Text = ds.Tables[0].Rows[0]["HomePageTemplet"].ToString();
                con.Dispose();
            }
            else
            {
                Response.Write("error");
            }
        }


    }
    protected void btnRegSubmit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            SqlConnection con = new SqlConnection("Server=speedwell.arvixe.com;Database=canadiansoccerclub;User Id=mijamal;Password=2014db!@#$");
            SqlDataAdapter adp = new SqlDataAdapter("select * from tbluser where isdeleted=0 and isher is null and PlayerID is not null and email='" + tbRegEmail + "'", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Response.Redirect("Success.aspx?reg=done");
            }
            else
            {
                // SqlConnection con = new SqlConnection("Server=speedwell.arvixe.com;Database=canadiansoccerclub;User Id=mijamal;Password=2014db!@#$");
                SqlCommand cmd = new SqlCommand();
                if (chkS.Checked == false && chkT.Checked == false && chkTh.Checked == false)
                {
                    chkS.Checked = true;
                }
                string sun = chkS.Checked == true ? "1" : "0";
                string thu = chkT.Checked == true ? "1" : "0";
                string thu2 = chkTh.Checked == true ? "1" : "0";
                string fry = chkF.Checked == true ? "1" : "0";

                string q = "delete from tblUser where email='" + tbRegEmail.Text + "' and roleid=2; ";
                string query = q + @"insert into tblUser (PlayerID,Password,Fname,Sname,Email,Phone,Position,RoleID,isPaid,IsActive,IsDeleted,isPaid1,isNew,Sunday,Tuesday,Thursday,Saturday,isPaid2,ispaidsat)
            values(" + "'" + tbRegUserId.Text + "','" + tbRegPassword.Text + "','" +
                                            tbFirstName.Text + "','" +
                                            tbSurname.Text + "','" +
                                            tbRegEmail.Text + "','" +
                                            tbRegPhoneNumber.Text + "','" +
                                            ddlRegPosition.SelectedItem.Text + "',2,0,0,0,0,1," + sun + "," + thu + "," + thu2 + "," + fry + ",0,0 )";

                cmd.CommandText = query;// "drop table tblUser";
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                con.Dispose();

                Response.Redirect("Success.aspx",true);
            }
        }
        catch (Exception ex)
        {
            //Response.Write(ex.Message);
        }


    }
    protected void btnc_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection("Server=speedwell.arvixe.com;Database=canadiansoccerclub;User Id=mijamal;Password=2014db!@#$");
        SqlDataAdapter adp = new SqlDataAdapter("select * from tbluser where email='" + txtcemail.Text + "'", con);
        DataSet ds = new DataSet();
        Int32 s;

        if (CheckBox1.Checked == false && CheckBox2.Checked == false && CheckBox3.Checked == false && CheckBox4.Checked == false)
        {
            CheckBox1.Checked = true;
        }

        if (CheckBox1.Checked)
        {
            s = 1;
        }
        else
        {
            s = 0;
        }
        Int32 s1;
        if (CheckBox2.Checked)
        {
            s1 = 1;
        }
        else
        {
            s1 = 0;
        }

        Int32 s3;
        if (CheckBox3.Checked)
        {
            s3 = 1;
        }
        else
        {
            s3 = 0;
        }

        Int32 s4; //friday
        if (CheckBox4.Checked)
        {
            s4 = 1;
        }
        else
        {
            s4 = 0;
        }

        adp.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["PlayerID"].ToString() == "")
            {
                lblmsgc.Text = "You are not registered with us. Please complete new player registration.";
            }
            else
            {
                lblmsgc.Text = "Registration confirmed.";
                SqlCommand cmd = new SqlCommand();
                string query = @"update tbluser set isnew=1,RoleID=2,isDeleted=0, isPaid=0,Sunday=" + s + ",Tuesday=" + s1 + ",Thursday=" + s3 + ",Saturday=" + s4 + " where email='" + txtcemail.Text + "'";
                cmd.CommandText = query;
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                con.Dispose();
                txtcemail.Text = "";
            }
        }
        else
        {
            lblmsgc.Text = "You are not registered with us. Please complete new player registration.";
        }
    }
}