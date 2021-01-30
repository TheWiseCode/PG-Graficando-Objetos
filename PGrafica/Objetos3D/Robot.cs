using System.Drawing;
using PGrafica.Objetos3D;
using System.Collections;
using OpenTK.Graphics.OpenGL;

namespace PGrafica
{
    class Robot : IFigura3D
    {
        #region Atributos
        private Hashtable partes;
        private Color[] colors;
        private Dim dimBody, dimHead;
        private float angBody, angHead;
        //private int xp;
        private float lPiernas, lBrazos;
        private float grExt;
        public float[] angFlexPI, angFlexPD;
        public float[] angFlexBI, angFlexBD;
        private string[] nomPartes =
        {
            "brazoI", "brazoD",
            "piernaI", "piernaD",
            "cabeza", "tronco"
        };
        #endregion

        #region Constructores
        public Robot() : this(new Punto(0), new Dim(0.2f, 0.4f, 0.6f), new Dim(0.3f), 0.3f, 0.25f, 0.1f,
            Color.Black, Color.Gray)
        {
        }

        public Robot(Punto cm, Dim dimCuerpo, Dim dimCabeza, float larPiernas, float larBrazos, 
            float grosorExt, Color cBody, Color cRopa): base()
        {
            //xp = 0;
            CMasa = cm;
            dimBody = dimCuerpo;
            dimHead = dimCabeza;
            angBody = 0;
            angHead = 0;
            angFlexBI = new float[] { 0, 0 };
            angFlexBD = new float[] { 0, 0 };
            angFlexPI = new float[] { 0, 0 };
            angFlexPD = new float[] { 0, 0 };
            lPiernas = larPiernas;
            lBrazos = larBrazos;
            grExt = grosorExt;
            colors = new Color[] { cBody, cRopa };
            Init();
        }
        #endregion

        private void Init()
        {
            partes = new Hashtable();
            ActualizarPuntos();
        }

        public void ActualizarPuntos()
        {
            //xp = 0;
            partes.Clear();
            ActualizarPuntosBrazo();
            ActualizarPuntosPiern();
            ActualizarPuntosHead();
            ActualizarPuntosBody();
        }

        private void ActualizarPuntosBrazo()
        {
            Color[] cs = colors;
            float sep = 0.01f, ab = dimBody.ANCHO / 2;
            float dx = ab + sep + grExt / 2;
            float angFin = AngOrg.Z + angBody;
            Brazo b;
            b = new Brazo(dx, grExt, lBrazos, angFin, angFlexBI, Extremidad.IZQUIERDO, cs);
            partes.Add("brazoI", b);
            b = new Brazo(-dx, grExt, lBrazos, angFin, angFlexBD, Extremidad.DERECHO, cs);
            partes.Add("brazoD", b);
        }

        public void SetAngulosFlex(bool pierna, bool izq, float angSup, float angInf)
        {
            Extremidad ex = pierna ? (izq ? (Extremidad)partes["piernaI"] : (Extremidad)partes["piernaD"]) :
                (izq ? (Extremidad)partes["brazoI"] : (Extremidad)partes["brazoD"]);
            ex.AngFlexSup = angSup;
            ex.AngFlexInf = angInf;
        }

        public void AddAngulosFlex(bool pierna, bool izq, float angSup, float angInf)
        {
            Extremidad ex = pierna ? (izq ? (Extremidad)partes["piernaI"] : (Extremidad)partes["piernaD"]) :
                (izq ? (Extremidad)partes["brazoI"] : (Extremidad)partes["brazoD"]);
            ex.AngFlexSup += angSup;
            ex.AngFlexInf += angInf;
        }


        public void ActualizarPuntosPiern()
        {
            Color[] cs = colors;
            float ab = dimBody.ANCHO / 2;
            float dx = ab - grExt / 2;
            Pierna p;
            p = new Pierna(dx, grExt, lPiernas, AngOrg.Z, angFlexPI, Extremidad.IZQUIERDO, cs);
            partes.Add("piernaI", p);
            p = new Pierna(-dx, grExt, lPiernas, AngOrg.Z, angFlexPD, Extremidad.DERECHO, cs);
            partes.Add("piernaD", p);
        }

        private void ActualizarPuntosHead()
        {
            Cabeza cab = new Cabeza(dimHead, AngOrg.Z, angHead, colors[0]);
            partes.Add("cabeza", cab);
        }

        private void ActualizarPuntosBody()
        {
            Tronco tron = new Tronco(dimBody, AngOrg.Z, angBody, colors[1]);
            partes.Add("tronco", tron);
        }

        public override void Draw()
        {
            for (int i = 0; i < nomPartes.Length; i++)
            {
                IFigura3D fig = (IFigura3D)partes[nomPartes[i]];
                GL.PushMatrix();
                float zt = 0;
                if (fig is Cabeza)
                    zt = dimBody.ALTO / 2 + 0.01f + dimHead.ALTO / 2;
                else if (fig is Pierna)
                    zt = -(dimBody.ALTO / 2 - 0.01f);
                else if (fig is Brazo)
                    zt = dimBody.ALTO / 2;
                GL.Translate(0, zt, 0);
                fig.Draw();
                GL.PopMatrix();
            }
        }

        public override void DoOperations()
        {
            GL.PushMatrix();
            GL.Scale(Esc.X, Esc.Y, Esc.Z);
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

    }
}
