using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Midterm_420_DA3_AS_Part2.VALIDATION
{
    internal class Validator
    {
        public static bool IsValidID(string id)
        {
            return (Regex.IsMatch(id, @"^\d{7}$"));
        }
        public static bool IsValidEmail(string email)
        {
            return (Regex.IsMatch(email, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"));
        }
        public static bool IsValidPhoneNumberFormat(string phone)
        {
            return (Regex.IsMatch(phone, @"^\(\d{3}\)\d{3}-\d{4}$"));
        }
        public static bool IsValidName(string name)
        {
            if (name.Length == 0 || name.Length > 50)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < name.Length; i++)
                {
                    if ((!Char.IsLetter(name[i])) && (!Char.IsWhiteSpace(name[i])))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
