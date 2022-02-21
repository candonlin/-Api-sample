using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAPI.Models
{
    public class BaseResult
    {
        public int code { get; set; }
        public object data { get; set; }
        public string errmsg { get; set; }
    }
}