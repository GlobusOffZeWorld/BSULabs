using System;
using System.Xml.Serialization;

namespace fifteenGame {
  [Serializable]
  public class Results {
    public Results(){}
    public Results(string player, DateTime gameStartTime, int gameDuration, int numberOfMoves) {
      Player = player;
      GameStartTime = gameStartTime;
      GameDuration = gameDuration;
      NumberOfMoves = numberOfMoves;
    }

    public override string ToString() {
      return $"Player: {Player}\n" +
             $"Game start time: {GameStartTime}\n" +
             $"Game duration: {GameDuration}\n" +
             $"Number of moves: {NumberOfMoves}\n";
    }

    [XmlElement("Player")]
    public string Player {
      get => _player;
      set => _player = value;
    }

    [XmlElement("GameStartTime")]
    public DateTime GameStartTime {
      get => _gameStartTime;
      set => _gameStartTime = value;
    }

    [XmlElement("GameDuration")]
    public int GameDuration {
      get => _gameDuration;
      set => _gameDuration = value;
    }

    [XmlElement("NumberOfMoves")]
    public int NumberOfMoves {
      get => _numberOfMoves;
      set => _numberOfMoves = value;
    }


    private string _player;
    private DateTime _gameStartTime;
    private int _gameDuration;
    private int _numberOfMoves;
  }
}