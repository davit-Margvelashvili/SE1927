namespace Shooter.Core
{
    public interface IPlayer
    {
        bool BuyWeapon(Weapon weapon);

        double Shoot();

        void Reload();

        void TakeDamage(double damage);

        bool IsAlive { get; }
    }
}