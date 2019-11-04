using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {
            DateTime currDate = startDate;
            int weekInterval = 0;
            bool isWeekEnd;
            isWeekEnd = false;
            if (!(weekEnds is null))
            {
                for (int i = 0; i < weekEnds.Length; i++)
                {
                    if ((!isWeekEnd) && (weekEnds[i].StartDate <= startDate) && (weekEnds[i].EndDate >= startDate))
                    {
                        isWeekEnd = true;
                    }
                }    
            }
            if (!isWeekEnd)
            {
                dayCount--;
            }

            if (!(weekEnds is null))
            {
                while (dayCount > 0)
                {
                    currDate = currDate.AddDays(1);
                    isWeekEnd = false;
                    for (int i = weekInterval; i < weekEnds.Length; i++)
                    {
                        if ((!isWeekEnd) && (weekEnds[i].StartDate <= currDate) && (weekEnds[i].EndDate >= currDate))
                        {
                            isWeekEnd = true;
                            weekInterval = i;
                        }
                    }
                    if (!isWeekEnd)
                    {
                        dayCount--;
                    }
                }
            }
            else
            {
                if (dayCount > 0) currDate = currDate.AddDays(dayCount);
            }
            return currDate;
        }
    }
}
