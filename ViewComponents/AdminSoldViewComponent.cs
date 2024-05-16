using BookStore2024.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookStore2024.ViewComponents
{
    public class AdminSoldViewComponent : ViewComponent
    {
        private readonly BookStoreContext DBContext;
        public AdminSoldViewComponent(BookStoreContext DatabaseContext) => DBContext = DatabaseContext;

        static DateOnly today = DateOnly.FromDateTime(DateTime.Today);
        static DateOnly yesterday = DateOnly.FromDateTime(DateTime.Today.AddDays(-1));

        //month
        static DateOnly firstDayOfMonth = new DateOnly(today.Year, today.Month, 1);
        static DateOnly firstDayOfNextMonth = firstDayOfMonth.AddMonths(1);
        static DateOnly firstDayOfLastMonth = firstDayOfMonth.AddMonths(-1);

        //year
        static DateOnly firstDayOfYear = new DateOnly(today.Year, 1, 1);
        static DateOnly firstDayOfNextYear = firstDayOfMonth.AddYears(1);
        static DateOnly firstDayOfLastYear = firstDayOfMonth.AddYears(-1);

        static bool IstodaySoldIncrease = true;
        static bool IsthisMonthSoldIncrease = true;
        static bool ISyearSoldIncrease = true;
        public IViewComponentResult Invoke()
        {

            float todaySold = DBContext.ViewOrderDetails
                           .Where(od => od.OrderDate == today)
                           .Sum(od => (float?)od.Quantity) ?? 0;

            float yesterdaySold = DBContext.ViewOrderDetails
                                       .Where(od => od.OrderDate == yesterday)
                                       .Sum(od => (float?)od.Quantity) ?? 0;
            float daySoldIncrease = 0;
            if (yesterdaySold != 0)
            {
                daySoldIncrease = ((todaySold - yesterdaySold) / yesterdaySold) * 100;
            }
            else { daySoldIncrease = 100; }

            if (daySoldIncrease < 0) { IstodaySoldIncrease = false;  }

            //////////////////////////////month/////////////////////////////////////////////

            float thisMonthSold = DBContext.ViewOrderDetails
                               .Where(od => od.OrderDate >= firstDayOfMonth && od.OrderDate < firstDayOfNextMonth)
                               .Sum(od => (float?)od.Quantity) ?? 0;

            float lastMonthSold = DBContext.ViewOrderDetails
                               .Where(od => od.OrderDate >= firstDayOfLastMonth && od.OrderDate < firstDayOfMonth).Sum(od => (float?)od.Quantity) ?? 0;

            float monthSoldIncrease = 0;
            if (lastMonthSold != 0)
            {
                monthSoldIncrease = ((thisMonthSold - lastMonthSold) / lastMonthSold) * 100;
            }
            else { monthSoldIncrease = 100; }

            if(monthSoldIncrease < 0) { IsthisMonthSoldIncrease = false; }

            //////////////////////////////year////////////////////////////////////////////

            float thisYearSold = DBContext.ViewOrderDetails
                               .Where(od => od.OrderDate >= firstDayOfYear && od.OrderDate < firstDayOfNextYear)
                               .Sum(od => (float?)od.Quantity) ?? 0;

            float lastYearSold = DBContext.ViewOrderDetails
                               .Where(od => od.OrderDate >= firstDayOfLastYear && od.OrderDate < firstDayOfYear)
                               .Sum(od => (float?)od.Quantity) ?? 0;

            float yearSoldIncrease = 0;
            if (lastYearSold != 0)
            {
                yearSoldIncrease = ((thisYearSold - lastYearSold) / lastYearSold) * 100;
            }
            else { yearSoldIncrease = 100; }

            if(yearSoldIncrease < 0) { ISyearSoldIncrease = false; }

            ViewBag.todaySold = todaySold;
            ViewBag.thisMonthSold = thisMonthSold;
            ViewBag.thisYearSold = thisYearSold;
            ViewBag.daySoldIncrease = daySoldIncrease;
            ViewBag.monthSoldIncrease = monthSoldIncrease;
            ViewBag.yearSoldIncrease = yearSoldIncrease;
            
            ViewBag.IstodaySoldIncrease = IstodaySoldIncrease;
            ViewBag.IsthisMonthSoldIncrease = IsthisMonthSoldIncrease;
            ViewBag.ISyearSoldIncrease = ISyearSoldIncrease;

            return View();
        }
    }
}
