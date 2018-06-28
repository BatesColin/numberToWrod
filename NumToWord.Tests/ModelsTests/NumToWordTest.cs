using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumToWord;
using System;
using System.Collections.Generic;

namespace NumToWord.Tests
{
  [TestClass]
  public class NumToWordTest
  {
    [TestMethod]
    public void SetUserNumber_GetUserNumber_True()
    {
    //arrange
    NumToWord newNumToWord = new NumToWord();
    string testNumber = "8";

    //act
    newNumToWord.SetUserNumber(testNumber);
    string result = newNumToWord.GetUserNumber();
    //assert
    Assert.AreEqual(testNumber, result);
    }

    [TestMethod]
    public void ListOfThrees_True()
    {
    //arrange
    NumToWord newNumToWord = new NumToWord();
    string testNumber = "34503830495";
    List<string> list = new List<string>{ "034", "503", "830", "495"};
    //act
    newNumToWord.SetUserNumber(testNumber);
    List<string> result = newNumToWord.ListOfThrees();
    //assert
    CollectionAssert.AreEqual(list, result);
    }

    [TestMethod]
    public void ToWords_Case1_True()
    {
    //arrange
    string testNumber1 = "964";
    //act
    string result1 = NumToWord.ToWords(testNumber1);
    //assert
    Assert.AreEqual("nine hundred sixty four", result1);
    }

    [TestMethod]
    public void ToWords_Case2_True()
    {
    //arrange
    string testNumber2 = "213";
    //act
    string result2 = NumToWord.ToWords(testNumber2);
    //assert
    Assert.AreEqual("two hundred thirteen", result2);
    }

    [TestMethod]
    public void Index_Case2_True()
    {
    //arrange
    string testNumber3 = "2342432";
    NumToWord newNumToWord1 = new NumToWord();
    //act
    newNumToWord1.SetUserNumber(testNumber3);
    newNumToWord1.ListOfThrees();
    int result3 = NumToWord.GetIndex();
    //assert
    Assert.AreEqual(3, result3);
    }
  }
}
