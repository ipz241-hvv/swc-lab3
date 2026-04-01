namespace SWCLab3.src.Bridge;

public class Triangle : Shape
{
    public Triangle(int x, int y, int width, int height, IRenderer renderer)
        : base(x, y, width, height, renderer) { }

    public override void Draw()
    {
        Renderer.RenderTriangle(X, Y, Width, Height);
    }
}