using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_A_Day.RandomEasy
{
	public class Self_Dividing_Numbers_LC_728_E
	{
		public static IList<int> SelfDividingNumbers(int left, int right)
		{
			if (left > right) return new List<int>();

			IList<int> result = new List<int>();

			for (int i = left; i <= right; i++)
			{
				if (IsASelfDividingNumber(i)) result.Add(i);
			}
			return result;
		}

		private static bool IsASelfDividingNumber(int number)
		{
			string convertedNumber = number.ToString();

			if (convertedNumber.Contains('0')) return false;

			bool result = true;

			foreach (char c in convertedNumber)
			{
				if (number % ToInt(c) != 0) result = false;
			}

			return result;
		}

		private static int ToInt(char c)
		{
			return (int)(c - '0');
		}



		// % 10 to get digit and / 10 - cropping digit
		public IList<int> SelfDividingNumbers3(int left, int right)
		{
			IList<int> res = new List<int>();
			for (int i = left; i <= right; i++)
			{
				bool passed = true;
				int num = i;
				while (true)
				{
					if (num == 0)
					{
						break;
					}

					int digit = num % 10;

					if (digit == 0)
					{
						passed = false;
						break;
					}

					if (i % digit != 0)
					{
						passed = false;
						break;
					}

					num = num / 10;
				}

				if (passed)
				{
					res.Add(i);
				}
			}

			return res;
		}

		public IList<int> SelfDividingNumbers4(int left, int right)
		{
			var retList = new List<int>();
			for (int i = left; i <= right; i++)
			{
				if (IsSelfDividingNo(i))
					retList.Add(i);
			}
			return retList;
		}
		private static bool IsSelfDividingNo(int i)
		{
			var num = i;// eg 128
			while (num > 1)// > 1, as 1 is always self dividing num.
			{
				var reminder = num % 10; // 128%10 = 8
				if (reminder == 0 || i % reminder != 0) // if reminder is 0 or 128%8!=0  then its not self dividing
				{
					return false;
				}
				num = num / 10;// cropping last digit .
			}
			return true;
		}

		//unecessary LINQ?
		public IList<int> SelfDividingNumbers2(int left, int right)
		{
			return Enumerable.Range(0, right - left + 1)
				.Select(x => x + left)
				.Where(x => !x.ToString().Contains("0"))
				.Where(x => x.ToString().ToCharArray().Select(y => int.Parse(y.ToString())).All(y => x % y == 0))
				.ToList();
		}


		/*
		 const selfDividingNumbers = (left, right) => {
		const output = [];
  
		// for each number from left to right
		for (let i = left; i <= right; i += 1) {
		let divisible = true;
	
		 // check if the number is divisible by each digit
		 for (let char of i.toString()) {
			if (i % Number(char) || Number(char) === 0) {
			divisible = false;
		}
		}
	
		// if it is, push onto output array
		if (divisible) {
		output.push(i);
		}
		}
  
		return output;
		};
		 


		const isSelfDividing = num => {
		let x = num;
		while (num > 0) {
		if (x % (num % 10) !== 0) { return false; } //TODO:understand
		num = Math.floor(num / 10);
		}
		return true;
		}

		const selfDividingNumbers = (left, right) => {
			let res = [];
			for (let num = left; num <= right; num++) {
			if (isSelfDividing(num)) { res.push(num); }
			}
			return res;
		};
		 */
	}
}
