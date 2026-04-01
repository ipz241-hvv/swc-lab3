namespace SWCLab3.src.Bridge;

public class Circle : Shape
{
    public int Radius => Width / 2;

    public Circle(int x, int y, int diameter, IRenderer renderer)
        : base(x, y, diameter, diameter, renderer) { }

    public override void Draw()
    {
        Renderer.RenderCircle(X, Y, Radius);
    }
}