using System.Drawing;

namespace PGrafica.Objetos3D
{
    class Pierna : Extremidad
    {
        public static int PIERNA_SUPERIOR = 1;
        public static int PIERNA_INFERIOR = 2;

        public Pierna() : this(0.3f, 0.2f, 0.6f, 0f, new float[] { 60, -30 }, 1,
            new Color[] { Color.Black, Color.Gray })
        {

        }

        public Pierna(float dx, float grosor, float altura, float angRot, float[] angFlexs,
            int lado, Color[] colors) :
            base(dx, grosor, altura, angRot, angFlexs, lado, colors)
        {
            angFlexInf = new float[] { 0, -135 };
            angFlexSup = new float[] { 90, -30 };
        }

    }
}
