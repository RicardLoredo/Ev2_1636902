using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

public class RiotGamesApiService
{
    private const string ApiKey = "TU_API_KEY"; // Reemplaza con tu clave de API de Riot Games

    public async Task<ChampionData> GetChampionDataAsync()
    {
        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri("https://na1.api.riotgames.com/lol/"); // Cambia "na1" según tu región
            client.DefaultRequestHeaders.Add("X-Riot-Token", ApiKey);

            HttpResponseMessage response = await client.GetAsync("/lol/platform/v3/champion-rotations"); // Ejemplo de ruta de la API

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                ChampionData championData = JsonConvert.DeserializeObject<ChampionData>(content);
                return championData;
            }
            else
            {
                // Manejar el error aquí
                return null;
            }
        }
    }

    public class ChampionData
    {
        public int ChampionId { get; set; }
        public string ChampionName { get; set; }
        public string Role { get; set; }
    }
}
