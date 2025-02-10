using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace std
{
    public enum errorType
    {
        None,
        BelowMinimum,
        AboveMaximum,
        IsNull,
        BelowSize,
        AboveSize,
        NoDigits,
        NoCapitals
    }
    public static class Passwords
    {

        public static List<errorType> PasswordTester(string password, int minSize, int maxSize ,bool needDigit, bool needCapital)
        {
            List<errorType> errors = new List<errorType>();

            if (password == null)
            {
                errors.Add(errorType.IsNull);
                return errors;
            }

            if (minSize <= 0)
                errors.Add(errorType.BelowMinimum);

            if (maxSize >= 256)
                errors.Add(errorType.AboveMaximum);

            if (password.Length < minSize)
                errors.Add(errorType.BelowSize);

            if (password.Length > maxSize)
                errors.Add(errorType.AboveSize);

            if (needCapital && !password.Any(char.IsUpper))
                errors.Add(errorType.NoCapitals);

            if (needDigit && !password.Any(char.IsDigit))
                errors.Add(errorType.NoDigits);

            return errors.Count > 0 ? errors : new List<errorType> { errorType.None };
        }
    }
}