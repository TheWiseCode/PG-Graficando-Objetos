using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;
using System.Drawing;

namespace PGrafica.Objetos3D
{
    class Tronco : IFigura3D
    {
        protected Dim dim;
        private List<Punto> puntosBody;
        protected Color color;

        public float AngGiro { get; set; }

        public Tronco() : this(new Dim(0.3f), 90, 0, Color.Black)
        {

        }

        public Tronco(Dim dim, float angRot, float angGiro, Color color)
        {
            this.dim = dim;
            this.color = color;
            AngGiro = angGiro;
            Init();
        }

        protected void Init()
        {
            puntosBody = new List<Punto>();
            ActualizarPuntos();
        }

        public void ActualizarPuntos()
        {
            puntosBody.Clear();
            CalcularPuntosHead();
        }

        private void CalcularPuntosHead()
        {
            float lb = dim.LARGO / 2, ab = dim.ANCHO / 2, hb = dim.ALTO / 2;
            float hu = hb;
            float hd = -hb;
            int[,] m = { { -1, -1 }, { -1, 1 }, { 1, 1 }, { 1, -1 } };
            for (int i = 0; i < 4; i++)
            {
                puntosBody.Add(new Punto(ab * m[i, 0], lb * m[i, 1], hu));
                puntosBody.Add(new Punto(ab * m[i, 0], lb * m[i, 1], hd));
            }
        }

        public override void Draw()
        {
            Primitivas.DrawCuboide(puntosBody, color);
        }

        public void Girar(float angAumento)
        {
            AngGiro = AngGiro >= 360 ? 360 - AngGiro + angAumento : AngGiro + angAumento;
            //ActualizarPuntos();
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
