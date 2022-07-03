using IdentityModel.Client;
using Newtonsoft.Json.Linq;
public class Program
{
    private static async Task Main()
    {

        var client = new HttpClient();
        var disco = await client.GetDiscoveryDocumentAsync("https://localhost:7080");

        if (disco.IsError)
        {
            Console.WriteLine(disco.Error);
            return;
        }

        var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
        {
            Address = disco.TokenEndpoint,

            ClientId = "client",
            ClientSecret = "secret",
            Scope = "MeetupAPI"
        });

        if (tokenResponse.IsError)
        {
            Console.WriteLine(tokenResponse.Error);
            return;
        }

        Console.WriteLine(tokenResponse.Json);

        var apiClient = new HttpClient();
        apiClient.SetBearerToken(tokenResponse.AccessToken);

        
    }
}