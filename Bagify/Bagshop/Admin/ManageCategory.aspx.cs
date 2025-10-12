using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace Bagshop.Admin
{
    public partial class ManageCategory : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnnew_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd.CommandText = "Select count (Catid) from Catagery";
            cmd.Connection = cn;
            int n = Convert.ToInt32(cmd.ExecuteScalar());
            n++;
            txtid.Text = n.ToString();
            cn.Close();
            GridView1.DataBind();
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd.CommandText= "Insert into Catagery values("+txtid.Text+",'"+txtname.Text+"','"+imgcategoryimage.ImageUrl+"','"+txtinfo.Text+"')";
            cmd.Connection = cn;
            cmd.ExecuteNonQuery();
            cn.Close();
            clear();
            ClientScript.RegisterStartupScript(Page.GetType(), "Insert", "<script language = 'javascript'>alert('catagery saved!!!')</script>");
            GridView1.DataBind();
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd.CommandText = "Update Catagery set catname='" + txtname.Text + "', catimage='" + imgcategoryimage.ImageUrl + "', catinfo='" + txtinfo.Text + "' where catid= " + txtid.Text + "";
            cmd.Connection = cn;
            cmd.ExecuteNonQuery();
            cn.Close();
            GridView1.DataBind();
            clear();
            ClientScript.RegisterStartupScript(Page.GetType(),"Update", "<script language='javascript'>alert('Categery updated!!!')</script>");
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd.CommandText = "delete from Catagery where catid = " + txtid.Text + "";
            cmd.Connection = cn;
            cmd.ExecuteNonQuery();
            cn.Close();
            GridView1.DataBind();
            clear();
            ClientScript.RegisterStartupScript(Page.GetType(), "Delete", "<script language = 'javascript'>alert('Catagery deleted!!!')</script>");
            
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            txtname.Text = "";
            imgcategoryimage.ImageUrl = "";
            txtinfo.Text = "";

        }

        protected void btnupload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile == true)
            {
                FileUpload1.SaveAs(Server.MapPath("~\\Images\\" + FileUpload1.FileName));
                imgcategoryimage.ImageUrl = "~\\images\\" + FileUpload1.FileName;
            }
        
        }

        protected void clear()
        {

            txtid.Text = "";
            txtname.Text = "";
            imgcategoryimage.ImageUrl = "";
            txtinfo.Text = "";
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtid.Text = GridView1.SelectedRow.Cells[1].Text;
            txtname.Text = GridView1.SelectedRow.Cells[2].Text;
            imgcategoryimage.ImageUrl = GridView1.SelectedRow.Cells[3].Text;
            txtinfo.Text = GridView1.SelectedRow.Cells[4].Text;

        }
    }
}