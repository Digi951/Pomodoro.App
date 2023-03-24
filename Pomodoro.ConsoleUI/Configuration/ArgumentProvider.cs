using CommandLine;

namespace Pomodoro.ConsoleUI.Configuration;

internal class ArgumentProvider
{
    private readonly String[] _args;
    private readonly Parser _parser;
    private CommandLineOptions _options = new();

    public ArgumentProvider(String[] args)
    {
        _args = args;
        _parser = new Parser(config => config.HelpWriter = Console.Out);
        ReadArguments();
    }

    public Int32 WorkTimeMinutes { get; private set; }
    public Int32 ShortBreakTimeMinutes { get; private set; }
    public Int32 LongBreakTimeMinutes { get; private set; }
    public Int32 Intervals { get; private set; }

    private void ReadArguments()
    {
        var result = _parser.ParseArguments<CommandLineOptions>(_args);

        result.WithParsed(o =>
        {
            WorkTimeMinutes = o.WorkTimeMinutes;
            ShortBreakTimeMinutes = o.ShortBreakTimeMinutes;
            LongBreakTimeMinutes = o.LongBreakTimeMinutes;
            Intervals = o.Intervals;
            _options = o;
        });

        result.WithNotParsed(errors =>
        {
            Console.WriteLine("Fehler bei der Verarbeitung der Argumente:");
            Console.WriteLine($"{String.Join(Environment.NewLine, errors)}");
        });

        // If the --help option was used, wait for a key press and exit the program.
        if (_args.Length > 0 && _args.First() == "--help")
        {
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
