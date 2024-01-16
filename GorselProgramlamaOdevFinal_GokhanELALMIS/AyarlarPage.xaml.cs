namespace GorselProgramlamaOdevFinal_GokhanELALMIS;

public partial class AyarlarPage : ContentPage
{
	public AyarlarPage()
	{
		InitializeComponent();
	}

    private void OnDarkModeToggle(object sender, ToggledEventArgs e)
    {
        if (e.Value)
        {
            Application.Current.Resources["PageBackgroundColor"] = Color.FromHex("#121212");
        }
        else
        {
            Application.Current.Resources["PageBackgroundColor"] = Color.FromHex("#FFFFFF");
        }
    }
}