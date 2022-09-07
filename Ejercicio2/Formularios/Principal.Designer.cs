namespace Ejercicio2
{
    partial class FrmEjercicio2
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEjercicio2));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmSalirApp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmNuevoArticulo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEditarArticulo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmNuevaFactura = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBajaLogica = new System.Windows.Forms.ToolStripMenuItem();
            this.tspdReportes = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.toolStripDropDownButton3,
            this.tspdReportes});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(531, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSalirApp});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(64, 22);
            this.toolStripDropDownButton1.Text = "Archivo";
            // 
            // tsmSalirApp
            // 
            this.tsmSalirApp.Name = "tsmSalirApp";
            this.tsmSalirApp.Size = new System.Drawing.Size(180, 22);
            this.tsmSalirApp.Text = "Salir";
            this.tsmSalirApp.Click += new System.EventHandler(this.tsmSalirApp_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmNuevoArticulo,
            this.tsmEditarArticulo});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(65, 22);
            this.toolStripDropDownButton2.Text = "Articulo";
            // 
            // tsmNuevoArticulo
            // 
            this.tsmNuevoArticulo.Name = "tsmNuevoArticulo";
            this.tsmNuevoArticulo.Size = new System.Drawing.Size(114, 22);
            this.tsmNuevoArticulo.Text = "Nuevo";
            // 
            // tsmEditarArticulo
            // 
            this.tsmEditarArticulo.Name = "tsmEditarArticulo";
            this.tsmEditarArticulo.Size = new System.Drawing.Size(114, 22);
            this.tsmEditarArticulo.Text = "Editar";
            // 
            // toolStripDropDownButton3
            // 
            this.toolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmNuevaFactura,
            this.tsmBajaLogica});
            this.toolStripDropDownButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton3.Image")));
            this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            this.toolStripDropDownButton3.Size = new System.Drawing.Size(69, 22);
            this.toolStripDropDownButton3.Text = "Facturas";
            // 
            // tsmNuevaFactura
            // 
            this.tsmNuevaFactura.Name = "tsmNuevaFactura";
            this.tsmNuevaFactura.Size = new System.Drawing.Size(180, 22);
            this.tsmNuevaFactura.Text = "Nuevo";
            this.tsmNuevaFactura.Click += new System.EventHandler(this.tsmNuevaFactura_Click);
            // 
            // tsmBajaLogica
            // 
            this.tsmBajaLogica.Name = "tsmBajaLogica";
            this.tsmBajaLogica.Size = new System.Drawing.Size(180, 22);
            this.tsmBajaLogica.Text = "Baja Logica";
            this.tsmBajaLogica.Click += new System.EventHandler(this.tsmBajaLogica_Click);
            // 
            // tspdReportes
            // 
            this.tspdReportes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tspdReportes.Image = ((System.Drawing.Image)(resources.GetObject("tspdReportes.Image")));
            this.tspdReportes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspdReportes.Name = "tspdReportes";
            this.tspdReportes.Size = new System.Drawing.Size(74, 22);
            this.tspdReportes.Text = "Reportes";
            this.tspdReportes.Click += new System.EventHandler(this.tspdReportes_Click);
            // 
            // FrmEjercicio2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 142);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FrmEjercicio2";
            this.Text = "Principal";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripMenuItem tsmNuevaFactura;
        private System.Windows.Forms.ToolStripMenuItem tsmBajaLogica;
        private System.Windows.Forms.ToolStripMenuItem tsmSalirApp;
        private System.Windows.Forms.ToolStripMenuItem tsmNuevoArticulo;
        private System.Windows.Forms.ToolStripMenuItem tsmEditarArticulo;
        private System.Windows.Forms.ToolStripDropDownButton tspdReportes;
    }
}

