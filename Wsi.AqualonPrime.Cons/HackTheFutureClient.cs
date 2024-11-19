using System.Net.Http.Json;
using Wsi.AqualonPrime.Cons.Dtos;

namespace Wsi.AqualonPrime.Cons
{

    public class HackTheFutureClient : HttpClient
    {
        public HackTheFutureClient()
        {
            BaseAddress = new Uri("https://app-htf-2024.azurewebsites.net/");
        }

        public async Task Login(string teamname, string password)
        {
            HttpResponseMessage response = await GetAsync($"/api/team/token?teamname={teamname}&password={password}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("You weren't able to log in, did you provide the correct credentials?");
            }

            AuthResponse? token = await response.Content.ReadFromJsonAsync<AuthResponse>() ?? throw new Exception("Invalid Token Parsing");
            DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Token);
        }
    }
}
