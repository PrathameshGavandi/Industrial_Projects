using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data.SqlClient;
using System.Data;

namespace Bagshop.Report
{
    public partial class Feedback_Report : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        DataSet da = new DataSet();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();

        ReportDocument crpt = new ReportDocument();

        protected void Page_Load(object sender, EventArgs e)
        {
            cn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Feedback", cn);
            da.Fill(ds, "Feedback");
            da.Fill(ds);
            crpt.Load(Server.MapPath(@"~\Report\Feedback.rpt"));
            crpt.SetDataSource(ds);
            CrystalReportViewer1.ReportSource = crpt;
            crpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Feedback");
            crpt.Refresh();
            cn.Close();
        }
    }
}