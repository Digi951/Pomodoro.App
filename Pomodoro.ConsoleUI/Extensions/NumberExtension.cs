namespace Pomodoro.ConsoleUI.Extensions
{
    internal static class NumberExtension
    {
        private static readonly Int64 _convertNumber = 60000;

        public static T MillisecondsToMinutes<T>(this T value) where T : struct, IConvertible
        {
            Int64 milliseconds = Convert.ToInt64(value);
            if (milliseconds > 3600000)
            {
                Console.WriteLine("Größere Zahlen werden nicht übernommen");
                return default;
            }
            Int64 result = milliseconds / _convertNumber;
            return (T)Convert.ChangeType(result, typeof(T));
        }

        public static T MinutesToMilliseconds<T>(this T value) where T : struct, IConvertible
        {
            Int64 minutes = Convert.ToInt64(value);
            if (minutes > 60000)
            {
                Console.WriteLine("Größere Zahlen werden nicht übernommen");
                return default;
            }
            Int64 result = minutes * _convertNumber;
            return (T)Convert.ChangeType(result, typeof(T));
        }
    }
}
