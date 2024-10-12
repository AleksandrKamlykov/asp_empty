using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Html;



namespace _12_10_24.ViewComponents
{
    public class HeaderViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string header = String.Empty;
            using (StreamReader reader = new StreamReader("Files/header.html"))
            {
                header = await reader.ReadToEndAsync();
            }

            return new HtmlContentViewComponentResult(new HtmlString(header));
        }
    }
}
