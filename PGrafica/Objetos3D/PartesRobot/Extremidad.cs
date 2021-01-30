using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;
using System.Drawing;

namespace PGrafica.Objetos3D
{
    abstract class Extremidad : IFigura3D
    {
        protected float gr, h, dx;
        protected List<Punto> puntos;
        protected Color colorPiel, colorRopa;
        protected int sentido = 1;
        protected int lado;
        protected float[] angFlexInf;
        protected float[] angFlexSup;
        protected float angGirExt, angGirInt;

        private static float sep = 0.01f;

        public float AngFlexSup { get; set; }
        public float AngFlexInf { get; set; }
        public float AngGiro { get; set; }

        public static int IZQUIERDO = 1;
        public static int DERECHO = 2;

        public Extremidad() : this(0.3f, 0.2f, 0.6f, 90f, new float[] { 0, 90 }, 1,
            new Color[] { Color.Black, Color.Gray })
        {
            angFlexInf = new float[2];
            angFlexSup = new float[2];
        }

        public Extremidad(float dx, float grosor, float altura, float angRot,
            float[] angFlexs, int lado, Color[] colors)
        {
            this.dx = dx;
            this.lado = lado;
            gr = grosor;
            h = altura;
            colorPiel = colors[0];
            colorRopa = colors[1];
            AngGiro = 0;
            AngFlexSup = angFlexs[0];
            AngFlexInf = angFlexs[1];
            Init();
        }

        protected void Init()
        {
            puntos = new List<Punto>();
            puntos = new List<Punto>();
            ActualizarPuntos();
        }

        public void ActualizarPuntos()
        {
            puntos.Clear();
            puntos.Clear();
            CalcularPuntos();
        }

        private void CalcularPuntos()
        {
            float l2 = gr / 2, a2 = gr / 2;
            float hu = 0;
            float hd = -h;
            int[,] m = { { -1, -1 }, { -1, 1 }, { 1, 1 }, { 1, -1 } };
            float dy = 0;
            for (int i = 0; i < 4; i++)
            {
                puntos.Add(new Punto(a2 * m[i, 0] + dx, l2 * m[i, 1] + dy, hu));
                puntos.Add(new Punto(a2 * m[i, 0] + dx, l2 * m[i, 1] + dy, hd));
            }
        }

        public override void Draw()
        {
            //Ahora Extremidad Superior
            GL.PushMatrix();
            GL.Rotate(-AngFlexSup, 1, 0, 0);
            Primitivas.DrawCuboide(puntos, colorRopa);
            GL.Translate(0, -h, 0);
            //Ahora Extremidad Inferior
            GL.PushMatrix();
            GL.Rotate(-AngFlexInf, 1, 0, 0);
            Primitivas.DrawCuboide(puntos, colorPiel);
            GL.PopMatrix();
            GL.PopMatrix();
        }

        public override void DoOperations()
        {
            //Ahora Extremidad Superior
            GL.PushMatrix();
            GL.Rotate(-AngFlexSup, 1, 0, 0);
            Primitivas.DrawCuboide(puntos, colorRopa);
            GL.Translate(0, -h, 0);
            //Ahora Extremidad Inferior
            GL.PushMatrix();
            GL.Rotate(-AngFlexInf, 1, 0, 0);
            Primitivas.DrawCuboide(puntos, colorPiel);
            GL.PopMatrix();
            GL.PopMatrix();
        }

        public void Girar(float angAumento)
        {
            //ActualizarPuntos();
        }

        public void Flexiona(float angAumento)
        {

        }
    }
}
