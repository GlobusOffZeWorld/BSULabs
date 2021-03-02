namespace BirdTask {
  public class Budgerigar : Bird, IFlayable {
    
    public enum Colors {
      Green,
      Yellow,
      Blue,
      White
    }
    
    public Budgerigar(Colors color = Colors.Green) {
      switch (color) {
        case Colors.Green: {
          _color = "Green";
          break;
        }
        case Colors.Yellow: {
          _color = "Yellow";
          break;
        }
        case Colors.Blue: {
          _color = "Blue";
          break;
        }
        case Colors.White: {
          _color = "White";
          break;
        }
      }
    }

    public string Flying() {
      return "Budgerigar can fly!";
    }

    public override string Sing() {
      return "I'm a parrot and i can speak! PI number one!";
    }

    public string Color {
      get => _color;
    }


    private string _color;
  }
}