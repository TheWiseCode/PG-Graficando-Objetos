using OpenTK;

namespace PGrafica
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        public GLControl gLControl;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.gLControl = new OpenTK.GLControl();
            this.comboOperar = new System.Windows.Forms.ComboBox();
            this.btnRestart = new System.Windows.Forms.Button();
            this.textScala = new System.Windows.Forms.TextBox();
            this.textRot = new System.Windows.Forms.TextBox();
            this.textTras = new System.Windows.Forms.TextBox();
            this.trackAngX = new System.Windows.Forms.TrackBar();
            this.trackAngZ = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.trackAngY = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.trackEscZ = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.trackEscY = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.trackEscX = new System.Windows.Forms.TrackBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.rdBtnTrasObjeto = new System.Windows.Forms.RadioButton();
            this.rdBtnTrasOrigen = new System.Windows.Forms.RadioButton();
            this.trackTrasZ = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.trackTrasY = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.trackTrasX = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rdBtnRotObjeto = new System.Windows.Forms.RadioButton();
            this.rdBtnRotOrigen = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.comboAgregar = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnFondo = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.comboEliminar = new System.Windows.Forms.ComboBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.cBoxAnimacion = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackAngX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackAngZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackAngY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackEscZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackEscY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackEscX)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackTrasZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackTrasY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackTrasX)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // gLControl
            // 
            this.gLControl.BackColor = System.Drawing.Color.Black;
            this.gLControl.Location = new System.Drawing.Point(420, 12);
            this.gLControl.Name = "gLControl";
            this.gLControl.Size = new System.Drawing.Size(500, 500);
            this.gLControl.TabIndex = 0;
            this.gLControl.VSync = true;
            this.gLControl.Load += new System.EventHandler(this.GLControl_Load);
            this.gLControl.Paint += new System.Windows.Forms.PaintEventHandler(this.GLControl_Paint);
            this.gLControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gLControl_KeyDown);
            this.gLControl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gLControl_KeyUp);
            this.gLControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gLControl_MouseDown);
            this.gLControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gLControl_MouseMove);
            this.gLControl.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.gLControl_MouseWheel);
            this.gLControl.Resize += new System.EventHandler(this.GLControl_Resize);
            // 
            // comboOperar
            // 
            this.comboOperar.DisplayMember = "0";
            this.comboOperar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboOperar.FormattingEnabled = true;
            this.comboOperar.Items.AddRange(new object[] {
            "Escenario"});
            this.comboOperar.Location = new System.Drawing.Point(12, 28);
            this.comboOperar.MaxDropDownItems = 10;
            this.comboOperar.Name = "comboOperar";
            this.comboOperar.Size = new System.Drawing.Size(170, 21);
            this.comboOperar.TabIndex = 1;
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(12, 57);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(170, 25);
            this.btnRestart.TabIndex = 2;
            this.btnRestart.Text = "Estado Inicial";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // textScala
            // 
            this.textScala.Location = new System.Drawing.Point(197, 12);
            this.textScala.Name = "textScala";
            this.textScala.Size = new System.Drawing.Size(161, 20);
            this.textScala.TabIndex = 3;
            // 
            // textRot
            // 
            this.textRot.Location = new System.Drawing.Point(197, 38);
            this.textRot.Name = "textRot";
            this.textRot.Size = new System.Drawing.Size(161, 20);
            this.textRot.TabIndex = 4;
            // 
            // textTras
            // 
            this.textTras.Location = new System.Drawing.Point(197, 64);
            this.textTras.Name = "textTras";
            this.textTras.Size = new System.Drawing.Size(161, 20);
            this.textTras.TabIndex = 5;
            // 
            // trackAngX
            // 
            this.trackAngX.Location = new System.Drawing.Point(7, 27);
            this.trackAngX.Maximum = 360;
            this.trackAngX.Name = "trackAngX";
            this.trackAngX.RightToLeftLayout = true;
            this.trackAngX.Size = new System.Drawing.Size(384, 45);
            this.trackAngX.TabIndex = 6;
            this.trackAngX.TickFrequency = 5;
            this.trackAngX.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackAngX.Scroll += new System.EventHandler(this.trackAngulos_Scroll);
            // 
            // trackAngZ
            // 
            this.trackAngZ.Location = new System.Drawing.Point(9, 154);
            this.trackAngZ.Maximum = 360;
            this.trackAngZ.Name = "trackAngZ";
            this.trackAngZ.Size = new System.Drawing.Size(382, 45);
            this.trackAngZ.TabIndex = 11;
            this.trackAngZ.TickFrequency = 5;
            this.trackAngZ.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackAngZ.Scroll += new System.EventHandler(this.trackAngulos_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Angulo Z";
            // 
            // trackAngY
            // 
            this.trackAngY.Location = new System.Drawing.Point(9, 91);
            this.trackAngY.Maximum = 360;
            this.trackAngY.Name = "trackAngY";
            this.trackAngY.RightToLeftLayout = true;
            this.trackAngY.Size = new System.Drawing.Size(382, 45);
            this.trackAngY.TabIndex = 9;
            this.trackAngY.TickFrequency = 5;
            this.trackAngY.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackAngY.Scroll += new System.EventHandler(this.trackAngulos_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Angulo Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Angulo X";
            // 
            // trackEscZ
            // 
            this.trackEscZ.Location = new System.Drawing.Point(6, 154);
            this.trackEscZ.Maximum = 50;
            this.trackEscZ.Name = "trackEscZ";
            this.trackEscZ.RightToLeftLayout = true;
            this.trackEscZ.Size = new System.Drawing.Size(385, 45);
            this.trackEscZ.TabIndex = 11;
            this.trackEscZ.TickFrequency = 2;
            this.trackEscZ.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackEscZ.Value = 10;
            this.trackEscZ.Scroll += new System.EventHandler(this.trackEscala_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Escala Z";
            // 
            // trackEscY
            // 
            this.trackEscY.Location = new System.Drawing.Point(6, 92);
            this.trackEscY.Maximum = 50;
            this.trackEscY.Name = "trackEscY";
            this.trackEscY.RightToLeftLayout = true;
            this.trackEscY.Size = new System.Drawing.Size(385, 45);
            this.trackEscY.TabIndex = 9;
            this.trackEscY.TickFrequency = 2;
            this.trackEscY.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackEscY.Value = 10;
            this.trackEscY.Scroll += new System.EventHandler(this.trackEscala_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Escala Y";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Escala X";
            // 
            // trackEscX
            // 
            this.trackEscX.Location = new System.Drawing.Point(6, 26);
            this.trackEscX.Maximum = 50;
            this.trackEscX.Name = "trackEscX";
            this.trackEscX.RightToLeftLayout = true;
            this.trackEscX.Size = new System.Drawing.Size(385, 45);
            this.trackEscX.TabIndex = 6;
            this.trackEscX.TickFrequency = 2;
            this.trackEscX.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackEscX.Value = 10;
            this.trackEscX.Scroll += new System.EventHandler(this.trackEscala_Scroll);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 90);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(402, 261);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.rdBtnTrasObjeto);
            this.tabPage3.Controls.Add(this.rdBtnTrasOrigen);
            this.tabPage3.Controls.Add(this.trackTrasZ);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.trackTrasY);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.trackTrasX);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(394, 235);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Traslacion";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // rdBtnTrasObjeto
            // 
            this.rdBtnTrasObjeto.AutoSize = true;
            this.rdBtnTrasObjeto.Location = new System.Drawing.Point(87, 204);
            this.rdBtnTrasObjeto.Name = "rdBtnTrasObjeto";
            this.rdBtnTrasObjeto.Size = new System.Drawing.Size(75, 17);
            this.rdBtnTrasObjeto.TabIndex = 7;
            this.rdBtnTrasObjeto.Text = "Del Objeto";
            this.rdBtnTrasObjeto.UseVisualStyleBackColor = true;
            // 
            // rdBtnTrasOrigen
            // 
            this.rdBtnTrasOrigen.AutoSize = true;
            this.rdBtnTrasOrigen.Checked = true;
            this.rdBtnTrasOrigen.Location = new System.Drawing.Point(6, 204);
            this.rdBtnTrasOrigen.Name = "rdBtnTrasOrigen";
            this.rdBtnTrasOrigen.Size = new System.Drawing.Size(75, 17);
            this.rdBtnTrasOrigen.TabIndex = 6;
            this.rdBtnTrasOrigen.TabStop = true;
            this.rdBtnTrasOrigen.Text = "Del Origen";
            this.rdBtnTrasOrigen.UseVisualStyleBackColor = true;
            // 
            // trackTrasZ
            // 
            this.trackTrasZ.Location = new System.Drawing.Point(2, 153);
            this.trackTrasZ.Maximum = 100;
            this.trackTrasZ.Minimum = -100;
            this.trackTrasZ.Name = "trackTrasZ";
            this.trackTrasZ.Size = new System.Drawing.Size(389, 45);
            this.trackTrasZ.TabIndex = 5;
            this.trackTrasZ.TickFrequency = 5;
            this.trackTrasZ.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackTrasZ.Scroll += new System.EventHandler(this.trackTraslacion_Scroll);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 137);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Coordenada Z";
            // 
            // trackTrasY
            // 
            this.trackTrasY.Location = new System.Drawing.Point(5, 89);
            this.trackTrasY.Maximum = 100;
            this.trackTrasY.Minimum = -100;
            this.trackTrasY.Name = "trackTrasY";
            this.trackTrasY.Size = new System.Drawing.Size(386, 45);
            this.trackTrasY.TabIndex = 3;
            this.trackTrasY.TickFrequency = 5;
            this.trackTrasY.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackTrasY.Scroll += new System.EventHandler(this.trackTraslacion_Scroll);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Coordenada Y";
            // 
            // trackTrasX
            // 
            this.trackTrasX.Location = new System.Drawing.Point(6, 25);
            this.trackTrasX.Maximum = 100;
            this.trackTrasX.Minimum = -100;
            this.trackTrasX.Name = "trackTrasX";
            this.trackTrasX.Size = new System.Drawing.Size(385, 45);
            this.trackTrasX.TabIndex = 1;
            this.trackTrasX.TickFrequency = 5;
            this.trackTrasX.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackTrasX.Scroll += new System.EventHandler(this.trackTraslacion_Scroll);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Coordenada X";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rdBtnRotObjeto);
            this.tabPage1.Controls.Add(this.rdBtnRotOrigen);
            this.tabPage1.Controls.Add(this.trackAngZ);
            this.tabPage1.Controls.Add(this.trackAngX);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.trackAngY);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(394, 235);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Rotacion";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rdBtnRotObjeto
            // 
            this.rdBtnRotObjeto.AutoSize = true;
            this.rdBtnRotObjeto.Location = new System.Drawing.Point(102, 205);
            this.rdBtnRotObjeto.Name = "rdBtnRotObjeto";
            this.rdBtnRotObjeto.Size = new System.Drawing.Size(87, 17);
            this.rdBtnRotObjeto.TabIndex = 23;
            this.rdBtnRotObjeto.Text = "Sobre Objeto";
            this.rdBtnRotObjeto.UseVisualStyleBackColor = true;
            // 
            // rdBtnRotOrigen
            // 
            this.rdBtnRotOrigen.AutoSize = true;
            this.rdBtnRotOrigen.Checked = true;
            this.rdBtnRotOrigen.Location = new System.Drawing.Point(9, 205);
            this.rdBtnRotOrigen.Name = "rdBtnRotOrigen";
            this.rdBtnRotOrigen.Size = new System.Drawing.Size(87, 17);
            this.rdBtnRotOrigen.TabIndex = 22;
            this.rdBtnRotOrigen.TabStop = true;
            this.rdBtnRotOrigen.Text = "Sobre Origen";
            this.rdBtnRotOrigen.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.trackEscY);
            this.tabPage2.Controls.Add(this.trackEscZ);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.trackEscX);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(394, 235);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Escalacion";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.richTextBox1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(394, 235);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Lista Animaciones";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(394, 232);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // comboAgregar
            // 
            this.comboAgregar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAgregar.FormattingEnabled = true;
            this.comboAgregar.Items.AddRange(new object[] {
            "Mesa",
            "Silla",
            "Robot"});
            this.comboAgregar.Location = new System.Drawing.Point(12, 357);
            this.comboAgregar.Name = "comboAgregar";
            this.comboAgregar.Size = new System.Drawing.Size(121, 21);
            this.comboAgregar.TabIndex = 15;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(12, 384);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(121, 23);
            this.btnAgregar.TabIndex = 16;
            this.btnAgregar.Text = "Agregar Objeto 3D";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnFondo
            // 
            this.btnFondo.Location = new System.Drawing.Point(12, 413);
            this.btnFondo.Name = "btnFondo";
            this.btnFondo.Size = new System.Drawing.Size(121, 50);
            this.btnFondo.TabIndex = 17;
            this.btnFondo.Text = "Color Fondo Escenario";
            this.btnFondo.UseVisualStyleBackColor = true;
            this.btnFondo.Click += new System.EventHandler(this.btnFondo_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Operar Sobre";
            // 
            // comboEliminar
            // 
            this.comboEliminar.BackColor = System.Drawing.SystemColors.Window;
            this.comboEliminar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEliminar.FormattingEnabled = true;
            this.comboEliminar.Location = new System.Drawing.Point(139, 357);
            this.comboEliminar.Name = "comboEliminar";
            this.comboEliminar.Size = new System.Drawing.Size(121, 21);
            this.comboEliminar.TabIndex = 19;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(139, 384);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(121, 23);
            this.btnEliminar.TabIndex = 20;
            this.btnEliminar.Text = "Eliminar Objeto 3D";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(139, 413);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "Agregar Objetos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnAddObjetos_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(266, 413);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(148, 23);
            this.button2.TabIndex = 22;
            this.button2.Text = "Correr Animaciones";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnRunAnimacion_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(266, 384);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(148, 23);
            this.button3.TabIndex = 23;
            this.button3.Text = "Añadir Animacion";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnAddAnimacion);
            // 
            // cBoxAnimacion
            // 
            this.cBoxAnimacion.BackColor = System.Drawing.SystemColors.Window;
            this.cBoxAnimacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxAnimacion.FormattingEnabled = true;
            this.cBoxAnimacion.Items.AddRange(new object[] {
            "Mover cierta distancia",
            "Trasladar al punto",
            "Rotar Objeto",
            "Rotar Origen",
            "Escalar cierta cantidad",
            "Escalar hasta"});
            this.cBoxAnimacion.Location = new System.Drawing.Point(266, 357);
            this.cBoxAnimacion.Name = "cBoxAnimacion";
            this.cBoxAnimacion.Size = new System.Drawing.Size(148, 21);
            this.cBoxAnimacion.TabIndex = 24;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(266, 470);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(148, 23);
            this.button4.TabIndex = 25;
            this.button4.Text = "Limpiar Animaciones";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnClearAnimaciones_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(266, 442);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(148, 23);
            this.button6.TabIndex = 27;
            this.button6.Text = "Eliminar animacion";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.btnDelAnimacion_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(12, 470);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(121, 23);
            this.button7.TabIndex = 28;
            this.button7.Text = "Cargar From Json";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.btnLoadJson_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(932, 535);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.cBoxAnimacion);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.comboEliminar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnFondo);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.comboAgregar);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.textTras);
            this.Controls.Add(this.textRot);
            this.Controls.Add(this.textScala);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.comboOperar);
            this.Controls.Add(this.gLControl);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Programacion Gráfica";
            ((System.ComponentModel.ISupportInitialize)(this.trackAngX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackAngZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackAngY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackEscZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackEscY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackEscX)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackTrasZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackTrasY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackTrasX)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboOperar;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.TextBox textScala;
        private System.Windows.Forms.TextBox textRot;
        private System.Windows.Forms.TextBox textTras;
        private System.Windows.Forms.TrackBar trackAngX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackAngY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trackAngZ;
        private System.Windows.Forms.TrackBar trackEscZ;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trackEscY;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar trackEscX;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar trackTrasX;
        private System.Windows.Forms.TrackBar trackTrasY;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TrackBar trackTrasZ;
        private System.Windows.Forms.ComboBox comboAgregar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnFondo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboEliminar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rdBtnRotOrigen;
        private System.Windows.Forms.RadioButton rdBtnRotObjeto;
        private System.Windows.Forms.RadioButton rdBtnTrasOrigen;
        private System.Windows.Forms.RadioButton rdBtnTrasObjeto;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox cBoxAnimacion;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
    }
}

