using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using SISTEMA.TATTOO;
using System.Threading;

namespace SISTEMA.MAINMENU
{
    public partial class frmTATUsuariosMDF : Form
    {
        public frmTATUsuariosMDF()
        {
            InitializeComponent();
        }

        #region OBJETOS
        TATUsuarios.strTATUsuarios strUsuarios = new TATUsuarios.strTATUsuarios();
        TATUsuarios TABLA_Usuarios = new TATUsuarios();

        TATEmpleados.strTATEmpleados[] ARREmpleados;
        public TATEmpleados.strTATEmpleados strEmpleados = new TATEmpleados.strTATEmpleados();
        TATEmpleados TABLA_Empleados = new TATEmpleados();
        ArrayList IDsEmpleados = new ArrayList();
        public int IdEmpleado;
        public int IdUsuario;

        TATPermisosTablas TABLA_PermisosTablas = new TATPermisosTablas();
        public TATPermisosTablas.strTATPermisosTablas[] ARRPermisosTablas = null;
        TATTIpoEmpleados TABLA_TiposEmpleados = new TATTIpoEmpleados();

        private bool Todos = false;
        bool doValidation = false;
        #endregion

        #region FILL COMBO EMPLEADOS
        private void FillComboEmpleados()
        {
            TABLA_Empleados.Listar(ref ARREmpleados);

            foreach(TATEmpleados.strTATEmpleados Dato in ARREmpleados)
            {
                cbxEmpleados.Items.Add(Dato.nombreEmpleado);
                IDsEmpleados.Add(Dato.idEmpleado);
            }
            int pos = 0;
            foreach(object Dato in IDsEmpleados)
            {
                if(Convert.ToInt32(Dato) == IdEmpleado)
                {
                    break;
                }
                pos++;
            }
            cbxEmpleados.SelectedIndex = pos;
            TABLA_Empleados.Dispose();

        }
        #endregion

        #region FILL LISTA PERMISOS
        public void FillListaPermisos()
        {
            int cuantos = 0;
            for (int i = 0; i < chkltsPermisos.Items.Count; i++)
            {
                for (int j = 0; j < ARRPermisosTablas.Length; j++)
                {
                    if (ARRPermisosTablas[j].NombreTabla.Equals(chkltsPermisos.Items[i].ToString()) && ARRPermisosTablas[j].Permiso == true)
                    {
                        chkltsPermisos.SetItemChecked(i, true);
                        cuantos++;
                    }
                }
            }
            if (cuantos == ARRPermisosTablas.Length)
            {
                chkltsPermisos.SetItemChecked(0, true);
                Todos = true;
            }

        }
        #endregion

        #region ENABLE BUTTONS
        public void EnableButtons()
        {
            if (txtNombreUsuario.Text.Trim() == "" || txtContraseña.Text.Trim() == "" || chkltsPermisos.CheckedItems.Count < 1)
            {
                btnAceptar.Enabled = false;
                lblMnesaje1.Visible = true;
                txtMensaje2.Visible = true;
            }
            else
            {
                btnAceptar.Enabled = true;
                lblMnesaje1.Visible = false;
                txtMensaje2.Visible = false;
            }
        }
        #endregion

