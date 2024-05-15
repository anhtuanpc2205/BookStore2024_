using BookStore2024.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore2024.ViewComponents
{
    public class AdminRevenueViewComponent : ViewComponent
    {
        private readonly BookStoreContext DBContext;
        public AdminRevenueViewComponent(BookStoreContext DatabaseContext) => DBContext = DatabaseContext;

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

        public IViewComponentResult Invoke()
        {
            //////////////////////////////day///////////////////////////////////////////////
            float todayRevenue = DBContext.ViewOrderDetails
                                .Where(od => od.OrderDate == today)
                                       .Sum(od => (float?)od.TotalAmount) ?? 0;

            float yesterdayRevenue = DBContext.ViewOrderDetails
                                .Where(od => od.OrderDate == yesterday)
                                       .Sum(od => (float?)od.TotalAmount) ?? 0;
            float dayRevenueIncrease = 0;
            if(yesterdayRevenue != 0)
            {
                dayRevenueIncrease = ((todayRevenue - yesterdayRevenue) / yesterdayRevenue)*100;
            }
            else { dayRevenueIncrease = 100; }
            //////////////////////////////month/////////////////////////////////////////////

            float thisMonthRevenue = DBContext.ViewOrderDetails
                               .Where(od => od.OrderDate >= firstDayOfMonth && od.OrderDate < firstDayOfNextMonth)
                               .Sum(od => (float?)od.TotalAmount) ?? 0;

            float lastMonthRevenue = DBContext.ViewOrderDetails
                               .Where(od => od.OrderDate >= firstDayOfLastMonth && od.OrderDate < firstDayOfMonth)
                               .Sum(od => (float?)od.TotalAmount) ?? 0;

            float monthRevenueIncrease = 0;
            if(lastMonthRevenue != 0)
            {
                monthRevenueIncrease = ((thisMonthRevenue - lastMonthRevenue) / lastMonthRevenue) * 100;
            }
            else { monthRevenueIncrease = 100; }
            //////////////////////////////year////////////////////////////////////////////

            float thisYearRevenue = DBContext.ViewOrderDetails
                               .Where(od => od.OrderDate >= firstDayOfYear && od.OrderDate < firstDayOfNextYear)
                               .Sum(od => (float?)od.TotalAmount) ?? 0;
            float lastYearRevenue = DBContext.ViewOrderDetails
                               .Where(od => od.OrderDate >= firstDayOfLastYear && od.OrderDate < firstDayOfYear)
                               .Sum(od => (float?)od.TotalAmount) ?? 0;

            float yearRevenueIncrease = 0;
            if (lastYearRevenue != 0)
            {
                yearRevenueIncrease = ((thisYearRevenue - lastYearRevenue) / lastYearRevenue) * 100;
            }
            else { yearRevenueIncrease = 100; }


            //thisMonthRevenue = 55555;
            ViewBag.todayRevenue = todayRevenue;
            ViewBag.thisMonthRevenue = thisMonthRevenue;
            ViewBag.thisYearRevenue = thisYearRevenue;
            ViewBag.dayRevenueIncrease = dayRevenueIncrease;
            ViewBag.monthRevenueIncrease = monthRevenueIncrease;
            ViewBag.yearRevenueIncrease = yearRevenueIncrease;

            return View();
        }
    }
}
