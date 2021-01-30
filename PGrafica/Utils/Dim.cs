namespace PGrafica { 
    struct Dim
    {
        public float LARGO;
        public float ANCHO;
        public float ALTO;

        public Dim(float dim)
        {
            LARGO = ANCHO = ALTO = dim;
        }

        public Dim(float largo, float ancho, float alto)
        {
            LARGO = largo;
            ANCHO = ancho;
            ALTO = alto;
        }

        public Dim(Dim d)
        {
            LARGO = d.LARGO;
            ANCHO = d.ANCHO;
            ALTO = d.ALTO;
        }

    }
}
