using SWCLab3.src.LightHTML.Interfaces;

namespace SWCLab3.src.LightHTML.States;

public class VisibleState : INodeState
{
    public string Render(LightElementNode context)
    {
        return context.RenderInternal();
    }
}