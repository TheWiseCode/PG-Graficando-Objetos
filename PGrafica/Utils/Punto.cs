using OpenTK;

namespace PGrafica
{
    class Punto
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Punto(float valor)
        {
            X = Y = Z = valor;
        }

        public Punto(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Punto(Punto p)
        {
            X = p.X;
            Y = p.Y;
            Z = p.Z;
        }

        public Vector3 ToVector3()
        {
            return new Vector3(X, Y, Z)
;
        }

    }
}
