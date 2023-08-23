
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DataProvider
    {
        private static DataProvider? instance;

        public static DataProvider Instance { get { if (instance == null) instance = new DataProvider(); return instance; } private set => instance = value; }
        
        private Dictionary<string,ServerInfo> DIC_SERVER = new Dictionary<string,ServerInfo>();
        private DataProvider() 
        {
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("Config.json", optional: true, reloadOnChange: true).Build();
            // Đọc các giá trị từ tệp JSON
            var ListServer = configuration.GetSection("ServerInfo").Get<List<ServerInfo>>();
            if (ListServer != null)
            {
                foreach (var item in ListServer)
                {
                    if (!string.IsNullOrEmpty(item.NameServer))
                    {
                        DIC_SERVER.Add(item.NameServer, item);
                    }                    
                }
            }
        }        
        public enum SERVER
        {
            NULL = 0,
            KVINA = 1,
            HUANTECH = 2
        }
        private string? ServerSTR(SERVER server)
        {
            switch (server)
            {
                case SERVER.NULL:
                    return null;
                case SERVER.KVINA:
                    return DIC_SERVER["KVINA"].Get_ConnectString();
                case SERVER.HUANTECH:
                    return DIC_SERVER["HUANTECH"].Get_ConnectString();
                default:
                    return null;
            }
        }

        public DataTable? ExecuteQuery(out string? exception,SERVER server, string query, object[]? parameter = null)
        {
            try
            {
                exception = default;
                string? str_conn = ServerSTR(server);
                if (str_conn != null) 
                {
                    DataTable db = new DataTable();
                    using (var conn = new SqlConnection(str_conn))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(query, conn);
                        if (parameter != null && parameter.Length > 0)
                        {
                            var listPara = query.Split(' ');
                            int i = 0;
                            foreach (var item in listPara)
                            {
                                if (item.Contains('@'))
                                {
                                    cmd.Parameters.AddWithValue(item, parameter[i]);
                                    i++;
                                }
                            }
                        }
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(db);
                        conn.Close();
                    }
                    return db;
                }
                else
                {
                    exception = "ERROR: Chuỗi kết nối không hợp lệ.";
                    return null;
                }
            }
            catch (Exception ex)
            {
                exception = ex.Message;
                return null; 
            }
        }

        public int ExecuteNonquery(out string? exception, SERVER server, string query, object[]? parameter = null)
        {
            try
            {
                exception = default;
                string? str_conn = ServerSTR(server);
                if (str_conn != null)
                {
                    int res = 0;
                    using (var conn = new SqlConnection(str_conn))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(query, conn);
                        if (parameter != null && parameter.Length > 0)
                        {
                            var listPara = query.Split(' ');
                            int i = 0;
                            foreach (var item in listPara)
                            {
                                if (item.Contains('@'))
                                {
                                    cmd.Parameters.AddWithValue(item, parameter[i]);
                                    i++;
                                }
                            }
                        }
                        res = cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    return res;
                }
                else
                {
                    exception = "ERROR: Chuỗi kết nối không hợp lệ.";
                    return 0;
                }
            }
            catch (Exception ex)
            {
                exception = ex.Message;
                return 0;
            }
        }

        public object? ExecuteScalar(out string? exception, SERVER server, string query, object[]? parameter = null)
        {
            try
            {
                exception = default;
                string? str_conn = ServerSTR(server);
                if (str_conn != null)
                {
                    object? res = null;
                    using (var conn = new SqlConnection(str_conn))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(query, conn);
                        if (parameter != null && parameter.Length > 0)
                        {
                            var listPara = query.Split(' ');
                            int i = 0;
                            foreach (var item in listPara)
                            {
                                if (item.Contains('@'))
                                {
                                    cmd.Parameters.AddWithValue(item, parameter[i]);
                                    i++;
                                }
                            }
                        }
                        res = cmd.ExecuteScalar();
                        conn.Close();
                    }
                    return res;
                }
                else
                {
                    exception = "ERROR: Chuỗi kết nối không hợp lệ.";
                    return null;
                }
            }
            catch (Exception ex)
            {
                exception = ex.Message;
                return null;
            }
        }
    }
}
