using IDCJupiterLoadCommon;
using IDCJupiterLoadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDCJupiterLoadDB
{
    public interface IMedicareIdDB
    {
        List<MedicareIdData> GetMedicareInfo();
        MedicareIdData SaveMedicareInfo(MedicareIdData medicareInfo);
    }
    public sealed class MedicareIdDB : BaseDB, IMedicareIdDB
    {
        public MedicareIdDB(HeaderData headerInfo, IIDCJupiterLogger logger) : base(headerInfo, logger)
        {

        }
        public List<MedicareIdData> GetMedicareInfo()
        {
            return null;
        }
        public MedicareIdData SaveMedicareInfo(MedicareIdData medicareInfo)
        {
            return medicareInfo;
        }
    }
}
