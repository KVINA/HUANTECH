using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ServiceProvider
    {
        private ServiceProvider() { }

        private static Account_dbo? account;

        public static Account_dbo? Account { get => account; private set => account = value; }

        public static bool Set_Login(string username, string password, bool isUserAdmin = false)
        {
            if (isUserAdmin)
            {
                if (username == "admin" && password == "admin123")
                {
                    account = new Account_dbo(username, password);
                    return true;
                }
                else
                {
                    account = null;
                    return false;
                }                    
            }
            else
            {
                string query = "SELECT Count(*) FROM [account] WHERE [Username] COLLATE Latin1_General_BIN = @Username AND [Password] COLLATE Latin1_General_BIN = @Password ;";
                var parameter = new object[] { username, password };
                var res = DataProvider.Instance.ExecuteScalar(out string? ex, DataProvider.SERVER.HUANTECH, query, parameter);
                if (res is int num && num > 0)
                {
                    account = new Account_dbo(username, password);
                    return true;
                }
                else
                {
                    account = null;
                    return false;
                }
            }            
        }

        public static void Set_Logout()
        {
            account = null;
        }
    }

    public class Account_dbo
    {
        private string? username;
        private string? password;

        public string? Username { get => username; set => username = value; }
        public string? Password { get => password; set => password = value; }

        public Account_dbo(string username, string password) 
        {
            this.Username = username;
            this.Password = password;
        }
    }
}
