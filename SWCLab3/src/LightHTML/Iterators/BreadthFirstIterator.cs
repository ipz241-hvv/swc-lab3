using SWCLab3.src.LightHTML.Interfaces;

namespace SWCLab3.src.LightHTML.Iterators;

public class BreadthFirstIterator : ILightIterator
{
    private readonly Queue<LightNode> _queue = new();

    public BreadthFirstIterator(LightNode root)
    {
        _queue.Enqueue(root);
    }

    public bool HasNext() => _queue.Count > 0;

    public LightNode Next()
    {
        var node = _queue.Dequeue();
        foreach (var child in node.Children)
        {
            _queue.Enqueue(child);
        }
        return node;
    }
}