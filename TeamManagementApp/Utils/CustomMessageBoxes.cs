using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManagementApp.Utils
{
    public static class CustomMessageBox
    {
        public static DialogResult ShowInfo(string message, string title = "Info")
        {
            return MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult ShowWarning(string message, string title = "Warning")
        {
            return MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static DialogResult ShowError(string message, string title = "Error")
        {
            return MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static DialogResult ShowStop(string message, string title = "Stop")
        {
            return MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        public static DialogResult ShowQuestion(string message, string title = "Validation")
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
