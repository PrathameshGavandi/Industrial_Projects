using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Bagshop.Custmar
{
    public partial class Cartdetails11 : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlDataReader dr;
        DataSet ds = new DataSet();

        int p, q, t;
        int st2;
        int st3, id;
        protected void Page_Load(object sender, EventArgs e)
        {
            cn.Open();
            cmd.CommandText = "select count(Oid) from [Order]";
            cmd.Connection = cn;
            int x = Convert.ToInt32(cmd.ExecuteScalar());
            x++;
            lblid.Text = x.ToString();
            cn.Close();

            lblname.Text = Session["user"].ToString();

            lbldate.Text = System.DateTime.Now.ToShortDateString();

            cn.Open();
            cmd.CommandText = "select sum (Total)from Cartdetails";
            double amt = Convert.ToDouble(cmd.ExecuteScalar());
            cmd.Connection = cn;
            lblamount.Text = amt.ToString();
            lbltime.Text = System.DateTime.Now.ToShortTimeString();
            cn.Close();
        }

        protected void btnorder_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {


                int oid = Convert.ToInt32(lblid.Text);
                id = Convert.ToInt32(GridView1.Rows[i].Cells[0].Text);
                string name = Session["user"].ToString();
                string catagery = Convert.ToString(GridView1.Rows[i].Cells[1].Text);
                string pname = Convert.ToString(GridView1.Rows[i].Cells[2].Text);
                string username = Convert.ToString(GridView1.Rows[i].Cells[3].Text);
                p = Convert.ToInt32(GridView1.Rows[i].Cells[4].Text);
                q = Convert.ToInt32(GridView1.Rows[i].Cells[5].Text);
                t = Convert.ToInt32(GridView1.Rows[i].Cells[6].Text);
                cn.Open();
                cmd.CommandText = "insert into Orderdetails values(" + oid + "," +id + ",'" + username + "','" +catagery  + "','" + pname + "'," + q + "," + p + "," + t + ",'" + txtaddress.Text + "')";
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                cn.Close();
            }


            string Status = "in Process";
            cn.Open();

            cmd.CommandText = "insert into [Order] values (" + lblid.Text + ",'" + txtaddress.Text + "'," + txtcontactno.Text + ",'" + lbldate.Text + "'," + lblamount.Text + ",'" + Status + "','" + lblname.Text + "','" + txtcity.Text + "')";
            cmd.ExecuteNonQuery();
            cn.Close();
            ClientScript.RegisterStartupScript(Page.GetType(), "Save", "<script language = 'javascript'>alert('Order Confirmed')</script>");
            Session["id"] = lblid.Text;
            Session["Total"] = lblamount.Text;
            
            cn.Open();
            cmd.CommandText = "Select Stock from product";
            cmd.Connection = cn;
            st2 = Convert.ToInt32(cmd.ExecuteScalar());
            cn.Close();

            int st3 = st2 - q;
            cn.Open();
            cmd.CommandText = " update [Product] set Stock = " + st3 + " Where Pid=" + id + "";
            cmd.Connection = cn;
            cmd.ExecuteNonQuery();
            cn.Close();

            cn.Open();
            cmd.CommandText = "Delete from  Cartdetails where Username='"+lblname.Text+"'";
            cmd.Connection = cn;
            cmd.ExecuteNonQuery();
            cn.Close();

            Response.Redirect("~/Customer/Payment.aspx");








        }
    }
}