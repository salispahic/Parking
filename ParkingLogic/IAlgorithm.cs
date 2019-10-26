using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLogic
{
    public interface IAlgorithm
    {
        Rate Rate { get; set; }

        string GetRateName();
        string GetRateType();

        Result IsFound(PatronTimeSpend patronTimeSpend);
    }
}
