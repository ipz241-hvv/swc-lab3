namespace SWCLab3.src.Bridge;

public class RasterRenderer : IRenderer
{
    public void RenderCircle(int x, int y, int radius)
    {
        Console.WriteLine($"Drawing Circle as pixels at ({x},{y}) with radius {radius}");
    }

    public void RenderSquare(int x, int y, int size) 
    {
        Console.WriteLine($"Drawing Square as pixels at ({x},{y}) with side {size}");
    }

    public void RenderTriangle(int x, int y, int w, int h)
    {
        Console.WriteLine($"Drawing Triangle as pixels at ({x},{y})");
    }
}
