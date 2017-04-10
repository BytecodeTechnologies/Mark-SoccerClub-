using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Server=speedwell.arvixe.com;Database=canadiansoccerclub;User Id=mijamal;Password=2014db!@#$");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["ds"] != null)
            {
                BindGrid();
            }
            else
            {
                Response.Redirect("default.aspx");
            }
        }
    }
    protected void btnSaveImage_Click(object sender, EventArgs e)
    {
        try
        {
            if (UploadImage.HasFile)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFile PostedFile = Request.Files[i];
                    if (PostedFile.ContentLength > 0)
                    {
                        Guid ImageId = Guid.NewGuid();
                        string FileName = Path.GetFileName(PostedFile.FileName);
                        PostedFile.SaveAs(Server.MapPath("/ImageUpload/") + ImageId + FileName);
                        string path = @"\ImageUpload\" + ImageId + FileName;
                        con.Open();
                        SqlCommand cmd = new SqlCommand("insert into tblImages(ImageName,path,IsDeleted,AddedDate,AddedBy) values('" + FileName + "','" + path + "','" + 0 + "','" + DateTime.Now + "','" + 1 + "')", con);
                        cmd.ExecuteNonQuery();
                        BindGrid();
                        con.Close();
                    }
                }
                lblMsgDisplay.Text = "Image Saved Successfully..!!";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void BindGrid()
    {
        try
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select ImageId,ImageName,Path from tblImages where IsDeleted=0 Order By(ImageId) DESC", con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            gridview.DataSource = table;
            gridview.DataBind();
            PagedDataSource pageds = new PagedDataSource();
            DataView dv = new DataView(table);
            pageds.DataSource = dv;
            pageds.AllowPaging = true;
            pageds.PageSize = 10;
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
                gridview.Visible = true;
                ArrayList pages = new ArrayList();
                for (int i = 0; i < pageds.PageCount; i++)
                    pages.Add((i + 1).ToString());
                rptPaging.DataSource = pages;
                rptPaging.DataBind();
            }
            else
            {
                gridview.Visible = true;
            }
            gridview.DataSource = pageds;
            gridview.DataBind();
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
        BindGrid();
    }

    protected void lbtnDelete1_Click1(object sender, EventArgs e)
    {
        try
        {
            string query = "update tblImages set IsDeleted=1 where ImageId=" + ((LinkButton)sender).CommandArgument;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            lblMsgDisplay.Text = "Image Deleted Successfully..!!";
            BindGrid();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
