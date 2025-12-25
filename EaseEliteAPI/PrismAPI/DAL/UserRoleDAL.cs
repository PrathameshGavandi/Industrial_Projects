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
public class UserRoleDAL
{
DbConnection conn = null;
public UserRoleDAL()
{
conn = new DbConnection();
}
public List<UserRole> GetAllUserRole()
{
List<UserRole> userRoleList = new List<UserRole>();
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("GetAllUserRole", con);
cmd.CommandType = CommandType.StoredProcedure;
SqlDataReader dr = cmd.ExecuteReader();
 while (dr.Read())
{
UserRole userRole = new UserRole();
userRole.UserRoleId = Convert.ToInt32(dr["UserRoleId"]);
userRole.RoleId = Convert.ToInt32(dr["RoleId"]);
userRole.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
userRole.Status = Convert.ToString(dr["Status"]);
userRole.CreatedDate = Convert.ToString(dr["CreatedDate"]);
userRole.CreatedBy = Convert.ToString(dr["CreatedBy"]);
userRole.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
userRole.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
userRoleList.Add(userRole);
}
con.Close();
return userRoleList;
}
public UserRole GetUserRoleById(int UserRoleId)
{
UserRole userRole = new UserRole();
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("GetUserRoleById" , con);
cmd.Parameters.Add("UserRoleId", SqlDbType.Int).Value = UserRoleId;
cmd.CommandType = CommandType.StoredProcedure;
 SqlDataReader dr = cmd.ExecuteReader();
if (dr.Read())
{
userRole.UserRoleId = Convert.ToInt32(dr["UserRoleId"]);
userRole.RoleId = Convert.ToInt32(dr["RoleId"]);
userRole.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
userRole.Status = Convert.ToString(dr["Status"]);
userRole.CreatedDate = Convert.ToString(dr["CreatedDate"]);
userRole.CreatedBy = Convert.ToString(dr["CreatedBy"]);
userRole.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
userRole.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
}
con.Close();
return userRole;
}
public string AddUserRole(UserRole userRole)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("AddUserRole", con);
cmd.Parameters.Add("RoleId", SqlDbType.Int).Value = userRole.RoleId;
cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = userRole.RegistrationId;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = userRole.Status;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = userRole.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = userRole.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = userRole.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = userRole.UpdatedBy;
Random r = new Random();
int num = r.Next();
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var UserRoleId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return UserRoleId.ToString();
}
 [HttpPost]
public string UpdateUserRole(UserRole userRole)
{
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("UpdateUserRole" , con);
cmd.Parameters.Add("UserRoleId", SqlDbType.Int).Value = userRole.UserRoleId;
cmd.Parameters.Add("RoleId", SqlDbType.Int).Value = userRole.RoleId;
cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = userRole.RegistrationId;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = userRole.Status;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = userRole.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = userRole.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = userRole.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = userRole.UpdatedBy;
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var UserRoleId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return UserRoleId.ToString();
}
public String DeleteUserRole(int UserRoleId)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("DeleteUserRole", con);
cmd.Parameters.Add("UserRoleId", SqlDbType.Int).Value = UserRoleId;
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
