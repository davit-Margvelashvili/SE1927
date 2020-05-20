using Shooter.Core.Abstractions;

namespace Shooter.Core.Implementations
{
    public class Player : IPlayer, IPilot, ITankDriver
    {
        public string Name { get; set; } = "Player";
        public double Health { get; private set; } = 100;
        public decimal Money { get; set; } = 800;
        public Weapon Weapon { get; set; }
        public bool IsAlive => Health > 0;

        public bool BuyWeapon(Weapon weapon)
        {
            if (Money < weapon.Price)
                return false;
            Money -= weapon.Price;
            Weapon = weapon;
            return true;
        }

        public double Shoot()
        {
            if (Weapon.BulletsLeft == 0)
                Weapon.Reload();
            return Weapon.Shoot();
        }

        public void Reload()
        {
            Weapon.Reload();
        }

        public void TakeDamage(double damage)
        {
            if (damage >= Health)
                Health = 0;
            else
                Health -= damage;
        }

        void IPilot.Fly()
        {
            // Change Coordinates
        }

        void IPilot.ThrowBombs()
        {
            Money -= 10;
        }

        double ITankDriver.Shoot()
        {
            Money -= 15;
            return 100;
        }

        void ITankDriver.Drive()
        {
            throw new System.NotImplementedException();
        }

        double ITankDriver.ShootMissile()
        {
            throw new System.NotImplementedException();
        }
    }
}