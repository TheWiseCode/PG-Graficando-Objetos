using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;
using System.Drawing;

namespace PGrafica
{
    class Mesa : IFigura3D
    {
        #region Atributos
        private Dim dim;
        private float gr;
        private Color color;
        private List<Punto> puntosBase;
        private List<List<Punto>> puntosPatas;
        #endregion

        #region Constructores
        public Mesa() : this(new Punto(0), new Dim(1), 0.1f, Color.Black)
        {

        }

        public Mesa(Punto centro, Dim dimMesa, float grosor, Color color): base()
        {
            CMasa = centro;
            dim = dimMesa;
            gr = grosor;
            this.color = color;
            Init();
        }
        #endregion

        private void Init()
        {
            puntosBase = new List<Punto>();
            puntosPatas = new List<List<Punto>>();
            for (int i = 0; i < 4; i++)
            {
                puntosPatas.Add(new List<Punto>());
            }
            CalcularPuntosBase();
            CalcularPuntosPatas();
        }

        private void CalcularPuntosBase()
        {
            float l2 = dim.LARGO / 2;
            float a2 = dim.ANCHO / 2;
            //float hu = dim.ALTO;
            //float hd = hu- gr;
            float hu = 0;
            float hd = -gr;
            int[,] m = { { -1, -1 }, { -1, 1 }, { 1, 1 }, { 1, -1 } };
            for (int i = 0; i < 4; i++)
            {
                puntosBase.Add(new Punto(a2 * m[i, 0], l2 * m[i, 1], hu));
                puntosBase.Add(new Punto(a2 * m[i, 0], l2 * m[i, 1], hd));
            }
        }

        private void CalcularPuntosPatas()
        {
            float g2 = gr / 2;
            float l2 = (dim.LARGO / 2) - g2;
            float a2 = (dim.ANCHO / 2) - g2;
            //float hu = dim.ALTO - gr;
            //float hd = 0;
            float hu = -gr;
            float hd = -dim.ALTO;
            int[,] m = { { -1, -1 }, { -1, 1 }, { 1, 1 }, { 1, -1 } };
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    float x = a2 * m[i, 0] + g2 * m[j, 0];
                    float y = l2 * m[i, 1] + g2 * m[j, 1];
                    puntosPatas[i].Add(new Punto(x, y, hu));
                    puntosPatas[i].Add(new Punto(x, y, hd));
                }
            }
        }

        public override void Draw()
        {
            DrawBase();
            DrawPatas();
        }

        public override void DoOperations()
        {
            Traslaciones();
            GL.PushMatrix();
            GL.Scale(Esc.X, Esc.Z, Esc.Y);
            GL.Translate(Origen.X, Origen.Z, Origen.Y);
            GL.Rotate(AngOrg.X, 1, 0, 0);
            GL.Rotate(AngOrg.Y, 0, 0, 1);
            GL.Rotate(AngOrg.Z, 0, 1, 0);
            GL.PushMatrix();
            GL.Translate(CMasa.X, CMasa.Z, CMasa.Y);
            GL.Rotate(AngObj.X, 1, 0, 0);
            GL.Rotate(AngObj.Y, 0, 0, 1);
            GL.Rotate(AngObj.Z, 0, 1, 0);
            Draw();
            GL.PopMatrix();
            GL.PopMatrix();
        }

        private void DrawBase()
        {
            Primitivas.DrawCuboide(puntosBase, color);
        }

        private void DrawPatas()
        {
            for (int i = 0; i < 4; i++)
            {
                Primitivas.DrawCuboide(puntosPatas[i], color);
            }
        }

        public override void Escalar(float auEscX, float auEscY, float auEscZ)
        {
            float limSup = 1.5f;
            bool plusX = auEscX > 0, plusY = auEscY > 0, plusZ = auEscZ > 0;
            if (plusX && Esc.X < limSup)
                Esc.X += auEscX;
            else if (Esc.X > 0.25f)
                Esc.X += auEscX;
            if (plusY && Esc.Y < limSup)
                Esc.Y += auEscY;
            else if (Esc.Y > 0.25f)
                Esc.Y += auEscY;
            if (plusZ && Esc.Z < limSup)
                Esc.Z += auEscZ;
            else if (Esc.Z > 0.25f)
                Esc.Z += auEscZ;
            // GL.Scale(escX, escY, escZ);
        }
    }
}
