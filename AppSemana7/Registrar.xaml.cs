using System;
using System.Collections.Generic;
using Xamarin.Forms;
using SQLite;
using AppSemana7.Models;
using System.IO;

namespace AppSemana7
{
    public partial class Registrar : ContentPage
    {
        private SQLiteAsyncConnection con;
        public Registrar()
        {
            InitializeComponent();
            con = DependencyService.Get<Database>().GetConnection();

        }

        void btnRegistro_Clicked(System.Object sender, System.EventArgs e)

        {
            var datosRegistro = new Estudiante { Nombre = txtNombre.Text, Usuario = txtUsuario.Text, Contrasena = txtPassword.Text };
            con.InsertAsync(datosRegistro);
            txtNombre.Text = "";
            txtUsuario.Text = "";
            txtPassword.Text = "";
            DisplayAlert("Mensaje", "Registro Exitoso", "OK");
            Navigation.PushAsync(new Login());
           
        }
    }
}
