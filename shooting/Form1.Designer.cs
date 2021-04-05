namespace shooting {
  partial class Form1 {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }

      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.textBoxInputRadius = new System.Windows.Forms.TextBox();
      this.labelHitRate = new System.Windows.Forms.Label();
      this.labelMissRate = new System.Windows.Forms.Label();
      this.labelHitName = new System.Windows.Forms.Label();
      this.labelMissName = new System.Windows.Forms.Label();
      this.labelInputRadius = new System.Windows.Forms.Label();
      this.buttonNewGame = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // textBoxInputRadius
      // 
      this.textBoxInputRadius.Location = new System.Drawing.Point(12, 31);
      this.textBoxInputRadius.Name = "textBoxInputRadius";
      this.textBoxInputRadius.Size = new System.Drawing.Size(100, 20);
      this.textBoxInputRadius.TabIndex = 0;
      this.textBoxInputRadius.TextChanged += new System.EventHandler(this.textBoxInputRadius_TextChanged);
      // 
      // labelHitRate
      // 
      this.labelHitRate.Location = new System.Drawing.Point(12, 86);
      this.labelHitRate.Name = "labelHitRate";
      this.labelHitRate.Size = new System.Drawing.Size(100, 23);
      this.labelHitRate.TabIndex = 1;
      this.labelHitRate.Text = "0";
      // 
      // labelMissRate
      // 
      this.labelMissRate.Location = new System.Drawing.Point(12, 142);
      this.labelMissRate.Name = "labelMissRate";
      this.labelMissRate.Size = new System.Drawing.Size(100, 23);
      this.labelMissRate.TabIndex = 1;
      this.labelMissRate.Text = "0";
      // 
      // labelHitName
      // 
      this.labelHitName.Location = new System.Drawing.Point(12, 63);
      this.labelHitName.Name = "labelHitName";
      this.labelHitName.Size = new System.Drawing.Size(100, 23);
      this.labelHitName.TabIndex = 1;
      this.labelHitName.Text = "Hit count:";
      // 
      // labelMissName
      // 
      this.labelMissName.Location = new System.Drawing.Point(12, 119);
      this.labelMissName.Name = "labelMissName";
      this.labelMissName.Size = new System.Drawing.Size(100, 23);
      this.labelMissName.TabIndex = 1;
      this.labelMissName.Text = "Miss count";
      // 
      // labelInputRadius
      // 
      this.labelInputRadius.Location = new System.Drawing.Point(12, 5);
      this.labelInputRadius.Name = "labelInputRadius";
      this.labelInputRadius.Size = new System.Drawing.Size(100, 23);
      this.labelInputRadius.TabIndex = 1;
      this.labelInputRadius.Text = "Input radius";
      // 
      // buttonNewGame
      // 
      this.buttonNewGame.Location = new System.Drawing.Point(12, 168);
      this.buttonNewGame.Name = "buttonNewGame";
      this.buttonNewGame.Size = new System.Drawing.Size(75, 23);
      this.buttonNewGame.TabIndex = 2;
      this.buttonNewGame.Text = "NewGame";
      this.buttonNewGame.UseVisualStyleBackColor = true;
      this.buttonNewGame.Click += new System.EventHandler(this.buttonNewGame_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1200, 900);
      this.Controls.Add(this.buttonNewGame);
      this.Controls.Add(this.labelMissRate);
      this.Controls.Add(this.labelMissName);
      this.Controls.Add(this.labelInputRadius);
      this.Controls.Add(this.labelHitName);
      this.Controls.Add(this.labelHitRate);
      this.Controls.Add(this.textBoxInputRadius);
      this.Name = "Form1";
      this.Text = "Target";
      this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Mouse_Click);
      this.Resize += new System.EventHandler(this.Form1_Resize);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private System.Windows.Forms.Button buttonNewGame;

    private System.Windows.Forms.Label labelInputRadius;

    private System.Windows.Forms.Label labelHitName;
    private System.Windows.Forms.Label labelMissName;

    private System.Windows.Forms.Label labelHitRate;
    private System.Windows.Forms.Label labelMissRate;

    private System.Windows.Forms.TextBox textBoxInputRadius;

    #endregion
  }
}