using SWCLab3.src.LightHTML.Interfaces;

namespace SWCLab3.src.LightHTML.Visitors;

public class ElementCounterVisitor : ILightVisitor
{
    public int ElementCount { get; private set; }
    public int TextCount { get; private set; }

    public void VisitElement(LightElementNode element) => ElementCount++;
    public void VisitText(LightTextNode text) => TextCount++;
}