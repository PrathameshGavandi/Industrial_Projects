using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Configuration;


namespace Bagshop.Custmar
{
    public partial class Payment : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        ReportDocument crpt = new ReportDocument();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            cn.Open();
            cmd.CommandText = "select Count(Paymentid) from Payment";
            cmd.Connection = cn;
            int x = Convert.ToInt32(cmd.ExecuteScalar());
            x++;
            lblpayid.Text = x.ToString();
            cn.Close();

            lbloid.Text = Session["id"].ToString();
            lblpdate.Text = System.DateTime.Now.ToShortDateString();

            lblname.Text = Session["user"].ToString();
            lbltamount.Text = Session["Total"].ToString();
            double t = Convert.ToDouble(lbltamount.Text);
            double GST = Convert.ToDouble(lblgst.Text);
            double net = t + ((t * GST) / 100);
            double dis = Convert.ToDouble(lbldis.Text);
            double net1 = net - (net * dis / 100);
            lblnamount.Text = net1.ToString();

        } 

        protected void rd1_CheckedChanged(object sender, EventArgs e)
        {
            if (rd1.Checked == true)
            {
                Image2.Visible = false;
                btnorder.Enabled = true;

            }

        }
        protected void btnorder_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd.CommandText = "insert Payment values(" + lblpayid.Text + "," + lbloid.Text + ",'" + lblpdate.Text + "',@p1, " + lbldis.Text + "," + lblgst.Text + "," + lblnamount.Text + "," + lbltamount.Text + ",'" + lblname.Text + "')";
            if (rd1.Checked == true)
                cmd.Parameters.AddWithValue("@p1", rd1.Text);
            else
                cmd.Parameters.AddWithValue("@p1", rd2.Text);
            cmd.Connection = cn;
            cmd.ExecuteNonQuery();
            cn.Close();

            cn.Open();
            cmd.CommandText = "Delete from Cartdetails";
            cmd.Connection = cn;
            cmd.ExecuteNonQuery();
            cn.Close();
            ClientScript.RegisterStartupScript(Page.GetType(), "Save", "<Script language = 'javascript'>alert('Order Place successfully')</Script>");

        }

        protected void rd2_CheckedChanged(object sender, EventArgs e)
        {
            if (rd2.Checked == true)
            {
                Image2.Visible = true;
                btnorder.Enabled = true;
            }
        }

        protected void btnbill_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlDataAdapter dal = new SqlDataAdapter("select distinct * from  Bill where Oid=" + lbloid.Text + "", cn);
            dal.Fill(ds, "Bill");
            dal.Fill(ds);
            crpt.Load(Server.MapPath(@"~/Custmar/Billing.rpt"));
            crpt.SetDataSource(ds);
           // CrystalReportViewer1.ReportSource = crpt;
            crpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Bill");
            crpt.Refresh();
            cn.Close();
            Response.Redirect(@"~//Customer/Billing.rpt");

        }
    }
}