namespace linqLab {
  public class Animals {

    public Animals(string animalType, string ownersName, string animalName, int animalAge = 0) {
      AnimalType = animalType;
      OwnersName = ownersName;
      AnimalName = animalName;
      AnimalAge = animalAge;
    }

     public override string ToString() {
       string age = AnimalAge == 0? "none" : AnimalAge.ToString();
       return $"Type: {AnimalType}\n" +
              $"Owner: {OwnersName}\n" +
              $"Animal name: {AnimalName}\n" +
              $"Age: {age} \n";
     }


    public string OwnersName {
      get => _ownersName;
      set => _ownersName = value;
    }

    public string AnimalType {
      get => _animalType;
      set => _animalType = value;
    }

    public string AnimalName {
      get => _animalName;
      set => _animalName = value;
    }

    public int AnimalAge {
      get => _animalAge;
      set => _animalAge = value;
    }

    private string _ownersName;
    private string _animalType;
    private string _animalName;
    private int _animalAge;
  }
}