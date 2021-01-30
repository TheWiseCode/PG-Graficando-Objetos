
using Microsoft.VisualBasic;
using OpenTK.Graphics.OpenGL;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace PGrafica
{
    public partial class Form1 : Form
    {
        #region Atributos
        private Escenario escenario;
        private Camara camara;
        private Color color;
        private double left, right, bottom, top, zNear, zFar;
        #endregion

        #region Constructores
        public Form1()
        {
            InitializeComponent();
            escenario = new Escenario();
            camara = new Camara();
            color = Color.DarkCyan;
            btnFondo.BackColor = color;
            comboOperar.SelectedIndex = 0;
            comboAgregar.SelectedIndex = 0;
            Init();
        }

        private void Init()
        {
            int v = 3;
            int w = -10;
            left = -v;
            right = v;
            top = v;
            bottom = -v;
            zNear = w;
            zFar = -w;
            this.textRot.Text = camara.AngX.ToString() + "," + camara.AngY.ToString() + "," + camara.AngZ.ToString();
            this.textTras.Text = camara.TlsX.ToString() + "," + camara.TlsY.ToString() + "," + camara.TlsZ.ToString();
            this.textScala.Text = camara.Scale.ToString();
        }

        public void AddObjetos()
        {
            try
            {
                float l = 1f, a = 1.6f, h = 0.8f, g = 0.1f, r = 0.05f;
                float xm = 0.3f, ym = 0.3f, zm = 0;
                float xc = xm + a / 2, yc = ym + l / 2, zc = h;
                Mesa mes = new Mesa(new Punto(xc, yc, zc), new Dim(l, a, h), g, Color.SaddleBrown);
                //mes = new Mesa();
                escenario.AddObject(mes, "Mesa");
                comboOperar.Items.Add("Mesa");
                comboEliminar.Items.Add("Mesa");
                //-------------------------------
                float sep = 0.3f;
                float h1 = 0.6f, h2 = h1 * 2;
                float gr = 0.075f, lg = 0.6f;
                float xs = xc, ys = yc - sep, zs = zm;
                Silla sill = new Silla(new Punto(xs, ys, h1), lg, gr, h1, h2, Color.DarkBlue);
                escenario.AddObject(sill, "Silla");
                comboOperar.Items.Add("Silla");
                comboEliminar.Items.Add("Silla");
                //-------------------------------
                float sepR = 0.01f;
                float gExt = 0.1f, hPier = 0.3f, lBra = 0.25f;
                float lBd = 0.2f, aBd = 0.4f, hBd = 0.6f;
                float lHd = 0.3f, aHd = 0.3f, hHd = 0.3f;
                float xr = xc, yr = yc, zr = zc + (2 * sepR) + (2 * hPier) + (hBd / 2);
                Robot robo = new Robot(new Punto(xr, yr, zr), new Dim(lBd, aBd, hBd), new Dim(lHd), hPier, lBra, gExt,
                    Color.DarkGoldenrod, Color.DarkGray);
                escenario.AddObject(robo, "Robot");
                comboOperar.Items.Add("Robot");
                comboEliminar.Items.Add("Robot");
                gLControl.Invalidate();
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region MetodosOpenGL
        private void GLControl_Load(object sender, EventArgs e)
        {
            GL.ClearColor(color);
            GL.Enable(EnableCap.DepthTest);
            //gLControl.Invalidate();
        }

        private void GLControl_Resize(object sender, EventArgs e)
        {

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Viewport(0, 0, gLControl.Width, gLControl.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(left, right, bottom, top, zNear, zFar);
            GL.MatrixMode(MatrixMode.Modelview);
            gLControl.Invalidate();
        }

        private void GLControl_Paint(object sender, PaintEventArgs e)
        {
            GL.ClearColor(color);
            gLControl.MakeCurrent();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            string objeto = comboOperar.SelectedItem.ToString();
            if (richTextBox1 != null && escenario.objects.ContainsKey("Robot"))
            {
                Robot rb = (Robot)escenario.objects["Robot"];
                richTextBox1.Text = "Pierna Izq: " + rb.angFlexPI[0] + "," + rb.angFlexPI[1] + "\n" +
                "Pierna Der: " + rb.angFlexPD[0] + "," + rb.angFlexPD[1] + "\n";
            }
            escenario.Traslaciones(objeto);
            escenario.DoOperations(objeto, camara);
            //escenario.DoOperations();
            GL.Flush();
            gLControl.SwapBuffers();
            //gLControl.Invalidate();
        }
        #endregion

        #region EventosRaton
        private void gLControl_MouseDown(object sender, MouseEventArgs e)
        {
            camara.MouseDown(e);
            gLControl.Invalidate();
        }

        private void gLControl_MouseMove(object sender, MouseEventArgs e)
        {
            camara.MouseMove(e);
            gLControl.Invalidate();
            this.textRot.Text = camara.AngX.ToString() + "," + camara.AngY.ToString() + "," + camara.AngZ.ToString();
            this.textTras.Text = camara.TlsX.ToString() + "," + camara.TlsY.ToString() + "," + camara.TlsZ.ToString();
        }

        private void gLControl_MouseWheel(object sender, MouseEventArgs e)
        {
            camara.MouseWheel(e);
            gLControl.Invalidate();
            this.textScala.Text = camara.Scale.ToString();
        }
        #endregion

        #region EventosTeclado
        private void gLControl_KeyDown(object sender, KeyEventArgs e)
        {
            string objeto = comboOperar.SelectedItem.ToString();
            if (e.KeyCode == Keys.A)
            {
                escenario.TrasladarThread(1, IFigura3D.EJE_X, objeto);
                this.richTextBox1.Text += "Down A\n";
            }
            if (e.KeyCode == Keys.D)
            {
                escenario.TrasladarThread(-1, IFigura3D.EJE_X, objeto);
                this.richTextBox1.Text += "Down D\n";
            }
            if (e.KeyCode == Keys.W)
            {
                escenario.TrasladarThread(1, IFigura3D.EJE_Y, objeto);
                this.richTextBox1.Text += "Down W\n";
            }
            if (e.KeyCode == Keys.S)
            {
                escenario.TrasladarThread(-1, IFigura3D.EJE_Y, objeto);
                this.richTextBox1.Text += "Down D\n";
            }
            if (e.KeyCode == Keys.E)
            {
                escenario.TrasladarThread(1, IFigura3D.EJE_Z, objeto);
                this.richTextBox1.Text += "Down E\n";
            }
            if (e.KeyCode == Keys.Q)
            {
                escenario.TrasladarThread(-1, IFigura3D.EJE_Z, objeto);
                this.richTextBox1.Text += "Down Q\n";
            }
            gLControl.Invalidate();
        }

        private void gLControl_KeyUp(object sender, KeyEventArgs e)
        {
            string objeto = comboOperar.SelectedItem.ToString();
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.D)
            {
                this.richTextBox1.Text += "UP " + e.KeyCode + "\n";
                escenario.TrasladarThread(0, IFigura3D.EJE_X, objeto);
            }
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.S)
            {
                this.richTextBox1.Text += "UP " + e.KeyCode + "\n";
                escenario.TrasladarThread(0, IFigura3D.EJE_Y, objeto);
            }
            if (e.KeyCode == Keys.E || e.KeyCode == Keys.Q)
            {
                this.richTextBox1.Text += "UP " + e.KeyCode + "\n";
                escenario.TrasladarThread(0, IFigura3D.EJE_Z, objeto);
            }
        }

        #endregion

        #region MetodosAñadirFiguras
        private void AddMesa(string clave)
        {
            float an = float.Parse(Interaction.InputBox("Ancho de la mesa con limites > 0f y <= 2f"
                    , "Ancho de la Mesa", "1", 100, 100));
            float lg = float.Parse(Interaction.InputBox("Largo de la mesa con limites > 0f y <= 2f"
                    , "Alto de la Mesa", "1", 100, 100));
            float al = float.Parse(Interaction.InputBox("Alto de la mesa con limites > 0f y <= 2f"
                    , "Largo de la Mesa", "1", 100, 100));
            float gr = float.Parse(Interaction.InputBox("Grosor de la mesa con limites > 0f y <= 0.2f"
                    , "Grosor de las patas", "0.1", 100, 100));
            MessageBox.Show("Escoja el color de la mesa");
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                Color cl = cd.Color;
                //Color cl = Color.Red;
                Mesa m1 = new Mesa(new Punto(0), new Dim(lg, an, al), gr, cl);
                escenario.AddObject(m1, clave);
            }
        }

        private void AddSilla(string clave)
        {
            float an = float.Parse(Interaction.InputBox("Largo y Ancho de la silla con limites > 0f y <= 2f"
                    , "Ancho y Largo de la Silla", "0.6", 100, 100));
            float hb = float.Parse(Interaction.InputBox("Altura hasta la base de la silla con limites > 0f y <= 2f"
                    , "Altura 1 de la Sila", "0.6", 100, 100));
            float ht = float.Parse(Interaction.InputBox("Altura total silla la mesa con limites > 0f y <= 2f"
                    , "Altura 2 de la Silla", "1.2", 100, 100));
            float gr = float.Parse(Interaction.InputBox("Grosor de la silla con limites > 0f y <= 0.2f"
                    , "Grosor de las patas", "0.075", 100, 100));
            MessageBox.Show("Escoja el color de la silla");
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                Color cl = cd.Color;
                Silla s1 = new Silla(new Punto(0), an, gr, hb, ht, cl);
                escenario.AddObject(s1, clave);
            }
        }

        private void AddRobot(string clave)
        {
            float lgT = float.Parse(Interaction.InputBox("Largo del Tronco del Robot con limites > 0f y <= 2f"
                    , "Alto Tronco", "0.2", 100, 100));
            float anT = float.Parse(Interaction.InputBox("Ancho del Tronco del Robot con limites > 0f y <= 2f"
                    , "Ancho Tronco", "0.4", 100, 100));
            float alT = float.Parse(Interaction.InputBox("Alto del Tronco del Robot con limites > 0f y <= 2f"
                    , "Largo Tronco", "0.6", 100, 100));
            float lgC = float.Parse(Interaction.InputBox("Largo de la Cabeza del Robot con limites > 0f y <= 2f"
                    , "Alto Cabeza", "0.3", 100, 100));
            float anC = float.Parse(Interaction.InputBox("Ancho de la Cabeza del Robot con limites > 0f y <= 2f"
                    , "Ancho Cabeza", "0.3", 100, 100));
            float alC = float.Parse(Interaction.InputBox("Alto de la Cabeza del Robot con limites > 0f y <= 2f"
                    , "Largo Cabeza", "0.3", 100, 100));
            float lBraz = float.Parse(Interaction.InputBox("Largo Brazos del Robot con limites > 0f y <= 2f"
                    , "Largo Brazos", "0.3", 100, 100));
            float lPiern = float.Parse(Interaction.InputBox("Largo Piernas del Robot con limites > 0f y <= 2f"
                    , "Largo Piernas", "0.25", 100, 100));
            float gr = float.Parse(Interaction.InputBox("Grosor de las Extremidades con limites > 0f y <= 0.2f"
                    , "Grosor de las extremidades", "0.1", 100, 100));
            MessageBox.Show("Escoja el color primario Robot");
            ColorDialog cc = new ColorDialog();
            if (cc.ShowDialog() == DialogResult.OK)//Color de Piel
            {
                Color colP = cc.Color;
                MessageBox.Show("Escoja el color secundario del Robot");
                ColorDialog cr = new ColorDialog();
                if (cc.ShowDialog() == DialogResult.OK)//Color de ropa
                {
                    Color colR = cr.Color;
                    Robot rb = new Robot(new Punto(0), new Dim(lgT, anT, alT), new Dim(lgC, anC, alC),
                        lPiern, lBraz, gr, colP, colR);
                    escenario.AddObject(rb, clave);
                }
            }
        }

        #endregion

        #region EventosClick
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string objeto = comboAgregar.SelectedItem.ToString();
            string clave = Interaction.InputBox("Introduzca la clave a guardarse para el objeto 3D seleccionado"
                , "Nombre del objeto", "", 100, 100);
            if (!escenario.ClaveValida(clave))
            {
                MessageBox.Show("Clave no valida");
                return;
            }
            try
            {
                if (objeto == "Mesa")
                {
                    AddMesa(clave);
                }
                else if (objeto == "Silla")
                {
                    AddSilla(clave);
                }
                else if (objeto == "Robot")
                {
                    AddRobot(clave);
                }
                comboOperar.Items.Add(clave);
                comboEliminar.Items.Add(clave);
                gLControl.Invalidate();
            }
            catch (Exception)
            {
                MessageBox.Show("Surgio un error inesperado");
            }
        }

        private void btnFondo_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                color = cd.Color;
                int contrario = ~color.ToArgb();
                btnFondo.BackColor = color;
                btnFondo.ForeColor = Color.FromArgb(contrario);
                gLControl.Invalidate();
            }

        }

        private void btnAddObjetos_Click(object sender, EventArgs e)
        {
            AddObjetos();
            comboEliminar.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Robot rb = (Robot)escenario.objects["Robot"];
            RobotAnimations le1 = new RobotAnimations(gLControl, rb, true, 60, 3 * 1000);
            RobotAnimations le2 = new RobotAnimations(gLControl, rb, false, -90, 3 * 1000);
            RobotAnimations le3 = new RobotAnimations(gLControl, rb, false, -40, 3 * 1000);
            RobotAnimations le4 = new RobotAnimations(gLControl, rb, 0.5f, (long)(1.5 * 1000));
            Thread h1 = new Thread(le1.LevaRodilla);
            Thread h2 = new Thread(le2.LevaBrazoComp);
            Thread h3 = new Thread(le3.LevaRodilla);
            Thread h4 = new Thread(le4.Caminar);
            //Thread h2 = new Thread(le2.LevantarBrazo);
            //h1.Start();
            //h2.Start();
            //h3.Start();
            h4.Start();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (comboEliminar.Items.Count > 0)
            {
                string objeto = comboEliminar.SelectedItem.ToString();
                escenario.RemoveObject(objeto);
                comboOperar.Items.Remove(objeto);
                comboEliminar.Items.Remove(objeto);
                comboOperar.SelectedIndex = 0;
                if (comboEliminar.Items.Count > 0)
                {
                    comboEliminar.SelectedIndex = 0;
                }
                gLControl.Invalidate();
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            //            GL.LoadIdentity();
            escenario.Restart();
            gLControl.Invalidate();
        }
        #endregion

        #region EventosTrackBar
        private void trackEscala_Scroll(object sender, EventArgs e)
        {
            float escX = trackEscX.Value / 10f;
            float escY = trackEscY.Value / 10f;
            float escZ = trackEscZ.Value / 10f;
            string objeto = comboOperar.SelectedItem.ToString();
            escenario.SetEscala(escX, escY, escZ, objeto);
            gLControl.Invalidate();
        }

        private void trackAngulos_Scroll(object sender, EventArgs e)
        {
            float angX = trackAngX.Value;
            float angY = trackAngY.Value;
            float angZ = trackAngZ.Value;
            string objeto = comboOperar.SelectedItem.ToString();
            if (rdBtnRotOrigen.Checked)
            {
                escenario.SetAngulosOrigen(angX, angY, angZ, objeto);
            }
            else
            {
                escenario.SetAngulosObjeto(angX, angY, angZ, objeto);
            }
            gLControl.Invalidate();
        }

        private void trackTraslacion_Scroll(object sender, EventArgs e)
        {
            float x = trackTrasX.Value / 20f;
            float y = trackTrasY.Value / 20f;
            float z = trackTrasZ.Value / 20f;
            string objeto = comboOperar.SelectedItem.ToString();
            if (rdBtnTrasOrigen.Checked)
            {
                escenario.SetPuntoOrigen(x, y, z, objeto);
            }
            else
            {
                escenario.SetPuntoObjeto(x, y, z, objeto);
            }
            gLControl.Invalidate();
        }
        #endregion
    }
}
