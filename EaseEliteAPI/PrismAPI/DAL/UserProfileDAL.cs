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
public class UserProfileDAL
{
DbConnection conn = null;
public UserProfileDAL()
{
conn = new DbConnection();
}
public List<UserProfile> GetAllUserProfile()
{
List<UserProfile> userProfileList = new List<UserProfile>();
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("GetAllUserProfile", con);
cmd.CommandType = CommandType.StoredProcedure;
SqlDataReader dr = cmd.ExecuteReader();
 while (dr.Read())
{
UserProfile userProfile = new UserProfile();
userProfile.UserProfileId = Convert.ToInt32(dr["UserProfileId"]);
userProfile.registration = new Registration();
userProfile.registration.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
userProfile.registration.RegistrationId = Convert.ToInt32(dr["RegistrationId1"]);
                
                userProfile.ContactNumber = Convert.ToString(dr["ContactNumber"]);
userProfile.Image = Convert.ToString(dr["Image"]);
userProfile.AlternativeEmail = Convert.ToString(dr["AlternativeEmail"]);
userProfile.Address = Convert.ToString(dr["Address"]);
userProfile.Country = Convert.ToString(dr["Country"]);
userProfile.Province = Convert.ToString(dr["Province"]);
userProfile.City = Convert.ToString(dr["City"]);
userProfile.PostalCode = Convert.ToString(dr["PostalCode"]);
userProfile.Status = Convert.ToString(dr["Status"]);
userProfile.Passport = Convert.ToString(dr["Passport"]);
userProfile.AddressProof = Convert.ToString(dr["AddressProof"]);
userProfile.KycStatus = Convert.ToString(dr["KycStatus"]);
userProfile.CreatedDate = Convert.ToString(dr["CreatedDate"]);
userProfile.CreatedBy = Convert.ToString(dr["CreatedBy"]);
userProfile.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
userProfile.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
userProfileList.Add(userProfile);
}
con.Close();
return userProfileList;
}
public UserProfile GetUserProfileById(int UserProfileId)
{
UserProfile userProfile = new UserProfile();
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("GetUserProfileById" , con);
cmd.Parameters.Add("UserProfileId", SqlDbType.Int).Value = UserProfileId;
cmd.CommandType = CommandType.StoredProcedure;
 SqlDataReader dr = cmd.ExecuteReader();
if (dr.Read())
{
userProfile.UserProfileId = Convert.ToInt32(dr["UserProfileId"]);
userProfile.registration = new Registration();
userProfile.registration.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
userProfile.registration.RegistrationId = Convert.ToInt32(dr["RegistrationId1"]);
               
                userProfile.ContactNumber = Convert.ToString(dr["ContactNumber"]);
userProfile.Image = Convert.ToString(dr["Image"]);
userProfile.AlternativeEmail = Convert.ToString(dr["AlternativeEmail"]);
userProfile.Address = Convert.ToString(dr["Address"]);
userProfile.Country = Convert.ToString(dr["Country"]);
userProfile.Province = Convert.ToString(dr["Province"]);
userProfile.City = Convert.ToString(dr["City"]);
userProfile.PostalCode = Convert.ToString(dr["PostalCode"]);
userProfile.Status = Convert.ToString(dr["Status"]);
userProfile.Passport = Convert.ToString(dr["Passport"]);
userProfile.AddressProof = Convert.ToString(dr["AddressProof"]);
userProfile.KycStatus = Convert.ToString(dr["KycStatus"]);
userProfile.CreatedDate = Convert.ToString(dr["CreatedDate"]);
userProfile.CreatedBy = Convert.ToString(dr["CreatedBy"]);
userProfile.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
userProfile.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
}
con.Close();
return userProfile;
}
public string AddUserProfile(UserProfile userProfile)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("AddUserProfile", con);
cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = userProfile.registration.RegistrationId;
cmd.Parameters.Add("ContactNumber", SqlDbType.NVarChar).Value = userProfile.ContactNumber;
cmd.Parameters.Add("Image", SqlDbType.NVarChar).Value = userProfile.Image;
cmd.Parameters.Add("AlternativeEmail", SqlDbType.NVarChar).Value = userProfile.AlternativeEmail;
cmd.Parameters.Add("Address", SqlDbType.NVarChar).Value = userProfile.Address;
cmd.Parameters.Add("Country", SqlDbType.NVarChar).Value = userProfile.Country;
cmd.Parameters.Add("Province", SqlDbType.NVarChar).Value = userProfile.Province;
cmd.Parameters.Add("City", SqlDbType.NVarChar).Value = userProfile.City;
cmd.Parameters.Add("PostalCode", SqlDbType.NVarChar).Value = userProfile.PostalCode;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = userProfile.Status;
cmd.Parameters.Add("Passport", SqlDbType.NVarChar).Value = userProfile.Passport;
cmd.Parameters.Add("AddressProof", SqlDbType.NVarChar).Value = userProfile.AddressProof;
cmd.Parameters.Add("KycStatus", SqlDbType.NVarChar).Value = userProfile.KycStatus;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = userProfile.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = userProfile.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = userProfile.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = userProfile.UpdatedBy;
Random r = new Random();
int num = r.Next();
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var UserProfileId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return UserProfileId.ToString();
}
 [HttpPost]
public string UpdateUserProfile(UserProfile userProfile)
{
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("UpdateUserProfile" , con);
cmd.Parameters.Add("UserProfileId", SqlDbType.Int).Value = userProfile.UserProfileId;
cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = userProfile.registration.RegistrationId;
cmd.Parameters.Add("ContactNumber", SqlDbType.NVarChar).Value = userProfile.ContactNumber;
cmd.Parameters.Add("Image", SqlDbType.NVarChar).Value = userProfile.Image;
cmd.Parameters.Add("AlternativeEmail", SqlDbType.NVarChar).Value = userProfile.AlternativeEmail;
cmd.Parameters.Add("Address", SqlDbType.NVarChar).Value = userProfile.Address;
cmd.Parameters.Add("Country", SqlDbType.NVarChar).Value = userProfile.Country;
cmd.Parameters.Add("Province", SqlDbType.NVarChar).Value = userProfile.Province;
cmd.Parameters.Add("City", SqlDbType.NVarChar).Value = userProfile.City;
cmd.Parameters.Add("PostalCode", SqlDbType.NVarChar).Value = userProfile.PostalCode;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = userProfile.Status;
cmd.Parameters.Add("Passport", SqlDbType.NVarChar).Value = userProfile.Passport;
cmd.Parameters.Add("AddressProof", SqlDbType.NVarChar).Value = userProfile.AddressProof;
cmd.Parameters.Add("KycStatus", SqlDbType.NVarChar).Value = userProfile.KycStatus;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = userProfile.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = userProfile.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = userProfile.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = userProfile.UpdatedBy;
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var UserProfileId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return UserProfileId.ToString();
}
public String DeleteUserProfile(int UserProfileId)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("DeleteUserProfile", con);
cmd.Parameters.Add("UserProfileId", SqlDbType.Int).Value = UserProfileId;
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return "Success";
}



        public String ApproveUserKyc(int UserProfileId)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("ApproveUserKyc", con);
            cmd.Parameters.Add("UserProfileId", SqlDbType.Int).Value = UserProfileId;
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
