using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDCJupiterLoadModel
{
    public static class MySettingData
    {
        public static AppSettingData AppSettings { get; set; } = new AppSettingData();
    }
    public class AppSettingData : BaseData
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string LogConnectionString { get; set; } = string.Empty;
    }
}
