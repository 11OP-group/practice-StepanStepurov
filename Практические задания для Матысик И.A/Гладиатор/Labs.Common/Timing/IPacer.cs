using System;

namespace Labs.Common.Timing
{
    /// <summary>
    /// Абстракция пауз в сценарии: позволяет подменять реальное ожидание в тестах.
    /// </summary>
    public interface IPacer
    {
        void Wait(TimeSpan duration);
    }
}
