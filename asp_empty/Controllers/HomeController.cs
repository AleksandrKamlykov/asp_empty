using asp_empty.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace asp_empty.Controllers
{
    public class HomeController : Controller
    {
        private static readonly List<Question> Questions = new List<Question>
        {
            new Question { Id = 1, Text = "What is the capital of Great Britan?", Answers = new List<string> { "Berlin", "Madrid", "London", "Rome" }, CorrectAnswerIndex = 2 },
            new Question { Id = 2, Text = "What is 2 + 2?", Answers = new List<string> { "3", "4", "5", "6" }, CorrectAnswerIndex = 1 },
        };

        public IActionResult Index(int questionIndex = 0)
        {
            if (questionIndex >= Questions.Count)
            {
                return RedirectToAction("Result");
            }

            ViewBag.QuestionIndex = questionIndex;
            return View(Questions[questionIndex]);
        }

        [HttpPost]
        public IActionResult SubmitAnswer(int questionIndex, int selectedAnswer)
        {
            if (questionIndex < Questions.Count)
            {
                var question = Questions[questionIndex];
                if (selectedAnswer == question.CorrectAnswerIndex)
                {
                    TempData["Score"] = (int)(TempData["Score"] ?? 0) + 1;
                }
            }

            return RedirectToAction("Index", new { questionIndex = questionIndex + 1 });
        }

        public IActionResult Result()
        {
            ViewBag.Score = TempData["Score"] ?? 0;
            ViewBag.TotalQuestions = Questions.Count;
            return View();
        }
    }
}
