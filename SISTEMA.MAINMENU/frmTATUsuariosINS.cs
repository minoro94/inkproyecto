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

namespace SISTEMA.MAINMENU
{
    public partial class frmTATUsuariosINS : Form
    {
        public frmTATUsuariosINS()
        {
            InitializeComponent();
        }

        #region OBJETOS
        public TATUsuarios.strTATUsuarios str = new TATUsuarios.strTATUsuarios();
        TATUsuarios TABLA = new TATUsuarios();
        public TATEmpleados.strTATEmpleados strEmpleados = new TATEmpleados.strTATEmpleados();
        TATEmpleados TABLA_Empleados = new TATEmpleados();
        ArrayList IDsEmpleados = new ArrayList();
        TATEmpleados.strTATEmpleados[] ARR_Empleados;
        TATPermisosTablas TABLA_PermisosTablas = new TATPermisosTablas();
        TATTIpoEmpleados TABLA_TiposEmpleados = new TATTIpoEmpleados();
        public bool doValidation = false;
        #endregion

        #region FILL COMBO EMPLEADOS
        private void FillComboEmpleados()
        {
            strEmpleados.nombreEmpleado = "";
            TABLA_Empleados.Listar(ref ARR_Empleados);

            foreach(TATEmpleados.strTATEmpleados Dato in ARR_Empleados)
            {
                cbxEmpleados.Items.Add(Dato.nombreEmpleado);
                IDsEmpleados.Add(Dato.idEmpleado);
            }
            cbxEmpleados.SelectedIndex = 0;
            TABLA_Empleados.Dispose();
        }
        #endregion

        #region ENABLE BUTTONS
        public void EnableButtons()
        {
            if (txtNombreUsuario.Text.Trim() == "" || txtContraseña.Text.Trim() == "" || chkltsPermisos.CheckedItems.Count < 1)
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

        #region BOTON APLICAR
        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (txtNombreUsuario.Text.Trim() != "" && txtContraseña.Text.Trim() != "" && chkltsPermisos.CheckedItems.Count >= 1)
            {
                str.nombreUsuario = txtNombreUsuario.Text.Trim();
                str.idEmpleado = Convert.ToInt32(IDsEmpleados[cbxEmpleados.SelectedIndex]);
                str.Contraseña = txtContraseña.Text.Trim();

                DataTable TablaPermisos = new DataTable();
                TablaPermisos.Columns.Add("idPermiso", typeof(System.Int32));
                TablaPermisos.Columns.Add("NombreTabla", typeof(System.String));
                TablaPermisos.Columns.Add("Permiso", typeof(System.Boolean));

                for (int i = 0; i < chkltsPermisos.Items.Count; i++)
                {
                    if (chkltsPermisos.GetItemChecked(i) && i != 0)
                    {
                        //AQUI ME QUEDE LLENANDO EL DATA TABLE
                        DataRow row = TablaPermisos.NewRow();
                        row["idPermiso"] = 0;
                        row["NombreTabla"] = chkltsPermisos.Items[i].ToString();
                        row["Permiso"] = true;
                        TablaPermisos.Rows.Add(row);

                    }
                    if (!chkltsPermisos.GetItemChecked(i) && i != 0)
                    {
                        DataRow row = TablaPermisos.NewRow();
                        row["idPermiso"] = 0;
                        row["NombreTabla"] = chkltsPermisos.Items[i].ToString();
                        row["Permiso"] = false;
                        TablaPermisos.Rows.Add(row);
                    }
                }

                bool agregado = TABLA.DAO(ref str, TablaPermisos, 1);
                if (agregado)
                {
                    MessageBox.Show(this, "Agregado Correctamente", "Operacion Correcta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.Yes;
                    cbxEmpleados.SelectedIndex = 0;
                    txtContraseña.Clear();
                    txtNombreUsuario.Clear();
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

        #region BOTON ACEPTAR
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtNombreUsuario.Text.Trim() != "" && txtContraseña.Text.Trim() != "" && chkltsPermisos.CheckedItems.Count >= 1)
            {
                str.nombreUsuario = txtNombreUsuario.Text.Trim();
                str.idEmpleado = Convert.ToInt32(IDsEmpleados[cbxEmpleados.SelectedIndex]);
                str.Contraseña = txtContraseña.Text.Trim();

                DataTable TablaPermisos = new DataTable();
                TablaPermisos.Columns.Add("idPermiso", typeof(System.Int32));
                TablaPermisos.Columns.Add("NombreTabla", typeof(System.String));
                TablaPermisos.Columns.Add("Permiso", typeof(System.Boolean));

                for (int i = 0; i < chkltsPermisos.Items.Count; i++)
                {
                    if (chkltsPermisos.GetItemChecked(i) && i != 0)
                    {

                        //AQUI ME QUEDE LLENANDO EL DATA TABLE
                        DataRow row = TablaPermisos.NewRow();
                        row["idPermiso"] = 0;
                        row["NombreTabla"] = chkltsPermisos.Items[i].ToString();
                        row["Permiso"] = true;
                        TablaPermisos.Rows.Add(row);

                    }
                    if (!chkltsPermisos.GetItemChecked(i) && i != 0)
                    {
                        DataRow row = TablaPermisos.NewRow();
                        row["idPermiso"] = 0;
                        row["NombreTabla"] = chkltsPermisos.Items[i].ToString();
                        row["Permiso"] = false;
                        TablaPermisos.Rows.Add(row);
                    }
                }

                bool agregado = TABLA.DAO(ref str, TablaPermisos, 1);
                if (agregado)
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
        }
        #endregion

        #region BOTON CANCELAR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region LOAD
        private void frmTATUsuariosINS_Load(object sender, EventArgs e)
        {
            FillComboEmpleados();
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
        private void frmTATUsuariosINS_FormClosing(object sender, FormClosingEventArgs e)
        {
            TABLA.Dispose();
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
            }
            EnableButtons();
        }
        #endregion

        #region LISTA PERMISOS INDEX CHANGED
        private void chkltsPermisos_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }
        #endregion

        #region KEY PRESS NOMBRE USUARIO
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

        #region KEY PRESS CONTRASEÑA
        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsSeparator(e.KeyChar))
            {
                MessageBox.Show("Carácter no permitido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        #endregion

        #region MOSTRAR CONTRA CON MOUSE
        private void button1_MouseHover(object sender, EventArgs e)
        {
            txtContraseña.UseSystemPasswordChar = false;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            txtContraseña.UseSystemPasswordChar = true;
        }
        #endregion

        #region KEYDOWN EN CHECKLIST
        private void chkltsPermisos_KeyDown(object sender, KeyEventArgs e)
        {
            doValidation = true;
        }
        #endregion

        #region ITEM CHECK
        private void chkltsPermisos_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckearTodos();
        }
        #endregion

        #region LISTA MOUSE CLICK
        private void chkltsPermisos_MouseClick(object sender, MouseEventArgs e)
        {
            doValidation = true;
        }
        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
