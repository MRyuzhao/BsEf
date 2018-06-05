using System.Collections.Generic;
using BsEf.Common;

namespace BsEf.Entities
{
    public class User : Entity
    {
        /// <summary>
        /// 员工编号
        /// </summary>
        public string UserNo { get; set; }
        /// <summary>
        /// 员工姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public Enums.Sex Sex { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// 删除状态
        /// </summary>
        public Enums.DeleteStatus DeleteState { get; set; }

        public virtual SystemUser SystemUser { get; set; }
        public virtual ICollection<StoreManager> StoreManagers { get; set; }
    }
}