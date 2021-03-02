namespace BirdTask {
  public class Duck : Bird, IFlayable, ISwimmable {
    
    public enum Colors {
      Brown,
      Grey,
      White
    }
    
    public Duck(Colors color = Colors.Brown) {
      switch (color) {
        case Colors.Brown: {
          _color = "Brown";
          break;
        }
        case Colors.Grey: {
          _color = "Grey";
          break;
        }
        case Colors.White: {
          _color = "White";
          break;
        }
      }
    }

    public string Flying() {
      return "Duck can fly!";
    }

    public string Swimming() {
      return "Duck can swim!";
    }

    public override string Sing() {
      return "krya! krya!";
    }

    public string Color {
      get => _color;
    }

    private string _color;
  }
}