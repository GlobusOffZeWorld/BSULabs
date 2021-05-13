using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace fifteenGame {
  public partial class Form1 : Form {
    private GameLogic game;
    private static int _stepCount;
    private static int _timeCount;
    private DateTime _gameStartTime;
    private List<Results> _resultsArray;
    private DateTime _dateToDelete;
    private string _playerName;


    public Form1() {
      InitializeComponent();
      _stepCount = 0;
      _timeCount = 0;
      ResultsArray = new List<Results>();
      Deserialize();
      game = new GameLogic();
      GameReconstructor();
    }

    public int StepCount {
      get => _stepCount;
      set => _stepCount = value;
    }

    public static int TimeCount {
      get => _timeCount;
      set => _timeCount = value;
    }

    public DateTime GameStartTime {
      get => _gameStartTime;
      set => _gameStartTime = value;
    }

    public DateTime DateToDelete {
      get => _dateToDelete;
      set => _dateToDelete = value;
    }

    public string PlayerName {
      get => _playerName;
      set => _playerName = value;
    }

    public List<Results> ResultsArray {
      get => _resultsArray;
      set => _resultsArray = value;
    }

    private void button_Click(object sender, EventArgs e) {
      game.PressButton(Convert.ToInt32(((Button) sender).Tag));
      UpdateField();
      labelStepCountNumbers.Text = (++StepCount).ToString();
      if (game.GameFinish()) {
        Results results = new Results($"{PlayerName}", GameStartTime, TimeCount, StepCount);
        ResultsArray.Add(results);
        Serialize();
        MessageBox.Show(@"You won!", @"Congratulations");
      }
    }

    private void UpdateField() {
      for (int i = 0; i < 16; i++) {
        GetButtonIndex(i).Text = game.GetButton(i).ToString();
        GetButtonIndex(i).Visible = (game.GetButton(i) > 0);
      }
    }

    private Button GetButtonIndex(int pos) {
      switch (pos) {
        case 0: {
          return button1;
        }
        case 1: {
          return button2;
        }
        case 2: {
          return button3;
        }
        case 3: {
          return button4;
        }
        case 4: {
          return button5;
        }
        case 5: {
          return button6;
        }
        case 6: {
          return button7;
        }
        case 7: {
          return button8;
        }
        case 8: {
          return button9;
        }
        case 9: {
          return button10;
        }
        case 10: {
          return button11;
        }
        case 11: {
          return button12;
        }
        case 12: {
          return button13;
        }
        case 13: {
          return button14;
        }
        case 14: {
          return button15;
        }
        case 15: {
          return button16;
        }
        default: {
          return null;
        }
      }
    }

    private void timer1_Elapsed(object sender, ElapsedEventArgs e) {
      labelTimerTime.Text = (++TimeCount).ToString();
    }

    private void FieldReset() {
      ResetStatistic();
      game.GameBeginning();
      UpdateField();
    }

    private void GameReconstructor() {
      GameStartTime = DateTime.Now;
      textBoxPlayerName.Clear();
      PlayerName = "";
      FieldReset();
    }

    private void buttonNewGame_Click(object sender, EventArgs e) {
      GameReconstructor();
    }

    private void buttonRestart_Click(object sender, EventArgs e) {
      ResetStatistic();
      UpdateField();
      for (int i = 0; i < 16; i++) {
        GetButtonIndex(i).Text = game.GetOldButton(i).ToString();
        GetButtonIndex(i).Visible = (game.GetOldButton(i) > 0);
      }
    }

    private void ResetStatistic() {
      StepCount = 0;
      TimeCount = 0;
      labelStepCountNumbers.Text = StepCount.ToString();
      labelTimerTime.Text = TimeCount.ToString();
    }

    private void Serialize() {
      XmlSerializer formatter = new XmlSerializer(typeof(List<Results>));
      using (FileStream fs = new FileStream("PlayersResults.xml", FileMode.Create)) {
        formatter.Serialize(fs, ResultsArray);
      }
    }

    public void Deserialize() {
      XmlSerializer formatter = new XmlSerializer(typeof(List<Results>));
      using (FileStream fs = new FileStream("PlayersResults.xml", FileMode.OpenOrCreate)) {
        ResultsArray = (List<Results>) formatter.Deserialize(fs);
      }
    }

    private void buttonBestOfMoves_Click(object sender, EventArgs e) {
      List<Results> resultsForOutput = new List<Results>(ResultsArray);
      resultsForOutput.Sort((first, second) => first.NumberOfMoves.CompareTo(second.NumberOfMoves));
      string output = "";
      for (int i = 0; i < resultsForOutput.Capacity && i < 10; ++i) {
        output += resultsForOutput[i] + "\n";
      }

      MessageBox.Show(output == "" ? "result list is empty" : output);
    }

    private void buttonOfTime_Click(object sender, EventArgs e) {
      List<Results> resultsForOutput = new List<Results>(ResultsArray);
      resultsForOutput.Sort((first, second) => first.GameDuration.CompareTo(second.GameDuration));
      string output = "";
      for (int i = 0; i < resultsForOutput.Capacity && i < 10; ++i) {
        output += resultsForOutput[i] + "\n";
      }

      MessageBox.Show(output == "" ? "result list is empty" : output);
    }

    private void buttonLastGames_Click(object sender, EventArgs e) {
      List<Results> resultsForOutput = new List<Results>(ResultsArray);
      resultsForOutput.Sort((first, second) => second.GameStartTime.CompareTo(first.GameStartTime));
      string output = "";
      for (int i = 0; i < resultsForOutput.Capacity && i < 10; ++i) {
        output += resultsForOutput[i] + "\n";
      }

      MessageBox.Show(output == "" ? "result list is empty" : output);
    }

    private void dateTimePicker1_ValueChanged(object sender, EventArgs e) {
      DateToDelete = dateTimePicker1.Value;
    }

    private void buttonDeleteResults_Click(object sender, EventArgs e) {
      ResultsArray.RemoveAll(res => res.GameStartTime < DateToDelete);
      Serialize();
      Deserialize();
    }

    private void textBoxPlayerName_TextChanged(object sender, EventArgs e) {
      PlayerName = textBoxPlayerName.Text;
    }
  }
}