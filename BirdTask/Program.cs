using System;
using System.Xml;

namespace BirdTask {
  class Program {
    static void Main(string[] args) {
      
      Budgerigar budgerigar = new Budgerigar(Budgerigar.Colors.Green);
      Console.WriteLine(budgerigar.Sing());
    }
  }
}