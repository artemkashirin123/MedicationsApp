using System.Collections.Generic;

namespace MedicationsData.Models
{
    public class PharmСompany
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public IEnumerable<Medication> Medications { get; set; }
    }
}
