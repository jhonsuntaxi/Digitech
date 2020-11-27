using Digitech;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.IO;
using System.Collections.ObjectModel;

using Digitech.Models;

namespace Digitech.Repo

{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Elemento : ContentPage
    {
        public int IdSeleccion;
        private SQLiteAsyncConnection _conn;
        IEnumerable<Cliente> resultDelete;
        IEnumerable<Cliente> resultUpdate;
        public Elemento(int id)
        {
            _conn = DependencyService.Get<Database>().GetConnection();
            IdSeleccion = id;
            InitializeComponent();

        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                resultUpdate = Update(db, txtNombre.Text, txtUsuario.Text, txtPasswd.Text, IdSeleccion);
                await DisplayAlert("Alerta", "Se Actualizo correctamente", "Ok");
            }
            catch (Exception ex)
            {

                await DisplayAlert("Alerta", ex.Message, "Ok");
            }
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                resultDelete = Delete(db, IdSeleccion);
                await DisplayAlert("Alerta", "Se elimino correctamente", "Ok");
            }
            catch (Exception ex)
            {

                await DisplayAlert("Alerta", ex.Message, "Ok");
            }
        }

        public static IEnumerable<Cliente> Update(SQLiteConnection db, string nombre, string usuario, string constra, int id)
        {
            return db.Query<Cliente>("UPDATE Cliente SET" +
                " Nombre = ?, Usuario = ?, Password = ? WHERE Id = ?", nombre, usuario, constra, id);
        }

        public static IEnumerable<Cliente> Delete(SQLiteConnection db, int id)
        {
            return db.Query<Cliente>("DELETE FROM Cliente WHERE Id = ?", id);
        }
    }
}