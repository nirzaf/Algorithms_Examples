using Algorithm_A_Day.RandomEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorith_A_Day.Tests.RandomEasy
{
    public class Shuffle_String_LC_1528_E_Tests
    {
        private Shuffle_String_LC_1528_E _sut;
        public Shuffle_String_LC_1528_E_Tests()
        {
            _sut = new Shuffle_String_LC_1528_E();
        }


        [Theory]
        [InlineData("abc", "abc", new int[] { 0, 1, 2 } )]
        [InlineData("aiohn", "nihao", new int[] { 3, 1, 4, 2, 0 })]
        [InlineData("leetcode", "codeleet", new int[] { 4, 5, 6, 7, 0, 2, 1, 3 })]
        [InlineData("arigatou", "aaiougrt", new int[] { 4, 0, 2, 6, 7, 3, 1, 5 })]
        [InlineData("", "aaiougrt", new int[] { 4, 0 })]

        public void Interpret_ReturnsShuffledString_WhenValidDataPassed(string expected, string s, int[] indices)
        {
            //Arrange

            //Act
            var actual = _sut.RestoreString(s, indices);
            //Assert
            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData("", "", new int[] { 4, 0, 2, 6, 7, 3, 1, 5 })]
        [InlineData("", null, new int[] { 4, 0, 2, 6, 7, 3, 1, 5 })]
        [InlineData("ssss", "ssss", new int[] {  })]
        [InlineData("ssss", "ssss", null)]
        public void Interpret_ReturnsEmptyStringOrString_WhenEmptyOrNullPassed(string expected, string s, int[] indices)
        {
            //Arrange

            //Act
            var actual = _sut.RestoreString(s, indices);
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
