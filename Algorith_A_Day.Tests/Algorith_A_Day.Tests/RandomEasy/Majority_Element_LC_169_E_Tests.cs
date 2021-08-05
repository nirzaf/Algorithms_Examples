using Algorithm_A_Day.RandomEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorith_A_Day.Tests.RandomEasy
{
    public class Majority_Element_LC_169_E_Tests
    {
        private readonly Majority_Element_LC_169_E _sut;

        public Majority_Element_LC_169_E_Tests()
        {
            _sut = new Majority_Element_LC_169_E();
        }

        [Theory]
        [InlineData(3, new int[] { 3, 2, 3 })]
        [InlineData(2, new int[] { 2, 2, 1, 1, 1, 2, 2 })]
        public void MajorityElement_ReturnsInt_WhenValidArrayPassed(int expected, int[] nums)
        {
            //Arrange

            //Act
            var actual = _sut.MajorityElement(nums);
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
