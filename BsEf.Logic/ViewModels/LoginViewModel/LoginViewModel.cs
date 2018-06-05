namespace BsEf.Logic.ViewModels.LoginViewModel
{
    public class LoginViewModel
    {
        public int Id { get; set; }
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
        public string Sex { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// 删除状态
        /// </summary>
        public string DeleteState { get; set; }
    }
}