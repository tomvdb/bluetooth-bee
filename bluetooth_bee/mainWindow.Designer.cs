namespace bluetooth_bee
{
  partial class mainWindow
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.ConnectButton = new System.Windows.Forms.Button();
      this.debugList = new System.Windows.Forms.ListBox();
      this.ConfigureButton = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.txtInput = new System.Windows.Forms.TextBox();
      this.sendButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // ConnectButton
      // 
      this.ConnectButton.Location = new System.Drawing.Point(12, 12);
      this.ConnectButton.Name = "ConnectButton";
      this.ConnectButton.Size = new System.Drawing.Size(75, 23);
      this.ConnectButton.TabIndex = 0;
      this.ConnectButton.Text = "Connect";
      this.ConnectButton.UseVisualStyleBackColor = true;
      this.ConnectButton.Click += new System.EventHandler(this.button1_Click);
      // 
      // debugList
      // 
      this.debugList.FormattingEnabled = true;
      this.debugList.Location = new System.Drawing.Point(12, 114);
      this.debugList.Name = "debugList";
      this.debugList.Size = new System.Drawing.Size(783, 394);
      this.debugList.TabIndex = 1;
      // 
      // ConfigureButton
      // 
      this.ConfigureButton.Location = new System.Drawing.Point(93, 12);
      this.ConfigureButton.Name = "ConfigureButton";
      this.ConfigureButton.Size = new System.Drawing.Size(75, 23);
      this.ConfigureButton.TabIndex = 2;
      this.ConfigureButton.Text = "Configure";
      this.ConfigureButton.UseVisualStyleBackColor = true;
      this.ConfigureButton.Click += new System.EventHandler(this.button2_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 62);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(34, 13);
      this.label1.TabIndex = 3;
      this.label1.Text = "Input:";
      // 
      // txtInput
      // 
      this.txtInput.Location = new System.Drawing.Point(52, 59);
      this.txtInput.Name = "txtInput";
      this.txtInput.Size = new System.Drawing.Size(562, 20);
      this.txtInput.TabIndex = 4;
      // 
      // sendButton
      // 
      this.sendButton.Location = new System.Drawing.Point(620, 57);
      this.sendButton.Name = "sendButton";
      this.sendButton.Size = new System.Drawing.Size(75, 23);
      this.sendButton.TabIndex = 5;
      this.sendButton.Text = "Send";
      this.sendButton.UseVisualStyleBackColor = true;
      this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
      // 
      // mainWindow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(807, 524);
      this.Controls.Add(this.sendButton);
      this.Controls.Add(this.txtInput);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.ConfigureButton);
      this.Controls.Add(this.debugList);
      this.Controls.Add(this.ConnectButton);
      this.Name = "mainWindow";
      this.Text = "Bluetooth Bee";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainWindow_FormClosing);
      this.Load += new System.EventHandler(this.mainWindow_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button ConnectButton;
    private System.Windows.Forms.ListBox debugList;
    private System.Windows.Forms.Button ConfigureButton;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtInput;
    private System.Windows.Forms.Button sendButton;
  }
}

