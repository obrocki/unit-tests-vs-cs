namespace BlazingApp.Server.Services
{
    public interface IDateTimeProvider
    {
        DateTime GetNow();
    }

    public class DateTimeProvider : IDateTimeProvider
    { 
        public DateTime GetNow() => DateTime.Now;
    }
}