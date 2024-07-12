using IDCJupiterLoadCommon;
using IDCJupiterLoadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDCJupiterLoadDB
{
    public class BaseDB : BaseData
    {
        internal HeaderData _headerInfo;
        internal IIDCJupiterLogger _logger;

        public BaseDB(HeaderData headerInfo, IIDCJupiterLogger logger)
        {
            _headerInfo = headerInfo;
            _logger = logger;
        }
    }
}
