using OpenTK;
using System.Collections.Generic;
using System.Threading;

namespace PGrafica
{
    class ListAnimacion: List<Animacion>
    {
        private Escenario escenario;
        private GLControl glControl;

        public ListAnimacion()
        {

        }
        public ListAnimacion(Escenario esc, GLControl gl)
        {
            escenario = esc;
            glControl = gl;
        }

        public void SetEscenario(Escenario esc)
        {
            escenario = esc;
            for(int i = 0;i < Count; i++)
            {
                this[i].SetEscenario(esc);
            }
        }

        public void SetGLControl(GLControl gl)
        {
            glControl = gl;
            for(int i = 0;i < Count; i++)
            {
                this[i].SetGLControl(gl);
            }
        }

        public new void Add(Animacion animacion)
        {
            animacion.SetEscenario(escenario);
            animacion.SetGLControl(glControl);
            base.Add(animacion);
        }

        public void Run(){
            new Thread(RunAnimaciones).Start();
        }

        private void RunAnimaciones()
        {
            for(int i = 0;i < Count; i++) {
                this[i].Animation();
            }
        }

    }
}
