using System;

namespace Labs.Common.Timing
{
    /// <summary>Пауза-заглушка без ожидания (для тестов).</summary>
    public sealed class InstantPacer : IPacer
    {
        public void Wait(TimeSpan duration) { }
    }
}
