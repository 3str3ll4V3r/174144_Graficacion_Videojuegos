using System.Drawing;

namespace ReadObj
{
    public class Triangle
    {
        public int A { get; }
        public int B { get; }
        public int C { get; }
        public Color color;

        public Triangle(int a, int b, int c, Color color)
        {
            A = a;
            B = b;
            C = c;
            this.color = color;

        }

    }
}
