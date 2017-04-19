using Com;
using Lib;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace WebApplication
{
    /// <summary>
    /// example 的摘要说明
    /// </summary>
    public class example : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            using (DataSet dataset = ProcedureHelper.ProcedureRDataTable(context, "PROC_ExpandActivity"))
            {
                JsonResult result = new JsonResult();
                if (dataset.Tables.Count > 0)
                {
                    result.status = 1;
                    result.msg = "查询成功！";
                    result.data = dataset.Tables[0];
                }
                else
                {
                    result.status = 0;
                    result.msg = "暂无数据！";
                }
                context.Response.Write(JsonConvert.SerializeObject(result));
            }
        }

        public bool IsReusable
        {
            get { return false; }
        }

    }
}