using SWCLab3.src.Composite;

namespace SWCLab3.src.Flyweight;

public class LightElementNodeFlyweight : LightNode
{
    private readonly LightElementType _type;
    private readonly List<LightNode> _children = new();
    public List<string> Classes { get; }

    public int ChildrenCount => _children.Count;

    public LightElementNodeFlyweight(string tagName, string displayType, string closingType, List<string>? classes = null)
    {
        _type = LightElementFactory.GetType(tagName, displayType, closingType);
        Classes = classes ?? new List<string>();
    }

    public void AddChild(LightNode node)
    {
        if (_type.ClosingType == "single")
            throw new InvalidOperationException("Одиничні теги не можуть мати дітей.");
        _children.Add(node);
    }

    public override string InnerHTML => string.Join("", _children.Select(child => child.OuterHTML));

    public override string OuterHTML
    {
        get
        {
            string classAttr = Classes.Any() ? $" class=\"{string.Join(" ", Classes)}\"" : "";
            if (_type.ClosingType == "single") return $"<{_type.TagName}{classAttr} />";
            return $"<{_type.TagName}{classAttr}>{InnerHTML}</{_type.TagName}>";
        }
    }
}