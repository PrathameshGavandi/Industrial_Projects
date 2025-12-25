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
public class MakeRequestDAL
{
DbConnection conn = null;
public MakeRequestDAL()
{
conn = new DbConnection();
}
public List<MakeRequest> GetAllMakeRequest()
{
List<MakeRequest> makeRequestList = new List<MakeRequest>();
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("GetAllMakeRequest", con);
cmd.CommandType = CommandType.StoredProcedure;
SqlDataReader dr = cmd.ExecuteReader();
 while (dr.Read())
{
MakeRequest makeRequest = new MakeRequest();
makeRequest.MakeRequestId = Convert.ToInt32(dr["MakeRequestId"]);
makeRequest.registration = new Registration();
makeRequest.registration.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
makeRequest.registration.FName = Convert.ToString(dr["FName1"]);
makeRequest.TicketId = Convert.ToInt32(dr["TicketId"]);
makeRequest.Status = Convert.ToString(dr["Status"]);
makeRequest.CompAgree = Convert.ToString(dr["CompAgree"]);
makeRequest.FttAgree = Convert.ToString(dr["FttAgree"]);
makeRequest.TicketStatus = Convert.ToString(dr["TicketStatus"]);
makeRequest.Feedback = Convert.ToString(dr["Feedback"]);
makeRequest.Txt = Convert.ToString(dr["Txt"]);
makeRequest.CreatedDate = Convert.ToString(dr["CreatedDate"]);
makeRequest.CreatedBy = Convert.ToString(dr["CreatedBy"]);
makeRequest.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
makeRequest.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
makeRequestList.Add(makeRequest);
}
con.Close();
return makeRequestList;
}
public MakeRequest GetMakeRequestById(int MakeRequestId)
{
MakeRequest makeRequest = new MakeRequest();
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("GetMakeRequestById" , con);
cmd.Parameters.Add("MakeRequestId", SqlDbType.Int).Value = MakeRequestId;
cmd.CommandType = CommandType.StoredProcedure;
 SqlDataReader dr = cmd.ExecuteReader();
if (dr.Read())
{
makeRequest.MakeRequestId = Convert.ToInt32(dr["MakeRequestId"]);
makeRequest.registration = new Registration();
makeRequest.registration.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
makeRequest.registration.FName = Convert.ToString(dr["FName1"]);
makeRequest.TicketId = Convert.ToInt32(dr["TicketId"]);
makeRequest.Status = Convert.ToString(dr["Status"]);
makeRequest.CompAgree = Convert.ToString(dr["CompAgree"]);
makeRequest.FttAgree = Convert.ToString(dr["FttAgree"]);
makeRequest.TicketStatus = Convert.ToString(dr["TicketStatus"]);
makeRequest.Feedback = Convert.ToString(dr["Feedback"]);
makeRequest.Txt = Convert.ToString(dr["Txt"]);
makeRequest.CreatedDate = Convert.ToString(dr["CreatedDate"]);
makeRequest.CreatedBy = Convert.ToString(dr["CreatedBy"]);
makeRequest.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
makeRequest.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
}
con.Close();
return makeRequest;
}
public string AddMakeRequest(MakeRequest makeRequest)
 {
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("AddMakeRequest", con);
cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = makeRequest.registration.RegistrationId;
cmd.Parameters.Add("TicketId", SqlDbType.Int).Value = makeRequest.TicketId;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = makeRequest.Status;
cmd.Parameters.Add("CompAgree", SqlDbType.NVarChar).Value = makeRequest.CompAgree;
cmd.Parameters.Add("FttAgree", SqlDbType.NVarChar).Value = makeRequest.FttAgree;
cmd.Parameters.Add("TicketStatus", SqlDbType.NVarChar).Value = makeRequest.TicketStatus;
cmd.Parameters.Add("Feedback", SqlDbType.NVarChar).Value = makeRequest.Feedback;
cmd.Parameters.Add("Txt", SqlDbType.NVarChar).Value = makeRequest.Txt;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = makeRequest.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = makeRequest.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = makeRequest.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = makeRequest.UpdatedBy;
Random r = new Random();
int num = r.Next();
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var MakeRequestId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return MakeRequestId.ToString();
}
 [HttpPost]
public string UpdateMakeRequest(MakeRequest makeRequest)
{
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("UpdateMakeRequest" , con);
cmd.Parameters.Add("MakeRequestId", SqlDbType.Int).Value = makeRequest.MakeRequestId;
cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = makeRequest.registration.RegistrationId;
cmd.Parameters.Add("TicketId", SqlDbType.Int).Value = makeRequest.TicketId;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = makeRequest.Status;
cmd.Parameters.Add("CompAgree", SqlDbType.NVarChar).Value = makeRequest.CompAgree;
cmd.Parameters.Add("FttAgree", SqlDbType.NVarChar).Value = makeRequest.FttAgree;
cmd.Parameters.Add("TicketStatus", SqlDbType.NVarChar).Value = makeRequest.TicketStatus;
cmd.Parameters.Add("Feedback", SqlDbType.NVarChar).Value = makeRequest.Feedback;
cmd.Parameters.Add("Txt", SqlDbType.NVarChar).Value = makeRequest.Txt;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = makeRequest.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = makeRequest.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = makeRequest.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = makeRequest.UpdatedBy;
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var MakeRequestId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return MakeRequestId.ToString();
}
public String DeleteMakeRequest(int MakeRequestId)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("DeleteMakeRequest", con);
cmd.Parameters.Add("MakeRequestId", SqlDbType.Int).Value = MakeRequestId;
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
