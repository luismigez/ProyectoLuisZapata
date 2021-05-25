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
using ZXing.Net.Mobile.Forms;

namespace ProyectoLuisZapata.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnviIngr : ContentPage
    {
        private const string Url = "http://192.168.100.24/proyecto/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Modelo.DatosEmple> _post;
        ZXingBarcodeImageView qr;
        public EnviIngr()
        {
            InitializeComponent();
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                Device.BeginInvokeOnMainThread(() =>
                lblTime.Text = DateTime.Now.ToString("HH.mm:ss")
                );
                return true;
            });
        }

        private async void BtnGeneCodi_Clicked(object sender, EventArgs e)
        {
            var content = await client.GetStringAsync(Url);
            List<Modelo.DatosEmple> posts = JsonConvert.DeserializeObject<List<Modelo.DatosEmple>>(content);
            _post = new ObservableCollection<Modelo.DatosEmple>(posts);
            MyListViewEmpl.ItemsSource = _post;

            qr = new ZXingBarcodeImageView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            qr.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
            qr.BarcodeOptions.Width = 500;
            qr.BarcodeOptions.Height = 500;
            qr.BarcodeValue = lblTime.Text;
            StkQR.Children.Add(qr);

        }
    }
}