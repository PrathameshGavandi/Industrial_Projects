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
public class OfferDAL
{
DbConnection conn = null;
public OfferDAL()
{
conn = new DbConnection();
}
public List<Offer> GetAllOffer()
{
List<Offer> offerList = new List<Offer>();
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("GetAllOffer", con);
cmd.CommandType = CommandType.StoredProcedure;
SqlDataReader dr = cmd.ExecuteReader();
 while (dr.Read())
{
Offer offer = new Offer();
offer.Id = Convert.ToInt32(dr["Id"]);
offer.Title = Convert.ToString(dr["Title"]);
offer.SubTitle = Convert.ToString(dr["SubTitle"]);
offer.Description = Convert.ToString(dr["Description"]);
offer.DiscountInPercent = Convert.ToString(dr["DiscountInPercent"]);
offer.Status = Convert.ToString(dr["Status"]);
offer.Image = Convert.ToString(dr["Image"]);
offer.CreatedDate = Convert.ToString(dr["CreatedDate"]);
offer.CreatedBy = Convert.ToString(dr["CreatedBy"]);
offer.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
offer.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
offerList.Add(offer);
}
con.Close();
return offerList;
}
public Offer GetOfferById(int Id)
{
Offer offer = new Offer();
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("GetOfferById" , con);
cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
cmd.CommandType = CommandType.StoredProcedure;
 SqlDataReader dr = cmd.ExecuteReader();
if (dr.Read())
{
offer.Id = Convert.ToInt32(dr["Id"]);
offer.Title = Convert.ToString(dr["Title"]);
offer.SubTitle = Convert.ToString(dr["SubTitle"]);
offer.Description = Convert.ToString(dr["Description"]);
offer.DiscountInPercent = Convert.ToString(dr["DiscountInPercent"]);
offer.Status = Convert.ToString(dr["Status"]);
offer.Image = Convert.ToString(dr["Image"]);
offer.CreatedDate = Convert.ToString(dr["CreatedDate"]);
offer.CreatedBy = Convert.ToString(dr["CreatedBy"]);
offer.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
offer.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
}
con.Close();
return offer;
}
public string AddOffer(Offer offer)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("AddOffer", con);
cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = offer.Title;
cmd.Parameters.Add("SubTitle", SqlDbType.NVarChar).Value = offer.SubTitle;
cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = offer.Description;
cmd.Parameters.Add("DiscountInPercent", SqlDbType.NVarChar).Value = offer.DiscountInPercent;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = offer.Status;
cmd.Parameters.Add("Image", SqlDbType.NVarChar).Value = offer.Image;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = offer.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = offer.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = offer.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = offer.UpdatedBy;
Random r = new Random();
int num = r.Next();
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var Id = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return Id.ToString();
}
 [HttpPost]
public string UpdateOffer(Offer offer)
{
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("UpdateOffer" , con);
cmd.Parameters.Add("Id", SqlDbType.Int).Value = offer.Id;
cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = offer.Title;
cmd.Parameters.Add("SubTitle", SqlDbType.NVarChar).Value = offer.SubTitle;
cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = offer.Description;
cmd.Parameters.Add("DiscountInPercent", SqlDbType.NVarChar).Value = offer.DiscountInPercent;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = offer.Status;
cmd.Parameters.Add("Image", SqlDbType.NVarChar).Value = offer.Image;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = offer.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = offer.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = offer.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = offer.UpdatedBy;
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var Id = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return Id.ToString();
}
public String DeleteOffer(int Id)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("DeleteOffer", con);
cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
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
