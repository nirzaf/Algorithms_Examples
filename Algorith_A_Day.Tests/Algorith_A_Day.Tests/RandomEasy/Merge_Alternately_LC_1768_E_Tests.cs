using Algorithm_A_Day.RandomEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorith_A_Day.Tests.RandomEasy
{
    public class Merge_Alternately_LC_1768_E_Tests
    {
        private Merge_Alternately_LC_1768_E _sut;
        public Merge_Alternately_LC_1768_E_Tests()
        {
            _sut = new Merge_Alternately_LC_1768_E();
        }

        [Theory]
        [InlineData("abc", "pqr", "apbqcr")]
        [InlineData("abcd", "pq", "apbqcd")]
        [InlineData("ab", "pqrs", "apbqrs")]
        [InlineData("", "xxx", "xxx")]
        [InlineData("xxx", "", "xxx")]

        public void MergeAlternately_Returns_WhenValidDataPassed(string word1, string word2, string expected)
        {
            //Arrange

            //Act
            var actual = _sut.MergeAlternately(word1, word2);
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
