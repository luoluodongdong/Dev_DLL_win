using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VISAInstrument.Port;
using System.Threading;

namespace NONATEST
{
    /// <summary>
    /// LOAD interface
    /// </summary>
    public interface Interface_LOAD
    {
        /// <summary>
        /// Scan Devices
        /// </summary>
        /// <returns>list of devices</returns>
        List<string> ScanDevices();
        /// <summary>
        /// open func
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="timeout"></param>
        /// <param name="baudrate"></param>
        /// <returns>result</returns>
        bool Open(string addr, int timeout, int baudrate = 9600);
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
        /// read line from device
        /// </summary>
        /// <returns>string value</returns>
        string ReadLine();
        /// <summary>
        /// reset func
        /// </summary>
        /// <returns></returns>
        bool Reset();
        /// <summary>
        /// get name of device
        /// </summary>
        /// <returns>name string</returns>
        string GetName();
        /// <summary>
        /// set load params
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="channel"></param>
        /// <param name="curr"></param>
        /// <returns>success=1/fail=0</returns>
        bool SetLoad(string mode = "CCH", string channel = "L1", string curr = "2.4");
        /// <summary>
        /// measure voltage
        /// </summary>
        /// <returns>value of voltage</returns>
        string MeasVolt();
        /// <summary>
        /// load ON
        /// </summary>
        /// <returns>sucess=1/fail=0</returns>
        bool LoadON();
        /// <summary>
        /// load OFF
        /// </summary>
        /// <returns>sucess=1/fail=0</returns>
        bool LoadOFF();
        
    }
    /// <summary>
    /// 34970 class
    /// </summary>
    public class _63610 : Interface_LOAD
    {
        PortOperatorBase _63610base = null;
        /// <summary>
        /// Scan Devices
        /// </summary>
        /// <returns>list of devices</returns>
        public List<string> ScanDevices()
        {
            return GetAllDevices();
        }
        /// <summary>
        /// Open Function
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="timeout"></param>
        /// <param name="baudrate"></param>
        /// <returns>bool(success/fail)</returns>
        public bool Open(string addr, int timeout = 2000, int baudrate = 9600)
        {
            return OpenDevice(ref _63610base, addr, timeout, baudrate);
        }
        /// <summary>
        /// Close Function
        /// </summary>
        /// <returns>bool(success/fail)</returns>
        public bool Close()
        {
            bool _result = true;
            if (_63610base.IsPortOpen)
            {
                try
                {
                    _63610base.Close();
                }
                catch (Exception ex)
                {
                    _result = false;
                }
            }
            return _result;
        }
        /// <summary>
        /// WriteLine to 34970
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns>bool(success/fail)</returns>
        public bool WriteLine(string cmd)
        {
            bool _result = true;
            try
            {
                _63610base.WriteLine(cmd);
            }
            catch (Exception ex)
            {
                _result = false;
            }
            return _result;
        }
        /// <summary>
        /// ReadLine from 34970
        /// </summary>
        /// <returns>read string</returns>
        public string ReadLine()
        {
            return _63610base.ReadLine();
        }
        /// <summary>
        /// Reset device
        /// </summary>
        /// <returns></returns>
        public bool Reset()
        {
            bool _result = false;
            _result = WriteLine("*RST");
            if (!_result) return false;
            Thread.Sleep(100);
            _result = WriteLine("*CLS");
            return _result;
        }
        /// <summary>
        /// Get name of device
        /// </summary>
        /// <returns>name string</returns>
        public string GetName()
        {
            string cmd = "*IDN?";
            string feedback = "";
            bool _result = sendAndReceive(_63610base, cmd, ref feedback);
            if (!_result) return "NA";
            return feedback;
        }
        /// <summary>
        /// set load params
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="channel"></param>
        /// <param name="curr"></param>
        /// <returns>success=1/fail=0</returns>
        public bool SetLoad(string mode = "CCH", string channel = "L1", string curr = "2.4")
        {
            bool _result = true;
            string cmd = string.Format("MODE {0};CURR:STAT:{1} {2}", mode,channel,curr);
            _result = sendCommands(_63610base, cmd);
            return _result;
        }
        /// <summary>
        /// measure voltage
        /// </summary>
        /// <returns>value of voltage</returns>
        public string MeasVolt()
        {
            string cmd = "MEAS:VOLT?";
            string feedback = "";
            bool _result = sendAndReceive(_63610base, cmd, ref feedback);
            if (!_result) return "";
            return feedback;
        }
        /// <summary>
        /// load ON
        /// </summary>
        /// <returns>sucess=1/fail=0</returns>
        public bool LoadON()
        {
            bool _result = true;
            string cmd = "LOAD ON";
            _result = sendCommands(_63610base, cmd);
            return _result;
        }
        /// <summary>
        /// load OFF
        /// </summary>
        /// <returns>sucess=1/fail=0</returns>
        public bool LoadOFF()
        {
            bool _result = true;
            string cmd = "LOAD OFF";
            _result = sendCommands(_63610base, cmd);
            return _result;
        }

