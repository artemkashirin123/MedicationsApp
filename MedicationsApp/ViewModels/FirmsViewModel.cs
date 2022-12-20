using MedicationsApp.Infrastracture;
using MedicationsApp.Models;
using MedicationsApp.Repositories;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace MedicationsApp.ViewModels
{
    /// <summary>
    /// Модель представления фирм
    /// </summary>
    public class FirmsViewModel : BaseViewModel
    {
        private readonly FirmRepository _firmRepository;
        private ObservableCollection<FirmDTO> _firms;
        private FirmDTO _selectedFirm;

        /// <summary>
        /// Команда сохранения изменений
        /// </summary>
        public ICommand SaveChangesCommand => new RelayCommand(SaveChanges);

        /// <summary>
        /// Команда удаления фирм
        /// </summary>
        public ICommand RemoveCommand => new RelayCommand(Remove);

        /// <summary>
        /// Текущая фирма
        /// </summary>
        public FirmDTO SelectedFirm
        {
            get => _selectedFirm;
            set
            {
                _selectedFirm = value;
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

        public FirmsViewModel(FirmRepository firmRepository)
        {
            _firmRepository = firmRepository;
            Firms = new ObservableCollection<FirmDTO>(_firmRepository.GetFirms());
        }

        /// <summary>
        /// Сохранить изменения
        /// </summary>
        /// <param name="obj"></param>
        private void SaveChanges(object obj)
        {
            foreach (var firm in Firms)
            {
                _firmRepository.AddOrUpdate(firm);
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

            _firmRepository.Remove(id.Value);
            Refresh(null);
        }

        /// <summary>
        /// Обновление представления
        /// </summary>
        /// <param name="obj"></param>
        private void Refresh(object obj)
        {
            Firms = new ObservableCollection<FirmDTO>(_firmRepository.GetFirms());
        }
    }
}
