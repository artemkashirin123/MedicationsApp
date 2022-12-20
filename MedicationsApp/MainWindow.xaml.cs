using MedicationsApp.Data;
using MedicationsApp.Repositories;
using MedicationsApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MedicationsApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Main_Click(null, null);
        }

        private void Medications_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.Medications(new MedicationRepository(), new PharmacyRepository(), new FirmRepository(), new ExcelService()));
        }

        private void Firms_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.Firms(new FirmRepository()));
        }

        private void Pharmacies_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.Pharmacy(new PharmacyRepository()));
        }

        private void Main_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.Main());
        }
    }
}
