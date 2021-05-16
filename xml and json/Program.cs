using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml;
using Newtonsoft.Json;

namespace XML {
  public class CandidateJson {
    CandidateJson(string name, List<Dish> dishes) {
      CandidateName = name;
      Dishes = new List<Dish>(dishes);
    }
    
    public string CandidateName {
      get => _candidateName;
      set => _candidateName = value;
    }

    public List<Dish> Dishes {
      get => _dishes;
      set => _dishes = value;
    }
    
    private string _candidateName;
    private List<Dish> _dishes;

  }

  public class Dish {

    Dish(string dishName, TypeEnum type, int timeToPrepare, int minimumServingsValue, List<Ingredient> ingredients) {
      DishName = dishName;
      Type = type;
      TimeToPrepare = timeToPrepare;
      MinimumServingsValue = minimumServingsValue;
      Ingredients = new List<Ingredient>(ingredients);
    }

    public string DishName {
      get => _dishName;
      set => _dishName = value;
    }

    public TypeEnum Type {
      get => _type;
      set => _type = value;
    }

    public int TimeToPrepare {
      get => _timeToPrepare;
      set => _timeToPrepare = value;
    }

    public int MinimumServingsValue {
      get => _minimumServingsValue;
      set => _minimumServingsValue = value;
    }

    public List<Ingredient> Ingredients {
      get => _ingredients;
      set => _ingredients = value;
    }

    public enum TypeEnum {
      DayToDay,
      Premium,
      Exclusive
    }
    private string _dishName;
    private TypeEnum _type;
    private int _timeToPrepare;
    private int _minimumServingsValue;
    private List<Ingredient> _ingredients;
  }

  public class Ingredient {
    Ingredient(string ingredientName, int count) {
      IngredientName = ingredientName;
      Count = count;
    }
    public string IngredientName {
      get => _ingredientName;
      set => _ingredientName = value;
    }

    public int Count {
      get => count;
      set => count = value;
    }
    
    private string _ingredientName;
    private int count;
  }
  
  internal class Program {
    public static void Main(string[] args) {
      using (XmlReader reader = new XmlTextReader(@"D:\programming\CSharpProjects\XML\XML\candidate.xml")) {
        while (reader.Read()) {
          switch (reader.NodeType) {
            case XmlNodeType.Element: {
              switch (reader.Name) {
                case "candidate": {
                  reader.MoveToNextAttribute();
                  Console.WriteLine($"\ncook {reader.Value}: ");
                  break;
                }
                case "dish": {
                  reader.MoveToNextAttribute();
                  Console.WriteLine($"  dish name: {reader.Value}");
                  break;
                }
      
                case "category": {
                  reader.MoveToNextAttribute();
                  Console.WriteLine($"    Type: {reader.Value}");
                  break;
                }
      
                case "timetocook": {
                  Console.Write("    Time to prepare: ");
                  break;
                }
      
                case "minimumservings": {
                  Console.Write("    Count of servings: ");
                  break;
                }
      
                case "ingredient": {
                  reader.MoveToNextAttribute();
                  Console.Write($"      Ingredient name: {reader.Value}\n       count:");
                  break;
                }
              }
      
              reader.MoveToElement();
              break;
            }
            case XmlNodeType.Text: {
              Console.WriteLine(reader.Value);
              break;
            }
            case XmlNodeType.XmlDeclaration: {
              Console.WriteLine("<?xml version='1.0'?>");
              break;
            }
          }
        }
      }
      // using (StreamReader sr = new StreamReader(@"D:\programming\CSharpProjects\XML\XML\candidate.json")) {
      //   string json = sr.ReadToEnd();
      //   List<CandidateJson> candidate = JsonConvert.DeserializeObject<List<CandidateJson>>(json);
      //   Console.WriteLine(candidate[0].CandidateName);
      // }
    }
  }
}