using System.Windows.Forms;

namespace foolWinForms {
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
      this.labelAreYouFool = new System.Windows.Forms.Label();
      this.buttonYes = new System.Windows.Forms.Button();
      this.buttonNo = new System.Windows.Forms.Button();
      this.textBoxForCheatCode = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // labelAreYouFool
      // 
      this.labelAreYouFool.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
      this.labelAreYouFool.Location = new System.Drawing.Point(284, 9);
      this.labelAreYouFool.Name = "labelAreYouFool";
      this.labelAreYouFool.Size = new System.Drawing.Size(234, 58);
      this.labelAreYouFool.TabIndex = 0;
      this.labelAreYouFool.Text = "Are you fool?";
      this.labelAreYouFool.MouseMove += new System.Windows.Forms.MouseEventHandler(this.textBoxForCheatCode_MouseMove);
      // 
      // buttonYes
      // 
      this.buttonYes.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.buttonYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
      this.buttonYes.Location = new System.Drawing.Point(284, 56);
      this.buttonYes.Name = "buttonYes";
      this.buttonYes.Size = new System.Drawing.Size(104, 70);
      this.buttonYes.TabIndex = 1;
      this.buttonYes.TabStop = false;
      this.buttonYes.Text = "Yes";
      this.buttonYes.UseVisualStyleBackColor = true;
      this.buttonYes.Click += new System.EventHandler(this.buttonYes_Click);
      this.buttonYes.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonYes_MouseMove);
      // 
      // buttonNo
      // 
      this.buttonNo.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.buttonNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
      this.buttonNo.Location = new System.Drawing.Point(394, 56);
      this.buttonNo.Name = "buttonNo";
      this.buttonNo.Size = new System.Drawing.Size(104, 70);
      this.buttonNo.TabIndex = 1;
      this.buttonNo.TabStop = false;
      this.buttonNo.Text = "NO!!!";
      this.buttonNo.UseVisualStyleBackColor = true;
      this.buttonNo.Click += new System.EventHandler(this.buttonNo_Click);
      // 
      // textBoxForCheatCode
      // 
      this.textBoxForCheatCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.textBoxForCheatCode.Location = new System.Drawing.Point(284, 166);
      this.textBoxForCheatCode.Name = "textBoxForCheatCode";
      this.textBoxForCheatCode.Size = new System.Drawing.Size(214, 13);
      this.textBoxForCheatCode.TabIndex = 1;
      this.textBoxForCheatCode.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1280, 720);
      this.Controls.Add(this.textBoxForCheatCode);
      this.Controls.Add(this.buttonNo);
      this.Controls.Add(this.buttonYes);
      this.Controls.Add(this.labelAreYouFool);
      this.Name = "Form1";
      this.Text = "Are you fool?";
      this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private System.Windows.Forms.TextBox textBoxForCheatCode;

    private System.Windows.Forms.Button buttonNo;
    private System.Windows.Forms.Button buttonYes;

    private System.Windows.Forms.Label labelAreYouFool;

    #endregion
  }
}