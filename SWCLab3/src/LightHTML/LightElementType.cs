namespace SWCLab3.src.LightHTML;

public class LightElementType
{
    public string TagName { get; }
    public string DisplayType { get; }
    public string ClosingType { get; }

    public LightElementType(string tagName, string displayType, string closingType)
    {
        TagName = tagName;
        DisplayType = displayType;
        ClosingType = closingType;
    }
}