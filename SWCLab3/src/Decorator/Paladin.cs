namespace SWCLab3.src.Decorator;

public class Paladin : IHero
{
    public string Name => "Паладин";
    public int Health { get; private set; } = 120;
    public int AttackPower => 25;
    public int Defense => 20;

    public string GetFullDescription() => $"{Name} (HP: {Health}, ATK: {AttackPower}, DEF: {Defense})";

    public void TakeDamage(int damage)
    {
        int effectiveDamage = Math.Max(0, damage - Defense);
        Health -= effectiveDamage;
        Console.WriteLine($"{Name} отримав {effectiveDamage} шкоди. Залишилось HP: {Health}");
    }
}
