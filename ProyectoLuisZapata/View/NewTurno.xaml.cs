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
    public partial class NewTurno : ContentPage
    {
        public NewTurno()
        {
            InitializeComponent();
        }

        private async void BtnReturn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.ATurno());
        }

        private async void BtnInsert_Clicked(object sender, EventArgs e)
        {
            try
            {
                DateTime fech = Convert.ToDateTime(DataFecha);
                 
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("ID_TIPO_TURN", TxtTipoTurn.Text);
                parametros.Add("ID_EMPL", TxtEmpl.Text);
               // parametros.Add("FECH", fech);
                //parametros.Add("HORA", TxtHora.Text);

                cliente.UploadValues("http://192.168.100.24/proyecto/turno_post.php", "POST", parametros);

                var mensaje = "Datos Ingresado Correctamente";
                DependencyService.Get<Modelo.Mensaje>().LongAlert(mensaje);
                
            }

            catch (Exception ex)
            {
                DependencyService.Get<Modelo.Mensaje>().ShortAlert(ex.ToString());
            }
        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {

        }
    }
}