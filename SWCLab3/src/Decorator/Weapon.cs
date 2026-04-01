using SWCLab3.src.Decorator;

internal class Weapon : HeroDecorator
{
    public Weapon(IHero hero) : base(hero) { }

    override public int AttackPower => Hero.AttackPower + 5;

    public override string GetFullDescription() => $"{Name} (HP: {Health}, ATK: {AttackPower}, DEF: {Defense})";
}