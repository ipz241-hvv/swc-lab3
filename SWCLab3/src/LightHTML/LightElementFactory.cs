namespace SWCLab3.src.LightHTML;

public static class LightElementFactory
{
    private static readonly Dictionary<(string, string, string), LightElementType> _types = new();

    public static LightElementType GetType(string tagName, string displayType, string closingType)
    {
        var key = (tagName, displayType, closingType);

        if (!_types.TryGetValue(key, out var type))
        {
            type = new LightElementType(tagName, displayType, closingType);
            _types[key] = type;
        }

        return type;
    }
}