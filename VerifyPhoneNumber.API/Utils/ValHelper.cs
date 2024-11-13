using System.Text.RegularExpressions;

namespace VerifyPhoneNumber.API.Utils
{
    public static class ValHelper
    {
        public static bool IsValidNumber(this string mobileNumber)
        {
            if (mobileNumber == null) { return false; }
            string pattern = @"^(0|[1-9]\d*)$";
            return Regex.IsMatch(mobileNumber, pattern);
        }
    }
}
