using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDCJupiterLoadModel
{
    public class HeaderData : BaseData
    {
        public int Id { get; set; }
        public string SessionId { get; set; } = string.Empty;
    }
}
