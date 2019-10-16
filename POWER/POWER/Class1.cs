using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using VISAInstrument.Port;

namespace NONATEST
{
    /// <summary>
    /// Power interface
    /// </summary>
    public interface Interface_POWER
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
        /// output volt(string channel = "1", string volt = "3.3", string curr = "0.1")
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="volt"></param>
        /// <param name="curr"></param>
        /// <returns>success=1/fail=0</returns>
        bool OutputVolt(string channel = "1", string volt = "3.3", string curr = "0.1");
        /// <summary>
        /// close output status
        /// </summary>
        /// <returns>success=1/fail=0</returns>
        bool CloseOutput();

    }
    /// <summary>
    /// 3615 class
    /// </summary>
    public class _3615 : Interface_POWER
    {
        PortOperatorBase _3615base = null;
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
            return OpenDevice(ref _3615base, addr, timeout, baudrate);
        }
        /// <summary>
        /// Close Function
        /// </summary>
        /// <returns>bool(success/fail)</returns>
        public bool Close()
        {
            bool _result = true;
            if (_3615base.IsPortOpen)
            {
                try
                {
                    _3615base.Close();
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
                _3615base.WriteLine(cmd);
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
            return _3615base.ReadLine();
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
            bool _result = sendAndReceive(_3615base, cmd, ref feedback);
            if (!_result) return "NA";
            return feedback;
        }
        /// <summary>
        /// output voltage
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="volt"></param>
        /// <param name="curr"></param>
        /// <returns>status=1/0</returns>
        public bool OutputVolt(string channel = "1", string volt = "3.3", string curr = "0.1")
        {
            bool _result = true;

            string cmd = "SOUR:CURR:PROT:STAT 0";
            _result = sendCommands(_3615base, cmd);
            if (!_result) return false;
            Thread.Sleep(100);
            cmd = "SYST:TRA 0";
            _result = sendCommands(_3615base, cmd);
            if (!_result) return false;
            Thread.Sleep(100);
            cmd = "SYST:PARA 0";
            _result = sendCommands(_3615base, cmd);
            if (!_result) return false;
            Thread.Sleep(100);
            cmd = string.Format("SOUR:CHAN {0};SOUR:VOLT {1};SOUR:CURR {2}",channel,volt,curr);
            _result = sendCommands(_3615base, cmd);
            if (!_result) return false;
            Thread.Sleep(100);
            double po_volt =38.5;
            if (channel == "3") po_volt = 7.0;
            cmd = string.Format("SOUR:VOLT:PROT {0}",po_volt);
            _result = sendCommands(_3615base, cmd);
            if (!_result) return false;
            Thread.Sleep(100);
            cmd = "OUTP:STAT 1";
            _result = sendCommands(_3615base, cmd);
            if (!_result) return false;
            Thread.Sleep(100);
            cmd = "SOUR:CURR:PROT:STAT 1";
            _result = sendCommands(_3615base, cmd);
            if (!_result) return false;
            Thread.Sleep(100);
            cmd = "SYST:ERR?";
            string feedback = "";
            _result= sendAndReceive(_3615base, cmd,ref feedback);
            Console.WriteLine(feedback);
            if (!_result) return false;
            if (!feedback.Contains("No error")) return false;
            Thread.Sleep(100);
            return _result;
        }
        /// <summary>
        /// close output status
        /// </summary>
        /// <returns>status=1/0</returns>
        public bool CloseOutput()
        {
            bool _result = true;

            string cmd = "OUTP:STAT 0";
            _result = sendCommands(_3615base, cmd);
            if (!_result) return false;

            return _result;
        }

        private bool sendCommands(PortOperatorBase _portBase, string cmd)
        {
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
