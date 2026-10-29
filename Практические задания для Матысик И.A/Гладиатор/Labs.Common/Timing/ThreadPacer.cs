using System;
using System.Threading;

namespace Labs.Common.Timing
{
    /// <summary>Реальная пауза, блокирующая текущий поток.</summary>
    public sealed class ThreadPacer : IPacer
    {
        public void Wait(TimeSpan duration) => Thread.Sleep(duration);
    }
}
