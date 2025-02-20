using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
namespace MyApp.Service;

public partial class DeviceOrientationService
{
    SerialPort? mySerialPort;

    public partial void ConfigureScanner(bool connect)
    {
        if (connect)
        {
            this.mySerialPort = new();

            mySerialPort.BaudRate = 9600;
            mySerialPort.PortName = "COM3";
            mySerialPort.Parity = Parity.None;
            mySerialPort.DataBits = 8;
            mySerialPort.StopBits = StopBits.One;
            mySerialPort.ReadTimeout = 1000;
            mySerialPort.WriteTimeout = 1000;

            if (mySerialPort.IsOpen) mySerialPort.Close();
            mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataHandler);
            try
            {
                mySerialPort.Open();
            }
            catch (Exception ex)
            {
                Shell.Current.DisplayAlert("Error !", ex.ToString(), "OK");
            }
        }
        else 
        {
            if (mySerialPort.IsOpen) mySerialPort.Close();
        }
        
    }

    private void DataHandler(object sender, EventArgs args)
    {
        SerialPort sp = (SerialPort)sender;

       

        SerialBuffer.Enqueue(sp.ReadTo("\r"));   // le string code barre va aller ici

        //sp.ReadTo("\r");
    }
}
