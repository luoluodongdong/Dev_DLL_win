using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace NONATEST
{
    /// <summary>
    /// Serial interface
    /// </summary>
    public interface Interface_Serial
    {
        /// <summary>
        /// Scan Devices
        /// </summary>
        /// <returns>list of devices</returns>
        List<string> ScanDevices();
        /// <summary>
        /// port receive data event
        /// </summary>
        event Action<string> PortReciveData;
        /// <summary>
        /// open port func
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="timeout"></param>
        /// <param name="baudrate"></param>
        /// <param name="dtr"></param>
        /// <param name="rts"></param>
        /// <returns></returns>
        bool Open(string addr, int timeout = 2000, int baudrate = 9600, bool dtr = false, bool rts = false);
        /// <summary>
        /// close func
        /// </summary>
        /// <returns>result</returns>
        bool Close();
        /// <summary>
        /// write line to device
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns>result</returns>
        bool WriteLine(string cmd);
        /// <summary>
        /// read line data from device
        /// </summary>
        /// <returns>string value</returns>
        string ReadLine();
    }
    /// <summary>
    /// serial port class
    /// </summary>
    public class _SerialDev : Interface_Serial
    {
        private SerialPort port = new SerialPort();
        /// <summary>
        /// port receive data event
        /// </summary>
        public event Action<string> PortReciveData;
        /// <summary>
        /// Scan Devices
        /// </summary>
        /// <returns>list of devices</returns>
        public List<string> ScanDevices()
        {
            string[] ports = SerialPort.GetPortNames();
            List<string> list_ports = new List<string>();
            list_ports.AddRange(ports);
            return list_ports;
        }
        /// <summary>
        /// open serial port
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="timeout"></param>
        /// <param name="br"></param>
        /// <param name="dtr"></param>
        /// <param name="rts"></param>
        /// <returns>sucess=1/fail=0</returns>
        public bool Open(string addr, int timeout = 2000, int br = 9600, bool dtr = false, bool rts = false)
        {//9600,N,8,1
            try
            {
                port = new SerialPort(addr);
                port.BaudRate = br;
                port.Parity = Parity.None;
                port.DataBits = 8;
                port.StopBits = StopBits.One;
                port.ReadTimeout = timeout;
                port.WriteTimeout = 500;
                port.ReadBufferSize = 1024 * 1024;
                port.WriteBufferSize = 1024 * 1024;
                port.NewLine = "\r\n";
                port.DtrEnable = dtr;
                port.RtsEnable = rts;

                port.Open();
                port.DataReceived += new SerialDataReceivedEventHandler(comm_DataReceived);
                //port.ErrorReceived += new SerialErrorReceivedEventHandler(HabndleError);
                //port.PinChanged += new SerialPinChangedEventHandler(HabndlePinChange);
            }
            catch (Exception ex)
            {
                Console.WriteLine("err:" + ex.ToString());
                return false;
            }
            return true;
        }
        /// <summary>
        /// serial port receive data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comm_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (PortReciveData != null)
            {
                string msg = port.ReadExisting();
                PortReciveData(msg);
            }
        }
        /// <summary>
        /// close func
        /// </summary>
        /// <returns>result</returns>
        public bool Close()
        {
            bool _result = true;
            if (port.IsOpen)
            {
                try
                {
                    port.Close();
                }
                catch
                {
                    _result = false;
                }
                finally
                {
                    port.Dispose();
                }
            }
            return _result;
        }
        /// <summary>
        /// write line to device
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns>result</returns>
        public bool WriteLine(string cmd)
        {
            try
            {
                if (!port.IsOpen)
                {
                    return false;
                }
                port.Write(cmd + "\r\n");
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
        /// <summary>
        /// read line from device
        /// </summary>
        /// <returns>string value</returns>
        public string ReadLine()
        {
            string rec = "";
            try
            {
                rec = port.ReadLine();
            }
            catch
            {
                return "";
            }
            return rec;
        }

    }
}
