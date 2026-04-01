namespace SWCLab3.src.Decorator;

public class Mage : IHero
{
    public string Name => "Маг";
    public int Health { get; private set; } = 80;
    public int AttackPower => 40;
    public int Defense => 5;

    public string GetFullDescription() => $"{Name} (HP: {Health}, ATK: {AttackPower}, DEF: {Defense})";

    public void TakeDamage(int damage)
    {
        int effectiveDamage = Math.Max(0, damage - Defense);
        Health -= effectiveDamage;
        Console.WriteLine($"{Name} отримав {effectiveDamage} шкоди. Залишилось HP: {Health}");
    }
}
