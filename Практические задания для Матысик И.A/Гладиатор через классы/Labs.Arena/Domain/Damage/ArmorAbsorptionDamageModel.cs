using System;

namespace Labs.Arena.Domain.Damage
{
    /// <summary>
    /// Модель «поглощения бронёй»: четверть силы удара разрушает броню, а оставшаяся
    /// после этого броня вычитается из силы удара — разность становится уроном по здоровью.
    /// </summary>
    public sealed class ArmorAbsorptionDamageModel : IDamageModel
    {
        private const double ArmorErosionRatio = 0.25;
        private const int VitalsDigits = 1;

        public StrikeResult Resolve(double force, double armor, double health)
        {
            double erosion = force * ArmorErosionRatio;
            double armorLeft = armor - erosion >= 0
                ? Math.Round(armor - erosion, VitalsDigits)
                : 0;

            double healthLoss = force - armorLeft;

            return health - healthLoss >= 0
                ? new StrikeResult(armorLeft, Math.Round(health - healthLoss, VitalsDigits), false)
                : new StrikeResult(armorLeft, 0, true);
        }
    }
}
