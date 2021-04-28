using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace regexp {
  struct RomanNumerals {
    private static readonly Dictionary<char, int> RomanDigits = new Dictionary<char, int> {
      {'I', 1},
      {'V', 5},
      {'X', 10},
      {'L', 50},
      {'C', 100},
      {'D', 500},
      {'M', 1000}
    };

    public static int Decode(string number) {
      int answer = 0;
      int previousDigit = 0;

      for (int i = number.Length - 1; i >= 0; --i) {
        int currentDigit = RomanDigits[number[i]];
        answer += currentDigit < previousDigit ? -currentDigit : currentDigit;
        previousDigit = currentDigit;
      }

      return answer;
    }
  }

  internal class Program {
    public static void Main(string[] args) {
      Console.WriteLine("Введите полный адрес входного файла и его название");
      string inPath = Console.ReadLine();
      StreamReader sr;

      try {
        sr = new StreamReader(inPath ?? throw new InvalidOperationException());
        if (sr.EndOfStream) {
          sr.Close();
          throw new Exception("There is an empty file");
        }
      }
      catch (Exception e) {
        Console.WriteLine(e.Message);
        return;
      }

      Console.WriteLine("Введите полный адрес выходного файла и его название");
      string outPath = Console.ReadLine();
      StreamWriter sw;

      try {
        sw = new StreamWriter(outPath ?? throw new InvalidOperationException());
      }
      catch (Exception e) {
        Console.WriteLine(e.Message);
        return;
      }

      Regex regex = new Regex(@"[IVXLCDM]+");
      string text = sr.ReadToEnd();
      MatchCollection matches = regex.Matches(text);

      int taskAnswer = 0;
      List<int> numbers = new List<int>();

      foreach (Match match in matches) {
        //sw.WriteLine(RomanNumerals.Decode(match.Value));
        numbers.Add(RomanNumerals.Decode(match.Value));
      }

      if (matches.Count != 0) {
        taskAnswer = numbers.Max();
      }

      sw.WriteLine(taskAnswer);

      sr.Close();
      sw.Close();
    }
  }
}