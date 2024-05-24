using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrySignorile_TP2
{
    public partial class frmInicioSesion : Form
    {
        public frmInicioSesion()
        {
            InitializeComponent();
        }
        private void RegistrarUsuario()
        {
            string nombre = txtUsuario.Text;
            string contrasena = txtContra.Text;


            string datosUsuario = $"{nombre},{contrasena}";


            try
            {
                using (StreamWriter writer = new StreamWriter("usuarios.txt", true))
                {
                    writer.WriteLine(datosUsuario);
                    MessageBox.Show("Usuario registrado exitosamente!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el usuario: " + ex.Message);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            RegistrarUsuario();
        }

        private void IniciarSesion()
        {

            string nombreUsuario = txtUsuario.Text;
            string contrasena = txtContra.Text;


            List<string> usuarios = LeerUsuarios();


            foreach (string usuario in usuarios)
            {
                string[] datosUsuario = usuario.Split(',');
                if (datosUsuario[0] == nombreUsuario && datosUsuario[2] == contrasena)
                {
                    MessageBox.Show("¡Inicio de sesión exitoso!");
                    return;
                }
            }


            MessageBox.Show("Nombre de usuario o contraseña incorrectos.");
        }

        private List<string> LeerUsuarios()
        {
            List<string> usuarios = new List<string>();
            try
            {
                using (StreamReader reader = new StreamReader("usuarios.txt"))
                {
                    string linea;
                    while ((linea = reader.ReadLine()) != null)
                    {
                        usuarios.Add(linea);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer el archivo de usuarios: " + ex.Message);
            }
            return usuarios;
        }
        private void frmInicioSesion_Load(object sender, EventArgs e)
        {

        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            IniciarSesion();
        }
    }
}
