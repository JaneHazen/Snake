using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Snake.Tests
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            // arrange
            StringWriter str = new StringWriter();
            Console.SetOut(str);
            int expectedLength = Board.Boardheight * Board.Boardwidth;

            // act
           string actual = str.ToString();
           int actualLength = actual.Length;

            //assert
            Assert.AreEqual(expectedLength, actualLength);
        }
    }
}
