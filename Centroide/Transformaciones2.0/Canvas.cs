using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Transformaciones2._0
{
   
    internal class Canvas
    {
        private Graphics g;
        private Bitmap bmp;

        public Canvas(Graphics graphics, Bitmap bitmap)
        {
            g = graphics;
            bmp = bitmap;
        }

        public void Render(Size size)
        {
            int w = bmp.Width;
            int h = bmp.Height;

            g.DrawLine(Pens.White, new Point(0, h / 2), new Point(w, h / 2));
            g.DrawLine(Pens.White, new Point(w / 2, 0), new Point(w / 2, h));

        }

        public void RenderFigura(Figura figura)
        {
            for (int i = 0; i < figura.vertices.Count; i++)
            {
                Point s = figura.vertices[i];
                Point e = figura.vertices[(i + 1) % figura.vertices.Count];
                g.DrawLine(Pens.Yellow, s, e);
            }
        }
        public void Clear()
        {
            g.Clear(Color.Black);
        }


    }

}
