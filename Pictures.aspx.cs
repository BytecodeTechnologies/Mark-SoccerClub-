using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pictures : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Server=speedwell.arvixe.com;Database=canadiansoccerclub;User Id=mijamal;Password=2014db!@#$");
    protected void Page_Load(object sender, EventArgs e)
    {
        BindRepeater();
    }
    protected void BindRepeater()
    {
        try
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select ImageId,Path from tblImages where IsDeleted=0 Order By(ImageId) DESC", con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            RepeaterImages.DataSource = table;
            RepeaterImages.DataBind();
            PagedDataSource pageds = new PagedDataSource();
            DataView dv = new DataView(table);
            pageds.DataSource = dv;
            pageds.AllowPaging = true;
            pageds.PageSize = 25;
            if (ViewState["PageNumber"] != null)
            {
                pageds.CurrentPageIndex = Convert.ToInt32(ViewState["PageNumber"]);
            }
            else
            {
                pageds.CurrentPageIndex = 0;
            }
            if (pageds.PageCount > 0)
            {
                RepeaterImages.Visible = true;
                ArrayList pages = new ArrayList();
                for (int i = 0; i < pageds.PageCount; i++)
                    pages.Add((i + 1).ToString());
                rptPaging.DataSource = pages;
                rptPaging.DataBind();
            }
            else
            {
                RepeaterImages.Visible = true;
            }
            RepeaterImages.DataSource = pageds;
            RepeaterImages.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public int PageNumber
    {
        get
        {
            if (ViewState["PageNumber"] != null)
            {
                return Convert.ToInt32(ViewState["PageNumber"]);
            }
            else
            {
                return 0;
            }
        }
        set { ViewState["PageNumber"] = value; }
    }
    protected void rptPaging_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        ViewState["PageNumber"] = Convert.ToInt32(e.CommandArgument) - 1;
        BindRepeater();
    }
}
