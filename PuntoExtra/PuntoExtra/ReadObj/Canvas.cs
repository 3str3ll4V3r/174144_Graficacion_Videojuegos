using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ReadObj

{
    public class Canvas
    {
        public Bitmap bitmap;
        private int _width;
        private int _height;
        private Byte[] _bits;
        int _pixelFormatSize, _stride;
        private const float ViewportSize = 1;
        private const float ProjectionPlaneZ = 1;

        public Canvas(Size size)
        {
            Init(size.Width, size.Height);
        }

        public void Init(int width, int height)
        {
            PixelFormat format;
            GCHandle handle;
            IntPtr bitPtr;
            int padding;
            format = PixelFormat.Format32bppRgb;
            _width = width;
            _height = height;
            _pixelFormatSize = Image.GetPixelFormatSize(format) / 8;
            _stride = width * _pixelFormatSize;
            padding = (_stride % 4);
            _stride += padding == 0 ? 0 : 4 - padding;
            _bits = new byte[_stride * height];
            handle = GCHandle.Alloc(bitmap, GCHandleType.Pinned);
            bitPtr = Marshal.UnsafeAddrOfPinnedArrayElement(_bits, 0);
            bitmap = new Bitmap(width, height, _stride, format, bitPtr);
            Graphics.FromImage(bitmap);
        }

        public void Render(Scene scene)
        {
            FastClear();
            foreach (var s in scene.Models)
            {
                RenderModel(s.Mesh, s.Transform.transform());
            }
        }
        
        
        public void setPixel(int x, int y, Color c)
        {
            long res = (x * _pixelFormatSize) + (y * _stride);

            _bits[res + 0] = c.B;// (byte)Blue;
            _bits[res + 1] = c.G;// (byte)Green;
            _bits[res + 2] = c.R;// (byte)Red;
            _bits[res + 3] = c.A;// (byte)Alpha;
        }

        public void DrawPixel(int x, int y, Color color)
        {
            x = _width / 2 + x;
            y = _height / 2 - y - 1;

            if (x < 0 || x >= _width || y < 0 || y >= _height)
            {
                return;
            }

            setPixel(x, y, color);
        }
        public void FastClear()
        {
            unsafe
            {
                BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
                int bytesPerPixel = Image.GetPixelFormatSize(bitmap.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;
                byte* PtrFirstPixel = (byte*)bitmapData.Scan0;

                Parallel.For(0, heightInPixels, y =>
                {
                    byte* bits = PtrFirstPixel + (y * bitmapData.Stride);
                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                    {
                        bits[x + 0] = 0;// (byte)oldBlue;
                        bits[x + 1] = 0;// (byte)oldGreen;
                        bits[x + 2] = 0;// (byte)oldRed;
                        bits[x + 3] = 0;// (byte)alpha;
                    }
                });
                bitmap.UnlockBits(bitmapData);
            }
        }

        void DrawLine(Vertex p0, Vertex p1, Color color)
        {
            var dx = p1.X - p0.X;
            var dy = p1.Y - p0.Y;

            if (Math.Abs(dx) > Math.Abs(dy))
            {
                // The line is horizontal-ish. Make sure it's left to right.
                if (dx < 0)
                {
                    (p0,p1) = (p1, p0);
                }

                // Compute the Y values and draw.
                var ys = Interpolate((int)p0.X, p0.Y, (int)p1.X, p1.Y);
                for (var x = (int)p0.X; x <= p1.X; x++)
                {
                    DrawPixel(x, (int)ys[(x - (int)p0.X)], color);
                }
            }
            else
            {
                // The line is vertical-ish. Make sure it's bottom to top.
                if (dy < 0)
                {
                    (p0,p1) = (p1, p0);
                }

                // Compute the X values and draw.
                var xs = Interpolate((int)p0.Y, p0.X, (int)p1.Y, p1.X);
                for (var y = (int)p0.Y; y <= p1.Y; y++)
                {
                    DrawPixel((int)xs[(y - (int)p0.Y)], y, color);
                }
            }
        }

        private void DrawWireFrameTriangle(Vertex p0, Vertex p1, Vertex p2, Color color)
        {
            DrawLine(p0, p1, color); 
            DrawLine(p1, p2, color);
            DrawLine(p2, p0, color);
        }

        private List<float> Interpolate(float i0, float d0, float i1, float d1)
        {
            List<float> values = new List<float>();
            if (Math.Abs(i0 - i1) < 0.1f)
            {
                values.Add(d0);
                return values;
            }
            float a = (d1 - d0) / (i1 - i0);
            float d = d0;
            for (int i = (int)i0; i <= i1; i++)
            {
                values.Add(d);
                d = d + a;
            }
            return values;
        }


        Vertex ViewportToCanvas(Vertex p2d)
        {
            float vW = (float)bitmap.Width / bitmap.Height;      
            return new Vertex((p2d.X * bitmap.Width / vW), (p2d.Y * bitmap.Height / ViewportSize), 0);
        }

        private Vertex ProjectVertex(Vertex v)
        {
            return ViewportToCanvas(new Vertex(v.X * ProjectionPlaneZ  / (v.Z), v.Y * ProjectionPlaneZ/ (v.Z), 0));
        }

        private void RenderTriangle(Triangle triangle, List<Vertex> projected)
        {
            DrawWireFrameTriangle(projected[triangle.A], projected[triangle.B], projected[triangle.C], triangle.Color);
        }


        private void RenderModel(Mesh model, Matrix transform)
        {
            List<Vertex> projected = new List<Vertex>();

            foreach (var t in model.Vertexes)
            {
                projected.Add(ProjectVertex(transform * t));
            }

            foreach (var t in model.Triangles)
            {
                RenderTriangle(t, projected);
            }
        }
    }
}
