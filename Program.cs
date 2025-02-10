using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace std
{
    [Flags]
    public enum errorType
    {
        None = 0,
        BelowMinimum = 1 << 0,
        AboveMaximum = 1 << 1,
        IsNull = 1 << 2,
        BelowSize = 1 << 3,
        AboveSize = 1 << 4,
        NoDigits = 1 << 5,
        NoCapitals = 1 << 6
    }
    public static class Passwords
    {
        public static errorType PasswordTester(string password, int minSize, int maxSize ,bool needDigit, bool needCapital)
        {
            errorType errors = errorType.None;

            if (password == null)
            {
                return errorType.IsNull;
            }

            if (minSize <= 0)
                errors |= errorType.BelowMinimum;

            if (maxSize >= 256)
                errors |= errorType.AboveMaximum;

            if (password.Length < minSize)
                errors |= errorType.BelowSize;

            if (password.Length > maxSize)
                errors |= errorType.AboveSize;

            if (needCapital && !password.Any(char.IsUpper))
                errors |= errorType.NoCapitals;

            if (needDigit && !password.Any(char.IsDigit))
                errors |= errorType.NoDigits;

            return errors;
        }
    }
}