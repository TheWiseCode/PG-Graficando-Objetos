using System.Drawing;

namespace PGrafica.Objetos3D
{
    class Brazo : Extremidad
    {
        public static int BRAZO = 1;
        public static int ANTEBRAZO = 2;

        public Brazo() : this(0.2f, 0.2f, 0.6f, 0f, new float[] { -30, 60 }, 1,
            new Color[] { Color.Black, Color.Gray })
        {

        }

        public Brazo(float dx, float grosor, float altura, float angRot, float[] angFlexs,
            int lado, Color[] colors) :
            base(dx, grosor, altura, angRot, angFlexs, lado, colors)
        {
            angFlexInf = new float[] { -45, 0 };
            angFlexSup = new float[] { 90, 0 };
        }
    }
}
