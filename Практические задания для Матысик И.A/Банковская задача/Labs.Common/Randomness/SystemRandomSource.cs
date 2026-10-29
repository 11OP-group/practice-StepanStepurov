using System;

namespace Labs.Common.Randomness
{
    /// <summary>
    /// Реализация на базе <see cref="Random"/>. Экземпляр не потокобезопасен;
    /// все вызывающие стороны приложения используют один общий экземпляр из одного потока.
    /// </summary>
    public sealed class SystemRandomSource : IRandomSource
    {
        private readonly Random _engine;

        public SystemRandomSource()
            : this(new Random())
        {
        }

        public SystemRandomSource(Random engine)
        {
            _engine = engine ?? throw new ArgumentNullException(nameof(engine));
        }

        public int NextInt(int minInclusive, int maxExclusive) => _engine.Next(minInclusive, maxExclusive);

        public double NextUnit() => _engine.NextDouble();
    }
}
