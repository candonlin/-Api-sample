using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoAPI.Controllers
{
    public class LoginController : ApiController
    {
        string connection = ConfigurationManager.ConnectionStrings["Connect"].ConnectionString;

        [HttpPost]
        [Route("api/login")]
        public IHttpActionResult Login([FromBody]UserRequest request)
        {
            if (request.EMPNO == null || request.EMPNO.Length == 0)
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                        Request.CreateErrorResponse(
                        (HttpStatusCode)900,
                        new HttpError("請輸入完整帳密")
                        )
                    );
            }
            if (request.EMPPASSWORD == null || request.EMPPASSWORD.Length == 0)
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                        Request.CreateErrorResponse(
                        (HttpStatusCode)901,
                        new HttpError("請輸入完整帳密")
                        )
                    );
            }
            BaseResult response = new BaseResult();

            //using (SqlConnection conn = new SqlConnection(connection))
            //{
            //    conn.Open();
            //    string sql = "SELECT * FROM UserInfo WHERE EMPNO = @EMPNO";

            //    SqlParameter para = new SqlParameter(); //宣告引數
            //    para = new SqlParameter("@EMPNO", request.EMPNO);

            //    using (SqlCommand command = new SqlCommand(sql, conn))
            //    {
            //        command.Parameters.Add(para);
            //        //command.Parameters["@EMPNO"].Value = request.EMPNO;
            //        SqlDataReader reader = command.ExecuteReader();
            //        try
            //        {
            //            DataTable dt = new DataTable();
            //            dt.Load(reader);
            //            if (dt.Rows.Count > 0)
            //            {
            //                DataRow[] result = dt.Select("EMPPASSWORD = '" + request.EMPPASSWORD+"'");
            //                if (result.Length != 0)
            //                {
            //                    UserInfo info = new UserInfo();
            //                    response.code = 1;
            //                    info.EMPNAME = result[0]["EMPNAME"].ToString().Trim();
            //                    response.data = info;


            //                }
            //                else
            //                {
            //                    response.code = 0;
            //                    response.errmsg = "密碼錯誤";
            //                }
            //            }
            //            else
            //            {
            //                response.code = 0;
            //                response.errmsg = "查無此帳號";
            //            }
            //            return Ok(response);
            //        }
            //        catch (Exception ex)
            //        {
            //            return new System.Web.Http.Results.ResponseMessageResult(
            //              Request.CreateErrorResponse(
            //          (HttpStatusCode)999,
            //          new HttpError(ex.Message)
            //          ));
            //        }
            //        finally
            //        {
            //            if (reader != null)
            //                ((IDisposable)reader).Dispose();
            //        }
            //    }
            //}
            if (request.EMPNO.Equals("sa") && request.EMPPASSWORD.Equals("1234"))
            {
                UserInfo info = new UserInfo();
                response.code = 1;
                info.EMPNAME = "測試帳號001";
                response.data = info;
            }
            else
            {
                response.code = 0;
                response.errmsg = "帳號密碼錯誤";
            }
            return Ok(response);
        }
    }
}
