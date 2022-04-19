using Entites.DomainModels.Account;
using Entites.ViewModel.Login;

namespace Abstract_Fu.Account
{
    public interface IAccountInterface : IBaseServices
    {
        public Task<(User?, bool)> Login(LoginData loginData);
    }
}
