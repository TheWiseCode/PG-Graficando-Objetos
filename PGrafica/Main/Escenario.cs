using OpenTK.Graphics.OpenGL;
using System;
using System.Collections;
using System.Collections.Generic;

namespace PGrafica
{
    class Escenario
    {
        #region Atributos
        private List<string> nombres;
        public Hashtable objects;
        private Punto Tras, Ang, Esc;
        private Punto SentTras;
        #endregion

        public Escenario()
        {
            Init();
        }

        private void Init()
        {
            nombres = new List<string>();
            objects = new Hashtable();
            Tras = new Punto(0);
            Ang = new Punto(0);
            Esc = new Punto(1);
            SentTras = new Punto(0);
        }

        public void AddObject(IFigura3D figure, string clave)
        {
            if (!objects.ContainsKey(clave) && clave != "")
            {
                objects.Add(clave, figure);
                nombres.Add(clave);
            }
            else
            {
                throw new InvalidOperationException("Clave de Objeto3D invalida");
            }
        }

        public void RemoveObject(string clave)
        {
            if (objects.Contains(clave))
            {
                objects.Remove(clave);
                nombres.Remove(clave);
            }
        }
        
        public void DoOperations(string objeto, Camara camara)
        {
            float aX = camara.AngX, aY = camara.AngY, aZ = camara.AngZ;
            float sX = camara.Scale, sY = sX, sZ = sX;
            float tX = camara.TlsX, tY = camara.TlsY, tZ = camara.TlsZ;
            camara.Scale = 0;
            Escalar(sX, sY, sZ, objeto);
            Rotar(aX, aY, aZ, objeto);
            Trasladar(tX, tY, tZ, objeto);
            DoOperations();
        }

        public void DoOperations()
        {
            GL.PushMatrix();
            GL.Translate(Tras.X, Tras.Z, Tras.Y);
            GL.Rotate(Ang.X, 1, 0, 0);
            GL.Rotate(Ang.Y, 0, 0, 1);
            GL.Rotate(Ang.Z, 0, 1, 0);
            GL.Scale(Esc.X, Esc.Z, Esc.Y);
            Draw();
            GL.PopMatrix();
        }

        public void Draw()
        {
            Primitivas.DrawEjes(10f);
            for (int i = 0; i < nombres.Count; i++)
            {
                IFigura3D fig = (IFigura3D)(objects[nombres[i]]);
                fig.DoOperations();
            }
        }

        public void Rotar(float auAngX, float auAngY, float auAngZ, string objeto)
        {
            if (objeto == "Escenario")
            {
                /*
                GL.Rotate(auAngX, 1, 0, 0);
                GL.Rotate(auAngY, 0, 0, 1);
                GL.Rotate(auAngZ, 0, 1, 0);
                return;*/
                Ang.X += auAngX;
                Ang.Y += auAngY;
                Ang.Z += auAngZ;
            }
            else if (objects.Contains(objeto))
            {
                IFigura3D fig = (IFigura3D)(objects[objeto]);
                fig.Rotar(auAngX, auAngY, auAngZ);
            }
        }
        
        public void Restart()
        {
            Ang.X = Ang.Y = Ang.Z = 0;
            Tras.X = Tras.Y = Tras.Z = 0;
            Esc.X = Esc.Y = Esc.Z = 1;
            for (int i = 0; i < nombres.Count; i++)
            {
                IFigura3D fig = (IFigura3D)(objects[nombres[i]]);
                fig.Restart();
            }
        }

        public void Escalar(float auEscX, float auEscY, float auEscZ, string objeto)
        {
            if (objeto == "Escenario")
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
                //GL.Scale(Esc.X, Esc.Y, Esc.Z);
            }
            else if (objects.Contains(objeto))
            {
                IFigura3D fig = (IFigura3D)(objects[objeto]);
                fig.Escalar(auEscX, auEscY, auEscZ);
            }
        }

        public void Trasladar(float auX, float auY, float auZ, string objeto)
        {
            if (objeto == "Escenario")
            {
                /*GL.Translate(auX, auZ, auY);
                return;*/
                Tras.X += auX;
                Tras.Y += auY;
                Tras.Z += auZ;
            }
            else if (objects.Contains(objeto))
            {
                IFigura3D fig = (IFigura3D)(objects[objeto]);
                fig.Trasladar(auX, auY, auZ);
            }
        }

        public void TrasladarThread(int sentido, int eje, string objeto)
        {
            if (objeto == "Escenario")
            {
                SentTras.X = eje == IFigura3D.EJE_X ? -sentido: SentTras.X;
                SentTras.Y = eje == IFigura3D.EJE_Y ? sentido: SentTras.Y;
                SentTras.Z = eje == IFigura3D.EJE_Z ? sentido: SentTras.Z;
            }
            else if (objects.Contains(objeto))
            {
                IFigura3D fig = (IFigura3D)(objects[objeto]);
                fig.ActiveTraslacion(sentido, eje);
            }
        }

        public void Traslaciones(string objeto)
        {
            if(objeto == "Escenario") {
                Tras.X = SentTras.X != 0 ? Tras.X += 0.1f * SentTras.X :  Tras.X;
                Tras.Y = SentTras.Y != 0 ? Tras.Y += 0.1f * SentTras.Y :  Tras.Y;
                Tras.Z = SentTras.Z != 0 ? Tras.Z += 0.1f * SentTras.Z :  Tras.Z;
            }
            else if (objects.ContainsKey(objeto))
            {
                IFigura3D fig = (IFigura3D)(objects[objeto]);
                fig.Traslaciones();
            }
        }

        public void SetAngulosOrigen(float angX, float angY, float angZ, string objeto)
        {
            if(objeto == "Escenario")
            {
                Ang = new Punto(angX, angY, angZ);
            }
            else if (objects.Contains(objeto))
            {
                IFigura3D fig = (IFigura3D)(objects[objeto]);
                fig.AngOrg = new Punto(angX, angY, angZ);
            }
        }

        public void SetAngulosObjeto(float angX, float angY, float angZ, string objeto)
        {
            if (objects.Contains(objeto))
            {
                IFigura3D fig = (IFigura3D)(objects[objeto]);
                fig.AngObj = new Punto(angX, angY, angZ);
            }
        }

        public void SetEscala(float escX, float escY, float escZ, string objeto)
        {
            if (objeto == "Escenario")
            {
                Esc = new Punto(escX, escY, escZ);
            }
            else if (objects.Contains(objeto))
            {
                IFigura3D fig = (IFigura3D)(objects[objeto]);
                fig.Esc = new Punto(escX, escY, escZ);
            }
        }

        public void SetPuntoOrigen(float x, float y, float z, string objeto)
        {
            if (objeto == "Escenario")
            {
                Tras = new Punto(x, y, z);
            }
            else if (objects.Contains(objeto))
            {
                IFigura3D fig = (IFigura3D)(objects[objeto]);
                fig.Origen = new Punto(x, y, z);
            }
        }

        public void SetPuntoObjeto(float x, float y, float z, string objeto)
        {
            if (objects.Contains(objeto))
            {
                IFigura3D fig = (IFigura3D)(objects[objeto]);
                fig.CMasa = new Punto(x, y, z);
            }
        }

        public void hilo()
        {
            if (objects.ContainsKey("Robot"))
            {
                
            }
        }

        public bool ClaveValida(string claveObjeto)
        {
            return !objects.ContainsKey(claveObjeto);
        }
    }
}
