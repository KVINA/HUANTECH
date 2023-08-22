using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    internal class ServerInfo
    {
        private string? nameServer;
        private string? dataSource;
        private string? initialCatalog;
        private bool? integratedSecurity;
        private string? userID;
        private string? password;

        public string? NameServer { get => nameServer; set => nameServer = value; }
        public string? DataSource { get => dataSource; set => dataSource = value; }
        public string? InitialCatalog { get => initialCatalog; set => initialCatalog = value; }
        public bool? IntegratedSecurity { get => integratedSecurity; set => integratedSecurity = value; }
        public string? UserID { get => userID; set => userID = value; }
        public string? Password { get => password; set => password = value; }

        public string Get_ConnectString()
        {
            return $"Data Source = {DataSource}; Initial Catalog = {NameServer}; User ID = {UserID}; Password = {Password}; Integrated Security = True;";
        }
    }
}
