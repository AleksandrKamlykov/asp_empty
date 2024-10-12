using Microsoft.AspNetCore.Mvc;
using _12_10_24.Models;

namespace _12_10_24.ViewComponents
{
    public class TimerWidthDiViewComponent:ViewComponent
    {
        private readonly ITimerService _timerService;

        public TimerWidthDiViewComponent(ITimerService timerService)
        {
            _timerService = timerService;
        }

        public string Invoke()
        {
            return _timerService.GetTime();
        }
    }
}
