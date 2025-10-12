using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace Bagshop.User
{
    public partial class Enquiry : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);
        SqlCommand cmd = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd.CommandText = "Insert into Enquiry values('" + txtname.Text + "','" + txtemail.Text + "'," + txtcontact.Text + ",'" + txtsubject.Text + "','" + txtmessage.Text + "','" + txtaddress.Text + "')";
            cmd.Connection = cn;
            cmd.ExecuteNonQuery();
            cn.Close();
            ClientScript.RegisterStartupScript(Page.GetType(), "submit", "<script language='javascript'>alert('Enquiry submitted successfully!!!')</script>");
            
        }

        protected void txtemail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}