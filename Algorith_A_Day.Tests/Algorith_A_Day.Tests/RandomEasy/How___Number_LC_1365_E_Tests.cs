using Algorithm_A_Day.RandomEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorith_A_Day.Tests.RandomEasy
{

    //Arrange

    //Act

    //Assert
    public class How___Number_LC_1365_E_Tests
    {
        private readonly How___Number_LC_1365_E _sut;
        public How___Number_LC_1365_E_Tests()
        {
            _sut = new How___Number_LC_1365_E();
        }


        [Theory]
        [InlineData(new int[] { 4, 0, 1, 1, 3 }, new int[] { 8, 1, 2, 2, 3 })]
        [InlineData(new int[] { 0, 0, 0, 0 }, new int[] { 7, 7, 7, 7 })]
        public void SmallerNumbersThanCurrent_ReturnsArray_WhenValidArrIsPassed(int[] expected, int[] nums)
        {
            //Arrange

            //Act
            var result = _sut.SmallerNumbersThanCurrent(nums);
            //Assert
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData(new int[] {  }, new int[] {  })]
        [InlineData(new int[] {  }, null)]
        public void SmallerNumbersThanCurrent_ReturnsEmptyArray_WhenInEmptyArrOrNullIsPassed(int[] expected, int[] nums)
        {
            //Arrange

            //Act
            var result = _sut.SmallerNumbersThanCurrent(nums);
            //Assert
            Assert.Equal(expected, result);
        }
    }
}
