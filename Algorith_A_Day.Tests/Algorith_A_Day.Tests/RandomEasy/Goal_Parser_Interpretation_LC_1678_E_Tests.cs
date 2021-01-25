using Algorithm_A_Day.RandomEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorith_A_Day.Tests.RandomEasy
{
    public class Goal_Parser_Interpretation_LC_1678_E_Tests
    {
        private Goal_Parser_Interpretation_LC_1678_E _sut;
        public Goal_Parser_Interpretation_LC_1678_E_Tests()
        {
            _sut = new Goal_Parser_Interpretation_LC_1678_E();
        }


        [Theory]
        [InlineData("Goal", "G()(al)")]
        [InlineData("Gooooal", "G()()()()(al)")]
        [InlineData("alGalooG", "(al)G(al)()()G")]
        public void Interpret_ReturnsValidString_WhenValidStringPassed(string expected, string command)
        {
            //Arrange

            //Act
            var actual = _sut.Interpret(command);
            //Assert
            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData("", null)]
        [InlineData("", "")]
        public void Interpret_ReturnsEmptyString_WhenEmptyOrNullPassed(string expected, string command)
        {
            //Arrange

            //Act
            var actual = _sut.Interpret(command);
            //Assert
            Assert.Equal(expected, actual);
        }

    }
}
