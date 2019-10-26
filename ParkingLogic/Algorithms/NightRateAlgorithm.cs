using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLogic.Algorithms
{
    public class NightRateAlgorithm : IAlgorithm
    {
        private const string V = "Night Rate";

        public Rate Rate { get; set; }

        public string GetRateName()
        {
            return V;
        }

        public string GetRateType()
        {
            return "Flat Rate";
        }

        public Result IsFound(PatronTimeSpend patronTimeSpend)
        {
            if (!patronTimeSpend.IsEntryWeekday())
            {
                return null;
            }
            if(patronTimeSpend.EntryDateTime.Hour < 18)
            {
                return null;
            }
            if (patronTimeSpend.EntryDateTime.Hour > 24)
            {
                return null;
            }

            if (patronTimeSpend.IsEntryAndExitGreaterThanOneDay())
            {
                return null;
            }

            if((patronTimeSpend.ExitDateTime.Hour>= 6)&&(patronTimeSpend.ExitDateTime.Minute >0))
            {
                return null;
            }

            Result retVal = new Result();
            retVal.RateName = V;
            retVal.TotalPrice = 6.50;
            return retVal;
        }
    }
}
