global using Microsoft.EntityFrameworkCore;
using Abstract_Fu.Home;
using Common_Fu;
using EFCore_Fu.EFCoreFactroy;
using Entites.DomainModels.Resource;
using Entities.DomainModels.RelationshipTable;
using Entities.DtoModels.MenuDto;

namespace Realization_Fu.Home;

public class HomeServices : BaseServices, IHomeInterface
{
    public HomeServices(IEFCoreFactory iEFCoreFactory) : base(iEFCoreFactory)
    {
    }

    public async Task<IEnumerable<MenuDto>?> FindIdbyMenuDataAsync(Guid? id)
    {
        //通过用户ID找到他的所有角色ID
        IQueryable<Guid>? roleIdList = base
            .QueryEntityCommon<UserRole>(x => x.UserId == id.ToGuid())
            ?.Where(x => !x.IsDeleted)
            .Select(x => x.RoleId);
        //通过角色ID找到他的资源ID
        IEnumerable<Guid>? roleResouces = await base
            .QueryEntityCommon<RoleResource>(x => roleIdList!.Contains(x.RoleId))
            !.Select(x => x.ResourceId)!.ToListAsync();
        //获取所以资源
        IEnumerable<Resource> resourcesList = await base
            .QueryEntityCommon<Resource>(x => roleResouces!.Contains(x.Id))
            !.ToListAsync();
        if (resourcesList is null) return null;
        return GetMenuDto(resourcesList, null, new List<MenuDto>());
    }
    //通过递归将资源分级
    private IEnumerable<MenuDto>? GetMenuDto(IEnumerable<Resource> Resources, Guid? parentId, List<MenuDto> menuDtos)
    {
        var nextMenuList = Resources.Where(x => x.ParentId == parentId); //父级菜单

        foreach (var menu in nextMenuList)  //遍历给当前级菜单加子菜单
        {
            MenuDto currentMenuDto = new()
            {
                MenuId = menu.Id,
                MenuName = menu.ResourceName ?? string.Empty,
                Icon = menu.Icon ?? string.Empty,
                Level = menu.Level,
                Path = menu.Path ?? string.Empty,
                ParentId = menu.ParentId,
                Sort = menu.Sort
            };
            //当前的下一级菜单
            List<Resource> resources = Resources.Where(m => m.ParentId != parentId).ToList();
            GetMenuDto(resources, menu.Id, currentMenuDto.Children);
            menuDtos.Add(currentMenuDto);
        }

        return menuDtos;
    }
}

