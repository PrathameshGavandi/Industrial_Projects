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
    public partial class Product : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);
        SqlCommand cmd = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnaddnew_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd.CommandText = "Select count (pid) from product";
            cmd.Connection = cn;
            int n = Convert.ToInt32(cmd.ExecuteScalar());
            n++;
            txtid.Text = n.ToString();
            cn.Close();
        }

        protected void btnasave_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd.CommandText = "Insert into Product values(" + txtid.Text + ",'" + txtname.Text + "','" + drpcatagery.Text + "'," + txtprice.Text + ",'" + txtspecification.Text + "','" + Image1.ImageUrl + "',"+txtstock.Text+")";
            cmd.Connection = cn;
            cmd.ExecuteNonQuery();
            cn.Close();
            clear();
            ClientScript.RegisterStartupScript(Page.GetType(), "Insert", "<script language = 'javascript'>alert('Product saved!!!')</script>");
            GridView1.DataBind();
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd.CommandText = "update product set pname='" + txtname.Text + "',pcatagery='" + drpcatagery.Text + "',price=" + txtprice.Text + ",pspecification='" + txtspecification.Text + "',image='" + Image1.ImageUrl + "',Stock ="+txtstock.Text+" where pid= " + txtid.Text + "";
            cmd.Connection = cn;
            cmd.ExecuteNonQuery();
            cn.Close();
            clear();
            ClientScript.RegisterStartupScript(Page.GetType(), "Update", "<script language='javascript'>alert('Product updated!!!')</script>");
            GridView1.DataBind();
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd.CommandText = "delete from product where pid = " + txtid.Text + "";
            cmd.Connection = cn;
            cmd.ExecuteNonQuery();
            cn.Close();
            clear();
            ClientScript.RegisterStartupScript(Page.GetType(), "Delete", "<script language='javascript'>alert('Product deleted!!!')</script>");
            GridView1.DataBind();
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            txtname.Text = "";
            txtprice.Text = "";
            txtspecification.Text = "";
            Image1.ImageUrl = "";
            txtstock.Text = "";
        }

        protected void btnupload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile == true)
            {
                FileUpload1.SaveAs(Server.MapPath("~\\Images\\" + FileUpload1.FileName));
                Image1.ImageUrl = "~\\Images\\" + FileUpload1.FileName;
            }
        }

        protected void clear()
        {
            txtid.Text = "";
            txtname.Text = "";
            txtprice.Text = "";
            txtspecification.Text = "";
            Image1.ImageUrl = "";
            txtstock.Text = "";

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtid.Text = GridView1.SelectedRow.Cells[1].Text;
            txtname.Text = GridView1.SelectedRow.Cells[2].Text;
            drpcatagery.Text = GridView1.SelectedRow.Cells[3].Text;

            txtprice.Text = GridView1.SelectedRow.Cells[4].Text;
            txtspecification.Text = GridView1.SelectedRow.Cells[5].Text;
            Image1.ImageUrl = GridView1.SelectedRow.Cells[6].Text;
            txtstock.Text = GridView1.SelectedRow.Cells[7].Text;

        }
    }
}