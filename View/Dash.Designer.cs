﻿
namespace VistoriaZN
{
    partial class Dash
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
            Nav = new Panel();
            Parceiro = new Panel();
            label3 = new Label();
            Servico = new Panel();
            label2 = new Label();
            Inicio = new Panel();
            label1 = new Label();
            BoxInfo = new Panel();
            Nav.SuspendLayout();
            Parceiro.SuspendLayout();
            Servico.SuspendLayout();
            Inicio.SuspendLayout();
            SuspendLayout();
            // 
            // Nav
            // 
            Nav.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Nav.Controls.Add(Parceiro);
            Nav.Controls.Add(Servico);
            Nav.Controls.Add(Inicio);
            Nav.Location = new Point(12, 12);
            Nav.Margin = new Padding(5);
            Nav.Name = "Nav";
            Nav.Size = new Size(1658, 124);
            Nav.TabIndex = 0;
            Nav.Paint += Nav_Paint;
            // 
            // Parceiro
            // 
            Parceiro.BackColor = SystemColors.Control;
            Parceiro.Controls.Add(label3);
            Parceiro.Location = new Point(997, 43);
            Parceiro.Name = "Parceiro";
            Parceiro.Size = new Size(239, 53);
            Parceiro.TabIndex = 3;
            Parceiro.Click += Parceiro_Click;
            Parceiro.Paint += Parceiro_Paint;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Location = new Point(58, 17);
            label3.Name = "label3";
            label3.Size = new Size(132, 20);
            label3.TabIndex = 1;
            label3.Text = "Adicionar parceiro";
            // 
            // Servico
            // 
            Servico.BackColor = SystemColors.Control;
            Servico.Controls.Add(label2);
            Servico.Location = new Point(675, 43);
            Servico.Name = "Servico";
            Servico.Size = new Size(239, 53);
            Servico.TabIndex = 2;
            Servico.Click += Servico_Click;
            Servico.Paint += Servico_Paint;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(62, 17);
            label2.Name = "label2";
            label2.Size = new Size(123, 20);
            label2.TabIndex = 2;
            label2.Text = "Adicionar serviço";
            // 
            // Inicio
            // 
            Inicio.BackColor = SystemColors.Control;
            Inicio.Controls.Add(label1);
            Inicio.Location = new Point(350, 43);
            Inicio.Name = "Inicio";
            Inicio.Size = new Size(239, 53);
            Inicio.TabIndex = 1;
            Inicio.Click += Inicio_Click;
            Inicio.Paint += Inicio_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(92, 17);
            label1.Name = "label1";
            label1.Size = new Size(45, 20);
            label1.TabIndex = 1;
            label1.Text = "Inicio";
            // 
            // BoxInfo
            // 
            BoxInfo.Location = new Point(12, 132);
            BoxInfo.Name = "BoxInfo";
            BoxInfo.Size = new Size(1658, 1196);
            BoxInfo.TabIndex = 1;
            BoxInfo.Paint += BoxInfo_Paint;
            // 
            // Dash
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1682, 1340);
            Controls.Add(Nav);
            Controls.Add(BoxInfo);
            Name = "Dash";
            Text = "Form1";
            Load += Dash_Load;
            Nav.ResumeLayout(false);
            Parceiro.ResumeLayout(false);
            Parceiro.PerformLayout();
            Servico.ResumeLayout(false);
            Servico.PerformLayout();
            Inicio.ResumeLayout(false);
            Inicio.PerformLayout();
            ResumeLayout(false);
        }


        #endregion

        private Panel Nav;
        private Panel Parceiro;
        private Panel Servico;
        private Panel Inicio;
        private Label label1;
        private Label label3;
        private Label label2;
        private Panel BoxInfo;
    }
}