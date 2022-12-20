using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MedicationsApp.Models
{
    /// <summary>
    /// Базовый класс вью моделей 
    /// </summary>
    /// <remarks>
    /// Необходим для привязки интерфейса к моделям представления
    /// </remarks>
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Вызов события для обновления представления
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
