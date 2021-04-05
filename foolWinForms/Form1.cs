using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace foolWinForms {
  public partial class Form1 : Form {
    public Form1() {
      InitializeComponent();
      buttonNo.BringToFront();
    }

    private const string SuperSecretCheatCode = "imnotfool";
    private static string _inputKeys = "";
    private static bool _buttonStop = false;

    public static string InputKeys {
      get => _inputKeys;
      set => _inputKeys = value;
    }

    public static bool ButtonStop {
      get => _buttonStop;
      set => _buttonStop = value;
    }

    private void MoveButtonNo() {
      if (ButtonStop) {
        return;
      }

      const int buttonSpeed = 16;

      int buttonNoDimensionX = buttonNo.Location.X + 52 - MousePosition.X + Location.X;
      int buttonNoDimensionY = buttonNo.Location.Y + 35 - MousePosition.Y + Location.Y;

      MoveX(buttonNoDimensionX, buttonNoDimensionY, buttonSpeed);
      MoveY(buttonNoDimensionY, buttonNoDimensionX, buttonSpeed);

      Random rnd = new Random();
      int randomCoordinatesX = rnd.Next(20, this.Size.Width - 176);
      int randomCoordinatesY = rnd.Next(20, this.Size.Height - 125);

      if (buttonNo.Location.X <= 20 || buttonNo.Location.X >= this.Size.Width - 176) {
        buttonNo.Location = new Point(randomCoordinatesX, randomCoordinatesY);
      }

      if (buttonNo.Location.Y <= 20 || buttonNo.Location.Y >= this.Size.Height - 125) {
        buttonNo.Location = new Point(randomCoordinatesX, randomCoordinatesY);
      }
    }

    private void MoveX(int buttonNoDimensionX, int buttonNoDimensionY, int buttonSpeed) {
      if (buttonNoDimensionX >= 0 && buttonNoDimensionX - 124 <= 0 && Math.Abs(buttonNoDimensionY) - 70 <= 0) {
        buttonNo.Left += buttonSpeed;
      } else if (buttonNoDimensionX <= 0 && buttonNoDimensionX + 124 >= 0 && Math.Abs(buttonNoDimensionY) - 70 <= 0) {
        buttonNo.Left -= buttonSpeed;
      }
    }

    private void MoveY(int buttonNoDimensionY, int buttonNoDimensionX, int buttonSpeed) {
      if (buttonNoDimensionY >= 0 && buttonNoDimensionY - 90 <= 0 && Math.Abs(buttonNoDimensionX) - 104 <= 0) {
        buttonNo.Top += buttonSpeed;
      } else if (buttonNoDimensionY <= 0 && buttonNoDimensionY + 90 >= 0 && Math.Abs(buttonNoDimensionX) - 104 <= 0) {
        buttonNo.Top -= buttonSpeed;
      }
    }

    private void Form1_MouseMove(object sender, MouseEventArgs e) {
      MoveButtonNo();
    }

    private void buttonYes_MouseMove(object sender, EventArgs e) {
      MoveButtonNo();
    }

    private void textBoxForCheatCode_MouseMove(object sender, EventArgs e) {
      MoveButtonNo();
    }

    private void IsCheatCodeActivated() {
      ButtonStop = (InputKeys.Contains(SuperSecretCheatCode));
    }

    private void textBox1_TextChanged(object sender, EventArgs e) {
      InputKeys = textBoxForCheatCode.Text;
      IsCheatCodeActivated();
    }

    private void buttonYes_Click(object sender, EventArgs e) {
      MessageBox.Show("Oh, really?", "AHAHAH YOU ARE FOOL!!");
    }

    private void buttonNo_Click(object sender, EventArgs e) {
      if (ButtonStop) {
        MessageBox.Show("WOWOW YOU'RE NOT FOOL!!!", "MLG 360 PRO GAMER");
      }
    }
  }
}