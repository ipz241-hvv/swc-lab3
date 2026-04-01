using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCLab3.src.Bridge;

public class Square : Shape
{
    public Square(int x, int y, int size, IRenderer renderer)
        : base(x, y, size, size, renderer) { }

    public override void Draw()
    {
        Renderer.RenderSquare(X, Y, Height);
    }
}