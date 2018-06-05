using System.Collections.Generic;

namespace BsEf.Entities
{
    public class Store:Entity
    {
        public string StoreNo { get; set; }

        public string StoreName { get; set; }

        public virtual ICollection<StoreManager> StoreManagers { get; set; }
    }
}