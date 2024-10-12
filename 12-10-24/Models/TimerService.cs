namespace _12_10_24.Models
{
    public interface ITimerService
    {
        public string GetTime();
    }
    public class TimerService:ITimerService
    {
        public string GetTime()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
