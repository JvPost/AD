using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MijnDatastructuren;

namespace DataStructurenUnitTests
{
	[TestClass]
	public class ArrayListTest
	{
		[TestMethod]
		public void ConstructorTest()
		{
			// arrange & act
			ArrayList<int> AL = new ArrayList<int>();

			// Assert
			Assert.AreEqual(10, AL.BaseArrayLength);
			Assert.AreEqual(0, AL.Length);
		}

		[TestMethod]
		public void PushTest()
		{
			// Arrange
			ArrayList<int> AL = new ArrayList<int>();
			int length = 10;

			// act
			for (int i = 0; i < length; i++)
			{
				AL.Push(i);
			}

			// Assert
			for (int i = 0; i < length; i++)
			{

			}
		}
	}
}
