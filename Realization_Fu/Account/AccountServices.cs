using Abstract_Fu.Account;
using Common_Fu;
using EFCore_Fu;
using EFCore_Fu.EFCoreFactroy;
using Entites.DomainModels.Account;
using Entites.ViewModel.Login;
using Microsoft.EntityFrameworkCore;

namespace Realization_Fu.Account
{
    public class AccountServices : BaseServices, IAccountInterface
    {
        public AccountServices
            (IEFCoreFactory iEFCoreFactory) : base(iEFCoreFactory)
        {
        }
        public async Task<(User?, bool)> Login(LoginData loginData)
        {
            User? user = await (from T1 in base.GetIQueryTable<User>()
                                join T2 in base.GetIQueryTable<PassWord>()
                           on T1.Id equals T2.UserId
                                where T1.Email == loginData.Email
                                where T2.NewPassWord == loginData.Password.ToMD5()
                                select T1).FirstOrDefaultAsync();
            if (user is null) return (null, false);
            else return (user, true);
        }
    }
}
