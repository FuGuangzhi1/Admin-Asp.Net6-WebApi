using NPOI.SS.UserModel;

namespace Common_Fu.ExeclHelper
{
    public interface IMyNpoiExeclHelper
    {
        IWorkbook CreateExecl<T>(IList<T> dataList, string sheetname);
        List<T>? CreateList<T>(IWorkbook wook);
    }
}