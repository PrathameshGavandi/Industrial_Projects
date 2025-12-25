using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bagshop.Custmar
{
    public partial class Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string str = btn.CommandArgument;
            Session["Catname"] = str;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string str = btn.CommandArgument;
            Session["Catname"] = str;


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string str = btn.CommandArgument;
            Session["pid"] = str;
            Response.Redirect("~/Custmar/productdetails.aspx");
        }
    }
}