using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;
using System.Drawing;

namespace PGrafica
{
    class Primitivas
    {

        public static void DrawRectFill(Punto[] ps, Color color)
        {
            if (ps.Length == 4)
            {
                GL.Begin(PrimitiveType.Quads);
                GL.Color3(color);
                GL.Vertex3(ps[0].X, ps[0].Z, ps[0].Y);
                GL.Vertex3(ps[1].X, ps[1].Z, ps[1].Y);
                GL.Vertex3(ps[2].X, ps[2].Z, ps[2].Y);
                GL.Vertex3(ps[3].X, ps[3].Z, ps[3].Y);
                GL.End();
            }
        }

        public static void DrawCuboide(List<Punto> pts, Color color)
        {
            if (pts.Count == 8)
            {
                Punto[] ps;
                //Cara L
                ps = new Punto[] { pts[0], pts[1], pts[3], pts[2] };
                DrawRectFill(ps, color);
                //Cara F
                ps = new Punto[] { pts[2], pts[3], pts[5], pts[4] };
                DrawRectFill(ps, color);
                //Cara R
                ps = new Punto[] { pts[6], pts[7], pts[5], pts[4] };
                DrawRectFill(ps, color);
                //Cara B
                ps = new Punto[] { pts[0], pts[1], pts[7], pts[6] };
                DrawRectFill(ps, color);
                //Cara U
                ps = new Punto[] { pts[0], pts[2], pts[4], pts[6] };
                DrawRectFill(ps, color);
                //Cara D
                ps = new Punto[] { pts[1], pts[3], pts[5], pts[7] };
                DrawRectFill(ps, color);
            }
        }

        public static void DrawEjes(float longitud)
        {
            float sep = 0.5f;
            //Eje X 
            DrawLine(new Punto(0, 0, 0), new Punto(longitud, 0, 0), Color.Red);
            DrawEjeNeg(longitud, sep, 1, Color.Red);
            //Eje Y
            DrawLine(new Punto(0, 0, 0), new Punto(0, 0, longitud), Color.Green);
            DrawEjeNeg(longitud, sep, 2, Color.Green);
            //Eje Z
            DrawLine(new Punto(0, 0, 0), new Punto(0, longitud, 0), Color.Blue);
            DrawEjeNeg(longitud, sep, 3, Color.Blue);
        }

        public static void DrawLine(Punto a, Punto b, Color color)
        {
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(color);
            GL.Vertex3(a.X, a.Y, a.Z);
            GL.Vertex3(b.X, b.Y, b.Z);
            GL.End();
        }

        private static void DrawEjeNeg(float longitud, float sep, int eje, Color color)
        {
            float ax = eje == 1 ? sep : 0;
            float ay = eje == 2 ? sep : 0;
            float az = eje == 3 ? sep : 0;
            Punto aux = new Punto(0);
            bool d = true;
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(color);
            for (float e = 0;e <= longitud; e += sep)
            {
                if (d) {
                    GL.Vertex3(aux.X, aux.Z, aux.Y);
                    GL.Vertex3(aux.X - ax, aux.Z - az, aux.Y - ay);
                }
                aux = new Punto(aux.X - ax, aux.Y - ay, aux.Z - az);
                d = !d;
            }
            GL.End();
        }
    }
}
