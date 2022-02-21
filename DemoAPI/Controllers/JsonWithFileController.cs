using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace DemoAPI.Controllers
{
    public class JsonWithFileController : ApiController
    {
        [HttpPost]
        [Route("api/UploadAnyFile")]
        public IHttpActionResult UploadAnyFile()
        {
            HttpContext context = HttpContext.Current;
            HttpFileCollection files = HttpContext.Current.Request.Files;
            string jsonContent = context.Request["jsonContent"];
            BaseResult result = new BaseResult();

            Boolean hasFile = false;
            string content = "Json: "+jsonContent+" File: ";
            foreach (string key in files.AllKeys)
            {
                HttpPostedFile Zipfile = files[key];
                if (string.IsNullOrEmpty(Zipfile.FileName) == false)
                {
                    content+=Zipfile.FileName;
                    hasFile = true;
                    break;
                }
            }


            if (string.IsNullOrEmpty(jsonContent))
            {
                result.code = 0;
                result.errmsg = "未收到任何json請求";
            }
            else if (!hasFile)
            {
                result.code = 0;
                result.errmsg = "未收到任何json請求";
            }
            else {
                result.code = 1;
                result.data = content;
            }

            return Ok(result);
        }
    }
}
