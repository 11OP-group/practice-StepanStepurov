namespace Labs.Common.Randomness
{
    /// <summary>
    /// Источник случайности. Выделен в интерфейс, чтобы сделать недетерминированную
    /// логику воспроизводимой в тестах.
    /// </summary>
    public interface IRandomSource
    {
        /// <summary>Целое в диапазоне [minInclusive, maxExclusive).</summary>
        int NextInt(int minInclusive, int maxExclusive);

        /// <summary>Вещественное в диапазоне [0.0, 1.0).</summary>
        double NextUnit();
    }
}
