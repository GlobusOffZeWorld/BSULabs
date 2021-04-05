using System;
using System.Drawing;
using System.Windows.Forms;

namespace laos_and_ugoslavia_flag {
  public partial class Form1 : Form {
    private static bool _isMainFlag = true;

    public static bool IsMainFlag {
      get => _isMainFlag;
      set => _isMainFlag = value;
    }

    public Form1() {
      InitializeComponent();
    }

    protected override void OnPaint(PaintEventArgs e) {
      base.OnPaint(e);
      if (IsMainFlag) {
        DrawLaosFlag(ClientRectangle, e.Graphics);
      } else {
        DrawYugoslavianFlag(ClientRectangle, e.Graphics);
      }
    }

    private void Ratio(int PROPX, int PROPY, Rectangle r, out int H, out int W) {
      H = r.Height;
      W = r.Width;
      if (PROPX * r.Width > PROPY * r.Height) {
        W = H * PROPY / PROPX;
      } else if (PROPX * r.Width < PROPY * r.Height) {
        H = W * PROPX / PROPY;
      }
    }

    private void DrawStar(Point center, int rayCount, int bigDistance, int smallDistance, Graphics g, Color color) {
      Point[] pointsArr = new Point[2 * rayCount + 1];
      double step = Math.PI / rayCount;
      double angle = -Math.PI / 2;

      SolidBrush brush = new SolidBrush(color);

      int length;

      for (int i = 0; i < 2 * rayCount + 1; i++, angle += step) {
        if (i % 2 == 0) {
          length = bigDistance;
        } else {
          length = smallDistance;
        }

        pointsArr[i] = new Point(Convert.ToInt32(center.X + length * Math.Cos(angle)),
          Convert.ToInt32(center.Y + length * Math.Sin(angle)));
      }

      brush.Color = color;
      g.FillPolygon(brush, pointsArr);
    }

    private void DrawLaosFlag(Rectangle r, Graphics g) {
      const int PROPX = 2, PROPY = 3;
      g.Clear(Color.Gray);

      int H;
      int W;

      Ratio(PROPX, PROPY, r, out H, out W);

      Point centralPoint = new Point(W / 2, H / 2);

      Point leftTopBlueRectPoint = new Point(0, H / 4);
      Point rightTopBlueRectPoint = new Point(W, H / 4);
      Point rightBottomBlueRectPoint = new Point(W, 3 * H / 4);
      Point leftBottomBlueRectPoint = new Point(0, 3 * H / 4);

      Point[] bluePart = new Point[4];

      bluePart[0] = leftTopBlueRectPoint;
      bluePart[1] = rightTopBlueRectPoint;
      bluePart[2] = rightBottomBlueRectPoint;
      bluePart[3] = leftBottomBlueRectPoint;

      SolidBrush brush = new SolidBrush(Color.Firebrick);
      Pen pen = new Pen(brush);
      g.FillRectangle(brush, 0, 0, W, H);
      brush.Color = Color.MidnightBlue;
      g.FillPolygon(brush, bluePart);
      brush.Color = Color.White;
      g.FillEllipse(brush, centralPoint.X - H / 5, centralPoint.Y - H / 5, 2 * H / 5, 2 * H / 5);

      Font font = new Font("Courier New", 15, FontStyle.Bold | FontStyle.Italic);
      StringFormat drawFormat = new System.Drawing.StringFormat();
      g.DrawString("Лаос", font, brush, 0, 0, drawFormat);

      brush.Dispose();
      pen.Dispose();
      font.Dispose();
    }

    private void DrawYugoslavianFlag(Rectangle r, Graphics g) {
      const int PROPX = 1, PROPY = 2;
      g.Clear(Color.Gray);

      int H;
      int W;

      Ratio(PROPX, PROPY, r, out H, out W);

      Point centralPoint = new Point(W / 2, H / 2);

      Point leftTopWhiteRectPoint = new Point(0, H / 3);
      Point rightTopWhiteRectPoint = new Point(W, H / 3);
      Point rightBottomWhiteRectPoint = new Point(W, H);
      Point leftBottomWhiteRectPoint = new Point(0, H);

      Point[] whitePart = new Point[4];

      whitePart[0] = leftTopWhiteRectPoint;
      whitePart[1] = rightTopWhiteRectPoint;
      whitePart[2] = rightBottomWhiteRectPoint;
      whitePart[3] = leftBottomWhiteRectPoint;

      Point leftTopRedRectPoint = new Point(leftTopWhiteRectPoint.X, leftTopWhiteRectPoint.Y + H / 3);
      Point rightTopRedRectPoint = new Point(rightTopWhiteRectPoint.X, rightTopWhiteRectPoint.Y + H / 3);

      Point[] redPart = new Point[4];

      redPart[0] = leftTopRedRectPoint;
      redPart[1] = rightTopRedRectPoint;
      redPart[2] = rightBottomWhiteRectPoint;
      redPart[3] = leftBottomWhiteRectPoint;

      Color blueColor = Color.FromArgb(0, 56, 147);
      Color yellowColor = Color.FromArgb(252, 209, 21);
      Color redColor = Color.FromArgb(222, 0, 0);

      SolidBrush brush = new SolidBrush(blueColor);
      Pen pen = new Pen(brush);
      g.FillRectangle(brush, 0, 0, W, H);
      brush.Color = Color.White;
      g.FillPolygon(brush, whitePart);
      brush.Color = redColor;
      g.FillPolygon(brush, redPart);
      brush.Color = Color.White;

      DrawStar(centralPoint, 5, 3 * H / 10, 3 * W / 52, g, yellowColor);
      DrawStar(centralPoint, 5, H / 4, W / 21, g, redColor);

      Font font = new Font("Courier New", 15, FontStyle.Bold | FontStyle.Italic);
      StringFormat drawFormat = new System.Drawing.StringFormat();
      g.DrawString("Социалистическая Федеративная Республика Югославия", font, brush, 0, 0, drawFormat);

      brush.Dispose();
      pen.Dispose();
      font.Dispose();
    }

    private void Form1_Resize(object sender, EventArgs e) {
      Invalidate();
    }

    private void buttonLaosFlag_Click(object sender, EventArgs e) {
      IsMainFlag = true;
      Invalidate();
    }

    private void buttonYugoslavianFLag_Click(object sender, EventArgs e) {
      IsMainFlag = false;
      Invalidate();
    }
  }
}