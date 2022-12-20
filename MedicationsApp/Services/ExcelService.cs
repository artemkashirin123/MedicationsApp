using MedicationsApp.Models;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System;

namespace MedicationsApp.Services
{
    public class ExcelService
    {
        public bool UploadExcel(List<MedicationDTO> printItems)
        {
            try
            {
                Application excelApp = new Application();
                var ws = GetWorksheet(excelApp);
                ws.Cells[1, 6] = DateTime.Now.ToString();
                int indexRows = 1;

                //ячейка
                ws.Cells[1][indexRows] = "№";
                ws.Cells[2][indexRows] = "Название";
                ws.Cells[3][indexRows] = "Цена";
                ws.Cells[4][indexRows] = "Количество";
                ws.Cells[5][indexRows] = "Сумма";
                ws.Cells[6][indexRows] = "Фирма";
                ws.Cells[7][indexRows] = "Аптека";

                //цикл по данным из списка для печати
                foreach (var medication in printItems)
                {
                    ws.Cells[1][indexRows + 1] = indexRows;
                    ws.Cells[2][indexRows + 1] = medication.Name;
                    ws.Cells[3][indexRows + 1] = medication.Price;
                    ws.Cells[4][indexRows + 1] = medication.Count;
                    ws.Cells[5][indexRows + 1].Formula = $"=C*D";
                    ws.Cells[6][indexRows + 1] = medication.Firm.Name;
                    ws.Cells[7][indexRows + 1] = medication.Pharmacy.Name;

                    indexRows++;
                }
                excelApp.Visible = true;
                return true;
            }
            catch (Exception ex)
            {
                //TODO: Можно возвращать сообщение об ошибке и вверху его обрабатывать и выводить
                return false;
            }
           
        }

        private Worksheet GetWorksheet(Application application)
        {
            var path = Path.Combine(Environment.CurrentDirectory, $"Отчёт по медикаментам{DateTime.Now.ToString("yyyy_MM_dd")}.xlsx");
            if (!File.Exists(path))
            {
                var workbook = application.Workbooks.Add();
                workbook.SaveAs(path);
            }

            Workbook wb = application.Workbooks.Open(path);//Что если нет файла? Нужно предусмотреть
            Worksheet ws = (Worksheet)wb.Worksheets[1];

            return ws;
        }
    }
}
