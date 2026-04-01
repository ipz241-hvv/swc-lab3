namespace SWCLab3.src.Flyweight;

public class LightElementType
{
    public string TagName { get; private set; }
    public string DisplayType { get; private set; }
    public string ClosingType { get; private set; }

    public LightElementType(string tagName, string displayType, string closingType)
    {
        TagName = tagName;
        DisplayType = displayType;
        ClosingType = closingType;
    }
}
