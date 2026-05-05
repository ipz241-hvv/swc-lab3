namespace SWCLab3.src.LightHTML;

public class LightElementNode : LightNode
{
    private readonly LightElementType _type;
    private readonly List<LightNode> _children = new();
    public List<string> Classes { get; }

    public override List<LightNode> Children => _children;
    public string TagName => _type.TagName;

    public LightElementNode(string tagName, string displayType, string closingType, List<string>? classes = null)
    {
        _type = LightElementFactory.GetType(tagName, displayType, closingType);
        Classes = classes ?? new List<string>();
        OnCreated();
    }

    public void AddChild(LightNode node)
    {
        if (_type.ClosingType == "single")
            throw new InvalidOperationException($"Тег <{_type.TagName}/> є одиничним і не може мати дочірніх вузлів.");

        _children.Add(node);
        OnChildAdded(node);
    }

    public override void OnCreated()
    {
        Console.WriteLine($"Element <{_type.TagName}> was created.");
    }

    public override void OnChildAdded(LightNode child)
    {
        Console.WriteLine($"Node added to <{_type.TagName}>.");
    }

    public override void OnStylesApplied()
    {
        if (Classes.Any())
        {
            Console.WriteLine($"Applying styles for classes: {string.Join(", ", Classes)}");
        }
        else
        {
            Console.WriteLine($"No classes to apply for <{TagName}>");
        }
    }

    public override string InnerHTML => string.Join("", _children.Select(child => child.OuterHTML));

    public override string OuterHTML
    {
        get
        {
            OnStylesApplied();

            string classAttr = Classes.Any() ? $" class=\"{string.Join(" ", Classes)}\"" : "";

            if (_type.ClosingType == "single")
                return $"<{_type.TagName}{classAttr} />";

            return $"<{_type.TagName}{classAttr}>{InnerHTML}</{_type.TagName}>";
        }
    }
}