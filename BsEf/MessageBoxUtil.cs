using System.Windows.Forms;

namespace BsEf.Ui
{
    public class MessageBoxUtil
    {
        /// <summary>
        /// 一般信息
        /// </summary>
        /// <param name="message">信息</param>
        /// <returns></returns>
        public static DialogResult ShowTips(string message)
        {
            return MessageBox.Show(message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// 显示警告信息
        /// </summary>
        /// <param name="message">警告信息</param>
        public static DialogResult ShowWarning(string message)
        {
            return MessageBox.Show(message, @"警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// 显示错误信息
        /// </summary>
        /// <param name="message">错误信息</param>
        public static DialogResult ShowError(string message)
        {
            return MessageBox.Show(message, @"错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 显示一个YesNo选择对话框
        /// </summary>
        /// <param name="message">对话框的选择内容提示信息</param>
        public static DialogResult ShowYesNo(string message)
        {
            return MessageBox.Show(message, @"确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }
    }
}