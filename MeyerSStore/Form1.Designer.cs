
namespace MeyerSStore
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelCursor = new System.Windows.Forms.Panel();
            this.buttonSalir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonConfigurar = new System.Windows.Forms.Button();
            this.buttonAgregar = new System.Windows.Forms.Button();
            this.buttonInventario = new System.Windows.Forms.Button();
            this.buttonVender = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.esperaControl = new MeyerSStore.EsperaControl();
            this.configurarControl = new MeyerSStore.ConfigurarControl();
            this.vender = new MeyerSStore.VenderControl(this, configurarControl, esperaControl);
            this.agregar = new MeyerSStore.AgregarControl(this, configurarControl, esperaControl);
            this.inventario = new MeyerSStore.InventarioControl(this);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.panelCursor);
            this.panel1.Controls.Add(this.buttonSalir);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.buttonConfigurar);
            this.panel1.Controls.Add(this.buttonAgregar);
            this.panel1.Controls.Add(this.buttonInventario);
            this.panel1.Controls.Add(this.buttonVender);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 450);
            this.panel1.TabIndex = 4;
            // 
            // panelCursor
            // 
            this.panelCursor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.panelCursor.Location = new System.Drawing.Point(0, 83);
            this.panelCursor.Name = "panelCursor";
            this.panelCursor.Size = new System.Drawing.Size(10, 60);
            this.panelCursor.TabIndex = 6;
            // 
            // buttonSalir
            // 
            this.buttonSalir.FlatAppearance.BorderSize = 0;
            this.buttonSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSalir.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonSalir.ForeColor = System.Drawing.Color.White;
            this.buttonSalir.Location = new System.Drawing.Point(11, 347);
            this.buttonSalir.Name = "buttonSalir";
            this.buttonSalir.Size = new System.Drawing.Size(188, 60);
            this.buttonSalir.TabIndex = 11;
            this.buttonSalir.Text = "Salir";
            this.buttonSalir.UseVisualStyleBackColor = true;
            this.buttonSalir.Click += new System.EventHandler(this.buttonSalir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.label2.Location = new System.Drawing.Point(28, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 29);
            this.label2.TabIndex = 10;
            this.label2.Text = "Meyer\'s Store";
            // 
            // buttonConfigurar
            // 
            this.buttonConfigurar.FlatAppearance.BorderSize = 0;
            this.buttonConfigurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfigurar.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonConfigurar.ForeColor = System.Drawing.Color.White;
            this.buttonConfigurar.Location = new System.Drawing.Point(11, 281);
            this.buttonConfigurar.Name = "buttonConfigurar";
            this.buttonConfigurar.Size = new System.Drawing.Size(188, 60);
            this.buttonConfigurar.TabIndex = 9;
            this.buttonConfigurar.Text = "Configurar";
            this.buttonConfigurar.UseVisualStyleBackColor = true;
            this.buttonConfigurar.Click += new System.EventHandler(this.buttonConfigurar_Click);
            // 
            // buttonAgregar
            // 
            this.buttonAgregar.FlatAppearance.BorderSize = 0;
            this.buttonAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAgregar.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonAgregar.ForeColor = System.Drawing.Color.White;
            this.buttonAgregar.Location = new System.Drawing.Point(11, 149);
            this.buttonAgregar.Name = "buttonAgregar";
            this.buttonAgregar.Size = new System.Drawing.Size(188, 60);
            this.buttonAgregar.TabIndex = 8;
            this.buttonAgregar.Text = "Agregar";
            this.buttonAgregar.UseVisualStyleBackColor = true;
            this.buttonAgregar.Click += new System.EventHandler(this.buttonAgregar_Click);
            // 
            // buttonInventario
            // 
            this.buttonInventario.FlatAppearance.BorderSize = 0;
            this.buttonInventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInventario.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonInventario.ForeColor = System.Drawing.Color.White;
            this.buttonInventario.Location = new System.Drawing.Point(11, 215);
            this.buttonInventario.Name = "buttonInventario";
            this.buttonInventario.Size = new System.Drawing.Size(188, 60);
            this.buttonInventario.TabIndex = 7;
            this.buttonInventario.Text = "Inventario";
            this.buttonInventario.UseVisualStyleBackColor = true;
            this.buttonInventario.Click += new System.EventHandler(this.buttonInventario_Click);
            // 
            // buttonVender
            // 
            this.buttonVender.FlatAppearance.BorderSize = 0;
            this.buttonVender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVender.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonVender.ForeColor = System.Drawing.Color.White;
            this.buttonVender.Location = new System.Drawing.Point(10, 83);
            this.buttonVender.Name = "buttonVender";
            this.buttonVender.Size = new System.Drawing.Size(188, 60);
            this.buttonVender.TabIndex = 6;
            this.buttonVender.Text = "Vender";
            this.buttonVender.UseVisualStyleBackColor = true;
            this.buttonVender.Click += new System.EventHandler(this.buttonVender_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 10);
            this.panel2.TabIndex = 5;
            // 
            // esperaControl
            // 
            this.esperaControl.Location = new System.Drawing.Point(208, 16);
            this.esperaControl.Name = "esperaControl";
            this.esperaControl.Size = new System.Drawing.Size(584, 422);
            this.esperaControl.TabIndex = 0;
            // 
            // vender
            // 
            this.vender.BackColor = System.Drawing.Color.White;
            this.vender.Location = new System.Drawing.Point(208, 16);
            this.vender.Name = "vender";
            this.vender.Size = new System.Drawing.Size(584, 422);
            this.vender.TabIndex = 9;
            // 
            // inventario
            // 
            this.inventario.BackColor = System.Drawing.Color.White;
            this.inventario.Location = new System.Drawing.Point(208, 16);
            this.inventario.Name = "inventario";
            this.inventario.Size = new System.Drawing.Size(584, 422);
            this.inventario.TabIndex = 9;
            // 
            // agregar
            // 
            this.agregar.BackColor = System.Drawing.Color.White;
            this.agregar.Location = new System.Drawing.Point(208, 16);
            this.agregar.Name = "agregar";
            this.agregar.Size = new System.Drawing.Size(584, 422);
            this.agregar.TabIndex = 9;
            // 
            // configurarControl
            // 
            this.configurarControl.BackColor = System.Drawing.Color.White;
            this.configurarControl.Location = new System.Drawing.Point(208, 16);
            this.configurarControl.Name = "configurarControl";
            this.configurarControl.Size = new System.Drawing.Size(584, 422);
            this.configurarControl.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.esperaControl);
            this.Controls.Add(this.inventario);
            this.Controls.Add(this.agregar);
            this.Controls.Add(this.configurarControl);
            this.Controls.Add(this.vender);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonConfigurar;
        private System.Windows.Forms.Button buttonAgregar;
        private System.Windows.Forms.Button buttonInventario;
        private System.Windows.Forms.Button buttonVender;
        private System.Windows.Forms.Button buttonSalir;
        private System.Windows.Forms.Panel panelCursor;
        private InventarioControl inventario;
        private AgregarControl agregar;
        private VenderControl vender;
        private EsperaControl esperaControl;
        private ConfigurarControl configurarControl;
    }
}

