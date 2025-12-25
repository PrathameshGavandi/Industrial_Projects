//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Data;
//using System.Data.SqlClient;
//using System.Web.Http;
//using PrismAPI.Models;
//using PrismAPI.DAL;
//using System.Data.Common;

//namespace PrismAPI.DAL
//{
//    public class LoginDAL
//    {
//        DbConnection conn = null;
//        public LoginDAL()
//        {
//            conn = new DbConnection();
//        }



//        public Login Login(string Email, string Password)
//        {
//            Login user = new Login();
//            SqlConnection con = conn.OpenDbConnection();
//            SqlCommand cmd = new SqlCommand("GetUserByEmailAndPassword", con);
//            cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = Email;
//            cmd.Parameters.Add("Password", SqlDbType.NVarChar).Value = Password;
//            cmd.CommandType = CommandType.StoredProcedure;
//            SqlDataReader dr = cmd.ExecuteReader();
//            if (dr.Read())
//            {
//                user.LoginId = Convert.ToInt32(dr["LoginId"]);
//                //user.Role = Convert.ToString(dr["Role"]);
//            }
//            return user;
//        }
//    }
//}