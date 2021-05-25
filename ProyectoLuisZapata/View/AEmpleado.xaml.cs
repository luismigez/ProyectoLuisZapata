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
    public partial class AEmpleado : ContentPage
    {
        private const string Url = "http://192.168.100.24/proyecto/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Modelo.DatosEmple> _post;
        public AEmpleado()
        {
            InitializeComponent();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.NewEmpl());
        }

        private  async void BtnConEmp_Clicked(object sender, EventArgs e)
        {
            var content = await client.GetStringAsync(Url);
            List<Modelo.DatosEmple> posts = JsonConvert.DeserializeObject<List<Modelo.DatosEmple>>(content);
            _post = new ObservableCollection<Modelo.DatosEmple>(posts);
            MyListViewEmpl.ItemsSource = _post;
        }
    }
}