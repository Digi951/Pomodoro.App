using Pomodoro.ConsoleUI.Configuration;
using Pomodoro.ConsoleUI.Enums;
using Pomodoro.ConsoleUI.Extensions;
using Pomodoro.ConsoleUI.Jobs;

ArgumentProvider argsProvider = new(args);

Int32 WorkTime = argsProvider.WorkTimeMinutes.MinutesToMilliseconds<Int32>();
Int32 shortBreakTime = argsProvider.ShortBreakTimeMinutes.MinutesToMilliseconds<Int32>();
Int32 longBreakTime = argsProvider.LongBreakTimeMinutes.MinutesToMilliseconds<Int32>();
Int32 intervalls = argsProvider.Intervals;

Int32 intervalCounter = 0;

while (true)
{
    PhaseManager.StartPhase(PhaseKind.Work, WorkTime, true);
    intervalCounter++;

    if (intervalCounter == intervalls) // Falls eine lange Pause eingelegt werden soll
    {
        intervalCounter = 0;
        PhaseManager.StartPhase(PhaseKind.LongBreak, longBreakTime, false);
    }
    else
    {
        PhaseManager.StartPhase(PhaseKind.ShortBreak, shortBreakTime, false);
    }
}
