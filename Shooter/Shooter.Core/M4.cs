namespace Shooter.Core
{
    public class M4 : Weapon
    {
        public override decimal Price => 3200.00m;
        public override int Accuracy => 50;
        public override double Damage => 400;
        public override ushort MaxBullets => 30;

        public M4() : base(30)
        {
        }
    }
}