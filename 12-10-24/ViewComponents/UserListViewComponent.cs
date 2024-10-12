using Microsoft.AspNetCore.Mvc;

namespace _12_10_24.ViewComponents
{
    public class UserListViewComponent : ViewComponent
    {
        List<string> users = new List<string>
        {
            "Alice", "Bob", "Charlie"
        };
        public IViewComponentResult Invoke()
        {
            return View(users);
        }
    }
}
