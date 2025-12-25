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
public class RefferalDAL
{
DbConnection conn = null;
public RefferalDAL()
{
conn = new DbConnection();
}
public List<Refferal> GetAllRefferal()
{
List<Refferal> refferalList = new List<Refferal>();
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("GetAllRefferal", con);
cmd.CommandType = CommandType.StoredProcedure;
SqlDataReader dr = cmd.ExecuteReader();
 while (dr.Read())
{
Refferal refferal = new Refferal();
refferal.RefferalId = Convert.ToInt32(dr["RefferalId"]);
refferal.admRegistration = new AdmRegistration();
//refferal.admRegistration.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
//refferal.admRegistration.RegistrationId = Convert.ToInt32(dr["RegistrationId1"]);
refferal.UserReferralCode = Convert.ToString(dr["UserReferralCode"]);
refferal.UsedReferralCode = Convert.ToString(dr["UsedReferralCode"]);
refferal.TotalReferred = Convert.ToString(dr["TotalReferred"]);
refferal.MonthlyReferred = Convert.ToString(dr["MonthlyReferred"]);
refferal.Status = Convert.ToString(dr["Status"]);
refferal.CreatedDate = Convert.ToString(dr["CreatedDate"]);
refferal.CreatedBy = Convert.ToString(dr["CreatedBy"]);
refferal.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
refferal.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
refferalList.Add(refferal);
}
con.Close();
return refferalList;
}
public Refferal GetRefferalById(int RefferalId)
{
Refferal refferal = new Refferal();
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("GetRefferalById" , con);
cmd.Parameters.Add("RefferalId", SqlDbType.Int).Value = RefferalId;
cmd.CommandType = CommandType.StoredProcedure;
 SqlDataReader dr = cmd.ExecuteReader();
if (dr.Read())
{
refferal.RefferalId = Convert.ToInt32(dr["RefferalId"]);
refferal.admRegistration = new AdmRegistration();
//refferal.admRegistration.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
//refferal.admRegistration.RegistrationId = Convert.ToInt32(dr["RegistrationId1"]);
refferal.UserReferralCode = Convert.ToString(dr["UserReferralCode"]);
refferal.UsedReferralCode = Convert.ToString(dr["UsedReferralCode"]);
refferal.TotalReferred = Convert.ToString(dr["TotalReferred"]);
refferal.MonthlyReferred = Convert.ToString(dr["MonthlyReferred"]);
refferal.Status = Convert.ToString(dr["Status"]);
refferal.CreatedDate = Convert.ToString(dr["CreatedDate"]);
refferal.CreatedBy = Convert.ToString(dr["CreatedBy"]);
refferal.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
refferal.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
}
con.Close();
return refferal;
}
public string AddRefferal(Refferal refferal)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("AddRefferal", con);
//cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = refferal.admRegistration.RegistrationId;
cmd.Parameters.Add("UserReferralCode", SqlDbType.NVarChar).Value = refferal.UserReferralCode;
cmd.Parameters.Add("UsedReferralCode", SqlDbType.NVarChar).Value = refferal.UsedReferralCode;
cmd.Parameters.Add("TotalReferred", SqlDbType.NVarChar).Value = refferal.TotalReferred;
cmd.Parameters.Add("MonthlyReferred", SqlDbType.NVarChar).Value = refferal.MonthlyReferred;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = refferal.Status;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = refferal.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = refferal.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = refferal.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = refferal.UpdatedBy;
Random r = new Random();
int num = r.Next();
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var RefferalId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return RefferalId.ToString();
}
 [HttpPost]
public string UpdateRefferal(Refferal refferal)
{
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("UpdateRefferal" , con);
cmd.Parameters.Add("RefferalId", SqlDbType.Int).Value = refferal.RefferalId;
//cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = refferal.admRegistration.RegistrationId;
cmd.Parameters.Add("UserReferralCode", SqlDbType.NVarChar).Value = refferal.UserReferralCode;
cmd.Parameters.Add("UsedReferralCode", SqlDbType.NVarChar).Value = refferal.UsedReferralCode;
cmd.Parameters.Add("TotalReferred", SqlDbType.NVarChar).Value = refferal.TotalReferred;
cmd.Parameters.Add("MonthlyReferred", SqlDbType.NVarChar).Value = refferal.MonthlyReferred;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = refferal.Status;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = refferal.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = refferal.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = refferal.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = refferal.UpdatedBy;
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var RefferalId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return RefferalId.ToString();
}
public String DeleteRefferal(int RefferalId)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("DeleteRefferal", con);
cmd.Parameters.Add("RefferalId", SqlDbType.Int).Value = RefferalId;
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
