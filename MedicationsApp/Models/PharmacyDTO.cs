using System.Collections.Generic;

namespace MedicationsApp.Models
{

    /// <summary>
    /// View Model для сущности аптеки
    /// </summary>
    public class PharmacyDTO : BaseViewModel
    {
        private int id_Pharmacy;
        private string name;
        private string address;
        private string phone;
        private List<MedicationDTO> medications;

        /// <summary>
        /// Идентификатор аптеки
        /// </summary>
        public int Id_Pharmacy 
        {
            get => id_Pharmacy;
            set 
            { 
                id_Pharmacy = value; 
                OnPropertyChanged(); 
            } 
        }

        /// <summary>
        /// Наименование аптеки
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
        /// Адресс аптеки
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
        /// Телефон аптеки
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

