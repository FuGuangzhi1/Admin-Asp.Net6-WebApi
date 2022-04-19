using Abstract_Fu.PersonalManagement.PersonalInfo;
using Common_Fu;
using EFCore_Fu.EFCoreFactroy;
using Entites.DomainModels.Account;
using Entities.DomainModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realization_Fu.PersonalManagement.PersonalInfo
{
    public class PersonalInfoServices : BaseServices, IPersonalInfoInterface
    {
        public PersonalInfoServices(IEFCoreFactory iEFCoreFactory) : base(iEFCoreFactory)
        {
        }

        public async Task<string?> GetProfilePhotoAsync(Guid? identity)
        {
            return await base.GetIQueryTable<UserFile>()
                .Where(x => x.UserId == identity)
                .Select(x => x.PictrueData)
                .FirstOrDefaultAsync();
        }

        public async Task<User?> GetUserAsync(Guid? identity)
          =>
           await base.FindAsync<User, Guid>(identity.ToGuid());

        public async Task<bool?> SaveProfilePhotoImgAsync(Guid? identity, string fileName, string data)
        {
            UserFile? result = await base.GetIQueryTable<UserFile>()
                .Where(x => x.UserId == identity)
                .FirstOrDefaultAsync();
            if (result is null)
            {
                UserFile file = new()
                {
                    PictrueData = data,
                    PictrueName = fileName,
                    UserId = identity
                };
                file.InitDomainEntity(true);
                await base.AddAsync<UserFile>(file);
            }
            else
            {
                result.PictrueData = data;
                result.PictrueName = fileName;
                await base.UpdateAsync<UserFile>(result);
            }
            await base.CommitAsync();
            return result is null;
        }
    }
}
