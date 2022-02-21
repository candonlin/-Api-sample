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
    public class GenericController : ApiController
    {
        [HttpGet]
        [Route("api/getTemp")]
        public IHttpActionResult getTemp()
        {
            BaseResult result = new BaseResult();
            List<DataModel> infos = new List<DataModel>();
            string ConnStr = ConfigurationManager.ConnectionStrings["Connect"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    using (SqlCommand command = new SqlCommand("SELECT * FROM TempBigData ", conn))
                    {
                        SqlDataReader dr = command.ExecuteReader();
                        try
                        {
                            DataTable dt = new DataTable();
                            dt.Load(dr);
                            if (dt.Rows.Count > 0)
                            {
                                foreach (DataRow DR in dt.Rows)
                                {
                                    DataModel obj = new DataModel();
                                    obj.col_1 = DR["col_1"].ToString().Trim();
                                    obj.col_2 = DR["col_2"].ToString().Trim();
                                    obj.col_3 = DR["col_3"].ToString().Trim();
                                    obj.col_4 = DR["col_4"].ToString().Trim();
                                    obj.col_5 = DR["col_5"].ToString().Trim();
                                    obj.col_6 = DR["col_6"].ToString().Trim();
                                    obj.col_7 = DR["col_7"].ToString().Trim();
                                    obj.col_8 = DR["col_8"].ToString().Trim();
                                    obj.col_9 = DR["col_9"].ToString().Trim();
                                    obj.col_10 = DR["col_10"].ToString().Trim();
                                    obj.col_11 = DR["col_11"].ToString().Trim();
                                    obj.col_12 = DR["col_12"].ToString().Trim();
                                    obj.col_13 = DR["col_13"].ToString().Trim();
                                    obj.col_14 = DR["col_14"].ToString().Trim();
                                    obj.col_15 = DR["col_15"].ToString().Trim();

                                    infos.Add(obj);
                                }
                            }
                            else
                            {
                                conn.Close();
                                return new System.Web.Http.Results.ResponseMessageResult(
                                Request.CreateErrorResponse(
                                    (HttpStatusCode)999,
                                    new HttpError("查無資料!")
                                    ));
                            }

                        }
                        catch (Exception ex)
                        {
                            return new System.Web.Http.Results.ResponseMessageResult(
                                Request.CreateErrorResponse(
                                    (HttpStatusCode)999,
                                    new HttpError(ex.Message)
                                    ));
                        }
                        finally
                        {
                            if (dr != null)
                                ((IDisposable)dr).Dispose();
                        }
                    }
                }
            }

            result.code = 1;
            result.data = infos;
            result.errmsg = "";

            return Ok(result);
        }

        [HttpGet]
        [Route("api/getinfo_product")]
        public IHttpActionResult getinfo_product()
        {
            BaseResult result = new BaseResult();

            List<ProductInfo> infos = new List<ProductInfo>();
            ProductInfo info = new ProductInfo();
            info.No = "1234";
            info.Name = "測試商品";
            info.Unit = "KG";
            info.LotManager = false;
            infos.Add(info);

            result.code = 1;
            result.data = infos;
            result.errmsg = "";

            return Ok(result);
        }

        [HttpGet]
        [Route("api/getinfo_inv")]
        public IHttpActionResult getinfo_inv()
        {
            BaseResult result = new BaseResult();

            List<InvInfo> infos = new List<InvInfo>();
            InvInfo info = new InvInfo();
            info.No = "A0001";
            info.Name = "成品倉";
            info.Nature = "存貨倉";
            infos.Add(info);

            result.code = 1;
            result.data = infos;
            result.errmsg = "";

            return Ok(result);
        }
    }
}
