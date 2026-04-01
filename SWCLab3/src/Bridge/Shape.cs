namespace SWCLab3.src.Bridge;

public abstract class Shape
{
    public int X { get; set; } 
    public int Y { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public IRenderer Renderer { get; set; }

    protected Shape(int x, int y, int width, int height, IRenderer renderer)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
        Renderer = renderer;
    }

    public abstract void Draw();
}
