using ParkingLogic.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLogic
{
    public class AvailableRates
    {
        IList<Rate> _rates;

        public AvailableRates()
        {
            _rates = new List<Rate>();
            _rates.Add(new Rate(new EarlyBirdAlgorithm()));
            _rates.Add(new Rate(new NightRateAlgorithm()));
            _rates.Add(new Rate(new WeekendRateAlgorithm()));
            _rates.Add(new Rate(new StandardRateAlgorithm()));
        }

        public Result GetResult(PatronTimeSpend patronTimeSpend)
        {
            Result retVal = null;
            for(int i=0; i<_rates.Count; i++)
            {
                retVal = _rates[i].IsFound(patronTimeSpend);
                if(retVal != null)
                {
                    break;
                }
            }
            return retVal;
        }
    }
}
