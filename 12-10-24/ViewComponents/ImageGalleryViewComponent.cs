using Microsoft.AspNetCore.Mvc;
using _12_10_24.Models;

namespace _12_10_24.ViewComponents
{
    public class ImageGalleryViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var images = new List<Image>
            {
                new Image { Title = "Surface Abstract 1", Description = "Description 1", FilePath = "/images/Surface Abstract_1.png" },
                new Image { Title = "Surface Abstract 2", Description = "Description 2", FilePath = "/images/Surface Abstract_2.png" },
                new Image { Title = "Surface Abstract 3", Description = "Description 3", FilePath = "/images/Surface Abstract_3.png" },
                new Image { Title = "Surface Abstract 3", Description = "Description 3", FilePath = "/images/Surface Abstract_4.png" }

            };

            return View(images);
        }
    }
}
