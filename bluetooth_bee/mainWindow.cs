using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace bluetooth_bee
{
  public partial class mainWindow : Form
  {
    private delegate void debugDelegate(string msg);

    private SerialPort bluetoothSerial;

    public mainWindow()
    {
      InitializeComponent();
    }

    static string ReceiveBuffer = "";
    static string SerialData = "";

    private bool OK = false;
    private bool ERROR = false;

    public void log(string msg)
    {
      if (debugList.InvokeRequired)
      {
        debugList.BeginInvoke(new debugDelegate(log), new object[] {  msg });
      }
      else
      {
        string dt = DateTime.Now.ToString("HH.mm.ss.FFF");
        int i = debugList.Items.Add(dt + " " + msg);

        debugList.TopIndex = i;
      }
    }

    private void mainWindow_Load(object sender, EventArgs e)
    {
      bluetoothSerial = new SerialPort("com31", 38400);
      bluetoothSerial.DataReceived += new SerialDataReceivedEventHandler(bluetoothSerial_DataReceived);
    }

    void bluetoothSerial_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
      ReceiveBuffer += bluetoothSerial.ReadExisting();
      processRX();
    }

    private void processRX()
    {
      lock (ReceiveBuffer)
      {

        while (ReceiveBuffer.Length > 1)
        {
          if (ReceiveBuffer.Substring(0, 2) == "\r\n")
          {
            if (!ReceiveBuffer.Substring(2).Contains("\r\n")) // need more data
              return;

            // get command
            string command = ReceiveBuffer.Substring(2, ReceiveBuffer.Substring(2).IndexOf("\r\n"));

            log("Command: " + command);
            ReceiveBuffer = ReceiveBuffer.Substring(command.Length + 4);

            if (command == "OK") OK = true;
            if (command == "ERROR") ERROR = true;
          }
          else
          {
            SerialData += ReceiveBuffer.Substring(0, 1);
            ReceiveBuffer = ReceiveBuffer.Substring(1);
          }
        }

        if (SerialData.Length > 0)
        {
          log("SER: " + SerialData);
          SerialData = "";
        }
      }
    }

    private void sendCommand(string cmd)
    {
      OK = false;
      ERROR = false;

      if (!bluetoothSerial.IsOpen)
      {
        log("Open Connection First!");
        return;
      }

      log(">>" + cmd);

      bluetoothSerial.Write("\r\n" + cmd + "\r\n");
    }

    private bool sendCommand(string cmd, bool waitForResponse)
    {
      sendCommand(cmd);

      while (!OK && !ERROR)
        Application.DoEvents();

      if (OK) return true;
      else
        return false;
    }


    private void configure()
    {
      if (!bluetoothSerial.IsOpen)
      {
        log("Open Connection First!");
        return;
      }

      sendCommand("+RTADDR", true); // get module address
      sendCommand("+STWMOD=0", true); // mode
      sendCommand("+STNA=bluetoothbee", true); // setname
      sendCommand("+STAUTO=0", true); // auto connect last paired device
      sendCommand("+STOAUT=1", true); // permit paired device to connect
      sendCommand("+DLPIN", true); // delete pin
      sendCommand("+STPIN=1234", true); // set pin
      Thread.Sleep(2000);
      sendCommand("+INQ=1", true); // start
    }

    private void button1_Click(object sender, EventArgs e)
    {
      if (bluetoothSerial.IsOpen)
        bluetoothSerial.Close();

      bluetoothSerial.Open();

      log("Open");
    }

    private void button2_Click(object sender, EventArgs e)
    {
      configure();
    }

    private void mainWindow_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (bluetoothSerial.IsOpen)
        bluetoothSerial.Close();
    }

    private void sendButton_Click(object sender, EventArgs e)
    {
      if (bluetoothSerial.IsOpen)
        bluetoothSerial.WriteLine(txtInput.Text);
    }
  }
}
