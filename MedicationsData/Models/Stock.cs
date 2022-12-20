using System.Collections.Generic;

namespace MedicationsData.Models
{
    public class Stock
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Medication> Medications { get; set; }
    }
}
