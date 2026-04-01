namespace SWCLab3.src.Decorator;

internal class Armor : HeroDecorator
{
    public Armor(IHero hero) : base(hero) { }

    override public int Defense => Hero.Defense + 20;

    public override string GetFullDescription() => $"{Name} (HP: {Health}, ATK: {AttackPower}, DEF: {Defense})";
}
