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
public class UserKycDAL
{
DbConnection conn = null;
public UserKycDAL()
{
conn = new DbConnection();
}
public List<UserKyc> GetAllUserKyc()
{
List<UserKyc> userKycList = new List<UserKyc>();
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("GetAllUserKyc", con);
cmd.CommandType = CommandType.StoredProcedure;
SqlDataReader dr = cmd.ExecuteReader();
 while (dr.Read())
{
UserKyc userKyc = new UserKyc();
userKyc.UserKycId = Convert.ToInt32(dr["UserKycId"]);
userKyc.userProfile = new UserProfile();
userKyc.userProfile.UserProfileId = Convert.ToInt32(dr["UserProfileId"]);
userKyc.userProfile.UserProfileId = Convert.ToInt32(dr["UserProfileId1"]);
userKyc.Passport = Convert.ToString(dr["Passport"]);
userKyc.AddressProof = Convert.ToString(dr["AddressProof"]);
userKyc.KycStatus = Convert.ToString(dr["KycStatus"]);
userKyc.CreatedDate = Convert.ToString(dr["CreatedDate"]);
userKyc.CreatedBy = Convert.ToString(dr["CreatedBy"]);
userKyc.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
userKyc.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
userKycList.Add(userKyc);
}
con.Close();
return userKycList;
}
public UserKyc GetUserKycById(int UserKycId)
{
UserKyc userKyc = new UserKyc();
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("GetUserKycById" , con);
cmd.Parameters.Add("UserKycId", SqlDbType.Int).Value = UserKycId;
cmd.CommandType = CommandType.StoredProcedure;
 SqlDataReader dr = cmd.ExecuteReader();
if (dr.Read())
{
userKyc.UserKycId = Convert.ToInt32(dr["UserKycId"]);
userKyc.userProfile = new UserProfile();
userKyc.userProfile.UserProfileId = Convert.ToInt32(dr["UserProfileId"]);
userKyc.userProfile.UserProfileId = Convert.ToInt32(dr["UserProfileId1"]);
userKyc.Passport = Convert.ToString(dr["Passport"]);
userKyc.AddressProof = Convert.ToString(dr["AddressProof"]);
userKyc.KycStatus = Convert.ToString(dr["KycStatus"]);
userKyc.CreatedDate = Convert.ToString(dr["CreatedDate"]);
userKyc.CreatedBy = Convert.ToString(dr["CreatedBy"]);
userKyc.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
userKyc.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
}
con.Close();
return userKyc;
}
public string AddUserKyc(UserKyc userKyc)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("AddUserKyc", con);
cmd.Parameters.Add("UserProfileId", SqlDbType.Int).Value = userKyc.userProfile.UserProfileId;
cmd.Parameters.Add("Passport", SqlDbType.NVarChar).Value = userKyc.Passport;
cmd.Parameters.Add("AddressProof", SqlDbType.NVarChar).Value = userKyc.AddressProof;
cmd.Parameters.Add("KycStatus", SqlDbType.NVarChar).Value = userKyc.KycStatus;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = userKyc.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = userKyc.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = userKyc.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = userKyc.UpdatedBy;
Random r = new Random();
int num = r.Next();
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var UserKycId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return UserKycId.ToString();
}
 [HttpPost]
public string UpdateUserKyc(UserKyc userKyc)
{
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("UpdateUserKyc" , con);
cmd.Parameters.Add("UserKycId", SqlDbType.Int).Value = userKyc.UserKycId;
cmd.Parameters.Add("UserProfileId", SqlDbType.Int).Value = userKyc.userProfile.UserProfileId;
cmd.Parameters.Add("Passport", SqlDbType.NVarChar).Value = userKyc.Passport;
cmd.Parameters.Add("AddressProof", SqlDbType.NVarChar).Value = userKyc.AddressProof;
cmd.Parameters.Add("KycStatus", SqlDbType.NVarChar).Value = userKyc.KycStatus;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = userKyc.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = userKyc.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = userKyc.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = userKyc.UpdatedBy;
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var UserKycId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return UserKycId.ToString();
}
public String DeleteUserKyc(int UserKycId)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("DeleteUserKyc", con);
cmd.Parameters.Add("UserKycId", SqlDbType.Int).Value = UserKycId;
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
