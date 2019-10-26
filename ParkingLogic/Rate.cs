using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLogic
{
    public class Rate
    {
        public IAlgorithm Algorythm { get; set; }

        public string GetRateName()
        {
            return Algorythm.GetRateName();
        }

        public string GetRateType()
        {
            return Algorythm.GetRateType();
        }

        public Result IsFound(PatronTimeSpend patronTimeSpend)
        {
            return Algorythm.IsFound(patronTimeSpend);
        }

        public Rate(IAlgorithm algorythm)
        {
            Algorythm = algorythm;
        }
    }
}
