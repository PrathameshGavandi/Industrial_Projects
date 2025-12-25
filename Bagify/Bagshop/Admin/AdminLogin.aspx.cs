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
    public partial class AdminLogin : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlDataReader dr;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        String strAdminname, strAdminpassword;

        protected void btncancel_Click(object sender, EventArgs e)
        {
            txtname.Text = "";
            txtpassword.Text = "";
        }

        protected void btnlogin_Click2(object sender, EventArgs e)
        {
            
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            cn.Close();
            cn.Open();
            cmd.CommandText = "select * from Admin  where Adminname='" + txtname.Text + "' and Adminpassword='" + txtpassword.Text + "'";
            cmd.Connection = cn;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    strAdminname = dr.GetString(0);
                    strAdminpassword = dr.GetString(1);
                }
            }
            cn.Close();

            if (strAdminname == txtname.Text && strAdminpassword == txtpassword.Text)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "Login", "<script Language = 'javascript'>alert('Login Successfully!!!')</script>");
                Response.Redirect("~/Admin/home.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "Login", "<script Language = 'javascript'>alert('Incorrect Username or password!')</script>");

            }

        }

        protected void btncancel_Click1(object sender, EventArgs e)
        {
            txtname.Text = "";
            txtpassword.Text = "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

       


    }
}