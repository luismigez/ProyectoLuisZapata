using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoLuisZapata.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ATurno : ContentPage
    {
        private const string Url = "http://192.168.100.24/proyecto/turno_post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Modelo.DatosTurno> _post;
        public ATurno()
        {
            InitializeComponent();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.NewTurno());
        }

        private async void BtnConsuTurn_Clicked(object sender, EventArgs e)
        {
            var content = await client.GetStringAsync(Url);
            List<Modelo.DatosTurno> posts = JsonConvert.DeserializeObject<List<Modelo.DatosTurno>>(content);
            _post = new ObservableCollection<Modelo.DatosTurno>(posts);
            MyListViewTurn.ItemsSource = _post;
        }
    }
}