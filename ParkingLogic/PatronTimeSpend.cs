using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLogic
{
    public class PatronTimeSpend
    {
        internal DateTime EntryDateTime { get; set; }
        internal DateTime ExitDateTime { get; set; }

        public PatronTimeSpend(DateTime entryDate, DateTime exitDate)
        {
            if(entryDate.Subtract(exitDate).TotalMilliseconds > 0)
            {
                throw new InvalidOperationException();
            }
            EntryDateTime = entryDate;
            ExitDateTime = exitDate;
        }

        public bool IsSameDay()
        {
            DateTime dtEn = EntryDateTime.Date;
            DateTime dtEx = ExitDateTime.Date;

            if (dtEn.Equals(dtEx))
            {
                return true;
            }
            return false;
        }

        public bool IsEntryWeekday()
        {
            if((EntryDateTime.DayOfWeek == DayOfWeek.Saturday) || (EntryDateTime.DayOfWeek == DayOfWeek.Sunday))
            {
                return false;
            }
            return true;
        }

        public bool IsExitWeekday()
        {
            if ((ExitDateTime.DayOfWeek == DayOfWeek.Saturday) || (ExitDateTime.DayOfWeek == DayOfWeek.Sunday))
            {
                return false;
            }
            return true;
        }

        public bool IsEntryAndExitGreaterThanOneDay()
        {
            if(ExitDateTime.Subtract(EntryDateTime).TotalDays > 1)
            {
                return true;
            }
            return false;
        }
    }
}
