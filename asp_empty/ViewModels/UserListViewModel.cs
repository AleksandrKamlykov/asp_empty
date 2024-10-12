using asp_empty.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace asp_empty.ViewModels
{
    public class UserListViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public SelectList Companies { get; set; }
        public string Name { get; set; }
    }
}
