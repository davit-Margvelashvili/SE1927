using Shooter.Core.Abstractions;

namespace Shooter.Core.Implementations.Weapons
{
    public class ShotGun : Weapon
    {
        public override decimal Price => 1200;
        public override int Accuracy => 20;
        public override double Damage => 500;
        public override ushort MaxBullets => 7;

        public ShotGun() : base(7)
        {
        }
    }
}