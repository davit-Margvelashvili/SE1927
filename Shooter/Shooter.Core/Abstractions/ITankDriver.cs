namespace Shooter.Core.Abstractions
{
    public interface ITankDriver
    {
        double Shoot();

        void Drive();

        double ShootMissile();
    }
}