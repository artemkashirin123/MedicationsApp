using MedicationsApp.Data;
using MedicationsApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace MedicationsApp.Repositories
{
    /// <summary>
    /// Репозиторий для бизнесс логики аптек
    /// </summary>
    public class PharmacyRepository
    {
        /// <summary>
        /// Получить все аптеки
        /// </summary>
        /// <returns>Список аптек</returns>
        public IEnumerable<PharmacyDTO> GetPharmacies()
        {
            using (var context = new Context())
            {
                return context.Pharmacies.ToList().Select(x => new PharmacyDTO()
                {
                    Address = x.Address,
                    Id_Pharmacy = x.Id_Pharmacy,
                    Name = x.Name,
                    Phone = x.Phone
                });
            }
        }

        /// <summary>
        /// Удаление аптеки по её идентификатору
        /// </summary>
        /// <param name="id">id аптеки</param>
        public void Remove(int id)
        {
            using (var context = new Context())
            {
                var selectedPharmacy = context.Pharmacies.FirstOrDefault(x => x.Id_Pharmacy == id);
                context.Pharmacies.Remove(selectedPharmacy);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Добавить или удалить аптеку
        /// </summary>
        /// <param name="firm">Текущая аптека</param>
        public void AddOrUpdate(PharmacyDTO pharmacy)
        {
            using (var context = new Context())
            {
                var selectedPharmacy = context.Pharmacies.FirstOrDefault(x => x.Id_Pharmacy == pharmacy.Id_Pharmacy);

                if (selectedPharmacy is null)
                {
                    context.Pharmacies.Add(new Pharmacy
                    {
                        Address = pharmacy.Address,
                        Name = pharmacy.Name,
                        Phone = pharmacy.Phone
                    });
                    context.SaveChanges();
                    return;
                }

                selectedPharmacy.Phone = pharmacy.Phone;
                selectedPharmacy.Name = pharmacy.Name;
                selectedPharmacy.Address = pharmacy.Address;

                //context.SaveChanges();
            }
        }
    }
}