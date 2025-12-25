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
public class AdmRoleDAL
{
DbConnection conn = null;
public AdmRoleDAL()
{
conn = new DbConnection();
}
public List<AdmRole> GetAllAdmRole()
{
List<AdmRole> admRoleList = new List<AdmRole>();
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("GetAllAdmRole", con);
cmd.CommandType = CommandType.StoredProcedure;
SqlDataReader dr = cmd.ExecuteReader();
 while (dr.Read())
{
AdmRole admRole = new AdmRole();
admRole.AdmRoleId = Convert.ToInt32(dr["AdmRoleId"]);
admRole.Title = Convert.ToString(dr["Title"]);
admRole.Description = Convert.ToString(dr["Description"]);
admRole.Status = Convert.ToString(dr["Status"]);
admRole.CreatedDate = Convert.ToString(dr["CreatedDate"]);
admRole.CreatedBy = Convert.ToString(dr["CreatedBy"]);
admRole.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
admRole.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
admRoleList.Add(admRole);
}
con.Close();
return admRoleList;
}
public AdmRole GetAdmRoleById(int AdmRoleId)
{
AdmRole admRole = new AdmRole();
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("GetAdmRoleById" , con);
cmd.Parameters.Add("AdmRoleId", SqlDbType.Int).Value = AdmRoleId;
cmd.CommandType = CommandType.StoredProcedure;
 SqlDataReader dr = cmd.ExecuteReader();
if (dr.Read())
{
admRole.AdmRoleId = Convert.ToInt32(dr["AdmRoleId"]);
admRole.Title = Convert.ToString(dr["Title"]);
admRole.Description = Convert.ToString(dr["Description"]);
admRole.Status = Convert.ToString(dr["Status"]);
admRole.CreatedDate = Convert.ToString(dr["CreatedDate"]);
admRole.CreatedBy = Convert.ToString(dr["CreatedBy"]);
admRole.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
admRole.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
}
con.Close();
return admRole;
}
public string AddAdmRole(AdmRole admRole)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("AddAdmRole", con);
cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = admRole.Title;
cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = admRole.Description;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = admRole.Status;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = admRole.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = admRole.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = admRole.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = admRole.UpdatedBy;
Random r = new Random();
int num = r.Next();
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var AdmRoleId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return AdmRoleId.ToString();
}
 [HttpPost]
public string UpdateAdmRole(AdmRole admRole)
{
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("UpdateAdmRole" , con);
cmd.Parameters.Add("AdmRoleId", SqlDbType.Int).Value = admRole.AdmRoleId;
cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = admRole.Title;
cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = admRole.Description;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = admRole.Status;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = admRole.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = admRole.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = admRole.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = admRole.UpdatedBy;
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var AdmRoleId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return AdmRoleId.ToString();
}
public String DeleteAdmRole(int AdmRoleId)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("DeleteAdmRole", con);
cmd.Parameters.Add("AdmRoleId", SqlDbType.Int).Value = AdmRoleId;
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
