using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLogic.Algorithms
{
    public class WeekendRateAlgorithm : IAlgorithm
    {
        private const string V = "Weekend Rate";

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
            if (patronTimeSpend.IsEntryWeekday())
            {
                return null;
            }
            if (patronTimeSpend.IsExitWeekday())
            {
                return null;
            }

            if(patronTimeSpend.ExitDateTime.Subtract(patronTimeSpend.EntryDateTime).TotalDays > 2)
            {
                return null;
            }

            Result retVal = new Result();
            retVal.RateName = V;
            retVal.TotalPrice = 10.00;
            return retVal;
        }
    }
}
