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
    public partial class Feedback : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            txtname.Text = "";
            txtemail.Text = "";
            txtcontact.Text = "";
            rdqualityvsatisfied.Checked = false;
            rdqualitysatisfied.Checked = false;
            rdqualityunsatisfied.Checked = false;
            rdqualityvunsatisfied.Checked = false;

            rdpricevsatisfied.Checked = false;
            rdpricesatisfied.Checked = false;
            rdpriceunsatisfied.Checked = false;
            rdpricevunsatisfied.Checked = false;

            rdprocessvsatisfied.Checked = false;
            rdprocesssatisfied.Checked = false;
            rdprocessunsatisfied.Checked = false;
            rdprocessvunsatisfied.Checked = false;

            rddeliveryvsatisfied.Checked = false;
            rddeliverysatisfied.Checked = false;
            rddeliveryunsatisfied.Checked = false;
            rddeliveryvunsatisfied.Checked = false;




            txtsuggestion.Text = "";
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd.CommandText = "insert into Feedback values('" + txtname.Text + "','" + txtemail.Text + "','" + txtcontact.Text + "',@p1,@p2,@p3,@p4,'"+txtdate.Text+"','" + txtsuggestion.Text + "')";
            cmd.Connection = cn;
            if (rdqualityvsatisfied.Checked == true)
                cmd.Parameters.AddWithValue("@p1", "V.Satisfied");
            else if (rdqualitysatisfied.Checked == true)
                cmd.Parameters.AddWithValue("@p1", "Satisfied");
            else if (rdqualityunsatisfied.Checked == true)
                cmd.Parameters.AddWithValue("@p1", "Unsatisfied");
            else
                cmd.Parameters.AddWithValue("@p1", "V.Unsatisfied");

            if (rdpricevsatisfied.Checked == true)
                cmd.Parameters.AddWithValue("@p2","V.Satisfied");
            else if (rdpricesatisfied.Checked == true)
                cmd.Parameters.AddWithValue("@p2", "Satisfied");
            else if (rdpriceunsatisfied.Checked == true)
                cmd.Parameters.AddWithValue("@p2", "Unsatisfied");
            else
                cmd.Parameters.AddWithValue("@p2", "V.Unsatisfied");

            if (rdprocessvsatisfied.Checked == true)
                cmd.Parameters.AddWithValue("@p3", "V.Satisfied");
            else if (rdprocesssatisfied.Checked == true)
                cmd.Parameters.AddWithValue("@p3", "Satisfied");
            else if (rdprocessunsatisfied.Checked == true)
                cmd.Parameters.AddWithValue("@p3", "Unsatisfied");
            else
                cmd.Parameters.AddWithValue("@p3", "V.Unsatisfied");

            if (rddeliveryvsatisfied.Checked == true)
                cmd.Parameters.AddWithValue("@p4", "V.Satisfied");
            else if (rddeliverysatisfied.Checked == true)
                cmd.Parameters.AddWithValue("@p4", "Satisfied");
            else if (rddeliveryvunsatisfied.Checked == true)
                cmd.Parameters.AddWithValue("@p4", "Unsatisfied");
            else
                cmd.Parameters.AddWithValue("@p4", "V.Unsatisfied");

            cmd.ExecuteNonQuery();
            cn.Close();
            ClientScript.RegisterStartupScript(Page.GetType(), "Submit", "<script language = 'javascript'>alert('Submit Successfully!!!')</script>");

        }


    }
}