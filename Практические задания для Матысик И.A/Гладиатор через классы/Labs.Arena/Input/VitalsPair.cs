using System;

namespace Labs.Arena.Input
{
    /// <summary>Показатели двух бойцов, введённые за один проход диалога.</summary>
    public sealed class VitalsPair
    {
        public VitalsPair(FighterVitals first, FighterVitals second)
        {
            First = first ?? throw new ArgumentNullException(nameof(first));
            Second = second ?? throw new ArgumentNullException(nameof(second));
        }

        public FighterVitals First { get; }

        public FighterVitals Second { get; }
    }
}
