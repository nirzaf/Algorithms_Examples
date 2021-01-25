using Algorithm_A_Day.FromCompanies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorith_A_Day.Tests.FromCompanies
{
    /// <summary>
    /// Napisz przynajmniej 3 testy jednostkowe do funkcji IleJestWDrugiejTablicy (z poprzedniego pytania).
    /// W tym zadaniu oceniane jest pokrycie różnych przypadków, 
    /// a kluczowe jest użycie unikalnych nazw funkcji testowych zgodnie dobrymi praktykami BDD.
    /// A więc nazwa funkcji testowej musi mówić co jest testowane,
    /// jaki przypadek testowy (scenariusz użycia) jest testowany oraz jaki jest oczekiwany wynik."
    /// </summary>
    public class LyftronTests
    {
        private readonly Lyftron _lyftron;

        public LyftronTests()
        {
            _lyftron = new Lyftron();
        }

        [Theory]
        [InlineData(1, new string[] { "abc", "def", "ghi" }, new string[] { "aaaa", "def", "ddd"})]
        [InlineData(2, new string[] { "abc", "def", "ddd" }, new string[] { "aaaa", "def", "ddd"})]
        public void IleJestWDrugiejTablicy_ShouldReturnInt_WhenGivenArraysWithNoDuplicates(
            int expected , string[] arr1, string[] arr2)
        {
            //Arrange

            //Act
            int actual = _lyftron.IleJestWDrugiejTablicy(arr1, arr2);

            //Assert
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData(1, new string[] { "abc", "def", "ghi" }, new string[] { "aaaa", "def", "def"})]
        [InlineData(2, new string[] { "abc", "def", "def" }, new string[] { "aaaa", "def", "ddd" })]
        [InlineData(2, new string[] { "aaaaa", "def", "ghi" }, new string[] { "abc", "abc", "def", "def", "ghi" })]
        [InlineData(2, new string[] { "aaaaa", "def", "def" }, new string[] { "abc", "abc", "def", "def", "ghi" })]
        public void IleJestWDrugiejTablicy_ShouldReturnInt_WhenAnyGivenArraysOrBothHasDuplicates(
            int expected , string[] arr1, string[] arr2)
        {
            //Arrange

            //Act
            int actual = _lyftron.IleJestWDrugiejTablicy(arr1, arr2);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, new string[] { }, new string[] { "aaaa", "def", "ddd" })]
        [InlineData(0, new string[] { "aaaa", "def", "ddd"  }, new string[] {  })]
        [InlineData(0, null, new string[] { "aaaa", "def", "ddd" })]
        [InlineData(0, new string[] { "aaaa", "def", "ddd" }, null)]
        public void IleJestWDrugiejTablicy_ShouldReturn0_WhenAnyGivenAarrayIsEmptyorNull(
            int expected , string[] arr1, string[] arr2)
        {
            //Arrange

            //Act
            int actual = _lyftron.IleJestWDrugiejTablicy(arr1, arr2);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
