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
    }

}
