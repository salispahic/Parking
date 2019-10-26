using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLogic.Algorithms
{
    public class EarlyBirdAlgorithm : IAlgorithm
    {
        private const string V = "Early Bird";

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
            if (!patronTimeSpend.IsSameDay())
            {
                return null;
            }
            if (!IsEntryEarlyBirdStart(patronTimeSpend) || !IsEarlyBirdEnd(patronTimeSpend)){
                return null;
            }

            Result retVal = new Result();
            retVal.RateName = V;
            retVal.TotalPrice = 13.00;
            return retVal;
        }

        private bool IsEntryEarlyBirdStart(PatronTimeSpend patronTimeSpend)
        {
            if((patronTimeSpend.EntryDateTime.Hour >=6) && (patronTimeSpend.EntryDateTime.Hour <= 9))
            {
                return true;
            }
            return false;
        }

        private bool IsInExitSpan(DateTime timeToTest)
        {
            //exit before 3
            if(timeToTest.Hour < 15)
            {
                return false;
            }
            //exit before 3.30
            if((timeToTest.Hour ==3) && (timeToTest.Minute < 30))
            {
                return false;
            }
            //exit midnight
            if(timeToTest.Hour > 23)
            {
                return false;
            }
            //exit after 11.30
            if(timeToTest.Hour == 23 && timeToTest.Minute > 30)
            {
                return false;
            }

            return true;
        }
        private bool IsEarlyBirdEnd(PatronTimeSpend patronTimeSpend)
        {
            return IsInExitSpan(patronTimeSpend.ExitDateTime);
        }
    }
}
