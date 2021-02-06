using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;
using System.Drawing;

namespace PGrafica
{
    class Silla : IFigura3D
    {
        #region Atributos
        private float lg, gr, hp, he;
        private Color color;
        private List<Punto> puntosBase;
        private List<Punto> puntosEspaldar;
        private List<List<Punto>> puntosPatas;
        #endregion

        #region Constructores
        public Silla() : this(new Punto(0), 0.6f, 0.075f, 0.6f, 1.2f, Color.Black)
        {

        }

        public Silla(Punto centro, float largo, float grosor, float altPatas, float altEspaldar, Color color) : base()
        {
            CMasa = centro;
            lg = largo;
            gr = grosor;
            hp = altPatas;
            he = altEspaldar;
            this.color = color;
            Init();
        }
        #endregion

        #region Metodos Calculo
        private void Init()
        {
            puntosBase = new List<Punto>();
            puntosEspaldar = new List<Punto>();
            puntosPatas = new List<List<Punto>>();
            for (int i = 0; i < 4; i++)
            {
                puntosPatas.Add(new List<Punto>());
            }
            CalcularPuntosBase();
            CalcularPuntosEspaldar();
            CalcularPuntosPatas();
        }

        private void CalcularPuntosPatas()
        {
            float g2 = gr / 2;
            float l2 = (lg / 2) - g2;
            float a2 = (lg / 2) - g2;
            //float hu = hp - gr;
            //float hd = 0;
            float hu = - gr;
            float hd = -hp;
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

        private void CalcularPuntosEspaldar()
        {
            float d2 = lg / 2;
            float[] au = { 0, gr, gr, 0 };
            int[,] m = { { -1, -1 }, { -1, -1 }, { 1, -1 }, { 1, -1 } };
            //float hu = he;
            //float hd = hp;
            float hu = he - hp;
            float hd = 0;
            for (int i = 0; i < 4; i++)
            {
                float x = d2 * m[i, 0];
                float y = d2 * m[i, 1] + au[i];
                puntosEspaldar.Add(new Punto(x, y, hu));
                puntosEspaldar.Add(new Punto(x, y, hd));
            }
        }

        private void CalcularPuntosBase()
        {
            float l2 = lg / 2;
            float a2 = lg / 2;
            //float hu = hp;
            //float hd = hp - gr;
            float hu = 0;
            float hd = -gr;
            int[,] m = { { -1, -1 }, { -1, 1 }, { 1, 1 }, { 1, -1 } };
            for (int i = 0; i < 4; i++)
            {
                puntosBase.Add(new Punto(a2 * m[i, 0], l2 * m[i, 1], hu));
                puntosBase.Add(new Punto(a2 * m[i, 0], l2 * m[i, 1], hd));
            }
        }
        #endregion

        #region Metodos OpenGL
        public override void Draw()
        {
            DrawBase();
            DrawPatas();
            DrawEspaldar();
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

        private void DrawEspaldar()
        {
            Primitivas.DrawCuboide(puntosEspaldar, color);
        }

        public override void RotarOrigen(float auAngX, float auAngY, float auAngZ)
        {
            AngOrg.X += auAngX;
            AngOrg.Y += auAngY;
            AngOrg.Z += auAngZ;
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
        }

        public override void Trasladar(float auX, float auY, float auZ)
        {
            Origen.X += auX;
            Origen.Y += auY;
            Origen.Z += auZ;
        }

        public override void DoOperations()
        {
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
        #endregion

    }
}