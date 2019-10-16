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
    /// 3497xx interface
    /// </summary>
    public interface Interface_3497xx
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
        bool Open(string addr, int timeout, int baudrate=9600);
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
        /// Read open/short values
        /// </summary>
        /// <param name="channels"></param>
        /// <param name="cable"></param>
        /// <returns>value of open/short</returns>
        string ReadOpenShort(string channels,int cable=2);
    }
    /// <summary>
    /// 34970 class
    /// </summary>
    public class _34970:Interface_3497xx
    {
        PortOperatorBase _34970base = null;
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
        public bool Open(string addr, int timeout=2000, int baudrate = 9600)
        {
            return OpenDevice(ref _34970base,addr,timeout,baudrate);
        }
        /// <summary>
        /// Close Function
        /// </summary>
        /// <returns>bool(success/fail)</returns>
        public bool Close()
        {
            bool _result = true;
            if (_34970base.IsPortOpen)
            {
                try
                {
                    _34970base.Close();
                }catch(Exception ex)
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
                _34970base.WriteLine(cmd);
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
            return _34970base.ReadLine();
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
            Thread.Sleep(100);
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
            bool _result = sendAndReceive(cmd, ref feedback);
            if (!_result) return "NA";
            return feedback;
        }
        /// <summary>
        /// read values of open/short channels:"101:113"
        /// </summary>
        /// <param name="channels"></param>
        /// <param name="cable"></param>
        /// <returns>values of open/short</returns>
        public string ReadOpenShort(string channels,int cable=2)
        {
            bool _result = false;
            string cmd = string.Format("CONF:RES AUTO,(@{0})", channels);
            if (cable == 4)
            {
                cmd = string.Format("CONF:FRES AUTO,(@{0})", channels);
            }
            _result = sendCommands(cmd);
            if (!_result) return "";
            Thread.Sleep(100);
            cmd = string.Format("ROUT:CHAN:DEL:AUTO 1,(@{0})", channels);
            _result = sendCommands(cmd);
            if (!_result) return "";
            Thread.Sleep(100);
            cmd = string.Format("ROUT:SCAN (@{0})", channels);
            _result = sendCommands(cmd);
            if (!_result) return "";
            Thread.Sleep(100);
            cmd ="TRIG:SOUR BUS;INIT;*TRG";
            _result = sendCommands(cmd);
            if (!_result) return "";
            Thread.Sleep(100);
            cmd = "SYST:ERR?";
            string feedback = "";
            _result = sendAndReceive(cmd,ref feedback);
            if (!_result) return "";
            if (!feedback.Contains("+0")) return "";
            Thread.Sleep(100);
            cmd = "FETC?";
            feedback = "";
            _result = sendAndReceive(cmd, ref feedback);
            if (!_result) return ""; 
            return feedback;
        }
        private bool sendCommands(string cmd)
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
                        _34970base.WriteLine(item);
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
                    _34970base.WriteLine(cmd);
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
        private bool sendAndReceive(string cmd, ref string receData)
        {
            bool fb = true;
            receData = "";
            try
            {
                Console.WriteLine("CMD:" + cmd);
                _34970base.WriteLine(cmd);
                Thread.Sleep(100);
                receData = _34970base.ReadLine();
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
        private bool OpenDevice(ref PortOperatorBase _portBase, string addr, int timeout = 2000,int br = 9600)
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
            else{
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
