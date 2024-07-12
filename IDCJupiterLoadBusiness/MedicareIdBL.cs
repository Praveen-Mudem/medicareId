using IDCJupiterLoadCommon;
using IDCJupiterLoadDB;
using IDCJupiterLoadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDCJupiterLoadBusiness
{
    public interface IMedicareIdBL
    {
        List<MedicareIdData> GetMedicareInfo();
        MedicareIdData SaveMedicareInfo(MedicareIdData medicareInfo);
    }
    public sealed class MedicareIdBL : BaseBL, IMedicareIdBL
    {
        private IMedicareIdDB _medicareDB;
        public MedicareIdBL(HeaderData headerInfo, IIDCJupiterLogger logger) : base(headerInfo, logger)
        {
            _medicareDB = new MedicareIdDB(_headerInfo, _logger);
        }
        public List<MedicareIdData> GetMedicareInfo()
        {
            try
            {
                return _medicareDB.GetMedicareInfo();
            }
            catch(Exception ex)
            {
                _logger.LogException(_headerInfo, "Exception at GetMedicareInfo", ex);
            }
            return null;
        }
        public MedicareIdData SaveMedicareInfo(MedicareIdData medicareInfo)
        {
            try
            {
                return _medicareDB.SaveMedicareInfo(medicareInfo);
            }
            catch (Exception ex)
            {
                _logger.LogException(_headerInfo, "Exception at SaveMedicareInfo", ex);
            }
            return medicareInfo;
        }
    }
}
