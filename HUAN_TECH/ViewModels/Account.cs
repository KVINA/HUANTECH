using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUAN_TECH.ViewModels
{
    internal class Account
    {
        public static bool IsCheckLogin(string username, string password)
        {
            string query = "SELECT Count(*) FROM [account] WHERE [Username] COLLATE Latin1_General_BIN = @Username AND [Password] COLLATE Latin1_General_BIN = @Password ;";
            var parameter = new object[] { username, password };
            var res = DataProvider.Instance.ExecuteScalar(out string? ex, DataProvider.SERVER.HUANTECH, query, parameter);
            if (res is int num && num > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
