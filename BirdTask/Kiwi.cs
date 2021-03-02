using System;

namespace BirdTask {
  public class Kiwi : Bird {
    public enum Colors {
      Grey,
      Brown,
      White
    }

    public Kiwi(Colors color = Colors.Grey) {
      switch (color) {
        case Colors.Grey: {
          _color = "Grey";
          break;
        }
        case Colors.Brown: {
          _color = "Brown";
          break;
        }
        case Colors.White: {
          _color = "White";
          break;
        }
      }
    }

    public override string Sing() {
      return "wiii! wiii! wii!";
    }

    public string Color {
      get => _color;
    }

    private string _color;
  }
}