        private bool sendCommands(PortOperatorBase _portBase, string cmd)
        {
            Thread.Sleep(100);
            bool fb = true;
            if (cmd.Contains(";"))
            {
                string[] cmds = cmd.Split(';');
                foreach (string item in cmds)
                {
                    Console.WriteLine("CMD:" + item);
                    Thread.Sleep(50);
                    try
                    {
                        _portBase.WriteLine(item);
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("write Error:" + ex.ToString());
                        fb = false;
                        break;
                    }
                }
            }
            else
            {
                try
                {
                    Console.WriteLine("CMD:" + cmd);
                    _portBase.WriteLine(cmd);
                    Thread.Sleep(50);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("write Error:" + ex.ToString());
                    fb = false;
                }

            }
            Thread.Sleep(100);
            return fb;
        }
        private bool sendAndReceive(PortOperatorBase _portBase, string cmd, ref string receData)
        {
            Thread.Sleep(100);
            bool fb = true;
            receData = "";
            try
            {
                Console.WriteLine("CMD:" + cmd);
                _portBase.WriteLine(cmd);
                Thread.Sleep(100);
                receData = _portBase.ReadLine();
                Console.WriteLine("read:" + receData);
            }
            catch (Exception ex)
            {
                Console.WriteLine("write Error:" + ex.ToString());
                fb = false;
            }
            Thread.Sleep(100);
            return fb;
        }
        /// <summary>
        /// open device func
        /// </summary>
        /// <param name="_portBase"></param>
        /// <param name="addr"></param>
        /// <param name="timeout"></param>
        /// <param name="br"></param>
        /// <returns>result(success/fail)</returns>
        private bool OpenDevice(ref PortOperatorBase _portBase, string addr, int timeout = 2000, int br = 9600)
        {
            _portBase = null;
            bool hasAddress = false;
            bool hasException = false;
            if (addr.ToUpper().Contains("ASRL"))
            {
                try
                {
                    _portBase = new RS232PortOperator(addr, br, 0, 0, 8);
                    hasAddress = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("rs232 error:" + ex.ToString());
                    hasException = true;
                }
            }
            else if (addr.ToUpper().Contains("USB"))
            {
                _portBase = new USBPortOperator(addr);
                hasAddress = true;
            }
            else if (addr.ToUpper().Contains("GPIB"))
            {
                _portBase = new GPIBPortOperator(addr);
                hasAddress = true;
            }
            else if (addr.ToUpper().Contains("TCPIP"))
            {
                _portBase = new LANPortOperator(addr);
                hasAddress = true;
            }
            if (!hasException && hasAddress)
            {
                _portBase.Timeout = timeout;
                try
                {
                    _portBase.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("open error:" + ex.ToString());
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// scan devices
        /// </summary>
        /// <returns>devices list<string></string></returns>
        private List<string> GetAllDevices()
        {
            List<string> result = new List<string>();
            Task t = Task.Factory.StartNew(() =>
            {
                try
                {

                    string[] content1 = PortUltility.FindAddresses(PortType.RS232);
                    string[] content2 = PortUltility.FindRS232Type(content1);
                    List<string> list1 = new List<string>();
                    List<string> list2 = new List<string>();
                    for (int i = 0; i < content2.Length; i++)
                    {
                        if (content2[i].Contains("LPT")) continue;
                        list1.Add(content1[i]);
                        list2.Add(content2[i]);
                    }
                    content1 = list1.ToArray();  //ASRL1::INSR...
                    content2 = list2.ToArray(); //COM1...
                                                // result = list1;
                    result.AddRange(list1);
                    content1 = PortUltility.FindAddresses(PortType.USB);
                    result.AddRange(content1);

                    content1 = PortUltility.FindAddresses(PortType.GPIB);
                    result.AddRange(content1);
                    content1 = PortUltility.FindAddresses(PortType.LAN);
                    result.AddRange(content1);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("exception:" + ex.ToString());
                }

            }).ContinueWith(x =>
            {
                if (x.IsFaulted)
                {
                    Console.WriteLine("Scan not completed! Error!!!");
                }
            });
            t.Wait();
            return result;
        }

    }
}
