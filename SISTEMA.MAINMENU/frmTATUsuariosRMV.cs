using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SISTEMA.TATTOO;

namespace SISTEMA.MAINMENU
{
    public partial class frmTATUsuariosRMV : Form
    {
        public frmTATUsuariosRMV()
        {
            InitializeComponent();
        }

        #region OBJETOS
        public TATUsuarios.strTATUsuarios strUsuarios = new TATUsuarios.strTATUsuarios();
        TATUsuarios TABLA_Usuarios = new TATUsuarios();
        public int idUsuario;
        public TATPermisosTablas.strTATPermisosTablas[] ARRPermisosTablas;
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

            }

        }
        #endregion

        #region BOTON ACEPTAR
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            strUsuarios.idUsuario = idUsuario;
            DataTable tbl = new DataTable();
            for (int i = 0; i < 3; i++)
            {
                tbl.Columns.Add(i.ToString());
            }
            if (TABLA_Usuarios.DAO(ref strUsuarios, tbl, 3))
            {
                MessageBox.Show(this, "El registro ah sido eliminado correctamente", "OPERACION CORRECTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(this, "No se ah podido eliminar", "OPERACION INCORRECTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
            }
        }

        #endregion

        #region BOTON CANCELAR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        private void frmTATUsuariosRMV_Load(object sender, EventArgs e)
        {
            FillListaPermisos();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
