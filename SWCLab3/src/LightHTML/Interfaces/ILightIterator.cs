namespace SWCLab3.src.LightHTML.Interfaces;

using SWCLab3.src.LightHTML;

public interface ILightIterator
{
    bool HasNext();
    LightNode Next();
}