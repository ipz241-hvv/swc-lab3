using SWCLab3.src.LightHTML.Interfaces;

namespace SWCLab3.src.LightHTML;

public class LightTextNode : LightNode
{
    private readonly string _text;

    public LightTextNode(string text)
    {
        _text = text;
    }

    public override string OuterHTML => _text;
    public override string InnerHTML => _text;

    public override void Accept(ILightVisitor visitor) => visitor.VisitText(this);
}