        #region BOTON ACEPTAR
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtNombreUsuario.Text.Trim() != "" && txtContraseña.Text.Trim() != "" && chkltsPermisos.CheckedItems.Count >= 1)
            {
                strUsuarios.idUsuario = IdUsuario;
                strUsuarios.nombreUsuario = txtNombreUsuario.Text.Trim();
                strUsuarios.idEmpleado = Convert.ToInt32(IDsEmpleados[cbxEmpleados.SelectedIndex]);
                strUsuarios.Contraseña = txtContraseña.Text.Trim();

                DataTable TablaPermisos = new DataTable();
                TablaPermisos.Columns.Add("idPermiso", typeof(System.Int32));
                TablaPermisos.Columns.Add("NombreTabla", typeof(System.String));
                TablaPermisos.Columns.Add("Permiso", typeof(System.Boolean));
                int pos = 0, idAux = 0;
                for (int i = 0; i < chkltsPermisos.Items.Count; i++)
                {
                    if (i != 0)
                    {
                        for (int k = 0; k < ARRPermisosTablas.Length; k++)
                        {
                            if (chkltsPermisos.Items[i].ToString() == ARRPermisosTablas[k].NombreTabla)
                            {
                                idAux = ARRPermisosTablas[k].idPermiso;
                                break;
                            }
                        }
                    }
                    if (chkltsPermisos.GetItemChecked(i) && i != 0)
                    {
                        //AQUI ME QUEDE LLENANDO EL DATA TABLE
                        DataRow row = TablaPermisos.NewRow();
                        row["idPermiso"] = idAux;
                        row["NombreTabla"] = chkltsPermisos.Items[i].ToString();
                        row["Permiso"] = true;
                        TablaPermisos.Rows.Add(row);
                        pos++;
                    }
                    if (!chkltsPermisos.GetItemChecked(i) && i != 0)
                    {
                        DataRow row = TablaPermisos.NewRow();
                        row["idPermiso"] = idAux;
                        row["NombreTabla"] = chkltsPermisos.Items[i].ToString();
                        row["Permiso"] = false;
                        TablaPermisos.Rows.Add(row);
                        pos++;
                    }

                }

                bool modificado = TABLA_Usuarios.DAO(ref strUsuarios, TablaPermisos, 2);
                if (modificado)
                {
                    MessageBox.Show(this, "Modificado Correctamente", "Operacion Correcta", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }
        #endregion

        #region BOTON CANCELAR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region LOAD
        private void frmTATUsuariosMDF_Load(object sender, EventArgs e)
        {
            FillComboEmpleados();
            FillListaPermisos();
            EnableButtons();
        }
        #endregion

        #region OBLIGATORIO NOMBRE
        private void txtNombreUsuario_TextChanged(object sender, EventArgs e)
        {
            if (txtNombreUsuario.Text.Trim() != "")
            {
                Obligatorio.Visible = false;
            }
            else
            {
                Obligatorio.Visible = true;
            }
            EnableButtons();
        }
        #endregion

        #region OBLIGATORIO CONTRASEÑA
        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            if (txtContraseña.Text.Trim() != "")
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
        private void frmTATUsuariosMDF_FormClosing(object sender, FormClosingEventArgs e)
        {
            TABLA_Usuarios.Dispose();
        }
        #endregion

        #region LISTA PERMISOS INDEX CHANGED
        private void chkltsPermisos_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }
        #endregion

        #region LISTA MOUSE CLICK
        private void chkltsPermisos_MouseClick(object sender, MouseEventArgs e)
        {
            doValidation = true;
        }
        #endregion

        #region KEYPRESS NOMBRE USUARIO
        private void txtNombreUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && !(char.IsNumber(e.KeyChar)))
            {
                MessageBox.Show("Solo se permiten letras y números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            char[] NoPermitir = { 'é', 'ý', 'ú', 'í', 'ó', 'á', 'ë', 'ÿ', 'ü', 'ï', 'ö', 'ä', 'ê', 'û', 'î', 'ô', 'â', 'Ä', 'Ë', 'Ï', 'Ö', 'Ü', 'Á', 'É', 'Í', 'Ó', 'Ú', 'Ý' };
            if (NoPermitir.Contains(e.KeyChar))
            {
                MessageBox.Show("Carácter no permitido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        #endregion

        #region KEYPRESS CONTRASEÑA
        private void Obligatorio2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsSeparator(e.KeyChar))
            {
                MessageBox.Show("Carácter no permitido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        #endregion

        #region KEY PRESS PERMISOS
        private void chkltsPermisos_KeyPress(object sender, KeyPressEventArgs e)
        {
            doValidation = true;
        }

        #endregion

        #region KEY DOWN PERMISOS
        private void chkltsPermisos_KeyDown(object sender, KeyEventArgs e)
        {
            doValidation = true;
        }
        #endregion

        #region ITEM CHECK PERMISOS
        private void chkltsPermisos_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckearTodos();
        }
        #endregion

        #region TODOS
        public void CheckearTodos()
        {
            if (doValidation)
            {
                doValidation = false;
                if (chkltsPermisos.SelectedItem.Equals("Todos"))
                {
                    if (chkltsPermisos.CheckedItems.Count == 0)
                    {
                        chkltsPermisos.SetItemChecked(0, (!chkltsPermisos.GetItemChecked(0)));
                        for (int i = 1; i < chkltsPermisos.Items.Count; i++)
                        {
                            chkltsPermisos.SetItemChecked(i, true);
                        }

                    }
                    else
                    {
                        for (int i = 1; i < chkltsPermisos.Items.Count; i++)
                        {
                            chkltsPermisos.SetItemChecked(i, !chkltsPermisos.CheckedItems[0].Equals("Todos"));
                        }
                    }

                }
                else
                {
                    if (chkltsPermisos.CheckedItems.Count == chkltsPermisos.Items.Count - 1)
                    {
                        chkltsPermisos.SetItemChecked(0, (!chkltsPermisos.GetItemChecked(0)));
                        chkltsPermisos.SetItemChecked(0, chkltsPermisos.CheckedItems[0].Equals("Todos"));
                    }
                    else
                    {
                        if (chkltsPermisos.CheckedItems.Count == chkltsPermisos.Items.Count - 2)
                        {

                            bool check = true;
                            for (int i = 0; i < chkltsPermisos.CheckedItems.Count; i++)
                            {
                                if (chkltsPermisos.CheckedItems[i].Equals(chkltsPermisos.SelectedItem.ToString()))
                                {
                                    check = false;
                                }
                            }
                            chkltsPermisos.SetItemChecked(0, check);
                        }
                        else
                        {
                            chkltsPermisos.SetItemChecked(0, false);
                        }

                    }
                }
                EnableButtons();
            }
        }

        #endregion

        #region OCULTAR CONTRASEÑA
        private void button1_MouseHover(object sender, EventArgs e)
        {
            txtContraseña.UseSystemPasswordChar = false;
        }


        private void button1_MouseLeave(object sender, EventArgs e)
        {
            txtContraseña.UseSystemPasswordChar = true;
        }
        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
