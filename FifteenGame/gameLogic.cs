using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace fifteenGame {
  public class GameLogic {
    private const int Size = 4;
    private int[,] field;
    private int _emptyButtonX;
    private int _emptyButtonY;
    private static int _inversionCount;
    private int[,] oldField;

    public int EmptyButtonX {
      get => _emptyButtonX;
      set => _emptyButtonX = value;
    }

    public int EmptyButtonY {
      get => _emptyButtonY;
      set => _emptyButtonY = value;
    }

    public static int InversionCount {
      get => _inversionCount;
      set => _inversionCount = value;
    }

    public GameLogic() {
      field = new int[Size, Size];
      oldField = new int[Size, Size];
    }

    public void GameBeginning() {
      EmptyButtonX = Size - 1;
      EmptyButtonY = EmptyButtonX;
      InversionCount = 0;

      for (int i = 0; i < 15; i++) {
        int x;
        int y;
        PositionToCoordinates(i, out x, out y);
        field[x, y] = i + 1;
      }

      field[EmptyButtonX, EmptyButtonY] = 0;

      Mixer();
      
      Array.Copy(field, oldField, Size * Size);
      
      IsGameImpossible();
    }

    public bool GameFinish() {
      if (field[Size - 1, Size - 1] == 0) {
        for (int i = 0; i < Size; i++) {
          for (int j = 0; j < Size; j++) {
            if (field[i, j] != (CoordinatesToPosition(i, j) + 1) && field[i, j] != 0) {
              return false;
            }
          }
        }

        return true;
      }

      return false;
    }

    public void PressButton(int pos) {
      int x;
      int y;
      PositionToCoordinates(pos, out x, out y);

      if (Math.Abs(EmptyButtonX - x) + Math.Abs(EmptyButtonY - y) != 1) {
        return;
      }

      field[EmptyButtonX, EmptyButtonY] = field[x, y];
      EmptyButtonX = x;
      EmptyButtonY = y;

      field[x, y] = 0;
    }

    public int GetButton(int pos) {
      int x;
      int y;
      PositionToCoordinates(pos, out x, out y);
      return field[x, y];
    }
    
    public int GetOldButton(int pos) {
      int x;
      int y;
      PositionToCoordinates(pos, out x, out y);
      field[x, y] = oldField[x, y];
      if (oldField[x, y] == 0) {
        EmptyButtonX = x;
        EmptyButtonY = y;
      }
      return oldField[x, y];
    }

    private int CoordinatesToPosition(int x, int y) {
      return y * Size + x;
    }

    private void PositionToCoordinates(int pos, out int x, out int y) {
      x = pos % Size;
      y = pos / Size;
    }

    private void Mixer() {
      Random rnd = new Random();

      for (int i = 0; i < 100; i++) {
        int pos = rnd.Next(0, 15);
        int x;
        int y;
        PositionToCoordinates(pos, out x, out y);

        field[EmptyButtonX, EmptyButtonY] = field[x, y];
        EmptyButtonX = x;
        EmptyButtonY = y;
        field[x, y] = 0;
      }

      field[EmptyButtonX, EmptyButtonY] = field[Size - 1, Size - 1];
      EmptyButtonX = Size - 1;
      EmptyButtonY = EmptyButtonX;
      field[EmptyButtonX, EmptyButtonY] = 0;
    }

    public bool IsGameImpossible() {
      for (int i = 0; i < 14; i++) {
        for (int j = i + 1; j < 15; j++) {
          if (GetButton(i) > GetButton(j)) {
            ++InversionCount;
          }
        }
      }

      if ((InversionCount % 2) == 0) {
        MessageBox.Show(@"You cant win this game!");
        return false;
      }
      
      InversionCount = 0;

      return true;
    }
  }
}