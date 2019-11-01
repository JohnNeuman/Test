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
            dayCount--;
            if (!(weekEnds is null))
            {
                while (dayCount > 0)
                {
                    isWeekEnd = false;
                    for (int i = weekInterval; i < weekEnds.Length; i++)
                    {
                        if ((!isWeekEnd) && (weekEnds[i].StartDate <= currDate) && (weekEnds[i].EndDate >= currDate))
                        {
                            isWeekEnd = true;
                            weekInterval = i;
                            currDate = currDate.AddDays(1);
                        }
                    }
                    if (!isWeekEnd)
                    {
                        dayCount--;
                        currDate = currDate.AddDays(1);
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
