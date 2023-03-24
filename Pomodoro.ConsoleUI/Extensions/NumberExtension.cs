namespace Pomodoro.ConsoleUI.Extensions
{
    internal static class NumberExtension
    {
        private static readonly long _convertNumber = 60000;

        public static T MillisecondsToMinutes<T>(this T value) where T : struct, IConvertible
        {
            long milliseconds = Convert.ToInt64(value);
            if (milliseconds > 3600000)
            {
                Console.WriteLine("Größere Zahlen werden nicht übernommen");
                return default;
            }
            long result = milliseconds / _convertNumber;
            return (T)Convert.ChangeType(result, typeof(T));
        }

        public static T MinutesToMilliseconds<T>(this T value) where T : struct, IConvertible
        {
            long minutes = Convert.ToInt64(value);
            if (minutes > 60000)
            {
                Console.WriteLine("Größere Zahlen werden nicht übernommen");
                return default;
            }
            long result = minutes * _convertNumber;
            return (T)Convert.ChangeType(result, typeof(T));
        }
    }
}
