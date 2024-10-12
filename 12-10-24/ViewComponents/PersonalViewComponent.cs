using _12_10_24.Models;
using Microsoft.AspNetCore.Mvc;

namespace _12_10_24.ViewComponents
{
    public class PersonalViewComponent : ViewComponent
    {
        public string Invoke(User user)
        {
            return $"Name: {user.Name}, Age: {user.Age}";
        }
    }
}
