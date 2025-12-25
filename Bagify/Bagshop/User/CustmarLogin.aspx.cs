using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Bagshop.User
{
    public partial class CustmorLogin : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        String strpassword, strusername;
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd.CommandText = "select username,password from Registration where  password = '" + txtpassword.Text + "' and username = '" + txtusername.Text + "'";
            cmd.Connection = cn;
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dt);
            string a = txtusername.Text;
            if (dt.Rows.Count > 0)
            {
                Session["user"] = txtusername.Text;
                Response.Redirect("~/Custmar/Home.aspx");
            }
            else
                ClientScript.RegisterStartupScript(Page.GetType(), "Error", "<Script Language = 'javascript'>alert('Incorrect User name or Passward')</Script");

        }
    }
}