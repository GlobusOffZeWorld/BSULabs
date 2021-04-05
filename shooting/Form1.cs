using System;
using System.Drawing;
using System.Windows.Forms;

namespace shooting {
  public partial class Form1 : Form {
    private Point[] _shotsArr = new Point[50];
    private int _radius = 400;
    private int _pointIndex = 0;
    private int _hitRate = 0;
    private int _missRate = 0;

    private int H = 1200;
    private int W = 900;

    public Form1() {
      InitializeComponent();
    }

    public int Radius {
      get => _radius;
      set => _radius = value;
    }

    protected override void OnPaint(PaintEventArgs e) {
      base.OnPaint(e);
      DrawTarget(ClientRectangle, e.Graphics);
      DrawShots(e.Graphics);
    }

    private void Mouse_Click(object sender, MouseEventArgs e) {
      Point shotCoordinates = new Point(MousePosition.X - Location.X - 12, MousePosition.Y - Location.Y - 35);
      _shotsArr[_pointIndex] = shotCoordinates;
      ++_pointIndex;

      if (_pointIndex == 50) {
        _pointIndex = 0;
      }

      Point hitCoordinates =
        new Point(shotCoordinates.X + 5, shotCoordinates.Y + 5); // we need center of point, where diameter 10
      HitCheck(hitCoordinates);

      labelHitRate.Text = _hitRate.ToString();
      labelMissRate.Text = _missRate.ToString();

      Invalidate();
    }

    private void HitCheck(Point shot) {
      Point centralPoint = new Point(W / 2, H / 2);

      if (shot.Y < centralPoint.Y &&
          Math.Sqrt(Math.Pow(shot.X - centralPoint.X, 2) + Math.Pow(shot.Y - centralPoint.Y, 2)) < Radius) {
        ++_hitRate;
      } else if (shot.Y > centralPoint.Y && ((centralPoint.X - _radius < shot.X && shot.X < centralPoint.X) &&
                                             (centralPoint.Y < shot.Y && shot.Y < centralPoint.Y + _radius) &&
                                             (centralPoint.X - shot.X < shot.Y - centralPoint.Y))) {
        ++_hitRate;
      } else {
        ++_missRate;
      }
    }

    private void DrawShots(Graphics g) {
      SolidBrush brush = new SolidBrush(Color.Blue);
      for (int i = 0; i < _shotsArr.Length; ++i) {
        if (_shotsArr[i].X == 0 && _shotsArr[i].Y == 0) {
          break;
        }

        g.FillEllipse(brush, _shotsArr[i].X, _shotsArr[i].Y, 10, 10);
      }
    }

    private void DrawTarget(Rectangle r, Graphics g) {
      g.Clear(Color.White);

      H = r.Height;
      W = r.Width;

      int diameter = Radius * 2;

      Point centralPoint = new Point(W / 2, H / 2);

      SolidBrush brush = new SolidBrush(Color.Red);
      Pen pen = new Pen(brush);

      Point rightTopTrianglePoint = new Point(centralPoint.X, centralPoint.Y);
      Point rightBottomTrianglePoint = new Point(centralPoint.X, centralPoint.Y + Radius);
      Point leftBottomTrianglePoint = new Point(centralPoint.X - Radius, centralPoint.Y + Radius);

      Point[] triangle = new Point[3];

      triangle[0] = rightTopTrianglePoint;
      triangle[1] = rightBottomTrianglePoint;
      triangle[2] = leftBottomTrianglePoint;

      Rectangle rect = new Rectangle(centralPoint.X - Radius, centralPoint.Y - Radius, diameter, diameter);
      g.FillPie(brush, rect, 0, -180);

      g.FillPolygon(brush, triangle);

      brush.Dispose();
      pen.Dispose();
    }

    private void ResetTarget() {
      for (int i = 0; i < _shotsArr.Length; ++i) {
        _shotsArr[i] = new Point(0, 0);
        _pointIndex = 0;
      }

      _hitRate = 0;
      _missRate = 0;

      labelHitRate.Text = _hitRate.ToString();
      labelMissRate.Text = _missRate.ToString();
    }

    private void Form1_Resize(object sender, EventArgs e) {
      ResetTarget();

      Invalidate();
    }

    private void textBoxInputRadius_TextChanged(object sender, EventArgs e) {
      ResetTarget();
      if (textBoxInputRadius.Text != "" && !textBoxInputRadius.Text.Contains("-") &&
          Convert.ToInt32(textBoxInputRadius.Text) < 10000) {
        Radius = Convert.ToInt32(textBoxInputRadius.Text);
        Invalidate();
      }
    }

    private void buttonNewGame_Click(object sender, EventArgs e) {
      ResetTarget();
      Invalidate();
    }
  }
}