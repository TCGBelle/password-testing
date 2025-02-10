using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;



namespace std
{
    public class PasswordTesterTests
    {
        public void Main()
        {

        }
        [Fact]
        [Trait("TestType", "PasswordTest")]
        public void PasswordTester_ShouldReturnIsNull_WhenPasswordIsNull()
        {
            var result = Passwords.PasswordTester(null, 5, 25, true, true);
            Assert.True(result.HasFlag(errorType.IsNull));
        }
        [Fact]
        [Trait("TestType", "PasswordTest")]
        public void PasswordTester_ShouldReturnBelowMinimum_WhenSizeIsBelowMaximum()
        {
            var result = Passwords.PasswordTester("ValidPassword1", 0,25, true, true);
            Assert.True(result.HasFlag(errorType.BelowMinimum));
        }
        [Fact]
        [Trait("TestType", "PasswordTest")]
        public void PasswordTester_ShouldReturnBelowSize_WhenPasswordTooShort()
        {
            var result = Passwords.PasswordTester("Iv2", 5, 25, true, true);
            Assert.True(result.HasFlag(errorType.BelowSize));
        }
        [Fact]
        [Trait("TestType", "PasswordTest")]
        public void PasswordTester_ShouldReturnAboveMaximum_WhenMaxSizeIsTooLarge()
        {
            var result = Passwords.PasswordTester("ValidPassword1", 5, 300, true, true);
            Assert.True(result.HasFlag(errorType.AboveMaximum));
        }
        [Fact]
        [Trait("TestType", "PasswordTest")]
        public void PasswordTester_ShouldReturnAboveSize_WhenPasswordTooLong()
        {
            var result = Passwords.PasswordTester(new string('A', 30), 5,25, false, true);
            Assert.True(result.HasFlag(errorType.AboveSize));
        }
        [Fact]
        [Trait("TestType", "PasswordTest")]
        public void PasswordTester_ShouldReturnNoCapitals_WhenCapitalLetterRequired()
        {
            var result = Passwords.PasswordTester("password1", 5, 25, true, true);
            Assert.True(result.HasFlag(errorType.NoCapitals));
        }
        [Fact]
        [Trait("TestType", "PasswordTest")]
        public void PasswordTester_ShouldReturnNoDigits_WhenDigitRequired()
        {
            var result = Passwords.PasswordTester("Password", 5, 25, true, true);
            Assert.True(result.HasFlag(errorType.NoDigits));
        }
        [Fact]
        [Trait("TestType", "PasswordTest")]
        public void PasswordTester_ShouldReturnMultipleErrors_WhenMultipleRulesFail()
        {
            var result = Passwords.PasswordTester("abc", 5, 25, true, true);
            Assert.True((result & (errorType.BelowSize | errorType.NoDigits | errorType.NoCapitals)) == (errorType.BelowSize | errorType.NoDigits | errorType.NoCapitals));
        }
        [Fact]
        [Trait("TestType", "PasswordTest")]
        public void PasswordTester_ShouldReturnNone_WhenPasswordIsValid()
        {
            var result = Passwords.PasswordTester("ValidPassword1", 5, 25, true, true);
            Assert.Equal(errorType.None, result);
        }
    }
}
