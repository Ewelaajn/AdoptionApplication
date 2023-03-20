namespace AdoptionApplication.Client.Services.Identity;

public interface IIdentityService
{
    Task<string> GetIp();
}