using OpenTK;
using System;
using System.Threading;


namespace PGrafica
{
    class RobotAnimations
    {
        private Robot rb;
        private GLControl gl;
        public float ang;
        public bool izq;
        public long Time { get; set; }
        public float dist;


        public RobotAnimations(GLControl gl, Robot rbt)
        {
            this.gl = gl;
            rb = rbt;
            izq = true;
            ang = 60;
            Time = 3000;
        }

        public RobotAnimations(GLControl gl, Robot rbt, bool izq, float ang, long timeMilisegundos)
        {
            this.gl = gl;
            rb = rbt;
            this.izq = izq;
            this.ang = ang;
            Time = timeMilisegundos;

        }

        public RobotAnimations(GLControl gl, Robot rbt, float dist, long timeMilisegundos)
        {
            this.gl = gl;
            rb = rbt;
            this.dist = dist;
            Time = timeMilisegundos;
        }

        public void SetTimeAnimation(long timeMilisegundos)
        {
            Time = timeMilisegundos;
        }

        public void LoadAnimationExtremidades(bool izq, float ang, long timeMilisegundos)
        {
            this.izq = izq;
            this.ang = ang;
            Time = timeMilisegundos;
        }

        public void LoadAnimationCaminar(float dist, long timeMilisegundos)
        {
            this.dist = dist;
            Time = timeMilisegundos;
        }

        public void FlexRodilla()
        {
            int s = ang > 0 ? 1 : -1;
            FlexRodilla(s);
        }

        private void FlexRodilla(int s)
        {
            float au = ang / Time;
            //float cAng = Math.Abs(au);
            DateTime dt = DateTime.Now;
            long ini = dt.Hour * 3600000 + dt.Minute * 60000 + dt.Second * 1000 + dt.Millisecond; ;
            long ant = ini;
            long fin = ini + Time;
            DateTime d1 = DateTime.Now;
            long time = d1.Hour * 3600000 + d1.Minute * 60000 + d1.Second * 1000 + d1.Millisecond;
            while (/*cAng < Math.Abs(ang) &&*/ time < fin)
            {
                if (time > ant)
                {
                    float aux = au;
                    float auxC = (s < 0 ? aux : -aux);
                    //cAng += Math.Abs(au);
                    //if (cAng < Math.Abs(ang))
                    rb.AddAngulosFlex(true, izq, aux, auxC);
                    gl.Invalidate();
                }
                ant = time;
                d1 = DateTime.Now;
                time = d1.Hour * 3600000 + d1.Minute * 60000 + d1.Second * 1000 + d1.Millisecond;
            }
        }

        public void FlexPierna()
        {
            float au = ang / Time;
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
                    float aux = au;
                    rb.AddAngulosFlex(true, izq, aux, 0);
                    gl.Invalidate();
                }
                ant = time;
                d1 = DateTime.Now;
                time = d1.Hour * 3600000 + d1.Minute * 60000 + d1.Second * 1000 + d1.Millisecond;
            }
        }

        public void LevaRodilla()
        {
            long mit = Time / 2;
            int s = ang > 0 ? 1 : -1;
            new RobotAnimations(gl, rb, izq, ang, mit).FlexRodilla(s);
            new RobotAnimations(gl, rb, izq, -ang, mit).FlexRodilla(s);
        }

        public void LevaPierna()
        {
            long mit = Time / 2;
            new RobotAnimations(gl, rb, izq, ang, mit).FlexPierna();
            new RobotAnimations(gl, rb, izq, -ang, mit).FlexPierna();
        }

        public void FlexBrazo()
        {
            int s = ang > 0 ? 1 : -1;
            FlexBrazo(s);
        }

        private void FlexBrazo(int s)
        {
            float au = ang / Time;
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
                    float aux = au;
                    //float auxC = ang > 0 ? (s > 0 ? aux : -aux) : (s > 0 ? aux : -aux);
                    float auxC = (s > 0 ? aux : -aux);
                    rb.AddAngulosFlex(false, izq, aux, auxC);
                    gl.Invalidate();
                }
                ant = time;
                d1 = DateTime.Now;
                time = d1.Hour * 3600000 + d1.Minute * 60000 + d1.Second * 1000 + d1.Millisecond;
            }
        }

        public void LevaBrazo()
        {
            long mit = Time / 2;
            int s = ang > 0 ? 1 : -1;
            new RobotAnimations(gl, rb, izq, ang, mit).FlexBrazo(s);
            new RobotAnimations(gl, rb, izq, -ang, mit).FlexBrazo(s);
        }

        public void FlexBrazoComp()
        {
            float au = ang / Time;
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
                    float aux = au;
                    rb.AddAngulosFlex(false, izq, aux, 0);
                    gl.Invalidate();
                }
                ant = time;
                d1 = DateTime.Now;
                time = d1.Hour * 3600000 + d1.Minute * 60000 + d1.Second * 1000 + d1.Millisecond;
            }
        }

        public void LevaBrazoComp()
        {
            long mit = Time / 2;
            new RobotAnimations(gl, rb, izq, ang, mit).FlexBrazoComp();
            new RobotAnimations(gl, rb, izq, -ang, mit).FlexBrazoComp();
        }

        public void Caminar()
        {
            RobotAnimations le1 = new RobotAnimations(gl, rb, true, 40, Time);
            RobotAnimations le2 = new RobotAnimations(gl, rb, false, -40, Time);
            RobotAnimations le3 = new RobotAnimations(gl, rb, dist, Time);
            new Thread(le1.LevaRodilla).Start();
            new Thread(le2.LevaRodilla).Start();
            new Thread(le3.Avanzar).Start();
        }

        public void Avanzar()
        {
            float au = dist / Time;
            DateTime dt = DateTime.Now;
            long ini = dt.Hour * 3600000 + dt.Minute * 60000 + dt.Second * 1000 + dt.Millisecond; ;
            long ant = ini;
            long fin = ini + Time;
            DateTime d1 = DateTime.Now;
            long time = d1.Hour * 3600000 + d1.Minute * 60000 + d1.Second * 1000 + d1.Millisecond;
            while (time < fin)
            {
                if (time > ant)
                {
                    rb.Trasladar(0, au, 0);
                    gl.Invalidate();
                }
                ant = time;
                d1 = DateTime.Now;
                time = d1.Hour * 3600000 + d1.Minute * 60000 + d1.Second * 1000 + d1.Millisecond;
            }
        }

    }
}
