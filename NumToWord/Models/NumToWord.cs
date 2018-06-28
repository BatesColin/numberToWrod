using System;
using System.Collections.Generic;

namespace NumToWord
{
public class NumToWord
  {
    private string _userNumber;
    private static int _index;
    public static Dictionary<string, string> dictionary0To19 = new Dictionary<string, string>()
    {
      {"0",""},
      {"1","one"},
      {"2","two"},
      {"3","three"},
      {"4","four"},
      {"5","five"},
      {"6","six"},
      {"7","seven"},
      {"8","eight"},
      {"9","nine"},
      {"10","ten"},
      {"11","eleven"},
      {"12","twelve"},
      {"13","thirteen"},
      {"14","fourteen"},
      {"15","fifteen"},
      {"16","sixteen"},
      {"17","seventeen"},
      {"18","eighteen"},
      {"19","nineteen"}
    };
    public static Dictionary<string, string> dictionary20To90 = new Dictionary<string, string>()
    {
      {"2","twenty"},
      {"3","thirty"},
      {"4","forty"},
      {"5","fifty"},
      {"6","sixty"},
      {"7","seventy"},
      {"8","eighty"},
      {"9","ninety"}
    };
    public static Dictionary<string, string> dictionary100To900 = new Dictionary<string, string>()
    {
      {"0",""},
      {"1","one hundred"},
      {"2","two hundred"},
      {"3","three hundred"},
      {"4","four hundred"},
      {"5","five hundred"},
      {"6","six hundred"},
      {"7","seven hundred"},
      {"8","eight hundred"},
      {"9","nine hundred"}
    };
    public static Dictionary<int, string> dictionaryHundredPlus = new Dictionary<int, string>()
    {
      {1, ""},
      {2,"thousand"},
      {3,"million"},
      {4,"billion"},
      {5,"trillion"}
    };
    public static int GetIndex()
    {
      return _index;
    }
    public static void SetIndex(int index)
    {
      _index = index;
    }
    public string GetUserNumber()
    {
      return _userNumber;
    }
    public void SetUserNumber(string userNumber)
    {
      _userNumber = userNumber;
    }
    public List<string> ListOfThrees()
    {
      string numberToThrees = _userNumber;
      int numberLength = numberToThrees.Length;
      if (numberLength % 3 == 2)
      {
        numberToThrees = "0" + numberToThrees;
      }
      else if (numberLength % 3 == 1)
      {
        numberToThrees = "00" + numberToThrees;
      }
      List<string> threesList = new List<string> {};
      NumToWord.SetIndex(numberToThrees.Length/3);
      for (int i = 0; i < numberToThrees.Length/3; i++)
      {
        threesList.Add(numberToThrees.Substring(i*3,3));
      }
      return threesList;
    }
    public static string ToWords(string three)
    {
      List<string> sectionSplit = new List<string> {};
      if(three[1] == '1')
      {
        sectionSplit.Add(three.Substring(0,1));
        sectionSplit.Add(three.Substring(1,2));
        return NumToWord.dictionary100To900[sectionSplit[0]] + " " + NumToWord.dictionary0To19[sectionSplit[1]];
      }
      else
      {
        for (int j = 0; j < 3; j++)
        {
          sectionSplit.Add(three.Substring(j,1));
        }
        return NumToWord.dictionary100To900[sectionSplit[0]] + " " + NumToWord.dictionary20To90[sectionSplit[1]] + " " + NumToWord.dictionary0To19[sectionSplit[2]];
      }
    }
    public static string AllToWords(List<string> splitNumber)
    {
      string numberToWords = "";
      for (int k = 0; k < NumToWord.GetIndex(); k++)
      {
        numberToWords = numberToWords + NumToWord.ToWords(splitNumber[k]) + NumToWord.dictionaryHundredPlus[NumToWord.GetIndex() - k];
      }
      return numberToWords;
    }
  }
  public class Program
  {
    public static void Main()
    {
      Console.WriteLine("Input a number and I will change it to words.");
      string userInput = Console.ReadLine();
      NumToWord newNumToWord = new NumToWord();
      newNumToWord.SetUserNumber(userInput);
      Console.WriteLine(NumToWord.AllToWords(newNumToWord.ListOfThrees()));
    }
  }
}
