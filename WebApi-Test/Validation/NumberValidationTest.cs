using WebApi.DataValidation;
using System;
using Xunit;

namespace WebApi_Test.Validation
{
    public class NumberValidationTest
    {
        private readonly NumberValidation _validation;
        public NumberValidationTest()
        {
            _validation = new NumberValidation();
        }

        [Fact]
        public void IsValid_ValidRegistrationNumber_ReturnsTrue()
        {
            Assert.True(_validation.IsValid("G-RNAC"));
        }

        [Theory]
        [InlineData("G-RNACC")]
        [InlineData("G-RNAC")]
        public void IsValid_AccountNumberFirstPartWrong_ReturnsFalse(string accountNumber)
        {
            Assert.False(_validation.IsValid(accountNumber));
        }

        [Theory]
        [InlineData("G-RNAC")]
        [InlineData("G-RNACA")]
        public void IsValid_RegistrationNumberMiddlePartWrong_ReturnsFalse(string accNumber)
        {
            Assert.False(_validation.IsValid(accNumber));
        }

        [Theory]
        [InlineData("G-RNAC")]
        [InlineData("G-RNACC")]
        public void IsValid_RegistrationNumberLastPartWrong_ReturnsFalse(string accNumber)
        {
            Assert.False(_validation.IsValid(accNumber));
        }

        [Theory]
        [InlineData("G-RNAC")]
        [InlineData("G+RNAC")]
        [InlineData("G-RNAC=")]
        public void IsValid_InvalidDelimiters_ThrowsArgumentException(string accNumber)
        {
            Assert.Throws<ArgumentException>(() => _validation.IsValid(accNumber));
        }
    }
}

