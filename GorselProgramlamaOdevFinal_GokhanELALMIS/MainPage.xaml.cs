using GorselProgramlamaOdevFinal_GokhanELALMIS.ViewModels;

namespace GorselProgramlamaOdevFinal_GokhanELALMIS
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        private async void OnHamburgerMenuClicked(object sender, EventArgs e)
        {
            var result = await DisplayActionSheet("Select Page", "Cancel", null, "Giriş", "Kurlar", "Hava Durumu", "Haberler", "Yapilacaklar", "Ayarlar");

            if (result == "Giriş")
                await Navigation.PushAsync(new MainPage());
            else if (result == "Kurlar")
                await Navigation.PushAsync(new KurlarPage());
            else if (result == "Haberler")
                await Navigation.PushAsync(new Haberler());
            else if (result == "Hava Durumu")
                await Navigation.PushAsync(new HavaDurumu());
            else if (result == "Yapilacaklar")
                await Navigation.PushAsync(new YapilacaklarPage());
            else if (result == "Ayarlar")
                await Navigation.PushAsync(new AyarlarPage());
        }
    }

}
