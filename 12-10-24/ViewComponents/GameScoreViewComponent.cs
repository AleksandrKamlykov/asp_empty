using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Text;

namespace _12_10_24.ViewComponents
{

    public record GameScore(int Score, string Name);
    public class GameScoreViewComponent : ViewComponent
    {
        public List<GameScore> Scores = new List<GameScore>
        {
            new GameScore(10, "Alice"),
            new GameScore(20, "Bob"),
            new GameScore(30, "Charlie")
        };
        public IViewComponentResult Invoke()
        {

            var res = new StringBuilder();
            res.Append("<ul>");
            foreach (var score in Scores)
            {
                res.Append($"<li>{score.Name}: {score.Score}</li>");
            }
            res.Append("</ul>");

            return new HtmlContentViewComponentResult(new HtmlString(res.ToString()));
        }
    }
}
