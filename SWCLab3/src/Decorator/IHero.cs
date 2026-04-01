namespace SWCLab3.src.Decorator;

public interface IHero
{
    string Name { get; }
    int Health { get; }
    int AttackPower { get; }
    int Defense { get; }
    string GetFullDescription();
    void TakeDamage(int damage);
}
