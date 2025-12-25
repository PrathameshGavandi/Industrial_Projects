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
    public class AdmRegistrationDAL
    {
        DbConnection conn = null;
        public AdmRegistrationDAL()
        {
            conn = new DbConnection();
        }



        public List<AdmRegistration> GetAllAdmRegistration()

        {
            List<AdmRegistration> AdmRegistrationList = new List<AdmRegistration>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllAdmRegistration", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                AdmRegistration AdmRegistration = new AdmRegistration();
                //LoginCo loginCode = new LoginCo();


                AdmRegistration.AdmRegistrationId = Convert.ToInt32(dr["AdmRegistrationId"]);

                //   AdmRegistration.FName = Convert.ToString(dr["FName"]);
                // AdmRegistration.LName = Convert.ToString(dr["LName"]);
                AdmRegistration.Email = Convert.ToString(dr["Email"]);
                AdmRegistration.Password = Convert.ToString(dr["Password"]);
                AdmRegistration.EmailStatus = Convert.ToString(dr["EmailStatus"]);
                AdmRegistration.OTPNo = Convert.ToString(dr["OTPNo"]);
                // AdmRegistration.DefaultRole = Convert.ToString(dr["DefaultRole"]);
                AdmRegistration.Status = Convert.ToString(dr["Status"]);

                AdmRegistration.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                AdmRegistration.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                AdmRegistration.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                AdmRegistration.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                AdmRegistrationList.Add(AdmRegistration);
            }
            con.Close();
            return AdmRegistrationList;
        }
        public string AddAdmRegistration(AdmRegistration AdmRegistration)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddAdmRegistration", con);
            //cmd.Parameters.Add("AdmRegistrationId", SqlDbType.Int).Value = AdmRegistration.AdmRegistrationId;

            //   cmd.Parameters.Add("FName", SqlDbType.NVarChar).Value = AdmRegistration.FName;
            //cmd.Parameters.Add("LName", SqlDbType.NVarChar).Value = AdmRegistration.LName;
            cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = AdmRegistration.Email;
            cmd.Parameters.Add("Password", SqlDbType.NVarChar).Value = AdmRegistration.Password;
            cmd.Parameters.Add("EmailStatus", SqlDbType.NVarChar).Value = AdmRegistration.EmailStatus;
            cmd.Parameters.Add("OTPNo", SqlDbType.NVarChar).Value = AdmRegistration.OTPNo;
            //cmd.Parameters.Add("DefaultRole", SqlDbType.NVarChar).Value = AdmRegistration.DefaultRole;



            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = AdmRegistration.Status;



            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = AdmRegistration.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = AdmRegistration.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = AdmRegistration.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = AdmRegistration.UpdatedDate;

            Random r = new Random();
            int num = r.Next();



            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var AdmRegistrationId = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return AdmRegistrationId.ToString();

        }

        [HttpPost]
        public string UpdateAdmRegistration(AdmRegistration AdmRegistration)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateAdmRegistration", con);

            cmd.Parameters.Add("AdmRegistrationId", SqlDbType.Int).Value = AdmRegistration.AdmRegistrationId;
            //cmd.Parameters.Add("FName", SqlDbType.NVarChar).Value = AdmRegistration.FName;
            // cmd.Parameters.Add("LName", SqlDbType.NVarChar).Value = AdmRegistration.LName;
            cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = AdmRegistration.Email;
            cmd.Parameters.Add("Password", SqlDbType.NVarChar).Value = AdmRegistration.Password;
            cmd.Parameters.Add("EmailStatus", SqlDbType.NVarChar).Value = AdmRegistration.EmailStatus;
            cmd.Parameters.Add("OTPNo", SqlDbType.NVarChar).Value = AdmRegistration.OTPNo;
            //cmd.Parameters.Add("DefaultRole", SqlDbType.NVarChar).Value = AdmRegistration.DefaultRole;

            //cmd.Parameters.Add("Photo", SqlDbType.NVarChar).Value = AdmRegistration.Photo;
            //cmd.Parameters.Add("Sign", SqlDbType.NVarChar).Value = AdmRegistration.Sign;

            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = AdmRegistration.Status;


            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = AdmRegistration.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = AdmRegistration.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = AdmRegistration.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = AdmRegistration.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var AdmRegistrationId = result.ToString();

            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return AdmRegistration.AdmRegistrationId.ToString();

        }

        public AdmRegistration GetAdmRegistrationById(int AdmRegistrationId)
        {
            AdmRegistration AdmRegistration = new AdmRegistration();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAdmRegistrationById", con);
            cmd.Parameters.Add("AdmRegistrationId", SqlDbType.Int).Value = AdmRegistrationId;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                AdmRegistration.AdmRegistrationId = Convert.ToInt32(dr["AdmRegistrationId"]);

                //  AdmRegistration.FName = Convert.ToString(dr["FName"]);
                // AdmRegistration.LName = Convert.ToString(dr["LName"]);
                AdmRegistration.Email = Convert.ToString(dr["Email"]);
                AdmRegistration.Password = Convert.ToString(dr["Password"]);
                AdmRegistration.EmailStatus = Convert.ToString(dr["EmailStatus"]);
                AdmRegistration.OTPNo = Convert.ToString(dr["OTPNo"]);
                // AdmRegistration.DefaultRole = Convert.ToString(dr["DefaultRole"]);
                //AdmRegistration.Photo = Convert.ToString(dr["Photo"]);
                //AdmRegistration.Sign = Convert.ToString(dr["Sign"]);

                AdmRegistration.Status = Convert.ToString(dr["Status"]);


                AdmRegistration.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                AdmRegistration.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                AdmRegistration.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                AdmRegistration.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return AdmRegistration;
        }
        public AdmRegistration GetAdmRegistrationByEmail(string Email)
        {
            AdmRegistration AdmRegistration = new AdmRegistration();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAdmRegistrationByEmail", con);
            cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = Email;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                AdmRegistration.AdmRegistrationId = Convert.ToInt32(dr["AdmRegistrationId"]);

                // AdmRegistration.FName = Convert.ToString(dr["FName"]);
                //AdmRegistration.LName = Convert.ToString(dr["LName"]);
                AdmRegistration.Email = Convert.ToString(dr["Email"]);
                AdmRegistration.Password = Convert.ToString(dr["Password"]);
                AdmRegistration.EmailStatus = Convert.ToString(dr["EmailStatus"]);
                AdmRegistration.OTPNo = Convert.ToString(dr["OTPNo"]);
                // AdmRegistration.DefaultRole = Convert.ToString(dr["DefaultRole"]);
                //AdmRegistration.Photo = Convert.ToString(dr["Photo"]);
                //AdmRegistration.Sign = Convert.ToString(dr["Sign"]);

                AdmRegistration.Status = Convert.ToString(dr["Status"]);


                AdmRegistration.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                AdmRegistration.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                AdmRegistration.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                AdmRegistration.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
            }
            con.Close();
            return AdmRegistration;
        }
        public string DeleteAdmRegistration(int AdmRegistrationId)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteAdmRegistration", con);
            cmd.Parameters.Add("AdmRegistrationId", SqlDbType.Int).Value = AdmRegistrationId;
            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            con.Close();
            if (result.ToString() == "0")
            {
                return "failed";
            }
            return "Success";
        }

        //public Loginc Loginc(string Email, string Password)
        //{
        //    Loginc user = new Loginc();
        //    SqlConnection con = conn.OpenDbConnection();
        //    SqlCommand cmd = new SqlCommand("GetUserByEmailAndPassword", con);
        //    cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = Email;
        //    cmd.Parameters.Add("Password", SqlDbType.NVarChar).Value = Password;
        //   cmd.CommandType = CommandType.StoredProcedure;
        //   SqlDataReader dr = cmd.ExecuteReader();
        //    if (dr.Read())
        //    {
        //        user.AdmRegistrationId = Convert.ToInt32(dr["AdmRegistrationId"]);
        //        //user.Role = Convert.ToString(dr["Role"]);
        //    }
        //    return user;
        //}

        public Loginc Loginc(string Email, string Password)
        {
            Loginc user = new Loginc();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAdminByEmailAndPassword", con);
            cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = Email;
            cmd.Parameters.Add("Password", SqlDbType.NVarChar).Value = Password;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                user.AdmRegistrationId = Convert.ToInt32(dr["AdmRegistrationId"]);
                //user.Role = Convert.ToString(dr["Role"]);
            }
            return user;
        }




    }

    }
