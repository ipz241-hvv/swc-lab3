using SWCLab3.src.Decorator;

internal class Artefact : HeroDecorator
{
    public Artefact(IHero hero) : base(hero) { }

    override public int Health => Hero.Health + 10;

    public override string GetFullDescription() => $"{Name} (HP: {Health}, ATK: {AttackPower}, DEF: {Defense})";
}

