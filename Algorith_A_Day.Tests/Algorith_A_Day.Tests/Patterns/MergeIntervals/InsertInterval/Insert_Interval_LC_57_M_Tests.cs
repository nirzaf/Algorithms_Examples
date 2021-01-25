using Algorithm_A_Day.Patterns.MergeIntervals.InsertInterval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorith_A_Day.Tests.Patterns.MergeIntervals.InsertInterval
{
    public class Insert_Interval_LC_57_M_Tests
    {
        private readonly Insert_Interval_LC_57_M _sut;
        public Insert_Interval_LC_57_M_Tests()
        {
            _sut = new Insert_Interval_LC_57_M();
        }


        [Fact]
        public void Insert_ReturnsMatrixWithNewInterval_WhenEmptyintervalsPassed()
        {
            //Arrange
            var intervals = new int[][] {  };
            var newInterval = new int[] { 2, 5 };

            var expected = new int[][] { newInterval };

            //Act
            var actual = _sut.Insert(intervals, newInterval );

            //Assert
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void Insert_ReturnsMergedMatrix_WhenProperIntervalsPassed()
        {
            //Arrange
            var intervals1 = new int[][] { new int[] { 1, 3 }, new int[] { 6, 9 } };
            var intervals2 = new int[][] { new int[] { 1, 2 }, new int[] { 3, 5 },
                                           new int[] { 6, 7 }, new int[] { 8, 10 },
                                           new int[] { 12, 16 } };
            var expected1 = new int[][] { new int[] { 1, 5 }, new int[] { 6, 9 } };
            var expected2 = new int[][] { new int[] { 1, 2 }, new int[] { 3, 10 },
                                           new int[] { 12, 16 } };

            //Act
            var actual1 = _sut.Insert(intervals1, new int[] { 2, 5 });
            var actual2 = _sut.Insert(intervals2, new int[] { 4, 8 });
            //Assert
            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
        }
    }
}
