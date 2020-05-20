using System;

namespace Shooter.Core.Abstractions
{
    public abstract class Weapon
    {
        protected static readonly Random Random = new Random();

        public abstract decimal Price { get; }
        public abstract int Accuracy { get; }
        public abstract double Damage { get; }
        public abstract ushort MaxBullets { get; }
        public ushort BulletsLeft { get; set; }

        protected Weapon(ushort bulletsLeft)
        {
            BulletsLeft = bulletsLeft;
        }

        public virtual double Shoot()
        {
            if (BulletsLeft == 0)
                return 0;

            // რაც მეტი სიზუსტე აქვს მით მეტი დაზიანება უნდა დააბრუნოს
            BulletsLeft--;
            return Damage / (100 - Random.Next(Accuracy));
        }

        public void Reload()
        {
            BulletsLeft = MaxBullets;
        }
    }
}