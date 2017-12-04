using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MyProject.IBLL.Database;
using Newtonsoft.Json;

namespace MyProject.BLL.Database
{
    public class DatabaseProvider:DatabaseProviderHelper
    {
        public DatabaseProvider(string dataProvider, string connectionString)
        {
            this.DataProvider = dataProvider;
            this.ConnectionString = connectionString;
        }
    }
}
