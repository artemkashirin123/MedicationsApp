using MedicationsApp.Data;
using MedicationsApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace MedicationsApp.Repositories
{
    /// <summary>
    /// Репозиторий для бизнесс логики лекарств
    /// </summary>
    public class MedicationRepository
    {
        /// <summary>
        /// Получить лекарства по фильтру(фильтр может отсутвствовать)
        /// </summary>
        /// <param name="medicationName">фильтр имени лекарства</param>
        /// <param name="priceMore">фильтр цена больше</param>
        /// <param name="priceLess">фильтр цена меньше</param>
        /// <param name="firmName">фильтр по фирме</param>
        /// <param name="pharmacyName">фильтр по аптеке</param>
        /// <returns></returns>
        public IEnumerable<MedicationDTO> GetMedications(string medicationName = null, int? priceMore = null, 
                                                                 int? priceLess = null, string firmName = null, string pharmacyName = null)
        {
            using (var context = new Context())
            {
                IEnumerable<Medication> allData = context.Medications.Include("Firm").Include("Pharmacy").ToList();

                if (!string.IsNullOrEmpty(medicationName))
                {
                    allData = allData.Where(x => x.Name == medicationName);
                }
                if (priceMore != null)
                {
                    allData = allData.Where(x => x.Price > priceMore);
                }
                if (priceLess != null)
                {
                    allData = allData.Where(x => x.Price < priceLess);
                }
                if (!string.IsNullOrEmpty(firmName))
                {
                    allData = allData.Where(x => x.Firm.Name == firmName);
                }
                if (!string.IsNullOrEmpty(pharmacyName))
                {
                    allData = allData.Where(x => x.Pharmacy.Name == pharmacyName);
                }

                var result = allData.Select(x => new MedicationDTO
                {
                    Count = x.Count,
                    Id_Firm = x.Id_Frim,
                    Id_Medication = x.Id_Medication,
                    Id_Pharmacy = x.Id_Pharmacy,
                    Name = x.Name,
                    Price = x.Price,
                    Pharmacy = x.Pharmacy != null ? new PharmacyDTO
                    {
                        Id_Pharmacy = x.Pharmacy.Id_Pharmacy,
                        Address = x.Pharmacy.Address,
                        Name = x.Pharmacy.Name,
                        Phone = x.Pharmacy.Phone
                    } : null,
                    Firm = x.Firm != null ? new FirmDTO
                    {
                        Id_Firm = x.Firm.Id_Firm,
                        Address = x.Firm.Address,
                        Name = x.Firm.Name,
                        Phone = x.Firm.Phone
                    } : null
                }).ToList();

                return result;
            }
        }

        /// <summary>
        /// Удаление лекарства по его идентификатору
        /// </summary>
        /// <param name="id">идентификатор лекарства</param>
        public void Remove(int id)
        {
            using (var context = new Context())
            {
                var selectedMedication = context.Medications.FirstOrDefault(x => x.Id_Medication == id);
                context.Medications.Remove(selectedMedication);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Добавить или удалить лекарство
        /// </summary>
        /// <param name="firm">Текущее лекарство</param>
        public void AddOrUpdate(MedicationDTO medication)
        {
            using (var context = new Context())
            {
                var selectedMedication = context.Medications.FirstOrDefault(x => x.Id_Medication == medication.Id_Medication);

                if (selectedMedication is null)
                {
                    context.Medications.Add(new Medication
                    {
                        Count = medication.Count,
                        Id_Frim = medication.Id_Firm,
                        Id_Pharmacy = medication.Id_Pharmacy,
                        Name = medication.Name,
                        Price = medication.Price,
                    });
                    context.SaveChanges();
                    return;
                }

                selectedMedication.Id_Frim = medication.Firm?.Id_Firm;
                selectedMedication.Id_Pharmacy = medication.Pharmacy?.Id_Pharmacy;
                selectedMedication.Name = medication.Name;
                selectedMedication.Price = medication.Price;
                selectedMedication.Count = medication.Count;

                context.SaveChanges();
            }
        }
    }
}
