using Algorithm_A_Day.RandomEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorith_A_Day.Tests.RandomEasy
{
    public class Number_of_Steps_to_Zero_LC_1342_E_Tests
    {
        private readonly Number_of_Steps_to_Zero_LC_1342_E _sut;
        public Number_of_Steps_to_Zero_LC_1342_E_Tests()
        {
            _sut = new Number_of_Steps_to_Zero_LC_1342_E();
        }

        [Theory]
        [InlineData(6, 14)]
        [InlineData(4, 8)]
        public void NumbersOfSteps_ReturnsInt_WhenNonNegativeIntPassed(int expected, int num)
        {
            //Arrange

            //Act
            var actual = _sut.NumberOfSteps(num);
            //Assert
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, -2)]
        public void NumbersOfSteps_ReturnsZero_WhenNegativeOrZeroPassed(int expected, int num)
        {
            //Arrange

            //Act
            var actual = _sut.NumberOfSteps(num);
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
