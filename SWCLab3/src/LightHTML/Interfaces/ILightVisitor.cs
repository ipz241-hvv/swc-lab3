namespace SWCLab3.src.LightHTML.Interfaces;

public interface ILightVisitor
{
    void VisitElement(LightElementNode element);
    void VisitText(LightTextNode text);
}