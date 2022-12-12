using GreeenGarden.Data.Entities;

namespace GreeenGarden.Business.Interface
{
    public interface ILoginService
    {
        Customer AuthenticateUser(string userName, string password);
    }
}
