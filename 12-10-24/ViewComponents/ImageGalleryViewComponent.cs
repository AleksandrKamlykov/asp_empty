using Microsoft.AspNetCore.Mvc;
using _12_10_24.Models;

namespace _12_10_24.ViewComponents
{
    public class ImageGalleryViewComponent : ViewComponent
    {
        private readonly IWebHostEnvironment _env;

        public ImageGalleryViewComponent(IWebHostEnvironment env)
        {
            _env = env;
        }

        public IViewComponentResult Invoke()
        {
            var images = GetImagesFromDirectory();
            return View(images);
        }

        private List<Image> GetImagesFromDirectory()
        {
            var images = new List<Image>();
            var imagesPath = Path.Combine(_env.WebRootPath, "images");

            if (Directory.Exists(imagesPath))
            {
                var imageFiles = Directory.GetFiles(imagesPath);

                foreach (var imageFile in imageFiles)
                {
                    var fileName = Path.GetFileName(imageFile);
                    images.Add(new Image
                    {
                        Title = Path.GetFileNameWithoutExtension(fileName),
                        Description = "Description for " + fileName,
                        FilePath = "/images/" + fileName
                    });
                }
            }

            return images;
        }
    }
}
