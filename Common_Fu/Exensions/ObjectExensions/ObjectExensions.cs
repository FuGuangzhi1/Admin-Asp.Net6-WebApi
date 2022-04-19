namespace Common_Fu;

public static partial class Exensions
{
    /// <summary>
    /// 数据库实体基础数据初始化
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="isAddIdValue"></param>
    public static void InitDomainEntity(this object obj, bool isAddIdValue = false)
    {
        Type type = obj.GetType();
        if (type == null) return;
        if (isAddIdValue)
        {
            var id = type.GetProperty("Id");
            id?.SetValue(obj, GuidHelper.GuidHelper.GetNewGuid());
        }
        var createTime = type.GetProperty("CreateTime");
        createTime?.SetValue(obj, DateTime.Now);
        var upDateTime = type.GetProperty("UpdateTime");
        upDateTime?.SetValue(obj, DateTime.Now);
        var isDeleted = type.GetProperty("IsDeleted");
        isDeleted?.SetValue(obj, false);
    }

    public static void EditDomainEntity(this object obj)
    {
        Type type = obj.GetType();
        if (type == null) return;
        var upDateTime = type.GetProperty("UpdateTime");
        upDateTime?.SetValue(obj, DateTime.Now);
    }

    public static void SoftDeleteDomainEntity(this object obj)
    {
        Type type = obj.GetType();
        if (type == null) return;
        var isDeleted = type.GetProperty("IsDeleted");
        isDeleted?.SetValue(obj, true);
    }
}

