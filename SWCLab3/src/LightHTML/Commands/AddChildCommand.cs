using SWCLab3.src.LightHTML.Interfaces;

namespace SWCLab3.src.LightHTML.Commands;

public class AddChildCommand : ICommand
{
    private readonly LightElementNode _container;
    private readonly LightNode _node;

    public AddChildCommand(LightElementNode container, LightNode node)
    {
        _container = container;
        _node = node;
    }

    public void Execute() => _container.AddChild(_node);

    public void Undo()
    {
        _container.Children.Remove(_node);
        Console.WriteLine($"Undo: Node removed from <{_container.TagName}>.");
    }
}