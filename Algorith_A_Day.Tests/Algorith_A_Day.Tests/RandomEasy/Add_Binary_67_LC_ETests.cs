using Algorithm_A_Day.RandomEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorith_A_Day.Tests.RandomEasy
{
    public class Add_Binary_67_LC_ETests
    {
        private readonly Add_Binary_67_LC_E _sut;
        public Add_Binary_67_LC_ETests()
        {
            _sut = new Add_Binary_67_LC_E();
        }


        [Theory]
        [InlineData("11", "1", "100")]
        [InlineData("1010", "1011", "10101")]
        public void AddBinary_ReturnsString_When2ProperStringsPassed(string a, string b, string expected)
        {
            //Arrange

            //Act
            var actual = _sut.AddBinary(a, b);
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
