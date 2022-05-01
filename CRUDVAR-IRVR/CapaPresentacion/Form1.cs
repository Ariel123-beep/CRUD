using CapaNegocio;
using System.Data;
namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        CN_Productos objetoCN = new CN_Productos();

        private string idProducto;

        private bool Editar = false;

        private void LeerProds()
        {
            CN_Productos objeto=new CN_Productos();
            dataGridView1.DataSource = objeto.LeerProd();
        }

        private void LimpiarForm()
        {
            txtProd.Clear();
            txtDesc.Clear();
            txtPrec.Clear();
            txtExis.Clear();
            txtEsta.Clear();
            
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LeerProds();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                if (Editar == false)
                {
                    try
                    {
                        objetoCN.insprod(txtProd.Text, txtDesc.Text, txtPrec.Text, txtExis.Text, txtEsta.Text);
                        MessageBox.Show("El registro fue insertado con exito");
                        LeerProds();
                        LimpiarForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("El registro no fue insertado por el siguiente motivo: " + ex);
                    }
                }

                if (Editar == true)
                {
                    try
                    {
                        objetoCN.Actprod(txtProd.Text, txtDesc.Text, txtPrec.Text, txtExis.Text, txtEsta.Text, idProducto);
                        MessageBox.Show("El registro actualizado con éxito!");
                        LeerProds();
                        LimpiarForm();
                        Editar = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("El registro no fue actualizado por el siguiente motivo: " + ex);
                    }
                }
            }


        }

        private void txtProd_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idProducto = dataGridView1.CurrentRow.Cells ["idProducto"].Value.ToString ();
                objetoCN.Eliprod(idProducto);
                MessageBox.Show("Eliminado correctamante");
                LeerProds ();

            }
            else
                MessageBox.Show("Seleccione la fila a eliminar");

        } 

        
    }

}
