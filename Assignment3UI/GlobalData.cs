using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3UI
{
    class GlobalData
    {
        const string CSTRING = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=SCM;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public GlobalData() { }
        public DataTable GetData(string query)
        {
            SqlDataAdapter da = new SqlDataAdapter(query, CSTRING);
            DataTable dtToReturn = new DataTable();
            da.Fill(dtToReturn);
            return dtToReturn;
        }
    }
}
