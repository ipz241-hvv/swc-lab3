namespace SWCLab3.src.Composite;

public class LightElementNode : LightNode
{
    public string TagName { get; }
    public string DisplayType { get; }
    public string ClosingType { get; }
    public List<string> Classes { get; }

    private readonly List<LightNode> _children = new List<LightNode>();

    public int ChildrenCount => _children.Count;

    public LightElementNode(
        string tagName,
        string displayType,
        string closingType,
        List<string>? classes = null)
    {
        TagName = tagName;
        DisplayType = displayType;
        ClosingType = closingType;
        Classes = classes ?? new List<string>();
    }

    public void AddChild(LightNode node)
    {
        if (ClosingType == "single")
        {
            throw new InvalidOperationException("Single tags (like <img/>) cannot have children.");
        }
        _children.Add(node);
    }

    public override string InnerHTML => string.Join("", _children.Select(child => child.OuterHTML));

    public override string OuterHTML
    {
        get
        {
            string classAttr = Classes.Any()
                ? $" class=\"{string.Join(" ", Classes)}\""
                : "";

            if (ClosingType == "single")
            {
                return $"<{TagName}{classAttr} />";
            }

            return $"<{TagName}{classAttr}>{InnerHTML}</{TagName}>";
        }
    }
}