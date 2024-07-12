using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDCJupiterLoadCommon
{
    public static class WriteConstants
    {
        public const string INSERT_STUDENTINFO = "INSERT INTO STUDENT(Name,Address) values(@Name,@Address) set @StudentId = SCOPE_IDENTITY()";
        public const string LOG_DATA_SP = "WriteLogData";
        public const string LOG_EXCEPTION_SP = "WriteLogException";
        public const string LOG_WRITE_SP = "WriteMessageLog";
    }
}
