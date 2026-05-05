namespace SWCLab3.src.LightHTML.Iterators;

using SWCLab3.src.LightHTML.Interfaces;

public class DepthFirstIterator : ILightIterator
{
    private readonly Stack<LightNode> _stack = new();

    public DepthFirstIterator(LightNode root)
    {
        _stack.Push(root);
    }

    public bool HasNext() => _stack.Count > 0;

    public LightNode Next()
    {
        var node = _stack.Pop();

        for (int i = node.Children.Count - 1; i >= 0; i--)
        {
            _stack.Push(node.Children[i]);
        }

        return node;
    }
}