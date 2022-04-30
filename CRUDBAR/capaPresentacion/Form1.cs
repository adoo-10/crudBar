using capaNegocio;
using System.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace capaPresentacion
{
    public partial class Form1 : Form
    {
        CN_Productos objetoCN = new CN_Productos();
        private string idproducto;
        private bool Editar = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

            LeerProd();
        }

        private void LeerProd()
        {
            CN_Productos objeto = new();
            dataGridView1.DataSource = objeto.LeerProd();
        }

        private void LimpiarForm()
        {
            txtProd.Clear();
            txtDesc.Clear();
            txtPrec.Clear();
            txtExis.Clear();
            txtProd.Clear();
            txtEsta.Clear();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            //inserta
            if(Editar == false)
            {
                try
                {
                    objetoCN.InsProd(txtProd.Text, txtDesc.Text, txtPrec.Text, txtExis.Text, txtEsta.Text);
                    MessageBox.Show("Registro insertado existosamente");
                    LeerProd();
                    LimpiarForm(); 
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Registro no pudo ser editado, debido a: " + ex);
                }
            }

            if (Editar == true)
            {
                try
                {
                    objetoCN.ActProd(txtProd.Text, txtDesc.Text, txtPrec.Text, txtExis.Text, txtEsta.Text, idproducto);
                    MessageBox.Show("Registro actualizado exitosamente");
                    LeerProd();
                    LimpiarForm();
                    Editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Registro no actualizado, debido a: " + ex);
                }
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                txtProd.Text = dataGridView1.CurrentRow.Cells["nomProd"].Value.ToString();
                txtDesc.Text = dataGridView1.CurrentRow.Cells["descripcion"].Value.ToString();
                txtPrec.Text = dataGridView1.CurrentRow.Cells["precio"].Value.ToString();
                txtExis.Text = dataGridView1.CurrentRow.Cells["cantidad"].Value.ToString();
                txtEsta.Text = dataGridView1.CurrentRow.Cells["estado"].Value.ToString();
                idproducto = dataGridView1.CurrentRow.Cells["idProducto"].Value.ToString();

               



            }
            else
                MessageBox.Show("Seleccione una fila por favor");



        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idproducto = dataGridView1.CurrentRow.Cells["idproducto"].Value.ToString();
                objetoCN.EliProd(idproducto);
                MessageBox.Show("Se ha eliminado correctamente");
                LeerProd();

            }
            else
                MessageBox.Show("Selecciona una fila");
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}