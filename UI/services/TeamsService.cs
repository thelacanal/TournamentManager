using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

public class TeamService
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://localhost:7234/api/"; // Replace this with your actual API URL

    public TeamService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Team>> GetTeams()
    {
        // Send a GET request to the API endpoint that returns the list of teams
        // Deserialize the JSON response to a list of Team objects
        return await _httpClient.GetFromJsonAsync<List<Team>>(BaseUrl + "teams");
    }
}