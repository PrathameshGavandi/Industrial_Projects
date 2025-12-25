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
public class AdmELInfoDAL
{
DbConnection conn = null;
public AdmELInfoDAL()
{
conn = new DbConnection();
}
public List<AdmELInfo> GetAllAdmELInfo()
{
List<AdmELInfo> admELInfoList = new List<AdmELInfo>();
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("GetAllAdmELInfo", con);
cmd.CommandType = CommandType.StoredProcedure;
SqlDataReader dr = cmd.ExecuteReader();
 while (dr.Read())
{
AdmELInfo admELInfo = new AdmELInfo();
admELInfo.AdmELInfoId = Convert.ToInt32(dr["AdmELInfoId"]);
admELInfo.Address = Convert.ToString(dr["Address"]);
admELInfo.Email = Convert.ToString(dr["Email"]);
admELInfo.Contact = Convert.ToString(dr["Contact"]);
admELInfo.SiteName = Convert.ToString(dr["SiteName"]);
admELInfo.WebsiteLink = Convert.ToString(dr["WebsiteLink"]);
admELInfo.Logo = Convert.ToString(dr["Logo"]);
admELInfo.Status = Convert.ToString(dr["Status"]);
admELInfo.CreatedDate = Convert.ToString(dr["CreatedDate"]);
admELInfo.CreatedBy = Convert.ToString(dr["CreatedBy"]);
admELInfo.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
admELInfo.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
admELInfoList.Add(admELInfo);
}
con.Close();
return admELInfoList;
}
public AdmELInfo GetAdmELInfoById(int AdmELInfoId)
{
AdmELInfo admELInfo = new AdmELInfo();
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("GetAdmELInfoById" , con);
cmd.Parameters.Add("AdmELInfoId", SqlDbType.Int).Value = AdmELInfoId;
cmd.CommandType = CommandType.StoredProcedure;
 SqlDataReader dr = cmd.ExecuteReader();
if (dr.Read())
{
admELInfo.AdmELInfoId = Convert.ToInt32(dr["AdmELInfoId"]);
admELInfo.Address = Convert.ToString(dr["Address"]);
admELInfo.Email = Convert.ToString(dr["Email"]);
admELInfo.Contact = Convert.ToString(dr["Contact"]);
admELInfo.SiteName = Convert.ToString(dr["SiteName"]);
admELInfo.WebsiteLink = Convert.ToString(dr["WebsiteLink"]);
admELInfo.Logo = Convert.ToString(dr["Logo"]);
admELInfo.Status = Convert.ToString(dr["Status"]);
admELInfo.CreatedDate = Convert.ToString(dr["CreatedDate"]);
admELInfo.CreatedBy = Convert.ToString(dr["CreatedBy"]);
admELInfo.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
admELInfo.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
}
con.Close();
return admELInfo;
}
public string AddAdmELInfo(AdmELInfo admELInfo)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("AddAdmELInfo", con);
cmd.Parameters.Add("Address", SqlDbType.NVarChar).Value = admELInfo.Address;
cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = admELInfo.Email;
cmd.Parameters.Add("Contact", SqlDbType.NVarChar).Value = admELInfo.Contact;
cmd.Parameters.Add("SiteName", SqlDbType.NVarChar).Value = admELInfo.SiteName;
cmd.Parameters.Add("WebsiteLink", SqlDbType.NVarChar).Value = admELInfo.WebsiteLink;
cmd.Parameters.Add("Logo", SqlDbType.NVarChar).Value = admELInfo.Logo;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = admELInfo.Status;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = admELInfo.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = admELInfo.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = admELInfo.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = admELInfo.UpdatedBy;
Random r = new Random();
int num = r.Next();
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var AdmELInfoId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return AdmELInfoId.ToString();
}
 [HttpPost]
public string UpdateAdmELInfo(AdmELInfo admELInfo)
{
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("UpdateAdmELInfo" , con);
cmd.Parameters.Add("AdmELInfoId", SqlDbType.Int).Value = admELInfo.AdmELInfoId;
cmd.Parameters.Add("Address", SqlDbType.NVarChar).Value = admELInfo.Address;
cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = admELInfo.Email;
cmd.Parameters.Add("Contact", SqlDbType.NVarChar).Value = admELInfo.Contact;
cmd.Parameters.Add("SiteName", SqlDbType.NVarChar).Value = admELInfo.SiteName;
cmd.Parameters.Add("WebsiteLink", SqlDbType.NVarChar).Value = admELInfo.WebsiteLink;
cmd.Parameters.Add("Logo", SqlDbType.NVarChar).Value = admELInfo.Logo;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = admELInfo.Status;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = admELInfo.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = admELInfo.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = admELInfo.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = admELInfo.UpdatedBy;
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var AdmELInfoId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return AdmELInfoId.ToString();
}
public String DeleteAdmELInfo(int AdmELInfoId)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("DeleteAdmELInfo", con);
cmd.Parameters.Add("AdmELInfoId", SqlDbType.Int).Value = AdmELInfoId;
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
