using Newtonsoft.Json;

namespace GorselProgramlamaOdevFinal_GokhanELALMIS;

public partial class KurlarPage : ContentPage
{
	public KurlarPage()
	{
		InitializeComponent();

        Task.Run(async () =>
        {
            var jsonData = await GetJsonData("https://api.genelpara.com/embed/altin.json");

            var currencyData = JsonConvert.DeserializeObject<Dictionary<string, Currency>>(jsonData);

            foreach (var kvp in currencyData)
            {
                var label = new Label
                {
                    Text = $"{kvp.Key}: Satış {kvp.Value.Satis}, Alış {kvp.Value.Alis}, Değişim {kvp.Value.Degisim}",
                    Margin = new Thickness(10),
                };

                Device.InvokeOnMainThreadAsync(() =>
                {
                    stackLayout.Children.Add(label);
                });
            }
        });
    }

    private async Task<string> GetJsonData(string url)
    {
        using (var httpClient = new HttpClient())
        {
            try
            {
                var response = await httpClient.GetStringAsync(url);
                return response;
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }

    public class Currency
    {
        public string Satis { get; set; }
        public string Alis { get; set; }
        public string Degisim { get; set; }
        public string DOran { get; set; }
        public string DYon { get; set; }
    }
}