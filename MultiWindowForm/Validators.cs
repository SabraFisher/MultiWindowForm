using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformTodo
{
    public static class Validators
    {
        public static bool IsEmptyText(Control control)
            => control.Text == "";
        public static bool IsTextNull(Control control)
            => control == null;

        public static bool IsCorrectLength(Control control, int characters) 
            => control.Text.Length == characters;

        
        public static bool IsBelowMaxLength(Control control, int maxLength)
            => control.Text.Length <= maxLength;

        public static bool IsAboveMinLength(Control control, int minLength)
            => control.Text.Length >= minLength;    

        public static bool IsValidDate(Control control)
        {
            DateTime temp = DateTime.Now;
            return DateTime.TryParse(control.Text, out temp);
        }
    }
}
