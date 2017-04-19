using Com;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Lib
{
    public static class ProcedureHelper
    {
        public static DataSet ProcedureRDataTable(HttpContext context, string storedProcName)
        {
            using (ConnDB db = new ConnDB())
            {
                context.Response.ContentType = "text/json";
                context.Response.Charset = "utf-8";
                context.Response.Cache.SetNoStore();

                SqlParameter[] pList;

                if (context.Request.HttpMethod == "GET")
                {
                    //获取url?后的键和值
                    var all_url = context.Request.Url;
                    string[] s1 = all_url.ToString().Split('?');
                    if (s1.Length > 1)
                    {
                        string[] s2 = s1[1].Split('&');
                        pList = new SqlParameter[s2.Length];
                        for (int i = 0; i < s2.Length; i++)
                        {
                            string name = s2[i].Split('=')[0];//键值
                            string val = s2[i].Split('=')[1];//对应的值
                            SqlParameter par = new SqlParameter();
                            par.ParameterName = "@" + name;
                            par.SqlDbType = SqlDbType.NVarChar;
                            par.SqlValue = val;
                            pList[i] = par;
                        }
                        return db.RunProcedureRdataSet(storedProcName, pList);
                    }
                    else
                    {
                        return db.RunProcedureRdataSet(storedProcName);
                    }
                }
                else if (context.Request.HttpMethod == "POST")
                {
                    //获取url?后的键和值
                    var pForm = context.Request.Form.AllKeys;
                    if (pForm.Length > 0)
                    {
                        pList = new SqlParameter[pForm.Length];
                        for (int i = 0; i < pForm.Length; i++)
                        {
                            string name = pForm[i];//键值
                            string val = context.Request.Form[pForm[i]];//对应的值
                            SqlParameter par = new SqlParameter();
                            par.ParameterName = "@" + name;
                            par.SqlDbType = SqlDbType.NVarChar;
                            par.SqlValue = val;
                            pList[i] = par;
                        }
                        return db.RunProcedureRdataSet(storedProcName, pList);
                    }
                    else
                    {
                        return db.RunProcedureRdataSet(storedProcName);
                    }
                }
            }
            return null;
        }
    }
}
