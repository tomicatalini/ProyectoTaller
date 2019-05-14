namespace AppTerminal.Vista
{
    public partial class FormPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonBlanqueoPIN = new System.Windows.Forms.Button();
            this.buttonSaldo = new System.Windows.Forms.Button();
            this.buttonUltimosMovimientos = new System.Windows.Forms.Button();
            this.buttonSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonBlanqueoPIN
            // 
            this.buttonBlanqueoPIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBlanqueoPIN.Location = new System.Drawing.Point(12, 63);
            this.buttonBlanqueoPIN.Name = "buttonBlanqueoPIN";
            this.buttonBlanqueoPIN.Size = new System.Drawing.Size(326, 48);
            this.buttonBlanqueoPIN.TabIndex = 0;
            this.buttonBlanqueoPIN.Text = "Blanqueo PIN";
            this.buttonBlanqueoPIN.UseVisualStyleBackColor = true;
            this.buttonBlanqueoPIN.Click += new System.EventHandler(this.ButtonBlanqueoPIN_Click);
            // 
            // buttonSaldo
            // 
            this.buttonSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaldo.Location = new System.Drawing.Point(12, 151);
            this.buttonSaldo.Name = "buttonSaldo";
            this.buttonSaldo.Size = new System.Drawing.Size(326, 48);
            this.buttonSaldo.TabIndex = 1;
            this.buttonSaldo.Text = "Saldo cuenta corriente";
            this.buttonSaldo.UseVisualStyleBackColor = true;
            this.buttonSaldo.Click += new System.EventHandler(this.ButtonSaldo_Click);
            // 
            // buttonUltimosMovimientos
            // 
            this.buttonUltimosMovimientos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUltimosMovimientos.Location = new System.Drawing.Point(12, 245);
            this.buttonUltimosMovimientos.Name = "buttonUltimosMovimientos";
            this.buttonUltimosMovimientos.Size = new System.Drawing.Size(326, 48);
            this.buttonUltimosMovimientos.TabIndex = 2;
            this.buttonUltimosMovimientos.Text = "Ultimos movimientos";
            this.buttonUltimosMovimientos.UseVisualStyleBackColor = true;
            this.buttonUltimosMovimientos.Click += new System.EventHandler(this.ButtonUltimosMovimientos_Click);
            // 
            // buttonSalir
            // 
            this.buttonSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSalir.Location = new System.Drawing.Point(12, 391);
            this.buttonSalir.Name = "buttonSalir";
            this.buttonSalir.Size = new System.Drawing.Size(326, 35);
            this.buttonSalir.TabIndex = 3;
            this.buttonSalir.Text = "Salir";
            this.buttonSalir.UseVisualStyleBackColor = true;
            this.buttonSalir.Click += new System.EventHandler(this.ButtonSalir_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 438);
            this.Controls.Add(this.buttonSalir);
            this.Controls.Add(this.buttonUltimosMovimientos);
            this.Controls.Add(this.buttonSaldo);
            this.Controls.Add(this.buttonBlanqueoPIN);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(366, 477);
            this.MinimumSize = new System.Drawing.Size(366, 477);
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VentanaPrincipal";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonBlanqueoPIN;
        private System.Windows.Forms.Button buttonSaldo;
        private System.Windows.Forms.Button buttonUltimosMovimientos;
        private System.Windows.Forms.Button buttonSalir;
    }
}