using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Table = TechTalk.SpecFlow.Table;

namespace IPortSpecflowFramework.Utilities
{
    public class ExcelUtility
    {
        
        public void CreateXLSFile(string path, Table table)
        {
            IWorkbook workbook;
            IRow excelrow;
            ICell cell;

            workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet();

            using (FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                ICreationHelper creationHelper = workbook.GetCreationHelper(); //this will write data to excel sheet
                string[] colam = table.Rows[0].Keys.ToArray<string>();
                excelrow = sheet.CreateRow(0); //creates the first rowin the excel sheet
                
                for (int i = 0; i < colam.Length; i++)
                {
                    cell = excelrow.CreateCell(i);
                    cell.SetCellValue(creationHelper.CreateRichTextString(colam[i]));
                    //int columnwidth = sheet.GetColumnWidth(i);
                    //sheet.SetColumnWidth(i, columnwidth);
                    sheet.AutoSizeColumn(i);
                }
                for (int i = 0; i < table.RowCount; i++)
                {
                    excelrow = sheet.CreateRow(i + 1);
                    string[] rowarr = table.Rows[i].Values.ToArray<string>();
                    for (int j = 0; j < rowarr.Length; j++)
                    {
                        cell = excelrow.CreateCell(j);
                        cell.SetCellValue(creationHelper.CreateRichTextString(rowarr[j]));
                        //int columnwidth1 = sheet.GetColumnWidth(j);
                        //sheet.SetColumnWidth(j, columnwidth1);
                        sheet.AutoSizeColumn(j);
                    }
                }
                workbook.Write(stream);
                workbook.Close();
            }
        }
        public string ReadXLSFile(string filepath, string cellvalue)
        {
            HSSFWorkbook hSSFWorkbook;
            using (FileStream file = new FileStream(filepath, FileMode.Open, FileAccess.Read))
            {
                hSSFWorkbook = new HSSFWorkbook(file);
            }

            ISheet sheet = hSSFWorkbook.GetSheetAt(0);
            string cellValueForLogin = string.Empty;
            for(int i = 0; i < sheet.LastRowNum; i++)
            {               
                for (int j = 0; j < sheet.GetRow(i).LastCellNum; j++)
                {
                    if(sheet.GetRow(i) != null)
                    {                        
                        string celldata = sheet.GetRow(i).GetCell(j).StringCellValue;
                        if (celldata == cellvalue)
                        {
                            cellValueForLogin = sheet.GetRow(i + 1).GetCell(j).StringCellValue;
                            break;
                        }                                             
                    }
                }
                break;
            }
            return cellValueForLogin;
        }
    }
}
