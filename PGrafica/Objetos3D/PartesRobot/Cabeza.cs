using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;
using System.Drawing;

namespace PGrafica.Objetos3D
{
    class Cabeza : IFigura3D
    {
        protected Dim dim;
        private List<Punto> puntosHead;
        protected Color color;

        public float AngGiro { get; set; }

        public Cabeza() : this(new Dim(0.3f), 90, 0, Color.Black)
        {

        }

        public Cabeza(Dim dim, float angRot, float angGiro, Color color)
        {
            this.dim = dim;
            this.color = color;
            AngGiro = angGiro;
            Init();
        }

        protected void Init()
        {
            puntosHead = new List<Punto>();
            ActualizarPuntos();
        }

        public void ActualizarPuntos()
        {
            puntosHead.Clear();
            CalcularPuntosHead();
        }

        private void CalcularPuntosHead()
        {
            float lh = dim.LARGO / 2, ah = dim.ANCHO / 2;
            float hh = dim.ALTO / 2;
            float hu = hh;
            float hd = -hh;
            int[,] m = { { -1, -1 }, { -1, 1 }, { 1, 1 }, { 1, -1 } };
            for (int i = 0; i < 4; i++)
            {
                puntosHead.Add(new Punto(ah * m[i, 0], lh * m[i, 1], hu));
                puntosHead.Add(new Punto(ah * m[i, 0], lh * m[i, 1], hd));
            }
        }

        public void Girar(float angAumento)
        {
            AngGiro = AngGiro >= 360 ? 360 - AngGiro + angAumento : AngGiro + angAumento;
            //ActualizarPuntos();
        }

        public override void Draw()
        {
            Primitivas.DrawCuboide(puntosHead, color);
        }

        public override void DoOperations()
        {
            GL.PushMatrix();
            GL.Rotate(AngGiro, 0, 1, 0);
            Draw();
            GL.PopMatrix();
        }
    }
}
