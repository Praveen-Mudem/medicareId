using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDCJupiterLoadModel
{
    public class LogData : BaseData
    {
        public string ShortMessage { get; set; } = string.Empty;
        public string LongMessage { get; set; } = string.Empty;
        public string StackTrace { get; set; } = string.Empty;
        public string BaseMessage { get; set; } = string.Empty;
        public string MessageType { get; set; } = string.Empty;
        public string Service { get; set; } = string.Empty;
        public int CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public string SessionId { get; set; } = string.Empty;
    }
}
