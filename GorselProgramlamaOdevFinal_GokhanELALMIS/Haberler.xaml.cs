using System.Text.Json;

namespace GorselProgramlamaOdevFinal_GokhanELALMIS;

public partial class Haberler : ContentPage
{

    public class Enclosure
    {
        public string link { get; set; }
        public string type { get; set; }
    }

    public class Feed
    {
        public string url { get; set; }
        public string title { get; set; }
        public string link { get; set; }
        public string author { get; set; }
        public string description { get; set; }
        public string image { get; set; }
    }

    public class Item
    {
        public string title { get; set; }
        public string pubDate { get; set; }
        public string link { get; set; }
        public string guid { get; set; }
        public string author { get; set; }
        public string thumbnail { get; set; }
        public string description { get; set; }
        public string content { get; set; }
        public Enclosure enclosure { get; set; }
        public List<object> categories { get; set; }
    }

    public class Root
    {
        public string status { get; set; }
        public Feed feed { get; set; }
        public List<Item> items { get; set; }
    }

    public Haberler()
	{
		InitializeComponent();
		LoadData();
	}

    private async void LoadData()
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = "https://api.rss2json.com/v1/api.json?rss_url=https://www.trthaber.com/manset_articles.rss";
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = await response.Content.ReadAsStringAsync();

                    var result = JsonSerializer.Deserialize<Root>(jsonContent);

                    // Update title label
                    titleLabel.Text = result.feed.title;

                    foreach (var item in result.items)
                    {
                        Label newsLabel = new Label
                        {
                            Text = $"{item.title}\n{item.pubDate}\n\n{item.description}",
                            Margin = new Thickness(10),
                            LineBreakMode = LineBreakMode.WordWrap
                        };

                        contentLayout.Children.Add(newsLabel);
                    }
                }
                else
                {
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
}