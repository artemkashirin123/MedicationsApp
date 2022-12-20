using System.Collections.Generic;

namespace MedicationsApp.Models
{
    /// <summary>
    /// View Model для сущности Фирмы
    /// </summary>
    public class FirmDTO : BaseViewModel
    {
        private int id_Firm;
        private string name;
        private string address;
        private string phone;
        private List<MedicationDTO> medications;

        /// <summary>
        /// Идентификатор фирмы
        /// </summary>
        public int Id_Firm
        {
            get => id_Firm;
            set 
            {
                id_Firm = value;
                OnPropertyChanged();
            } 
        }

        /// <summary>
        /// Наименование фирмы
        /// </summary>
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Адресс фирмы
        /// </summary>
        public string Address
        {
            get => address;
            set
            {
                address = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Номер телефона фирмы
        /// </summary>
        public string Phone
        {
            get => phone;
            set
            {
                phone = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Список лекарств
        /// </summary>
        public List<MedicationDTO> Medications
        {
            get => medications;
            set
            {
                medications = value;
                OnPropertyChanged();
            }
        }
    }
}
