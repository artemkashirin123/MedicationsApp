using MedicationsApp.Infrastracture;
using MedicationsApp.Models;
using MedicationsApp.Repositories;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace MedicationsApp.ViewModels
{
    /// <summary>
    /// Модель представления аптек
    /// </summary>
    public class PharmacyViewModel : BaseViewModel
    {
        private readonly PharmacyRepository _pharmacyRepository;
        private ObservableCollection<PharmacyDTO> _pharmacies;
        private PharmacyDTO _selectedPharmacy;

        /// <summary>
        /// Команда сохранения изменений
        /// </summary>
        public ICommand SaveChangesCommand => new RelayCommand(SaveChanges);

        /// <summary>
        /// Команда удаления аптек
        /// </summary>
        public ICommand RemoveCommand => new RelayCommand(Remove);

        /// <summary>
        /// Текущая аптека
        /// </summary>
        public PharmacyDTO SelectedPharmacy 
        { 
            get => _selectedPharmacy; 
            set
            { 
                _selectedPharmacy = value;
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

        public PharmacyViewModel(PharmacyRepository pharmacyRepository)
        {
            _pharmacyRepository = pharmacyRepository;
            Pharmacies = new ObservableCollection<PharmacyDTO>(_pharmacyRepository.GetPharmacies());
        }

        /// <summary>
        /// Сохранить изменения
        /// </summary>
        /// <param name="obj"></param>
        private void SaveChanges(object obj)
        {
            foreach (var pharmacy in Pharmacies)
            {
                _pharmacyRepository.AddOrUpdate(pharmacy);
            }
            Refresh(null);
        }

        /// <summary>
        /// Удалить фирму
        /// </summary>
        /// <param name="obj">id фирмы</param>
        private void Remove(object obj)
        {
            var id = obj as int?;
            if (id is null)
            {
                MessageBox.Show("Отсутствует id для удаления записи");
                return;
            }

            _pharmacyRepository.Remove(id.Value);
            Refresh(null);
        }

        /// <summary>
        /// Обновление представления
        /// </summary>
        /// <param name="obj"></param>
        private void Refresh(object obj)
        {
            Pharmacies = new ObservableCollection<PharmacyDTO>(_pharmacyRepository.GetPharmacies());
        }
    }
}
