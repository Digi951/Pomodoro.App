using Pomodoro.ConsoleUI.Enums;
using Pomodoro.ConsoleUI.Extensions;
using System.Diagnostics;

namespace Pomodoro.ConsoleUI.Jobs;
public static class PhaseManager
{
    public static void StartPhase(PhaseKind phase, Int32 duration, Boolean canPause)
    {
        DateTime now = DateTime.Now;
        TimeSpan startTime = now.TimeOfDay;
        DateTime offsetTime = now.AddMilliseconds(duration);
        String endTime = offsetTime.ToString("HH:mm");

        Console.ForegroundColor = phase switch
        {
            PhaseKind.Work => ConsoleColor.DarkBlue,
            PhaseKind.ShortBreak => ConsoleColor.DarkGreen,
            PhaseKind.LongBreak => ConsoleColor.DarkRed,
            _ => Console.ForegroundColor
        };

        Console.Write($"{phase.GetDescription()}");
        Console.ResetColor();

        Console.Write($" um {startTime:hh\\:mm}h für {duration / 1000 / 60} Minuten gestartet! {phase.GetDescription()} wird um");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write($" {endTime:hh\\:mm}h ");
        Console.ResetColor();
        Console.Write("beendet.\n");

        Console.ResetColor();

        var handle = Process.GetCurrentProcess().MainWindowHandle;

        UInt64 completed = 0;
        UInt64 total = (UInt64)duration;

        RefreshProgressBar(phase, canPause, ref offsetTime, ref endTime, ref completed, total);

        Console.WriteLine($"{phase.GetDescription()} beendet!\n");
        Console.Beep(); 
    }

    private static void RefreshProgressBar(PhaseKind phase, Boolean canPause, ref DateTime offsetTime, ref String endTime, ref UInt64 completed, UInt64 total)
    { 
        while (completed < total)
        {
            Int32 percent = (Int32)((double)completed / total * 100);
            Int32 completeBars = (Int32)((double)completed / total * 20);
            Int32 remainingBars = 20 - completeBars;

            Console.Write("\r"); 
            Console.Write(new String(' ', Console.WindowWidth - 1)); 
            Console.Write("\r");

            Console.Write($"[");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"{new String('=', completeBars)}");
            Console.ResetColor();
            Console.Write($"{new String('-', remainingBars)}] {percent}%\r");

            if (canPause && Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Spacebar)
            {
                Console.WriteLine($"{phase.GetDescription()} pausiert! Drücken Sie die Leertaste, um fortzufahren...");
                while (true)
                {
                    if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Spacebar)
                    {
                        Console.WriteLine($"{phase.GetDescription()} fortgesetzt!");

                        // Endzeit nach Pause berechnen und ausgeben
                        offsetTime = DateTime.Now.AddMilliseconds(total - completed);
                        endTime = offsetTime.ToString("HH:mm");
                        Console.Write($"Endzeit aktualisiert:");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write($" {endTime}h");
                        Console.ResetColor();
                        Console.WriteLine();
                        break;
                    }
                    Task.Delay(100);
                }
            }

            Task.Delay(500);
            completed += 500;
        }

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[====================] 100%");
        Console.ResetColor();
    }
}
