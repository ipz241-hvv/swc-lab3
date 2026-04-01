namespace SWCLab3.src.Bridge;

public interface IRenderer
{
    void RenderCircle(int x, int y, int radius);
    void RenderSquare(int x, int y, int size);
    void RenderTriangle(int x, int y, int width, int height);
}
