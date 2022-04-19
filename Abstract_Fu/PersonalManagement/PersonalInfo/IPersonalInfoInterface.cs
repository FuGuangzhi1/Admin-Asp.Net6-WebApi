using Entites.DomainModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Fu.PersonalManagement.PersonalInfo
{
    public interface IPersonalInfoInterface : IBaseServices
    {
        Task<User?> GetUserAsync(Guid? identity);
        Task<bool?> SaveProfilePhotoImgAsync(Guid? identity, string fileName, string data);
        Task<string?> GetProfilePhotoAsync(Guid? identity);
    }
}
