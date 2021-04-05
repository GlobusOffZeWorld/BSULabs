using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace fifteenGame {
  public partial class Form1 : Form {
    private GameLogic game;
    private static int _stepCount;
    private static int _timeCount;

    public Form1() {
      InitializeComponent();
      _stepCount = 0;
      _timeCount = 0;
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

    private void button_Click(object sender, EventArgs e) {
      game.PressButton(Convert.ToInt32(((Button) sender).Tag));
      UpdateField();
      labelStepCountNumbers.Text = (++StepCount).ToString();
      if (game.GameFinish()) {
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
      FieldReset();
      if (!game.IsGameImpossible()) {
        FieldReset();
      }
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
  }
}