using System;
using System.Collections.Generic;
using System.Linq;
 using System.Web;
 using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using PrismAPI.Models;
using PrismAPI.DAL;
using System.Data.Common;
 namespace PrismAPI.DAL
{
public class AdmContactUsDAL
{
DbConnection conn = null;
public AdmContactUsDAL()
{
conn = new DbConnection();
}
public List<AdmContactUs> GetAllAdmContactUs()
{
List<AdmContactUs> admContactUsList = new List<AdmContactUs>();
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("GetAllAdmContactUs", con);
cmd.CommandType = CommandType.StoredProcedure;
SqlDataReader dr = cmd.ExecuteReader();
 while (dr.Read())
{
AdmContactUs admContactUs = new AdmContactUs();
admContactUs.ContactUsId = Convert.ToInt32(dr["ContactUsId"]);
admContactUs.FullName = Convert.ToString(dr["FullName"]);
admContactUs.Email = Convert.ToString(dr["Email"]);
admContactUs.MobileNo = Convert.ToString(dr["MobileNo"]);
admContactUs.MessageText = Convert.ToString(dr["MessageText"]);
admContactUs.Status = Convert.ToString(dr["Status"]);
admContactUs.CreatedDate = Convert.ToString(dr["CreatedDate"]);
admContactUs.CreatedBy = Convert.ToString(dr["CreatedBy"]);
admContactUs.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
admContactUs.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
admContactUsList.Add(admContactUs);
}
con.Close();
return admContactUsList;
}
public AdmContactUs GetAdmContactUsById(int ContactUsId)
{
AdmContactUs admContactUs = new AdmContactUs();
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("GetAdmContactUsById" , con);
cmd.Parameters.Add("ContactUsId", SqlDbType.Int).Value = ContactUsId;
cmd.CommandType = CommandType.StoredProcedure;
 SqlDataReader dr = cmd.ExecuteReader();
if (dr.Read())
{
admContactUs.ContactUsId = Convert.ToInt32(dr["ContactUsId"]);
admContactUs.FullName = Convert.ToString(dr["FullName"]);
admContactUs.Email = Convert.ToString(dr["Email"]);
admContactUs.MobileNo = Convert.ToString(dr["MobileNo"]);
admContactUs.MessageText = Convert.ToString(dr["MessageText"]);
admContactUs.Status = Convert.ToString(dr["Status"]);
admContactUs.CreatedDate = Convert.ToString(dr["CreatedDate"]);
admContactUs.CreatedBy = Convert.ToString(dr["CreatedBy"]);
admContactUs.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
admContactUs.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
}
con.Close();
return admContactUs;
}
public string AddAdmContactUs(AdmContactUs admContactUs)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("AddAdmContactUs", con);
cmd.Parameters.Add("FullName", SqlDbType.NVarChar).Value = admContactUs.FullName;
cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = admContactUs.Email;
cmd.Parameters.Add("MobileNo", SqlDbType.NVarChar).Value = admContactUs.MobileNo;
cmd.Parameters.Add("MessageText", SqlDbType.NVarChar).Value = admContactUs.MessageText;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = admContactUs.Status;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = admContactUs.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = admContactUs.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = admContactUs.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = admContactUs.UpdatedBy;
Random r = new Random();
int num = r.Next();
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var ContactUsId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return ContactUsId.ToString();
}
 [HttpPost]
public string UpdateAdmContactUs(AdmContactUs admContactUs)
{
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("UpdateAdmContactUs" , con);
cmd.Parameters.Add("ContactUsId", SqlDbType.Int).Value = admContactUs.ContactUsId;
cmd.Parameters.Add("FullName", SqlDbType.NVarChar).Value = admContactUs.FullName;
cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = admContactUs.Email;
cmd.Parameters.Add("MobileNo", SqlDbType.NVarChar).Value = admContactUs.MobileNo;
cmd.Parameters.Add("MessageText", SqlDbType.NVarChar).Value = admContactUs.MessageText;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = admContactUs.Status;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = admContactUs.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = admContactUs.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = admContactUs.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = admContactUs.UpdatedBy;
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var ContactUsId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return ContactUsId.ToString();
}
public String DeleteAdmContactUs(int ContactUsId)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("DeleteAdmContactUs", con);
cmd.Parameters.Add("ContactUsId", SqlDbType.Int).Value = ContactUsId;
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return "Success";
}
}
}
