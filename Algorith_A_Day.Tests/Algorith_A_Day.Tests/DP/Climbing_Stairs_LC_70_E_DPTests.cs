using Algorithm_A_Day.DP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorith_A_Day.Tests.DP
{
    public class Climbing_Stairs_LC_70_E_DPTests
    {
        private readonly Climbing_Stairs_LC_70_E_DP _sut;

        public Climbing_Stairs_LC_70_E_DPTests()
        {
            _sut = new Climbing_Stairs_LC_70_E_DP();
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        [InlineData(8, 5)]
        public void ClimbStairs_ShouldReturnsInt_WhenPositiveIntPassed(int expected, int n)
        {
            //Arrange
            //Act
            var actual = _sut.ClimbStairs(n);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, -1)]
        [InlineData(0, -3)]
        public void ClimbStairs_ShouldReturnsZero_WhenNegativeIntPassed(int expected, int n)
        {
            //Arrange
            //Act
            var actual = _sut.ClimbStairs(n);
            //Assert
            Assert.Equal(expected, actual);
        }

    }
}
