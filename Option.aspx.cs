using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Option : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["done"] != null)
            {
                if (Request.QueryString["done"].ToString() == "t")
                {
                    lbl.Text = "Attendence confirmation status is updated for Tuesday.";
                }
                if (Request.QueryString["done"].ToString() == "th")
                {
                    lbl.Text = "Attendence confirmation status is updated for Thursday.";
                }
                if (Request.QueryString["done"].ToString() == "s")
                {
                    lbl.Text = "Attendence confirmation status is updated for Sunday.";
                }
                if (Request.QueryString["done"].ToString() == "sat")
                {
                    lbl.Text = "Attendence confirmation status is updated for Friday.";
                }
                if (Request.QueryString["done"].ToString() == "no")
                {
                    lbl.Text = "Attendence confirmation status is not updated.";
                }
            }
            if (Session["ds"] != null)
            {
                DataSet ds = (DataSet)Session["ds"];
                if (ds.Tables[0].Rows[0]["Sunday"].ToString().ToLower() == "false")
                {
                    btns.Visible = false;
                }
                else
                {
                    btns.Visible = true;
                }
                if (ds.Tables[0].Rows[0]["Tuesday"].ToString().ToLower() == "false")
                {
                    btnt.Visible = false;
                }
                else
                {
                    btnt.Visible = true;
                }
                if (ds.Tables[0].Rows[0]["Thursday"].ToString().ToLower() == "false")
                {
                    btnth.Visible = false;
                }
                else
                {
                    btnth.Visible = true;
                }
                if (ds.Tables[0].Rows[0]["Saturday"].ToString().ToLower() == "false")
                {
                    btnsat.Visible = false;
                }
                else
                {
                    btnsat.Visible = true;
                }

            }
            else
            {
                Response.Redirect("default.aspx");
            }
        }

    }
    protected void btnt_Click(object sender, EventArgs e)
    {
        Session["thu"] = "true";
        Session["thursday"] = null;
        Session["sun"] = null;
        Session["fri"] = null;
        Response.Redirect("tuesday.aspx");
    }


    protected void btns_Click(object sender, EventArgs e)
    {
        Session["sun"] = "true";
        Session["thu"] = null;
        Session["thursday"] = null;
        Session["fri"] = null;
        Response.Redirect("sunday.aspx");
    }

    protected void btnth_Click(object sender, EventArgs e)
    {
        Session["thursday"] = "true";
        Session["thu"] = null;
        Session["sun"] = null;
        Session["fri"] = null;
        Response.Redirect("thursday.aspx");
    }

    protected void btnsat_Click(object sender, EventArgs e)
    {
        Session["fri"] = "true";
        Session["thursday"] = null;
        Session["thu"] = null;
        Session["sun"] = null;
        Session["emails"] = "no";
        Response.Redirect("saturday.aspx");
    }


}