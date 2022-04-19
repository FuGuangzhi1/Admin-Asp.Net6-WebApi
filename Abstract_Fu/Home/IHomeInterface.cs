using Entities.DtoModels.MenuDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Fu.Home
{
    public interface IHomeInterface : IBaseServices
    {
        Task<IEnumerable<MenuDto>?> FindIdbyMenuDataAsync(Guid? identity);
    }
}
