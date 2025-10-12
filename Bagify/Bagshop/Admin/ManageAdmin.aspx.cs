using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace Bagshop.Admin
{
    public partial class ManageAdmin : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);
        SqlCommand cmd = new SqlCommand();



        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd.CommandText = "Update admin set Adminpassword='"+txtconfirmpassward.Text+"' where Adminname='"+txtname.Text+"'";
            cmd.Connection = cn;
            cmd.ExecuteNonQuery();
            cn.Close();

            ClientScript.RegisterStartupScript(Page.GetType(), "Update", "<script language = 'javascript'>alert('Data Updated!!!')</script>");
            GridView1.DataBind();
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd.CommandText = "Insert into Admin values('" + txtname.Text + "','" + txtconfirmpassward.Text + "')";
            cmd.Connection = cn;
            cmd.ExecuteNonQuery();
            ClientScript.RegisterStartupScript(Page.GetType(), "Insert", "<script language = 'javascript'>alert('Data Saved!!!')</script>");
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtname.Text = GridView1.SelectedRow.Cells[1].Text;
            txtoldpassward.Text = GridView1.SelectedRow.Cells[2].Text;
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            txtname.Text = "";
            txtoldpassward.Text = "";
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd.CommandText = "Delete from Admin where Adminname='" + txtname.Text + "'";
            cmd.Connection = cn;
            cmd.ExecuteNonQuery();
            cn.Close();
            ClientScript.RegisterStartupScript(Page.GetType(), "Delete", "<script language = 'javascript'>alert('Data Deleted!!!')</script>");
            GridView1.DataBind();

        }
    }
}