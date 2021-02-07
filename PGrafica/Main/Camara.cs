
using System.Windows.Forms;

namespace PGrafica
{

    class Camara
    {
        private int rotaX, rotaZ;
        private float oldX, oldY;

        public float AngX { get; set; }
        public float AngY { get; set; }
        public float AngZ { get; set; }
        public float TlsX { get; set; }
        public float TlsY { get; set; }
        public float TlsZ { get; set; }
        public float Scale { get; set; }

        public Camara()
        {
            rotaX = rotaZ = 0;
            AngX = AngY = AngZ = 0;
            TlsX = TlsY = TlsZ = 0;
            oldX = oldY = 0;
            Scale = 0f;
        }

        public void MouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                oldX = e.X;
                oldY = e.Y;
            }
        }

        public void MouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                RotarCamara(e);
            }
            else
            {
                AngX = AngY = AngZ = 0;
            }
            TlsX = TlsY = TlsZ = 0;
        }

        public void MouseWheel(MouseEventArgs e)
        {
            int au = e.Delta;
            float df = 0.25f;
            Scale = au > 0 ? df : - df;
        }

        private void RotarCamara(MouseEventArgs e)
        {
            float MovedX = e.X - oldX;
            float MovedY = e.Y - oldY;
            if (MovedX == 0 && MovedY != 0)
            {
                rotaX = MovedY > 0 ? 1 : -1;
                rotaZ = 0;
            }
            else if (MovedY == 0 && MovedX != 0)
            {
                rotaZ = MovedX > 0 ? 1 : -1;
                rotaX = 0;
            }
            oldX = e.X;
            oldY = e.Y;
            if (rotaX == 1 || rotaX == -1)
            {
                AngX = rotaX * 1.5f;
                AngZ = 0;
            }
            if (rotaZ == 1 || rotaZ == -1)
            {
                AngX = 0;
                AngZ = rotaZ * 1.5f;
            }
        }
    }
}
