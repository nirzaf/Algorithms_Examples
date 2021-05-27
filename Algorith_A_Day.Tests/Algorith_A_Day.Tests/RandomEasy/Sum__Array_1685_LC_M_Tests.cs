using Algorithm_A_Day.RandomMedium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorith_A_Day.Tests.RandomEasy
{

    public class Sum__Array_1685_LC_M_Tests
    {
        private Sum__Array_1685_LC_M _sut;
        public Sum__Array_1685_LC_M_Tests()
        {
            _sut = new Sum__Array_1685_LC_M();
        }

        [Theory]
        [InlineData(new int[] { 4, 3, 5 }, new int[] { 2, 3, 5 })]
        [InlineData(new int[] { 24, 15, 13, 15, 21 }, new int[] { 1, 4, 6, 8, 10 })]
        [InlineData(new int[] { }, new int[] { })]
        [InlineData(new int[] { }, null)]

        public void GetSumAbsoluteDifferences_ReturnsIntArray_WhenValidDataPassed(int[] expected, int[] nums)
        {
            //Arrange

            //Act
            var actual = _sut.GetSumAbsoluteDifferences(nums);
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
