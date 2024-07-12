using IDCJupiterLoadCommon;
using IDCJupiterLoadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace IDCJupiterLoadAPI.Controllers
{
    public class ApiControllerBase : ApiController
    {
        private HeaderData _headerInfoInner;
        protected HeaderData _headerInfo
        {
            get
            {
                if (_headerInfoInner == null)
                {
                    _headerInfoInner = HttpContext.Current.Items["medicalCareHeader"] as HeaderData;
                }
                return _headerInfoInner;
            }
        }
        private IIDCJupiterLogger _jupiterLogger;
        protected IIDCJupiterLogger _logger
        {
            get
            {
                if (_jupiterLogger == null)
                {
                    _jupiterLogger = new IDCJupiterLogger();
                }
                return _jupiterLogger;
            }
        }
    }
}
