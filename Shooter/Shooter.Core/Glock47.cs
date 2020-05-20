namespace Shooter.Core
{
    public class Glock47 : Weapon
    {
        public override decimal Price => 800.00m;
        public override int Accuracy => 20;
        public override double Damage => 300;
        public override ushort MaxBullets => 20;

        public Glock47() : base(20)
        {
        }
    }
}