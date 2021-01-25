
using Algorithm_A_Day.DesignOnes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorith_A_Day.Tests.DesignOnes
{
    public class Design_Parking_System_LC_1603_ETests
    {
        private Design_Parking_System_LC_1603_E _sut;

        public Design_Parking_System_LC_1603_ETests()
        {
            _sut = new Design_Parking_System_LC_1603_E(1, 1, 0);
        }

        [Fact]
        public void AddCar_ReturnsFalse_WhenThereIsRoomNoLeftForAnotherBigCar()
        {
            //Arrange
            _sut.AddCar(1);
            _sut.AddCar(2);
            _sut.AddCar(3);
            //Act
            var actual = _sut.AddCar(1);
            //Assert
            Assert.False(actual);
        }
        
        [Fact]
        public void AddCar_ReturnsTrue_WhenAllCarHaveRoom()
        {
            //Arrange
            _sut = new Design_Parking_System_LC_1603_E(1, 1, 1);
            
            //Act
            var actual_small = _sut.AddCar(1);
            var actual_medium = _sut.AddCar(2);
            var actual_big = _sut.AddCar(3);
            //Assert
            Assert.True(actual_small);
            Assert.True(actual_medium);
            Assert.True(actual_big);
        }
        
        [Fact]
        public void AddCar_ReturnsTrue_WhenNoRoomForCarsAtBeginning()
        {
            //Arrange
            _sut = new Design_Parking_System_LC_1603_E(0, 0, 0);
            
            //Act
            var actual_small = _sut.AddCar(1);
            var actual_medium = _sut.AddCar(2);
            var actual_big = _sut.AddCar(3);
            //Assert
            Assert.False(actual_small);
            Assert.False(actual_medium);
            Assert.False(actual_big);
        }
    }
}
