namespace MedicationsApp.Models
{
    /// <summary>
    /// View Model для сущности лекарства
    /// </summary>
    public class MedicationDTO : BaseViewModel
    {
        private int _id;
        private string _name;
        private int _count;
        private int _price;
        private int? _firmId;
        private int? _pharmacyId;
        private FirmDTO _firm;
        private PharmacyDTO _pharmacy;

        /// <summary>
        /// Идентификатор лекарства
        /// </summary>
        public int Id_Medication
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Наименование лекарства
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Количество
        /// </summary>
        public int Count
        {
            get => _count;
            set
            {
                _count = value;
                OnPropertyChanged();
                OnPropertyChanged("Average");
            }
        }

        /// <summary>
        /// Цена
        /// </summary>
        public int Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged();
                OnPropertyChanged("Average");
            }
        }

        /// <summary>
        /// Идентификатор фирмы
        /// </summary>
        public int? Id_Firm
        {
            get => _firmId;
            set
            {
                _firmId = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Идентификатор аптеки
        /// </summary>
        public int? Id_Pharmacy
        {
            get => _pharmacyId;
            set
            {
                _pharmacyId = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Общая сумма
        /// </summary>
        public int Average
        {
            get => Price * Count;
        }

        /// <summary>
        /// Фирма
        /// </summary>
        public FirmDTO Firm
        {
            get => _firm;
            set
            {
                _firm = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Аптека
        /// </summary>
        public PharmacyDTO Pharmacy
        {
            get => _pharmacy;
            set
            {
                _pharmacy = value;
                OnPropertyChanged();
            }
        }
    }
}
