using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Ev2_1636902
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Campeones : ContentPage
    {

        private const string championListUrl = "https://ddragon.leagueoflegends.com/cdn/13.18.1/data/en_US/champion.json";
        private const string currentNAVersionUrl = "https://ddragon.leagueoflegends.com/realms/na.json";

        public Campeones()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            _ = LoadChampionImagesAsync();
        }

        private async Task LoadChampionImagesAsync()
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                string json = await httpClient.GetStringAsync(championListUrl);

                // Parse the JSON response
                JObject championData = JObject.Parse(json);

                // Extract champion image URLs
                JObject champions = championData["data"].ToObject<JObject>();

                int column = 0;
                int row = 0;

                foreach (var champion in champions)
                {
                    string championName = champion.Key;
                    string championImageUrl = champion.Value["image"]["full"].ToString();

                    // Create a new Image control for each champion
                    Image image = new Image
                    {
                        Aspect = Aspect.AspectFit,
                        WidthRequest = 150, // Ajusta el ancho de la imagen según tus necesidades
                        HeightRequest = 90, // Ajusta la altura de la imagen según tus necesidades
                        Margin = new Thickness(1), // Agrega un margen entre las imágenes
                    };

                    // Set the image source to the champion's image URL
                    image.Source = ImageSource.FromUri(new Uri($"https://ddragon.leagueoflegends.com/cdn/13.18.1/img/champion/{championImageUrl}"));

                    // Add the image to the Grid in the specified row and column
                    grid.Children.Add(image, column, row);

                    // Increment the column counter
                    column++;

                    // When reaching the fifth column, move to a new row
                    if (column >= 5)
                    {
                        column = 0;
                        row++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }


    }
}