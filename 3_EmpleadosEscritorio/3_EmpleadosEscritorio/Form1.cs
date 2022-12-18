using _3_EmpleadosEscritorio.datos;
using _3_EmpleadosEscritorio.modelo;
using System.Data;

namespace _3_EmpleadosEscritorio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (consultado == false)
            {
                MessageBox.Show("Debe consultar el empleado");
            }
            else if (txtDocumento.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un documento válido");
            }
            else if (txtNombres.Text.Trim().Length < 2)
            {
                MessageBox.Show("Debe ingresar un nombre más largo");
            }
            else if (txtApellidos.Text.Trim().Length < 2)
            {
                MessageBox.Show("Debe ingresar un apellido más largo");
            }
            else if (txtEdad.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una edad válido");
            }
            else if (txtDireccion.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una dirección válida");
            }
            else if (txtFechaNacimiento.Text.Trim().Length < 2)
            {
                MessageBox.Show("Debe ingresar una fecha de nacimiento válida");
            }
            else
            {
                try
                {
                    Empleado em = new Empleado();
                    em.Nombres = txtNombres.Text.Trim().ToUpper();
                    em.Apellidos = txtApellidos.Text.Trim().ToUpper();
                    em.Direccion = txtDireccion.Text.Trim().ToUpper();
                    em.Documento = txtDocumento.Text.Trim();
                    em.Edad = Convert.ToInt32(txtEdad.Text.Trim());
                    em.Fecha_nacimiento = txtFechaNacimiento.Value.Year + "-" + txtFechaNacimiento.Value.Month + "-" + txtFechaNacimiento.Value.Day;

                    if (EmpleadoCAD.actualizar(em))
                    {
                        llenarGrid();
                        limpiarCampos();
                        MessageBox.Show("Empleado actualizado correctamente");
                        consultado = false;
                    }
                    else
                    {
                        MessageBox.Show("No se actualizó");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Comprobacion de errores
            if(txtDocumento.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un documento válido");
            } 
            else if (txtNombres.Text.Trim().Length < 2)
            {
                MessageBox.Show("Debe ingresar un nombre más largo");
            }
            else if (txtApellidos.Text.Trim().Length < 2)
            {
                MessageBox.Show("Debe ingresar un apellido más largo");
            }
            else if (txtEdad.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una edad válido");
            }
            else if (txtDireccion.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una dirección válida");
            }
            else if (txtFechaNacimiento.Text.Trim().Length < 2)
            {
                MessageBox.Show("Debe ingresar una fecha de nacimiento válida");
            }
            else
            {
                try
                {
                    Empleado em = new Empleado();
                    em.Nombres = txtNombres.Text.Trim().ToUpper();
                    em.Apellidos = txtApellidos.Text.Trim().ToUpper();
                    em.Direccion = txtDireccion.Text.Trim().ToUpper();
                    em.Documento = txtDocumento.Text.Trim();
                    em.Edad = Convert.ToInt32(txtEdad.Text.Trim());
                    em.Fecha_nacimiento = txtFechaNacimiento.Value.Year + "-" + txtFechaNacimiento.Value.Month + "-" + txtFechaNacimiento.Value.Day;

                    if (EmpleadoCAD.guardar(em))
                    {
                        llenarGrid();
                        MessageBox.Show("Empleado guardado correctamente");
                        limpiarCampos();
                    } else {
                        MessageBox.Show("Ya existe otro empleado con el documento");
                    }

                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }

        }

        //Private porque solo se va a usar en esta clase
        private void llenarGrid()
        {
            DataTable datos = EmpleadoCAD.listar();
            if (datos == null)
            {
                MessageBox.Show("No se logró acceder a los datos");
            }
            else
            {
                dgLista.DataSource = datos.DefaultView;

            }
        }

        private void limpiarCampos()
        {
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtEdad.Text = "";
            txtDireccion.Text = "";
            txtDocumento.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            llenarGrid();
        }


        bool consultado = false;
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtDocumento.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un documento");
            }   else
            {
                Empleado em = EmpleadoCAD.consultar(txtDocumento.Text.Trim());
                if (em == null)
                {
                    MessageBox.Show("No existe el empleado con documento " + txtDocumento.Text);
                    limpiarCampos();
                    consultado = false;
                }
                else
                {
                    txtNombres.Text = em.Nombres;
                    txtApellidos.Text = em.Apellidos;
                    txtEdad.Text = em.Direccion;
                    txtDireccion.Text = em.Direccion;
                    txtDocumento.Text = em.Documento;
                    txtEdad.Text = em.Edad.ToString();
                    txtFechaNacimiento.Text = em.Fecha_nacimiento;
                    consultado = true;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtDocumento.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un documento válido");
            }
            else if (DialogResult.Yes == MessageBox.Show(null,"Realmente desea eliminar el registro?", "Confirmar", MessageBoxButtons.YesNo))
            {
                try
                {
                   
                    if (EmpleadoCAD.eliminar(txtDocumento.Text.Trim()))
                    {
                        llenarGrid();
                        limpiarCampos();
                        MessageBox.Show("Empleado eliminado correctamente");
                        consultado = false;
                    }
                    else
                    {
                        MessageBox.Show("No se elimino");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
    }
}