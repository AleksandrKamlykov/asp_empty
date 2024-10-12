using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace _12_10_24.ViewComponents
{
    //public class TimerViewComponent
    //{
    //    public string Invoke()
    //    {
    //        return DateTime.Now.ToString("HH:mm:ss");
    //    }
    //}
    public class TimerViewComponent: ViewComponent
    {
        //public IViewComponentResult Invoke(bool includeSeconds)
        //{

        //    if (includeSeconds)
        //        return Content(DateTime.Now.ToString("HH:mm:ss"));


        //    Content(DateTime.Now.ToString("HH:mm"));

        //}
        public IViewComponentResult Invoke(bool includeSeconds)
        {

            if (includeSeconds)
                return new HtmlContentViewComponentResult(new HtmlString($"<p>{DateTime.Now.ToString("HH:mm:ss")}</p>"));


            return new HtmlContentViewComponentResult(new HtmlString($"<p>{DateTime.Now.ToString("HH:mm")}</p>"));


        }
    }
}
