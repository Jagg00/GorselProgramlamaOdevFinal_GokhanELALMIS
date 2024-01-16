namespace GorselProgramlamaOdevFinal_GokhanELALMIS;

public partial class HavaDurumu : ContentPage
{
    private HavaDurumu havaDurumu;
    private HttpClient httpClient;

    public HavaDurumu()
	{
        InitializeComponent();
        //havaDurumu = new HavaDurumu();
        //httpClient = new HttpClient();
        //ListViewSehirler.ItemsSource = havaDurumu.Sehirler;
    }

    private async void ButtonSehirEkle_Clicked(object sender, EventArgs e)
    {
        string sehir = await DisplayPromptAsync("Şehir:", "Şehir ismi", "OK", "Cancel");
        if (!string.IsNullOrEmpty(sehir))
        {
            sehir = sehir.ToUpper(System.Globalization.CultureInfo.CurrentCulture);
            sehir = sehir.Replace('Ç', 'C');
            sehir = sehir.Replace('Ğ', 'G');
            sehir = sehir.Replace('İ', 'I');
            sehir = sehir.Replace('Ö', 'O');
            sehir = sehir.Replace('Ü', 'U');
            sehir = sehir.Replace('Ş', 'S');

            string havaDurumuBilgisi = await GetHavaDurumu(sehir);

            //SehirHavaDurumu yeniSehir = new SehirHavaDurumu()
            //{
            //    Name = sehir,
            //    HavaDurumuBilgisi = havaDurumuBilgisi
            //};

            //havaDurumu.Sehirler.Add(yeniSehir);
            //ListViewSehirler.ItemsSource = null;
            //ListViewSehirler.ItemsSource = havaDurumu.Sehirler;
        }
    }

    private async Task<string> GetHavaDurumu(string sehir)
    {
        string url = $"https://www.mgm.gov.tr/sunum/tahmin-klasik-5070.aspx?m={sehir}&basla=1&bitir=5&rC=111&rZ=fff";
        HttpResponseMessage response = await httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }

        return "Hava durumu bilgisi alınamadı.";
    }
}