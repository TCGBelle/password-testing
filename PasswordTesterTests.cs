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
        [Fact]
        [Trait("TestType", "PasswordTest")]
        public void PasswordTester_ShouldReturnIsNull_WhenPasswordIsNull()
        {
            var result = Passwords.PasswordTester(null, 5, 25, true, true);
            Assert.Equal(new List<errorType> { errorType.IsNull }, result);
        }
        [Fact]
        [Trait("TestType", "PasswordTest")]
        public void PasswordTester_ShouldReturnBelowMinimum_WhenSizeIsZero()
        {
            var result = Passwords.PasswordTester("ValidPassword1", 0,25, true, true);
            Assert.Contains(errorType.BelowMinimum, result);
        }
        [Fact]
        [Trait("TestType", "PasswordTest")]
        public void PasswordTester_ShouldReturnBelowSize_WhenPasswordTooShort()
        {
            var result = Passwords.PasswordTester("Iv2", 5, 25, true, true);
            Assert.Contains(errorType.BelowSize, result);
        }
        [Fact]
        [Trait("TestType", "PasswordTest")]
        public void PasswordTester_ShouldReturnAboveMaximum_WhenMaxSizeIsTooLarge()
        {
            var result = Passwords.PasswordTester("ValidPassword1", 5, 300, true, true);
            Assert.Contains(errorType.AboveMaximum, result);
        }
        [Fact]
        [Trait("TestType", "PasswordTest")]
        public void PasswordTester_ShouldReturnAboveSize_WhenPasswordTooLong()
        {
            var result = Passwords.PasswordTester(new string('A', 30), 5,25, false, true);
            Assert.Contains(errorType.AboveSize, result);
        }
        [Fact]
        [Trait("TestType", "PasswordTest")]
        public void PasswordTester_ShouldReturnNoCapitals_WhenCapitalLetterRequired()
        {
            var result = Passwords.PasswordTester("password1", 5, 25, true, true);
            Assert.Contains(errorType.NoCapitals, result);
        }
        [Fact]
        [Trait("TestType", "PasswordTest")]
        public void PasswordTester_ShouldReturnNoDigits_WhenDigitRequired()
        {
            var result = Passwords.PasswordTester("Password", 5, 25, true, true);
            Assert.Contains(errorType.NoDigits, result);
        }
        [Fact]
        [Trait("TestType", "PasswordTest")]
        public void PasswordTester_ShouldReturnMultipleErrors_WhenMultipleRulesFail()
        {
            var result = Passwords.PasswordTester("abc", 5, 25, true, true);
            var expectedErrors = new List<errorType> { errorType.BelowSize, errorType.NoCapitals, errorType.NoDigits };
            Assert.Equal(expectedErrors, result);
        }
        [Fact]
        [Trait("TestType", "PasswordTest")]
        public void PasswordTester_ShouldReturnNone_WhenPasswordIsValid()
        {
            var result = Passwords.PasswordTester("ValidPassword1", 5, 25, true, true);
            Assert.Equal(new List<errorType> { errorType.None }, result);
        }
    }
}
