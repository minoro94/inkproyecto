﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SISTEMA.TATTOO;

namespace SISTEMA.WINFORMS.TATTOO
{
    public partial class frmTATEstadoCitaINS : Form
    {
        public frmTATEstadoCitaINS()
        {
            InitializeComponent();
        }

        #region OBJETOS
        public TATEstadoCita.strTATEstadoCita str = new TATEstadoCita.strTATEstadoCita();
        TATEstadoCita TABLA = new TATEstadoCita();
        public string USUARIO = "";
        #endregion

        #region ENABLE BUTTONS
        public void EnableButtons()
        {
            if(txtNombreEstadoCita.Text.Trim() == "" || txtDescripcion.Text.Trim() == "")
            {
                btnAceptar.Enabled = false;
                btnAplicar.Enabled = false;
                lblMnesaje1.Visible = true;
                txtMensaje2.Visible = true;
            }
            else
            {
                btnAceptar.Enabled = true;
                btnAplicar.Enabled = true;
                lblMnesaje1.Visible = false;
                txtMensaje2.Visible = false;
            }
        }
        #endregion

        #region LOAD
        private void frmTATEstadoCitaINS_Load(object sender, EventArgs e)
        {
            EnableButtons();
        }
        #endregion

        #region TEXT CHANGED
        private void txtNombreEstadoCita_TextChanged(object sender, EventArgs e)
        {
            if(txtNombreEstadoCita.Text.Trim() != "")
            {
                Obligatorio1.Visible = false;
            }
            else
            {
                Obligatorio1.Visible = true;
            }
            EnableButtons();
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            if(txtDescripcion.Text.Trim() != "")
            {
                Obligatorio2.Visible = false;
            }
            else
            {
                Obligatorio2.Visible = true;
            }
            EnableButtons();
        }

        #endregion

        #region FORM CLOSING
        private void frmTATEstadoCitaINS_FormClosing(object sender, FormClosingEventArgs e)
        {
            TABLA.Dispose();
        }
        #endregion

        #region CLOSE
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region BOTON CANCELAR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region BOTON APLICAR
        private void btnAplicar_Click(object sender, EventArgs e)
        {
            str.NombreEstadoCita = txtNombreEstadoCita.Text.Trim();
            str.Descripcion = txtDescripcion.Text.Trim();
            str.USUARIO = USUARIO;

            bool Agregado = TABLA.DAO(ref str, 1);
            if (Agregado)
            {
                MessageBox.Show(this, "Agregado Correctamente", "Operacion Correcta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.Yes;
                txtNombreEstadoCita.Clear();
                txtDescripcion.Clear();
            }
            else
            {
                MessageBox.Show(this, "Ha Ocurrido Un Error", "Operacion Fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                return;
            }
        }
        #endregion

        #region BOTON ACEPTAR
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            str.NombreEstadoCita = txtNombreEstadoCita.Text.Trim();
            str.Descripcion = txtDescripcion.Text.Trim();
            str.USUARIO = USUARIO;

            bool Agregado = TABLA.DAO(ref str, 1);

            if (Agregado)
            {
                MessageBox.Show(this, "Agregado Correctamente", "Operacion Correcta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(this, "Ha Ocurrido Un Error", "Operacion Fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                return;
            }
        }
        #endregion
    }
}
