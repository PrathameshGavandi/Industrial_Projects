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
    public partial class Productdetails : System.Web.UI.Page
    {

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = DataList1.Items.Count;
            for (int i = 0; i < count; i++)
            {
                Label lblprice = DataList1.Items[i].FindControl("lblprice") as Label;
                int p = Convert.ToInt32(lblprice.Text);
                DropDownList d = DataList1.Items[i].FindControl("dropDownList1") as DropDownList;
                int q = Convert.ToInt32(d.Text);
                int t = (p * q);
                Label lbltot = DataList1.Items[i].FindControl("lbltot") as Label;
                lbltot.Text = t.ToString();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/User/CustmarLogin.aspx");
        }

        
    }        
    
}