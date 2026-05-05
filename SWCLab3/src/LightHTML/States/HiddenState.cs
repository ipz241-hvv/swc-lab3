using SWCLab3.src.LightHTML.Interfaces;

namespace SWCLab3.src.LightHTML.States;

public class HiddenState : INodeState
{
    public string Render(LightElementNode context) => "";
}