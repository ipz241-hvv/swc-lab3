using SWCLab3.src.LightHTML.Interfaces;

namespace SWCLab3.src.LightHTML;

public abstract class LightNode
{
    public abstract string OuterHTML { get; }
    public abstract string InnerHTML { get; }
    public virtual List<LightNode> Children => new();

    public virtual void OnCreated() { }
    public virtual void OnChildAdded(LightNode child) { }
    public virtual void OnStylesApplied()
    {
        Console.WriteLine("Styles are being processed...");
    }

    public abstract void Accept(ILightVisitor visitor);
}