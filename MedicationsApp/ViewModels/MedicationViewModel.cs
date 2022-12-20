using MedicationsApp.Infrastracture;
using MedicationsApp.Models;
using MedicationsApp.Repositories;
using MedicationsApp.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace MedicationsApp.ViewModels
{
    /// <summary>
    /// Модель представления лекарств
    /// </summary>
    public class MedicationViewModel : BaseViewModel
    {
        private readonly MedicationRepository _medicationRepository;
        private readonly FirmRepository _firmRepository;
        private readonly PharmacyRepository _pharmacyRepository;
        private readonly ExcelService _excelService;

        private MedicationDTO _selectedMedication;
        private ObservableCollection<MedicationDTO> _medications;
        private ObservableCollection<FirmDTO> _firms;
        private ObservableCollection<PharmacyDTO> _pharmacies;
        private string _nameFilter;
        private int? _priceMoreFilter;
        private int? _priceLessFilter;
        private string _firmNameFilter;
        private string _pharmacyNameFilter;

        /// <summary>
        /// Список лекарств
        /// </summary>
        public ObservableCollection<MedicationDTO> Medications
        {
            get => _medications;
            set
            {
                _medications = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Список фирм
        /// </summary>
        public ObservableCollection<FirmDTO> Firms 
        { 
            get => _firms; 
            set 
            { 
                _firms = value;
                OnPropertyChanged(); 
            } 
        }

        /// <summary>
        /// Список аптек
        /// </summary>
        public ObservableCollection<PharmacyDTO> Pharmacies 
        { 
            get => _pharmacies; 
            set 
            { 
                _pharmacies = value; 
                OnPropertyChanged(); 
            } 
        }
        /// <summary>
        /// Команда сохранения изменений
        /// </summary>
        public ICommand SaveChangesCommand => new RelayCommand(SaveChanges);

        /// <summary>
        /// Команда удаления лекарств
        /// </summary>
        public ICommand RemoveCommand => new RelayCommand(Remove);

        /// <summary>
        /// Команда фильтрации
        /// </summary>
        public ICommand FindCommand => new RelayCommand(Find);

        /// <summary>
        /// Команда обновления изменений
        /// </summary>
        public ICommand RefreshCommand => new RelayCommand(Refresh);

        /// <summary>
        /// Команда выгрузки данных в excel
        /// </summary>
        public ICommand ExcelCommand => new RelayCommand(Excel);

        /// <summary>
        /// Фильтр наименования 
        /// </summary>
        public string NameFilter
        {
            get => _nameFilter;
            set
            {
                _nameFilter = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Фильтр цена больше
        /// </summary>
        public int? PriceMoreFilter
        {
            get => _priceMoreFilter;
            set
            {
                _priceMoreFilter = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Фильтр цена меньше
        /// </summary>
        public int? PriceLessFilter
        {
            get => _priceLessFilter;
            set
            {
                _priceLessFilter = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Фильтр наименование фирмы
        /// </summary>
        public string FirmNameFilter
        {
            get => _firmNameFilter;
            set
            {
                _firmNameFilter = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Фильтр наименование аптеки
        /// </summary>
        public string PharmacyNameFilter
        {
            get => _pharmacyNameFilter;
            set
            {
                _pharmacyNameFilter = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Текущее лекарство
        /// </summary>
        public MedicationDTO SelectedMedication
        {
            get => _selectedMedication;
            set
            {
                _selectedMedication = value;
                OnPropertyChanged();
            }
        }

        public MedicationViewModel(MedicationRepository medicationRepository, PharmacyRepository pharmacyRepository, FirmRepository firmRepository, ExcelService excelService)
        {
            _medicationRepository = medicationRepository;
            _firmRepository = firmRepository;
            _pharmacyRepository = pharmacyRepository;
            _excelService = excelService;

            Medications = new ObservableCollection<MedicationDTO>(_medicationRepository.GetMedications());
            Firms = new ObservableCollection<FirmDTO>(_firmRepository.GetFirms());
            Pharmacies = new ObservableCollection<PharmacyDTO>(_pharmacyRepository.GetPharmacies());
        }

        /// <summary>
        /// Сохранить изменения
        /// </summary>
        /// <param name="obj"></param>
        private void SaveChanges(object obj)
        {
            foreach (var medication in Medications)
            {
                _medicationRepository.AddOrUpdate(medication);
            }
            Refresh(null);
        }

        /// <summary>
        /// Удалиить лекарство по id
        /// </summary>
        /// <param name="obj"></param>
        private void Remove(object obj)
        {
            var id = obj as int?;
            if (id is null)
            {
                MessageBox.Show("Отсутствует id для удаления записи");
                return;
            }    
                
            _medicationRepository.Remove(id.Value);
            Refresh(null);
        }

        /// <summary>
        /// Фильтрация 
        /// </summary>
        /// <param name="obj"></param>
        private void Find(object obj)
        {
            var filteredData = _medicationRepository.GetMedications(NameFilter, PriceMoreFilter, PriceLessFilter, FirmNameFilter, PharmacyNameFilter);
            Medications = new ObservableCollection<MedicationDTO>(filteredData);
        }

        /// <summary>
        /// Обновить представление
        /// </summary>
        /// <param name="obj"></param>
        private void Refresh(object obj)
        {
            Medications = new ObservableCollection<MedicationDTO>(_medicationRepository.GetMedications());
        }

        private void Excel(object obj)
        {
            var isCreate = _excelService.UploadExcel(Medications.ToList());

            if (!isCreate) MessageBox.Show("Ошибка вывода в excel");//TODO: доработать нормальную систему исключений
        }
    }
}
