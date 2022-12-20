using MedicationsApp.Data;
using MedicationsApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace MedicationsApp.Repositories
{
    /// <summary>
    /// Репозиторий для бизнесс логики фирм
    /// </summary>
    public class FirmRepository
    {

        /// <summary>
        /// Получить все фирмы
        /// </summary>
        /// <returns>Список фирм</returns>
        public IEnumerable<FirmDTO> GetFirms()
        {
            using (var context = new Context())
            {
                return context.Firms.ToList().Select(x => new FirmDTO() 
                { 
                    Address = x.Address,
                    Id_Firm = x.Id_Firm,
                    Name = x.Name,
                    Phone = x.Phone
                });
            }
        }

        /// <summary>
        /// Удаление фирмы по её идентификатору
        /// </summary>
        /// <param name="id">id фирмы</param>
        public void Remove(int id)
        {
            using (var context = new Context())
            {
                var selectedFirm = context.Firms.FirstOrDefault(x => x.Id_Firm == id);
                context.Firms.Remove(selectedFirm);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Добавить или удалить фирму
        /// </summary>
        /// <param name="firm">Текущая фирма</param>
        public void AddOrUpdate(FirmDTO firm)
        {
            using (var context = new Context())
            {
                var selectedFirm = context.Firms.FirstOrDefault(x => x.Id_Firm == firm.Id_Firm);

                if (selectedFirm is null)
                {
                    context.Firms.Add(new Firm
                    {
                        Address = firm.Address,
                        Name = firm.Name,
                        Phone = firm.Phone
                    });
                    context.SaveChanges();
                    return;
                }

                selectedFirm.Phone = firm.Phone;
                selectedFirm.Name = firm.Name;
                selectedFirm.Address = firm.Address;

                context.SaveChanges();
            }
        }
    }
}
