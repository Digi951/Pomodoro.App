using CommandLine;

namespace Pomodoro.ConsoleUI.Configuration;
internal class CommandLineOptions
{
    [Option(shortName: 'w', longName: "work", Required = false, Default = 25, HelpText = "Defines the worktime in minutes. Default value is 25.")]
    public double WorkTimeMinutes { get; set; }

    [Option('s', "short", Required = false, Default = 5, HelpText = "Defines the time for the short break in minutes. Default value is 5.")]
    public double ShortBreakTimeMinutes { get; set; }

    [Option('l', "long", Required = false, Default = 30, HelpText = "Defines the time for the long break in minutes. Default value is 30.")]
    public double LongBreakTimeMinutes { get; set; }

    [Option('i', "intervals", Required = false, Default = 6, HelpText = "Defines how many intervals run through before the long break. Default value is 6.")]
    public double Intervals { get; set; }
}
