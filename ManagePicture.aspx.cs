using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            
            BindGrid();
        }

    }
    protected void btnSaveImage_Click(object sender, EventArgs e)
    {
        try
        {
            if (UploadImage.HasFile)
            {
                string fileName = UploadImage.FileName.ToString();
                UploadImage.PostedFile.SaveAs(Server.MapPath(@"\ImageUpload\" + fileName));
                string path = @"\ImageUpload\" + fileName;
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into tblImages(ImageName,path,IsDeleted,AddedDate,AddedBy) values('" + fileName + "','" + path + "','" + 0 + "','" + DateTime.Now.ToLongDateString() + "','" + 1 + "')", con);
                cmd.ExecuteNonQuery();
                lblMsgDisplay.Text = "Image Saved Successfully..!!";
                BindGrid();
                con.Close();
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
        }
        catch (Exception ex)
        {
            throw ex;
        }
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
