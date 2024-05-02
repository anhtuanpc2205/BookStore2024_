using BookStore2024.ViewModels;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BookStore2024.ViewComponents
{
    public class UserLoginViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var login = new LoginVM();
            
            return View(login);
        }
    }
}
