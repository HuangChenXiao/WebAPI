using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class JsonResult
    {
        public JsonResult() {
        }
        private int _status;

        public int status
        {
            get { return _status; }
            set { _status = value; }
        }
        private string _msg;
        public string msg
        {
            get { return _msg; }
            set { _msg = value; }
        }
        private DataTable _data;

        public DataTable data
        {
            get { return _data; }
            set { _data = value; }
        }
    }
}
