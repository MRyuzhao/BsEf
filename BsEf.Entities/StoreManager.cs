using System.Collections.Generic;

namespace BsEf.Entities
{
    public class StoreManager : Entity
    {
        public int UserId { get; set; }

        public virtual ICollection<Store> Stores { get; set; }
        public virtual User User { get; set; }
    }
}