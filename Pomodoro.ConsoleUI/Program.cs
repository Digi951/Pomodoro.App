using Pomodoro.ConsoleUI.Configuration;
using Pomodoro.ConsoleUI.Enums;
using Pomodoro.ConsoleUI.Extensions;
using Pomodoro.ConsoleUI.Jobs;

ArgumentProvider argsProvider = new(args);

var test = argsProvider.WorkTimeMinutes.MinutesToMilliseconds<Double>();
Int32 WorkTime = (Int32)test;
Int32 shortBreakTime = (Int32)argsProvider.ShortBreakTimeMinutes.MinutesToMilliseconds<Double>();
Int32 longBreakTime = (Int32)argsProvider.LongBreakTimeMinutes.MinutesToMilliseconds<Double>();
Int32 intervalls = (Int32)argsProvider.Intervals;

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
