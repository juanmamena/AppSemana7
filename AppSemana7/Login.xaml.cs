using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AppSemana7.Models;
using SQLite;
using Xamarin.Forms;

namespace AppSemana7
{
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection con;

        public Login()
        {
            InitializeComponent();
            con = DependencyService.Get<Database>().GetConnection();
        }

        public static IEnumerable<Estudiante> SELECT_WHERE(SQLiteConnection db, string usuario, string contrasena)
        {
            return db.Query<Estudiante>("SELECT * FROM Estudiante where Usuario =? and Contrasena=?", usuario, contrasena);

        }


        void btnLogin_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                var documentpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(documentpath);
                db.CreateTable<Estudiante>();
                IEnumerable<Estudiante> resultado = SELECT_WHERE(db, txtUsuario.Text, txtPassword.Text);

                if (resultado.Count() > 0)
                {
                    Navigation.PushAsync(new ConsultaRegistros());
                }
                else
                {
                    DisplayAlert("ALERTA", "Usuario incorrecto", "OK");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("ALERTA", ex.Message, "OK");
            }
        }

        void btnRegistro_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Registrar());
        }
    }
}
