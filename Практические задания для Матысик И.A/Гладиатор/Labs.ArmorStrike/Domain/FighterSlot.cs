namespace Labs.ArmorStrike.Domain
{
    /// <summary>Позиция бойца в поединке с русскоязычными формами для вывода.</summary>
    public sealed class FighterSlot
    {
        public static readonly FighterSlot First = new FighterSlot("первого");

        public static readonly FighterSlot Second = new FighterSlot("второго");

        private FighterSlot(string genitive)
        {
            Genitive = genitive;
        }

        /// <summary>Форма родительного падежа («у первого», «брони второго»).</summary>
        public string Genitive { get; }
    }
}
