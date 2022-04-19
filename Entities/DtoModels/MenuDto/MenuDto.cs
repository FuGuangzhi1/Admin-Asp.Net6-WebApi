namespace Entities.DtoModels.MenuDto
{
    public class MenuDto
    {
        public MenuDto()
        {
            Children = new List<MenuDto>();
        }
        public Guid MenuId { get; set; } = Guid.NewGuid();
        public string? MenuName { get; set; } = string.Empty;
        public Nullable<Guid> ParentId { get; set; } = null;
        public string? Path { get; set; } = string.Empty;
        public long Level { get; set; } = 0;  //层级
        public string? Icon { get; set; } = null;
        public int Sort { get; set; } = 0;
        public List<MenuDto> Children { get; set; }
    }


}
