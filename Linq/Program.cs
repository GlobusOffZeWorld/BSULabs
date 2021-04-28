using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;

namespace linqLab {
  internal class Program {
    public delegate void DisplayMethod(string strForOutput);

    public static void Main(string[] args) {
      //D:\programming\CSharpProjects\linqLab\linqLab\input.txt

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

      List<Animals> animalsList = new List<Animals>();


      string line;
      while ((line = sr.ReadLine()) != null) {
        string[] animalInfo = line.Split(new char[] {','}, StringSplitOptions.None);
        animalsList.Add(new Animals(animalInfo[1], animalInfo[0], animalInfo[2],
          animalInfo[3] == "" ? 0 : Convert.ToInt32(animalInfo[3])));
      }

      string userResponse = "";

      Console.WriteLine("Для выхода из программы введите q");
      Console.WriteLine("Введите 1 для вывода информации на консоль и 2 для вывода информации в файл output.txt");

      int withdrawType;
      if (Int32.TryParse(Console.ReadLine(), out withdrawType)) {
        //
      } else {
        Console.WriteLine("   Неверный формат ввода!");
      }

      Console.WriteLine("Введите код запроса: \n   " +
                        "1 - Найти всех владельцев кошек и собак \n   " +
                        "2 - Определить количество питомцев у каждого владельца \n   " +
                        "3 - Отобразить список владельцев, у которых количество питомцев в указанных пределах");

      StreamWriter sw;

      DisplayMethod displayMethod = Console.WriteLine;
      if (withdrawType == 2) {
        Console.WriteLine("Введите полный адрес выходного файла и его название");
        string outPath = Console.ReadLine();

        try {
          sw = new StreamWriter(outPath ?? throw new InvalidOperationException());
        }
        catch (Exception e) {
          Console.WriteLine(e.Message);
          return;
        }

        displayMethod = sw.WriteLine;
      } else {
        sw = new StreamWriter("");
      }

      while (userResponse != "q") {
        Console.WriteLine("Введите число от 1 до 3");
        userResponse = Console.ReadLine();
        int commandCode = 0;

        if (Int32.TryParse(userResponse, out commandCode)) { }

        switch (commandCode) {
          case 1: {
            var catsAndDogsOwners = from animal in animalsList
              where animal.AnimalType.ToLower() == "собака" || animal.AnimalType.ToLower() == "кошка"
              select animal;
            displayMethod("Владельцы кошек и собак: ");
            foreach (var i in catsAndDogsOwners) {
              displayMethod("   " + (i.OwnersName == "" ? "бездомное животное" : i.OwnersName));
            }

            break;
          }
          case 2: {
            var selectionOfPets = from animal in animalsList
              where animal.AnimalType.ToLower() != "мышь"
                    && animal.AnimalType.ToLower() != "хомяк"
                    && animal.AnimalType.ToLower() != "крыса"
                    && animal.AnimalType.ToLower() != "рыбка"
              select animal;
            var groupPetsForEveryOwner = from pet in selectionOfPets
              group pet by pet.OwnersName;

            foreach (var owner in groupPetsForEveryOwner) {
              if (owner.Key == "") {
                continue;
              }

              displayMethod($"   Количество питомцев у {owner.Key}: " + owner.Count());
            }

            break;
          }
          case 3: {
            Console.WriteLine("   введите через пробел два числа, между которыми должно лежать кол-во животных");

            string[] s = Console.ReadLine().Split();

            int higherNum;
            int lowerNum;

            try {
              if (Int32.TryParse(s[0], out higherNum) &&
                  Int32.TryParse(s[1], out lowerNum)) {
                //
              } else {
                throw new Exception("   Неверный формат ввода!");
              }
            }
            catch (Exception e) {
              sw.Flush();
              Console.WriteLine(e.Message);
              return;
            }

            var groupPetsForEveryOwner = from animal in animalsList
              group animal by animal.OwnersName;

            var petsCount = groupPetsForEveryOwner as IGrouping<string, Animals>[] ??
                            groupPetsForEveryOwner.ToArray();

            var numberPetsForOwner = from grouping in petsCount
              where grouping.Count() > higherNum && grouping.Count() < lowerNum
              select grouping;

            foreach (var number in numberPetsForOwner) {
              displayMethod(number.Key + " " + number.Count());
            }

            if (!numberPetsForOwner.Any()) {
              displayMethod("Нет подходящих данных");
            }

            break;
          }
        }
      }

      sr.Close();
      sw.Close();
    }
  }
}