using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Web.Http.Cors;
using PrismAPI.DAL;
using PrismAPI.Models;
namespace PrismAPI.Controllers
{
    public class OfferController : ApiController
   {
   public Logger Log = null;
       public OfferController()
       {
       Log = Logger.GetLogger();
       }
OfferDAL offerDAL = new OfferDAL();
[HttpGet]
[ActionName("GetAllOffer")]
public List<Offer> GetAllOffer()
{
Log.writeMessage("OfferController GetAllOffer Start");
List<Offer> list = null;
try
{
list = offerDAL.GetAllOffer();
}
catch (Exception ex)
{
Log.writeMessage("OfferController GetAllOffer Error " + ex.Message);
}
Log.writeMessage("OfferController GetAllOffer End ");
return list;
}
 [HttpGet]
 [ActionName("GetOfferById")]
 public Offer GetOfferById(int Id )
{
Log.writeMessage("OfferController GetOfferById Start");
Offer offer = null;
try
{
offer = offerDAL.GetOfferById(Id);
}
catch (Exception ex)
{
Log.writeMessage("OfferController GetOfferById Error " + ex.Message);
}
Log.writeMessage("OfferController GetOfferById End");
return offer;
}
[HttpPost]
 [ActionName("AddOffer")]
 public IHttpActionResult AddOffer(Offer offer)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
offer.CreatedBy = "Admin";
offer.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
offer.UpdatedBy = "Admin";
offer.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = offerDAL.AddOffer(offer);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("OfferController AddOffer Error " + ex.Message);
}
return Ok(result);
}
[HttpPost]
 [ActionName("UpdateOffer")]
 public IHttpActionResult UpdateOffer(Offer offer)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
offer.CreatedBy = "Admin";
offer.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
offer.UpdatedBy = "Admin";
offer.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = offerDAL.UpdateOffer(offer);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("OfferController UpdateOffer Error " + ex.Message);
}
return Ok(result);
}
 public IHttpActionResult DeleteOffer(int Id)
{
 try
 {
var result = offerDAL.DeleteOffer(Id);
if (result == "Success")
{
return Ok("Success");
}
else
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("OfferController DeleteOffer Error "  + ex.Message);
}
return Ok("Failed");
}
[HttpPost]
public async Task<IHttpActionResult> SaveOfferImage(int Id)
{
try
{
if (!Request.Content.IsMimeMultipartContent())
throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
var provider = new MultipartMemoryStreamProvider();
await Request.Content.ReadAsMultipartAsync(provider);
foreach (var file in provider.Contents)
{
var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
var buffer = await file.ReadAsByteArrayAsync();
string fullPath = (new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;
//get the folder that's in
string theDirectory = Path.GetDirectoryName(fullPath);
theDirectory = theDirectory.Substring(0, theDirectory.LastIndexOf('\\'));
File.WriteAllBytes(theDirectory + "/Content/Offer" + "/" + Id +"_" + filename, buffer);
//Do whatever you want with filename and its binary data.
// get existing rocrd
var offer = offerDAL.GetOfferById(Id);
var filenamenew = Id + "_" + filename;
if (offer.Image.ToLower() != filenamenew.ToLower())
{
File.Delete(theDirectory + "/Content/Offer" + "/"+ offer.Image);
offer.Image = Id +"_" + filename; 
var result = offerDAL.UpdateOffer(offer);
}
}
}
catch (Exception ex)
{
Log.writeMessage(ex.Message);
}
return Ok();
}
}
}
