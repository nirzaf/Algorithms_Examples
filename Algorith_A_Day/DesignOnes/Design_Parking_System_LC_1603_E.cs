using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_A_Day.DesignOnes
{
    public class Design_Parking_System_LC_1603_E
    {
        private int _big;
        private int _medium;
        private int _small;

        public Design_Parking_System_LC_1603_E(int big, int medium, int small)
        {
            _big = big;
            _medium = medium;
            _small = small;
        }

        public bool AddCar(int carType)
        {
            if (carType == 1)
            {
                if (_big > 0)
                {
                    _big--;
                    return true;
                }
                return false;

            }
            else if (carType == 2)
            {
                if (_medium > 0)
                {
                    _medium--;
                    return true;
                }
                return false;
            }
            else if (carType == 3)
            {
                if (_small > 0)
                {
                    _small--;
                    return true;
                }
                return false;
            }
            return false;
        }
    }

    // approach with array where index is carType - 1;
    public class ParkingSystem
    {

        private int[] _parkingLot = new int[3];

        public ParkingSystem(int big, int medium, int small)
        {
            _parkingLot[0] = big;
            _parkingLot[1] = medium;
            _parkingLot[2] = small;
        }

        public bool AddCar(int carType)
        {
            if (_parkingLot[carType - 1] <= 0) return false;
            _parkingLot[carType - 1]--;
            return true;
        }
    }

    // diffrent approach
    public class ParkingSystem2
    {

        private int _big;
        private int _medium;
        private int _small;

        public ParkingSystem2(int big, int medium, int small)
        {
            _big = big;
            _medium = medium;
            _small = small;
        }

        public bool AddCar(int carType)
        {
            switch (carType)
            {
                case 1:
                    return _AddCar(ref _big);
                case 2:
                    return _AddCar(ref _medium);
                case 3:
                    return _AddCar(ref _small);
                default:
                    return false;

            }
        }

        private bool _AddCar(ref int parkingVar)
        {
            if (parkingVar == 0)
            {
                return false;
            }

            parkingVar--;
            return true;
        }
    }

}
