using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Login
{
    static class truyxuat
    {
        private static string duongdan = @"Data Source=CHUTNGOCHANH\CTTH;Initial Catalog=QuanLyNhaThuoc;Integrated Security=True";
        private static SqlConnection taoketnoi()
        {
            return new SqlConnection(duongdan);
        }

    }
}
