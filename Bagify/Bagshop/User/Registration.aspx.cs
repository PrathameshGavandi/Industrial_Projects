using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Bagshop.User
{
    public partial class Registration : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btncreareaccount_Click(object sender, EventArgs e)
        {
            try 
            {
                if(txtpassword.Text == txtconfirmpassword.Text)
                {
                    cn.Open();
                    cmd.CommandText = "Insert into Registration values ('" + txtname.Text + "'," + txtcontact.Text + ",'" + txtemail.Text + "','" + txtaddress.Text + "','" + drpcity.Text + "','" + txtpassword.Text + "','" + txtusername.Text + "')";
                    cmd.Connection = cn;
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    ClientScript.RegisterStartupScript(Page.GetType(), "Create Account", "<script language = 'javascript'>alert('Registration Successful!!!')</script>");

                }
                else
                {
                    Response.Write("<script> alert('Mismatched Passwords..') </script>");
                }
            
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }

        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            txtname.Text = "";
            txtcontact.Text = "";
            txtemail.Text = "";
            txtaddress.Text = "";
            drpcity.Text = "";
            txtpassword.Text = "";
            txtconfirmpassword.Text = "";
            txtusername.Text = "";

        }
    }
}