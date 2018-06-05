using System;
using System.Windows.Forms;
using BsEf.Common;
using BsEf.Logic.ViewModels.User;

namespace BsEf.Ui
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Focus();
            textBox1.Focus();

            var postData = new { Account = textBox1.Text, Password = textBox2.Text };
            var data = HttpClientUtil.PostResponse<UserViewModel>(HttpClientUtil.ApiUrl + "logins/login/", postData);
            Program.UserInfo = data;
            ShowMsgBox(data);
        }

        private void ShowMsgBox(object response)
        {
            if (response != null)
            {
                MessageBoxUtil.ShowTips("登陆成功"+ Program.UserInfo.UserNo +"/"+ Program.UserInfo.UserName);
                var basePage = new BasePage();
                Program.BasePage = basePage;
                basePage.Show();
                Hide();
            }
            else
            {
                MessageBoxUtil.ShowError("登陆失败");
            }
        }

        private void label1_Click(object sender, EventArgs e){}
        private void Login_Load(object sender, EventArgs e){}
        private void textBox2_TextChanged(object sender, EventArgs e){}
        private void textBox1_TextChanged(object sender, EventArgs e){}
    }
}
