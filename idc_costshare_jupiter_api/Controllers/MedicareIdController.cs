using IDCJupiterLoadBusiness;
using IDCJupiterLoadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IDCJupiterLoadAPI.Controllers
{
    public class MedicareIdController : ApiControllerBase
    {
        private IMedicareIdBL _medicareBLInner;
        private IMedicareIdBL _medicareBL
        {
            get
            {
                if (_medicareBLInner == null && _headerInfo != null)
                {
                    _medicareBLInner = new MedicareIdBL(_headerInfo, _logger);
                }
                return _medicareBLInner;
            }
        }
        public MedicareIdController()
        {

        }
        [AllowAnonymous]
        [HttpGet]
        [Route("GetMedicareIdInfo")]
        public IHttpActionResult GetMedicareIdInfo()
        {
            return Json(_medicareBL.GetMedicareInfo());
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("SaveMedicareIdInfo")] 
        public IHttpActionResult SaveMedicareIdInfo(MedicareIdData medicareInfo)
        {
            return Json(_medicareBL.SaveMedicareInfo(medicareInfo));
        }
    }
}
