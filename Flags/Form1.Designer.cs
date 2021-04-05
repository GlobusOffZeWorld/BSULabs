namespace laos_and_ugoslavia_flag {
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
      this.buttonLaosFlag = new System.Windows.Forms.Button();
      this.buttonYugoslavianFLag = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // buttonLaosFlag
      // 
      this.buttonLaosFlag.Location = new System.Drawing.Point(732, 12);
      this.buttonLaosFlag.Name = "buttonLaosFlag";
      this.buttonLaosFlag.Size = new System.Drawing.Size(75, 23);
      this.buttonLaosFlag.TabIndex = 0;
      this.buttonLaosFlag.Text = "LaosFlag";
      this.buttonLaosFlag.UseVisualStyleBackColor = true;
      this.buttonLaosFlag.Click += new System.EventHandler(this.buttonLaosFlag_Click);
      // 
      // buttonYugoslavianFLag
      // 
      this.buttonYugoslavianFLag.Location = new System.Drawing.Point(813, 12);
      this.buttonYugoslavianFLag.Name = "buttonYugoslavianFLag";
      this.buttonYugoslavianFLag.Size = new System.Drawing.Size(75, 23);
      this.buttonYugoslavianFLag.TabIndex = 0;
      this.buttonYugoslavianFLag.Text = "YugoslavianFLag";
      this.buttonYugoslavianFLag.UseVisualStyleBackColor = true;
      this.buttonYugoslavianFLag.Click += new System.EventHandler(this.buttonYugoslavianFLag_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(900, 600);
      this.Controls.Add(this.buttonYugoslavianFLag);
      this.Controls.Add(this.buttonLaosFlag);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Resize += new System.EventHandler(this.Form1_Resize);
      this.ResumeLayout(false);
    }

    private System.Windows.Forms.Button buttonYugoslavianFLag;

    private System.Windows.Forms.Button buttonLaosFlag;

    #endregion
  }
}