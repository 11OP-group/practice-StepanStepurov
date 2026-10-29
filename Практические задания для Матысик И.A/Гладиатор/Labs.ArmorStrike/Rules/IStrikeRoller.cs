namespace Labs.ArmorStrike.Rules
{
    /// <summary>Определяет силу удара, наносимого по бойцу с заданной бронёй.</summary>
    public interface IStrikeRoller
    {
        double Roll(double armor);
    }
}
