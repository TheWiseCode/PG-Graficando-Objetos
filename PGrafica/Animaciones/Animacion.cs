using OpenTK;
using System;

namespace PGrafica
{
    class Animacion
    {
        #region Atributos
        public const int ROTAR_OBJ = 1;
        public const int ROTAR_ORG = 2;
        public const int MOVER = 3;
        public const int TRASLADAR = 4;
        public const int ESCALAR = 5;
        public const int ESCALATE = 6;

        private IFigura3D figura;
        private GLControl glControl;
        public string Objeto;
        public int TipoAnimacion;
        public float X, Y, Z;
        public long Time;
        #endregion

        public Animacion(string objeto, int tipo, float x, float y, float z, long time)
        {
            Time = time;
            X = x;
            Y = y;
            Z = z;
            Objeto = objeto;
            if (tipo >= 1 && tipo <= 6) {
                TipoAnimacion = tipo;
            }
        }

        public void SetEscenario(Escenario escenario)
        {
            if (escenario != null && escenario.ContainsObject(Objeto)) {
                figura = (IFigura3D)escenario.objects[Objeto];
            }
        }

        public void SetGLControl(GLControl gl)
        {
            if (gl != null) {
                glControl = gl;
            }
        }

        public void Animation()
        {
            if (figura != null && glControl != null)
            {
                switch (TipoAnimacion)
                {
                    case ROTAR_OBJ:
                        RotarObjeto();
                        break;
                    case ROTAR_ORG:
                        RotarOrigen();
                        break;
                    case MOVER:
                        Mover();
                        break;
                    case TRASLADAR:
                        Trasladar();
                        break;
                    case ESCALAR:
                        Escalar();
                        break;
                    case ESCALATE:
                        Escalate();
                        break;
                }
            }
        }


        private void Trasladar()
        {
            float aux = (X - figura.Origen.X) / Time;
            float auy = (Y - figura.Origen.Y) / Time;
            float auz = (Z - figura.Origen.Z) / Time;
            DateTime dt = DateTime.Now;
            long ini = dt.Hour * 3600000 + dt.Minute * 60000 + dt.Second * 1000 + dt.Millisecond;
            long ant = ini;
            long fin = ini + Time;
            DateTime d1 = DateTime.Now;
            long time = d1.Hour * 3600000 + d1.Minute * 60000 + d1.Second * 1000 + d1.Millisecond;
            while (time <= fin)
            {
                if (time > ant)
                {
                    figura.Trasladar(aux, auy, auz);
                    glControl.Invalidate();
                }
                ant = time;
                d1 = DateTime.Now;
                time = d1.Hour * 3600000 + d1.Minute * 60000 + d1.Second * 1000 + d1.Millisecond;
            }
        }

        private void Mover()
        {
            float aux = X / Time;
            float auy = Y / Time;
            float auz = Z / Time;
            DateTime dt = DateTime.Now;
            long ini = dt.Hour * 3600000 + dt.Minute * 60000 + dt.Second * 1000 + dt.Millisecond;
            long ant = ini;
            long fin = ini + Time;
            DateTime d1 = DateTime.Now;
            long time = d1.Hour * 3600000 + d1.Minute * 60000 + d1.Second * 1000 + d1.Millisecond;
            while (time <= fin)
            {
                if (time > ant)
                {
                    figura.Trasladar(aux, auy, auz);
                    glControl.Invalidate();
                }
                ant = time;
                d1 = DateTime.Now;
                time = d1.Hour * 3600000 + d1.Minute * 60000 + d1.Second * 1000 + d1.Millisecond;
            }
        }

        private void RotarObjeto()
        {
            float aux = X / Time;
            float auy = Y / Time;
            float auz = Z / Time;
            DateTime dt = DateTime.Now;
            long ini = dt.Hour * 3600000 + dt.Minute * 60000 + dt.Second * 1000 + dt.Millisecond; ;
            long ant = ini;
            long fin = ini + Time;
            DateTime d1 = DateTime.Now;
            long time = d1.Hour * 3600000 + d1.Minute * 60000 + d1.Second * 1000 + d1.Millisecond;
            while (time <= fin)
            {
                if (time > ant)
                {
                    figura.RotarObjeto(aux, auy, auz);
                    glControl.Invalidate();
                }
                ant = time;
                d1 = DateTime.Now;
                time = d1.Hour * 3600000 + d1.Minute * 60000 + d1.Second * 1000 + d1.Millisecond;
            }
        }

        private void RotarOrigen()
        {
            float aux = X / Time;
            float auy = Y / Time;
            float auz = Z / Time;
            DateTime dt = DateTime.Now;
            long ini = dt.Hour * 3600000 + dt.Minute * 60000 + dt.Second * 1000 + dt.Millisecond; ;
            long ant = ini;
            long fin = ini + Time;
            DateTime d1 = DateTime.Now;
            long time = d1.Hour * 3600000 + d1.Minute * 60000 + d1.Second * 1000 + d1.Millisecond;
            while (time <= fin)
            {
                if (time > ant)
                {
                    figura.RotarOrigen(aux, auy, auz);
                    glControl.Invalidate();
                }
                ant = time;
                d1 = DateTime.Now;
                time = d1.Hour * 3600000 + d1.Minute * 60000 + d1.Second * 1000 + d1.Millisecond;
            }
        }

        private void Escalar()
        {
            float aux = X / Time;
            float auy = Y / Time;
            float auz = Z / Time;
            DateTime dt = DateTime.Now;
            long ini = dt.Hour * 3600000 + dt.Minute * 60000 + dt.Second * 1000 + dt.Millisecond; ;
            long ant = ini;
            long fin = ini + Time;
            DateTime d1 = DateTime.Now;
            long time = d1.Hour * 3600000 + d1.Minute * 60000 + d1.Second * 1000 + d1.Millisecond;
            while (time <= fin)
            {
                if (time > ant)
                {
                    figura.Escalar(aux, auy, auz);
                    glControl.Invalidate();
                }
                ant = time;
                d1 = DateTime.Now;
                time = d1.Hour * 3600000 + d1.Minute * 60000 + d1.Second * 1000 + d1.Millisecond;
            }
        }

        private void Escalate()
        {
            float aux = (X - figura.Esc.X) / Time;
            float auy = (Y - figura.Esc.Y) / Time;
            float auz = (Z - figura.Esc.Z) / Time;
            DateTime dt = DateTime.Now;
            long ini = dt.Hour * 3600000 + dt.Minute * 60000 + dt.Second * 1000 + dt.Millisecond; ;
            long ant = ini;
            long fin = ini + Time;
            DateTime d1 = DateTime.Now;
            long time = d1.Hour * 3600000 + d1.Minute * 60000 + d1.Second * 1000 + d1.Millisecond;
            while (time <= fin)
            {
                if (time > ant)
                {
                    figura.Escalar(aux, auy, auz);
                    glControl.Invalidate();
                }
                ant = time;
                d1 = DateTime.Now;
                time = d1.Hour * 3600000 + d1.Minute * 60000 + d1.Second * 1000 + d1.Millisecond;
            }
        }
    }
}
