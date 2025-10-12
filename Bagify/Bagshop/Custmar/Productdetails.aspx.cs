using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace Bagshop.Custmar
{
    public partial class Productdetails : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int count = DataList2.Items.Count;
            for (int i = 0; i < count; i++)
            {
                Label lblname = DataList2.Items[i].FindControl("lblname") as Label;
                String name = (lblname.Text);

                Label lblpid = DataList2.Items[i].FindControl("lblpid") as Label;
                int pid = Convert.ToInt32(lblpid.Text);



                Label lblcat = DataList2.Items[i].FindControl("lblcat") as Label;
                String cat = (lblcat.Text);

                Label lprice = DataList2.Items[i].FindControl("lprice") as Label;
                int p = Convert.ToInt32(lprice.Text);

                Label lblstock = DataList2.Items[i].FindControl("lblstock") as Label;
                int stock = Convert.ToInt32(lblstock.Text);

                Label lblspecification = DataList2.Items[i].FindControl("lblspecification") as Label;
                String specification = (lblspecification.Text);

                DropDownList d = DataList2.Items[i].FindControl("DropDownList1") as DropDownList;
                int q = Convert.ToInt32(d.Text);
                int t = (p * q);

                Label lbltot = DataList2.Items[i].FindControl("lbltot") as Label;
                int tot = Convert.ToInt32(lbltot.Text);

                string l = Session["user"].ToString();
                cn.Open();
                cmd.CommandText = "insert into Cartdetails values("+pid+",'" + cat + "','" + name + "','" + l+ "'," + p + "," + q + "," + tot + ")";
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                cn.Close();
                ClientScript.RegisterStartupScript(Page.GetType(), "Submit", "<script language = 'javascript'>alert('Added To Cart Successfully!!!')</script>");


            }
        }

        protected void DataList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            int count = DataList2.Items.Count;
            for (int i = 0; i < count; i++)
            {
                Label lblprice = DataList2.Items[i].FindControl("lblprice") as Label;
                int p = Convert.ToInt32(lblprice.Text);
                DropDownList d = DataList2.Items[i].FindControl("dropDownList1") as DropDownList;
                int q = Convert.ToInt32(d.Text);
                int t = (p * q);
                Label lbltot = DataList2.Items[i].FindControl("lbltot") as Label;
                lbltot.Text = t.ToString();
            }
        }
    }
}