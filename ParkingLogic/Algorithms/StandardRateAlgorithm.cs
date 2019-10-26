using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLogic.Algorithms
{
    class StandardRateAlgorithm : IAlgorithm
    {
        private const string V = "Standard Rate";

        public Rate Rate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string GetRateName()
        {
            return V;
        }

        public string GetRateType()
        {
            return "Hourly Rate";
        }

        public Result IsFound(PatronTimeSpend patronTimeSpend)
        {
            double totalPrice = GetRate(patronTimeSpend);
            Result retVal = new Result();
            retVal.RateName = V;
            retVal.TotalPrice = totalPrice;
            return retVal;
        }

        private double GetRate(PatronTimeSpend patronTimeSpend)
        {
            double totalHours = patronTimeSpend.ExitDateTime.Subtract(patronTimeSpend.EntryDateTime).TotalHours;
            double rate = 0.0;    
            if (totalHours <= 1)
            {
                rate = 5;
                return 5;
            }

            if(totalHours <= 2)
            {
                rate = 10.00;
                return Math.Round(totalHours * rate);
            }

            if(totalHours <= 3)
            {
                rate = 15.00;
                return Math.Round(totalHours * rate);
            }
            double totalDays = Math.Round(patronTimeSpend.ExitDateTime.Subtract(patronTimeSpend.EntryDateTime).TotalDays);
            if(totalDays <= 1)
            {
                totalDays = 1;
            }

            rate = 20;
            return Math.Round(totalDays * rate);

        }
    }
}
