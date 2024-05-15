using BookStore2024.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore2024.ViewComponents
{
    public class AdminRevenueViewComponent : ViewComponent
    {
        private readonly BookStoreContext DBContext;
        public AdminRevenueViewComponent(BookStoreContext DatabaseContext) => DBContext = DatabaseContext;

        DateOnly today = DateOnly.FromDateTime(DateTime.Today);
        DateOnly yesterday = DateOnly.FromDateTime(DateTime.Today.AddDays(-1));

        public IViewComponentResult Invoke()
        {
            float todayRevenue = DBContext.ViewOrderDetails
                                .Where(od => od.OrderDate == today)
                                       .Sum(od => (float?)od.TotalAmount) ?? 0;
           
            ViewBag.todayRevenue = todayRevenue;

            DateTime now = DateTime.Now;
            DateOnly firstDayOfMonth = new DateOnly(now.Year, now.Month, 1);
            DateOnly firstDayOfNextMonth = firstDayOfMonth.AddMonths(1);
            
            float thisMonthRevenue = DBContext.ViewOrderDetails
                               .Where(od => od.OrderDate >= firstDayOfMonth && od.OrderDate < firstDayOfNextMonth)
                               .Sum(od => (float?)od.TotalAmount) ?? 0;

            ViewBag.thisMonthRevenue = thisMonthRevenue;
            return View();
        }
    }
}
