using System;
using System.Windows.Forms;
using BsEf.Logic.ViewModels.User;

namespace BsEf.Ui
{
    internal static class Program
    {
        public static Login LoginPage;
        public static BasePage BasePage;
        public static UserViewModel UserInfo = new UserViewModel();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginPage=new Login();
            Application.Run(LoginPage);
        }
    }
}
