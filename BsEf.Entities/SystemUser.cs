using System;
using BsEf.Common;

namespace BsEf.Entities
{
    public class SystemUser:Entity
    {
        public string LoginName { get; set; }
        public string Password { get; set; }
        public DateTime LastLoginDate { get; set; }
        public Enums.DeleteStatus DeleteState { get; set; }
        public virtual User User { get; set; }
    }
}
