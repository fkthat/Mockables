using System.Globalization;

namespace FkThat.Mockables.Demo
{
    public class Foo
    {
        private readonly ISystemClock _clock;
        private readonly IGuidGen _guidGen;
        private readonly IRandom _random;
        private readonly IConsole _console;

        public Foo(ISystemClock clock, IGuidGen guidGen, IRandom random, IConsole console)
        {
            _clock = clock;
            _guidGen = guidGen;
            _random = random;
            _console = console;
        }

        public void Bar()
        {
            var stdout = _console.Out;
            stdout.WriteLine(_clock.UtcNow.ToString("G", CultureInfo.InvariantCulture));
            stdout.WriteLine(_guidGen.NewGuid());
            stdout.WriteLine(_random.Next(16));
        }
    }
}
