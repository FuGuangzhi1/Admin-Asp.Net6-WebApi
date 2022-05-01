using NPOI.HSSF.UserModel;
using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common_Fu.ExeclHelper
{
    public class MyNpoiExeclHelper : IMyNpoiExeclHelper
    {
        public IWorkbook CreateExecl<T>(IList<T> dataList, string sheetname, bool isXlsx=false)
        {
            IWorkbook workbook;
            //创建工作簿
            if (isXlsx)
            {
                workbook = new XSSFWorkbook(); //xls
            }
            else
            {
                workbook = new HSSFWorkbook(); //xlsx
            }
            workbook.CreateFont().FontName = "宋体";
            //
            //创建工作表
            ISheet sheet = workbook.CreateSheet(sheetname);
            //反射获取列明
            Type type = typeof(T);
            //所有属性
            var propArray = type.GetProperties();
            //创建execl第一行数据（列名）
            {
                IRow row = sheet.CreateRow(0);
                int index = 0;
                foreach (var prop in propArray)
                {
                    var attrArray = prop.GetCustomAttributes(true);
                    foreach (var attr in attrArray)
                    {
                        if (attr is TitleAttribute titleAttribute)
                        {
                            ICell cell = row.CreateCell(index);
                            cell.SetCellValue(titleAttribute.Title);
                            //设置文字对齐方式
                            cell.CellStyle.Alignment = HorizontalAlignment.Center; //水平居中
                            cell.CellStyle.VerticalAlignment = VerticalAlignment.Center; //垂直居中
                            sheet.SetColumnWidth(index, 13 * 256);
                            index++;
                        }
                    }

                }
            }
            //循环数据集合写入工作表
            for (int i = 1; i < dataList.Count + 1; i++)
            {
                IRow row = sheet.CreateRow(i);

                T datarow = dataList[i - 1];
                int index = 0;
                foreach (var prop in propArray)
                {
                    var attrArray = prop.GetCustomAttributes(true);
                    foreach (var attr in attrArray)
                    {
                        if (attr is TitleAttribute titleAttribute)
                        {
                            ICell cell = row.CreateCell(index);
                            //根据属性名字获取单个数据
                            cell.SetCellValue(datarow?.GetPropertyValue(prop.Name)?.ToString());
                            index++;
                        }
                    }
                }
            }

            return workbook;
        }

        public List<T>? CreateList<T>(IWorkbook wook)
        {
            int sheetIndexLength = wook.ActiveSheetIndex;
            for (int sheetIndex = 0; sheetIndex < sheetIndexLength; sheetIndex++)
            {
                ISheet sheet = wook.GetSheetAt(sheetIndex);
                IRow heardRow = sheet.CreateRow(sheet.FirstRowNum);
                if (heardRow is null) break;
                //int index = 0;
                //for (int i = 0; i < heardRow.LastCellNum; i++)
                //{
                //    ICell cell=heardRow.GetCell(i);
                //    if (cell is not null) 
                //    {

                //    }
                //}

            }
            return default;
        }
    }
}
