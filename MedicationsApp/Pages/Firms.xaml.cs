using MedicationsApp.Repositories;
using MedicationsApp.ViewModels;
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

namespace MedicationsApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для Firms.xaml
    /// </summary>
    public partial class Firms : Page
    {
        public Firms(FirmRepository firmRepository)
        {
            InitializeComponent();
            DataContext = new FirmsViewModel(firmRepository);
        }
    }
}
