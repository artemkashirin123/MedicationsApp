using MedicationsApp.Repositories;
using MedicationsApp.Services;
using MedicationsApp.ViewModels;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Excel = Microsoft.Office.Interop.Excel;

namespace MedicationsApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для Medications.xaml
    /// </summary>
    public partial class Medications : Page
    {
        public Medications(MedicationRepository medicationRepository, PharmacyRepository pharmacyRepository, FirmRepository firmRepository, ExcelService excelService)
        {
            InitializeComponent();
            DataContext = new MedicationViewModel(medicationRepository, pharmacyRepository, firmRepository, excelService);
        }

        //private void btnExcel_Click(object sender, RoutedEventArgs e)
        //{
        //    Excel.Application excelApp = new Excel.Application();
        //    Excel.Workbook wb = excelApp.Workbooks.Open($"{Directory.GetCurrentDirectory()}\\Отчёт по продажам.xlsx");
        //    Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets[1];
        //    ws.Cells[1, 6] = DateTime.Now.ToString();
        //    int indexRows = 1;

        //    //ячейка
        //    ws.Cells[1][indexRows] = "№";
        //    ws.Cells[2][indexRows] = "Название";
        //    ws.Cells[3][indexRows] = "Цена";
        //    ws.Cells[4][indexRows] = "Количество";
        //    ws.Cells[5][indexRows] = "Сумма";
        //    ws.Cells[6][indexRows] = "Фирма";
        //    ws.Cells[7][indexRows] = "Аптека";

        //    //список пользователей из таблицы после фильтрации и поиска
        //    var printItems = DgridMedications.Items;
        //    //цикл по данным из списка для печати
        //    foreach (var item in printItems)
        //    {
        //        ws.Cells[1][indexRows + 1] = indexRows;
        //        ws.Cells[2][indexRows + 1] = item.Name;
        //        ws.Cells[3][indexRows + 1] = item.Price;
        //        ws.Cells[4][indexRows + 1] = item.Count;
        //        ws.Cells[5][indexRows + 1].Formula = $"=C*D";
        //        ws.Cells[6][indexRows + 1] = item.Firm.Name;
        //        ws.Cells[7][indexRows + 1] = item.Pharmacy.Name;

        //        indexRows++;
        //    }
        //}
    }
}
