using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Transformaciones2._0
{
    internal class Figura
    {
        private Random generadorAleatorio;
        public List<Point> vertices;

        public Figura(params Point[] puntos)
        {
            generadorAleatorio = new Random();
            vertices = new List<Point>(puntos);
        }

        public static Figura Cuadrado(int centroX, int centroY, int lado)
        {
            Point[] puntosCuadrado = new Point[]
            {
                new Point(centroX - lado / 2, centroY - lado / 2),
                new Point(centroX + lado / 2, centroY - lado / 2),
                new Point(centroX + lado / 2, centroY + lado / 2),
                new Point(centroX - lado / 2, centroY + lado / 2)
            };

            return new Figura(puntosCuadrado);
        }

        public static Figura Triangulo(int centroX, int centroY, int lado)
        {
            Point[] puntosTriangulo = new Point[]
            {
                new Point(centroX, centroY - lado / 2),
                new Point(centroX + lado / 2, centroY + lado / 2),
                new Point(centroX - lado / 2, centroY + lado / 2)
            };

            return new Figura(puntosTriangulo);
        }
        public static Figura Pentagono(int centroX, int centroY, int lado)
        {
            List<Point> puntosPentagono = new List<Point>();

            for (int i = 0; i < 5; i++)
            {
                double angulo = 2 * Math.PI * i / 5;
                int x = centroX + (int)(lado * Math.Cos(angulo));
                int y = centroY - (int)(lado * Math.Sin(angulo));
                puntosPentagono.Add(new Point(x, y));
            }

            return new Figura(puntosPentagono.ToArray());
        }
        public void Rotar(double angulo)
        {
            Point centroide = Centroide();

            for (int i = 0; i < vertices.Count; i++)
            {
                vertices[i] = RotarPunto(vertices[i], centroide, angulo);
            }
        }

        private Point RotarPunto(Point punto, Point pivote, double angulo)
        {
            double cosTheta = Math.Cos(angulo);
            double sinTheta = Math.Sin(angulo);

            int trasladadoX = punto.X - pivote.X;
            int trasladadoY = punto.Y - pivote.Y;

            return new Point
            {
                X = pivote.X + (int)(trasladadoX * cosTheta - trasladadoY * sinTheta),
                Y = pivote.Y + (int)(trasladadoX * sinTheta + trasladadoY * cosTheta)
            };
        }

        private Point Centroide()
        {
            int sumaX = 0, sumaY = 0;
            foreach (var vertice in vertices)
            {
                sumaX += vertice.X;
                sumaY += vertice.Y;
            }
            return new Point(sumaX / vertices.Count, sumaY / vertices.Count);
        }

        public void Trasladar(Size tamano)
        {
            int aleatorioX = generadorAleatorio.Next(0, tamano.Width - 100);
            int aleatorioY = generadorAleatorio.Next(0, tamano.Height - 100);

            int deltaX = aleatorioX - vertices[0].X;
            int deltaY = aleatorioY - vertices[0].Y;

            for (int i = 0; i < vertices.Count; i++)
            {
                vertices[i] = TrasladarPunto(vertices[i], deltaX, deltaY);
            }
        }

        private Point TrasladarPunto(Point punto, int deltaX, int deltaY)
        {
            return new Point
            {
                X = punto.X + deltaX,
                Y = punto.Y + deltaY
            };
        }

        public void Escalar()
        {
            double factorAleatorio = generadorAleatorio.NextDouble() + 0.5;

            Point centroide = Centroide();

            for (int i = 0; i < vertices.Count; i++)
            {
                vertices[i] = EscalarPunto(vertices[i], centroide, factorAleatorio);
            }
        }

        private Point EscalarPunto(Point punto, Point pivote, double factor)
        {
            int escaladoX = (int)((punto.X - pivote.X) * factor) + pivote.X;
            int escaladoY = (int)((punto.Y - pivote.Y) * factor) + pivote.Y;

            return new Point
            {
                X = escaladoX,
                Y = escaladoY
            };
        }
    }
}
