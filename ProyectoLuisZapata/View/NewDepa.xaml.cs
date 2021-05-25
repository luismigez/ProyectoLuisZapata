using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoLuisZapata.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewDepa : ContentPage
    {
        public NewDepa()
        {
            InitializeComponent();
        }

        private void BtnInsert_Clicked(object sender, EventArgs e)
        {
            if (TxtDepa.Text != null)
            {
                try
                {
                    WebClient cliente = new WebClient();
                    var parametros = new System.Collections.Specialized.NameValueCollection();
                    parametros.Add("DEPA_DETA", TxtDepa.Text);

                    cliente.UploadValues("http://192.168.100.24/proyecto/depa_post.php", "POST", parametros);

                    var mensaje = "Datos Ingresado Correctamente";
                    DependencyService.Get<Modelo.Mensaje>().LongAlert(mensaje);
                    TxtDepa.Text = "";
                }

                catch (Exception ex)
                {
                    DependencyService.Get<Modelo.Mensaje>().ShortAlert(ex.ToString());
                }
            }
            else
            {
                var mensaje = "Ingrese algun dato";
                DependencyService.Get<Modelo.Mensaje>().LongAlert(mensaje);

            }
        }

        private void BtnReturn_Clicked(object sender, EventArgs e)
        {

        }
    }
}