using Microsoft.AspNetCore.Mvc;

namespace _12_10_24.ViewComponents
{
    public class UserListQueryViewComponent:ViewComponent
    {
        List<string> users = new List<string>
            {
                "Alice", "Bob", "Charlie"
            };
        public IViewComponentResult Invoke()
        {
            int numbers =  users.Count;
            if (Request.Query.ContainsKey("numbers"))
            {
                int.TryParse(Request.Query["numbers"], out numbers);
            }


            ViewBag.Users = users.Take(numbers);
            ViewData["Header"] = "UserQueryList";
            return View();
        }
    }
}
