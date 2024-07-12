using IDCJupiterLoadCommon;
using IDCJupiterLoadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDCJupiterLoadBusiness
{
    public class BaseBL : BaseData
    {
        internal HeaderData _headerInfo; 
        internal IIDCJupiterLogger _logger;

        public BaseBL(HeaderData headerInfo, IIDCJupiterLogger logger)
        {
            _headerInfo = headerInfo;
            _logger = logger;
        }
    }
}
