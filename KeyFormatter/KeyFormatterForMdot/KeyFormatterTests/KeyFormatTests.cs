using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KeyFormatterForMdot;


/*
 * Class: KeyFormatTests
 * Author: Brendan Kelly
 * Date: 17/10/2017
 * Description: Unit test class for the KeyFormatter project
 */


namespace KeyFormatterTests
{
    [TestClass]
    public class KeyFormatTests
    {
        [TestMethod]
        public void TestKeyFormatAccurate()
        {
            //arrange
            string testKey = "5562df80acf603217ceadab0ee515f6d";
            string expected = "0x55, 0x62, 0xdf, 0x80, 0xac, 0xf6, 0x03, 0x21, 0x7c, 0xea, 0xda, 0xb0, 0xee, 0x51, 0x5f, 0x6d";

            //act
            string result = KeyChanger.FormatKey(testKey);

            //assert
            Assert.AreEqual(result,expected);
        }


        [TestMethod]
        public void TestDevAddrFormatAccurate()
        {
            //arrange
            string testKey = "5562df80";
            string expected = "0x55, 0x62, 0xdf, 0x80";

            //act
            string result = KeyChanger.FormatKey(testKey);

            //assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void TestKeyFailureOnBadCharacters()
        {
            //arrange
            string testKey = "5562df80a^f603217ceadab0!e515f6d";
            string expected = KeyChanger.INVALID_KEY;

            //act
            string result = KeyChanger.FormatKey(testKey);

            //assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void TestKeyFailureOnKeyTooShort()
        {
            //arrange
            string testKey = "5562df80dab0ee515f6d";
            string expected = KeyChanger.INVALID_KEY;

            //act
            string result = KeyChanger.FormatKey(testKey);

            //assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void TestKeyFailureOnKeyTooLong()
        {
            //arrange
            string testKey = "5562df80acf603217ceadab0effffffffffffffffffffffffe515f6d";
            string expected = KeyChanger.INVALID_KEY;

            //act
            string result = KeyChanger.FormatKey(testKey);

            //assert
            Assert.AreEqual(result, expected);
        }
    
    }
}
