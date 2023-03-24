using System.ComponentModel;

namespace Pomodoro.ConsoleUI.Enums;
public enum PhaseKind
{
    [Description("Arbeit")]
    Work,
    [Description("Kurze Pause")]
    ShortBreak,
    [Description("Lange Pause")]
    LongBreak
}
