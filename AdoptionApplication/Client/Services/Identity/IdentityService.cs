namespace AdoptionApplication.Client.Services.Identity;

public class IdentityService : IIdentityService
{
    private readonly HttpClient _httpClient;

    public IdentityService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetIp()
    {
        var result = await _httpClient.GetStringAsync($"api/Identity");
        return result;
    }
}