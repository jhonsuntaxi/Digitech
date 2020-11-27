using Digitech;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Digitech.Models;

namespace Digitech
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        public Login()
        {
            InitializeComponent();
            _conn = DependencyService.Get<Database>().GetConnection();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                //variables que acceden a la base de datos 
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                db.CreateTable<Cliente>();//tabla cliente 
                IEnumerable<Cliente> resultado = SelectWhere(db, usuario.Text, contra.Text);
                if (resultado.Count() > 0)
                {
                    Navigation.PushAsync(new ConsultaRegistro());
                }
                else
                {
                    DisplayAlert("Alerta", "Verifique su usuario", "ok");
                }
            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", ex.Message, "ok");
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }

        public static IEnumerable<Cliente> SelectWhere(SQLiteConnection db, string usuario, string contra)
        {
            return db.Query<Cliente>("Select * From Cliente where usuario=? and password=?", usuario, contra);
        }
    }
}