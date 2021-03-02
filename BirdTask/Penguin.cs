using System.Drawing;

namespace BirdTask {
  public class Penguin : Bird, ISwimmable {

    public enum Colors {
      Black,
      DarkBlue,
      Brown
    }
    public Penguin(Colors color = Colors.Black) {
      switch (color) {
        case Colors.Black: {
          _color = "Black";
          break;
        }
        case Colors.DarkBlue: {
          _color = "Dark blue";
          break;
        }
        case Colors.Brown: {
          _color = "Brown";
          break;
        }
      }
    }

    public string Swimming() {
      return "Penguin can swim!";
    }

    public override string Sing() {
      return "waaaaaraaaa! waaaaaraaaa!";
    }

    public string Color {
      get => _color;
    }


    private string _color;
  }
}