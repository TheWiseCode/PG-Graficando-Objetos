namespace PGrafica
{
    abstract class IFigura3D
    {
        
        public static int EJE_X = 1;
        public static int EJE_Y = 2;
        public static int EJE_Z = 3;
    
        #region Atributos
        public Punto AngOrg { get; set; }
        public Punto AngObj { get; set; }
        public Punto Esc { get; set; }
        public Punto CMasa { get; set; }
        public Punto Origen { get; set; }
        public Punto SentTras { get; set; }
        #endregion

        public IFigura3D()
        {
            AngOrg = new Punto(0);
            AngObj = new Punto(0);
            CMasa = new Punto(0);
            Origen = new Punto(0);
            Esc = new Punto(1);
            SentTras = new Punto(0);
        }

        public abstract void Draw();
        public virtual void Rotar(float auAngX, float auAngY, float auAngZ)
        {
            AngOrg.X += auAngX;
            AngOrg.Y += auAngY;
            AngOrg.Z += auAngZ;
        }
        public virtual void Escalar(float auEscX, float auEscY, float auEscZ)
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
        }

        public virtual void Trasladar(float auX, float auY, float auZ)
        {
            Origen.X += auX;
            Origen.Y += auY;
            Origen.Z += auZ;
        }

        public virtual void Traslaciones()
        {
            Origen.X = SentTras.X != 0 ? Origen.X += 0.1f * SentTras.X : Origen.X;
            Origen.Y = SentTras.Y != 0 ? Origen.Y += 0.1f * SentTras.Y : Origen.Y;
            Origen.Z = SentTras.Z != 0 ? Origen.Z += 0.1f * SentTras.Z : Origen.Z;
        }

        public void ActiveTraslacion(int sentido, int eje)
        {
            SentTras.X = eje == IFigura3D.EJE_X ? -sentido : SentTras.X;
            SentTras.Y = eje == IFigura3D.EJE_Y ? sentido : SentTras.Y;
            SentTras.Z = eje == IFigura3D.EJE_Z ? sentido : SentTras.Z;
        }

        public abstract void DoOperations();
        public void Restart()
        {
            AngOrg.X = AngOrg.Y = AngOrg.Z = 0;
            Origen.X = Origen.Y = Origen.Z = 0;
            Esc.X = Esc.Y = Esc.Z = 1;
        }
    }
}
