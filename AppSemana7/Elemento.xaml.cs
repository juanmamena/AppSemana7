using System;
using System.Collections.Generic;
using System.IO;
using AppSemana7.Models;
using SQLite;

using Xamarin.Forms;

namespace AppSemana7
{
    public partial class Elemento : ContentPage
    {

        private SQLiteAsyncConnection con;
        IEnumerable<Estudiante> Delete1;
        IEnumerable<Estudiante> Update1;
        int idSeleccionado;

        public Elemento(int id, string nombreUsuario, string username, string password)
        {
            InitializeComponent();
            idSeleccionado = id;

            txtId.Text = idSeleccionado.ToString();
            txtNombre.Text = nombreUsuario;
            txtUsuario.Text = username;
            txtContrasena.Text = password;
        }



        public static IEnumerable<Estudiante> delete(SQLiteConnection db, int id)
        {

            return db.Query<Estudiante>("DELETE FROM ESTUDIANTE WHERE Id =?", id);
        }

        public static IEnumerable<Estudiante> update(SQLiteConnection db, string nombre, string usuario, string contrasena, int id)
        {
            return db.Query<Estudiante>("UPDATE Estudiante set Nombre=?, Usuario=?, Contrasena=? where Id=?", nombre, usuario,contrasena, id);
        }
        void btnActualizar_Clicked(System.Object sender, System.EventArgs e)
        {
            var databasepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
            var db = new SQLiteConnection(databasepath);
            Update1 = update(db, txtNombre.Text,txtUsuario.Text,txtContrasena.Text,idSeleccionado);
            DisplayAlert("Mensaje", "Registro Actualizado", "OK");
        }

        void btnEliminar_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                var databasepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),"uisrael.db3");
                var db = new SQLiteConnection(databasepath);
                Delete1 = delete(db, idSeleccionado);
                DisplayAlert("Mensaje", "Usuario Eliminado", "OK");
                Navigation.PushAsync(new ConsultaRegistros());

            }
            catch (Exception ex)
            {

            }
        }

        void btnRegresar_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ConsultaRegistros());
        }
    }
}
