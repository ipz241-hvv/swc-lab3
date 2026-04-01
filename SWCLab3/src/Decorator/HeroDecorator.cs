namespace SWCLab3.src.Decorator;

internal class HeroDecorator : IHero
{
    protected IHero Hero { get; set; }
    
    public virtual string Name => Hero.Name;

    public virtual int Health => Hero.Health;

    public virtual int AttackPower => Hero.AttackPower;

    public virtual int Defense => Hero.Defense;

    public virtual string GetFullDescription()
    {
        return Hero.GetFullDescription();
    }

    public virtual void TakeDamage(int damage)
    {
        Hero.TakeDamage(damage);
    }

    public HeroDecorator(IHero hero)
    {
        Hero = hero; 
    }
}
