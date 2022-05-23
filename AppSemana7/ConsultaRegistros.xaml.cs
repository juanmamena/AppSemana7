using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AppSemana7.Models;
using SQLite;
using Xamarin.Forms;

namespace AppSemana7
{
    public partial class ConsultaRegistros : ContentPage

    {
        private SQLiteAsyncConnection con;
        private ObservableCollection<Estudiante> tablaEstudiante;

        public ConsultaRegistros()
        {
            InitializeComponent();
            con = DependencyService.Get<Database>().GetConnection();
            get();
        }

        public async void get()
        {
            var resultado = await con.Table<Estudiante>().ToListAsync();
            tablaEstudiante = new ObservableCollection<Estudiante>(resultado);
            listaUsuarios.ItemsSource = tablaEstudiante;
        }


        void listaUsuarios_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var obj = (Estudiante)e.SelectedItem;
            var itemId = obj.Id.ToString();
            var itemNombre = obj.Nombre.ToString();
            var itemUsuario = obj.Usuario.ToString();
            var itemPassword = obj.Contrasena.ToString();

            int id = Convert.ToInt32(itemId);
            Navigation.PushAsync(new Elemento(id,itemNombre,itemUsuario,itemPassword));

        }

        void btnSalir_Clicked(System.Object sender, System.EventArgs e)
        {
            DisplayAlert("Mensaje", "Vuelve Pronto !", "Cerrar");
            Navigation.PushAsync(new Login());
        }
    }
}
