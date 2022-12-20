using System.Collections.Generic;

namespace MedicationsData.Models
{
    public class Medication
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Count { get; set; }

        public decimal Price { get; set; }

        public PharmСompany PharmСompany { get; set; }

        public Stock Stock { get; set; }
    }

}
