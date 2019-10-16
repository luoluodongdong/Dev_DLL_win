using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;
using NONATEST;


namespace testModule_DLL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// device address
        /// </summary>
        string addr = "";
        /// <summary>
        /// received string data 
        /// </summary>
        string receiveData = "";
        _SocketClient myClient;
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// test 3497xx DLL button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            addr = devicesListCB.SelectedItem.ToString();
            Thread thread1 = new Thread(test3497xxThread);
            thread1.Start();  // 只要使用Start方法，线程才会运行  
        }
        /// <summary>
        /// thread for test 3497xx.dll
        /// </summary>
        private void test3497xxThread()
        {
            Interface_3497xx _34970base = new _34970();
            bool result=_34970base.Open(addr, 5000);
            printLog("open result:" + result.ToString());
            Thread.Sleep(2000);
            string feedback = "";
            feedback = _34970base.GetName();
            printLog("dev name:" + feedback);
            _34970base.Reset();
            feedback = _34970base.ReadOpenShort("101:113");
            printLog("openshort values:" + feedback);
            result=_34970base.Close();
            printLog("close result:" + result.ToString());
        }
        /// <summary>
        /// test DMM button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void testDMMbtn_Click(object sender, EventArgs e)
        {
            addr = devicesListCB.SelectedItem.ToString();
            Thread thread1 = new Thread(testDMMThread);
            thread1.Start();  // 只要使用Start方法，线程才会运行  
            
        }
        /// <summary>
        /// thread for test DMM.dll
        /// </summary>
        private void testDMMThread()
        {
            Interface_DMM _34465base = new _34465();
            bool result= _34465base.Open(addr, 5000);
            printLog("open result:" + result.ToString());
            Thread.Sleep(2000);
            string feedback = _34465base.GetName();
            printLog("dev name:" + feedback);
            _34465base.Reset();
            feedback = _34465base.MeasureResis();
            printLog("meas resis:" + feedback);
            feedback = _34465base.MeasureCap();
            printLog("meas cap:" + feedback);
            feedback = _34465base.MeasureDiode();
            printLog("meas diod:" + feedback);
            feedback = _34465base.MeasureVolt();
            printLog("meas volt:" + feedback);
            feedback = _34465base.MeasureCurr();
            printLog("meas curr:" + feedback);
            result=_34465base.Close();
            printLog("close result:" + result.ToString());
        }
        /// <summary>
        /// scan online devices
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void scanDevBtn_Click(object sender, EventArgs e)
        {
            devicesListCB.Items.Clear();
            Interface_3497xx _34970base = new _34970();
            List<string> devices = _34970base.ScanDevices();

            foreach (string item in devices)
            {
                devicesListCB.Items.Add(item);
                printLog("device:" + item);
            }
            if(devices.Count != 0)
            {
                devicesListCB.SelectedIndex = 0;
                test3497xxBtn.Enabled = true;
                testDMMbtn.Enabled = true;
                testPOWERbtn.Enabled = true;
                testLOADbtn.Enabled = true;
            }
            else
            {
                test3497xxBtn.Enabled = false;
                testDMMbtn.Enabled = false;
                testPOWERbtn.Enabled = false;
                testLOADbtn.Enabled = false;
                MessageBox.Show("No find any devices!");
            }
        }
        /// <summary>
        /// form1 shown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Shown(object sender, EventArgs e)
        {
            scanDevBtn.PerformClick();
        }
        /// <summary>
        /// test POWER DLL button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void testPOWERbtn_Click(object sender, EventArgs e)
        {
            addr = devicesListCB.SelectedItem.ToString();
            Thread thread1 = new Thread(testPOWERThread);
            thread1.Start();  // 只要使用Start方法，线程才会运行  
        }
        /// <summary>
        /// thread for test POWER.dll
        /// </summary>
        private void testPOWERThread()
        {
            
            Interface_POWER _3615base = new _3615();
            //address=xxxxx,timeout=5000ms
            bool result= _3615base.Open(addr, 5000);
            printLog("open result:" + result.ToString());
            Thread.Sleep(2000);
            string feedback = _3615base.GetName();
            printLog("dev name:" + feedback);
            result=_3615base.Reset();
            printLog("reset result:" + result.ToString());
            //channel 1 5V 0.2A
            result = _3615base.OutputVolt("1", "5.0", "0.2");
            printLog("output result:" + result.ToString());
            printLog("delay 5s...");
            Thread.Sleep(5000);
            result = _3615base.CloseOutput();
            printLog("close output result:" + result.ToString());
            result =_3615base.Close();
            printLog("close dev result:" + result.ToString());
        }
        /// <summary>
        /// test LOAD DLL button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void testLOADbtn_Click(object sender, EventArgs e)
        {
            addr = devicesListCB.SelectedItem.ToString();
            Thread thread1 = new Thread(testLOADThread);
            thread1.Start();  // 只要使用Start方法，线程才会运行 
            
        }
        /// <summary>
        /// thread for test LOAD.dll
        /// </summary>
        private void testLOADThread()
        {
            
            Interface_LOAD _63610base = new _63610();
            bool result=_63610base.Open(addr, 5000);
            printLog("open result:" + result.ToString());
            Thread.Sleep(2000);
            string feedback = _63610base.GetName();
            printLog("dev name:" + feedback);
            _63610base.Reset();
            //mode = CCH, channel=L1, current=2.4A
            result = _63610base.SetLoad("CCH", "L1", "2.4");
            printLog("setLoad result:" + result.ToString());
            Thread.Sleep(500);
            string value = _63610base.MeasVolt();
            printLog("load off output result:" + value);
            result = _63610base.LoadON();
            printLog("loadON result:" + result.ToString());
            Thread.Sleep(2000);
            value = _63610base.MeasVolt();
            printLog("load on output result:" + value);
            result = _63610base.LoadOFF();
            printLog("loadOFF result:" + result.ToString());
            result= _63610base.Close();
            printLog("close result:" + result.ToString());
        }
        /// <summary>
        /// scan FIXTURE devices button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void scanFixBtn_Click(object sender, EventArgs e)
        {
            fixCB.Items.Clear();
            Interface_Serial _fixture = new _SerialDev();
            List<string> devs = _fixture.ScanDevices();
            foreach(string item in devs)
            {
                fixCB.Items.Add(item);
                printLog("fix:" + item);
            }
            if(fixCB.Items.Count > 0)
            {
                fixCB.SelectedIndex = 0;
                testFIXbtn.Enabled = true;
            }
            else
            {
                MessageBox.Show("Not find fixtures!");
                testFIXbtn.Enabled = false;
            }
        }
        /// <summary>
        /// test FIXTURE button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void testFIXbtn_Click(object sender, EventArgs e)
        {
            addr = fixCB.SelectedItem.ToString();
            Thread thread1 = new Thread(testFixThread);
            thread1.Start();  // 只要使用Start方法，线程才会运行 
        }
        /// <summary>
        /// thread for test FIXTURE.dll
        /// </summary>
        private void testFixThread()
        {
            Interface_Serial fixture = new _SerialDev();
            //COM1,timeout=2000ms,baudrate=9600,DTREnable=true,RTSEnable=false
            bool result=fixture.Open(addr,2000,9600,true);
            printLog("open result:" + result.ToString());
            Thread.Sleep(2000);
            fixture.PortReciveData += CL_PortRecivedData;
            receiveData = "";
            result=fixture.WriteLine("help");
            printLog("write result:" + result.ToString());
            Thread.Sleep(2000);
            //string rec = fixture.ReadLine();
            //printLog("read result:" + rec);
            result =fixture.Close();
            printLog("close result:" + result.ToString());
        }
        /// <summary>
        /// fixture port receive data event
        /// </summary>
        /// <param name="data"></param>
        private void CL_PortRecivedData(string data)
        {
            
            receiveData += data;
            if (receiveData.EndsWith("\n"))
            {
                printLog(receiveData);
                receiveData = "";
            }
        }
        /// <summary>
        /// print log string
        /// </summary>
        /// <param name="log"></param>
        private void printLog(string log)
        {
            Invoke((EventHandler)(delegate
            {
                string[] arr_log = log.Split('\n');
                foreach(string item in arr_log)
                {
                    logListBox.Items.Add(item.TrimEnd('\r'));
                    Console.WriteLine(item);
                }
                logListBox.TopIndex = logListBox.Items.Count - 1;
            }));
        }
        /// <summary>
        /// clear log button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void ClearLogBtn_Click(object sender, EventArgs e)
        {
            logListBox.Items.Clear();
        }

        private void startServerBtn_Click(object sender, EventArgs e)
        {
            _SocketServer myServer = new _SocketServer();
            string ip = ipTB.Text.Trim();
            int port = int.Parse(portTB.Text);
            myServer.InitSocket(ip, port);
            //处理从客户端收到的消息
            myServer.server.HandleRecMsg = new Action<byte[], SocketConnection, SocketServer>((bytes, client, theServer) =>
            {
                string msg = Encoding.UTF8.GetString(bytes);
                Console.WriteLine($"收到消息:{msg}");
                printLog("[server][RX]" + msg);
                client.Send("server reply:" + msg);
                printLog("[server][TX]" + msg);
            });

            //处理服务器启动后事件
            myServer.server.HandleServerStarted = new Action<SocketServer>(theServer =>
            {
                Console.WriteLine("************服务已启动************");
                printLog("[server]***************server start************");
            });

            //处理新的客户端连接后的事件
            myServer.server.HandleNewClientConnected = new Action<SocketServer, SocketConnection>((theServer, theCon) =>
            {
                Console.WriteLine($@"一个新的客户端接入，当前连接数：{theServer.GetConnectionCount()}");
                printLog("[server]a new client connected，connect count：" + theServer.GetConnectionCount().ToString());
            });

            //处理客户端连接关闭后的事件
            myServer.server.HandleClientClose = new Action<SocketConnection, SocketServer>((theCon, theServer) =>
            {
                Console.WriteLine($@"一个客户端关闭，当前连接数为：{theServer.GetConnectionCount()}");
                printLog("[server]a client offline，connect count："+theServer.GetConnectionCount().ToString());
            });
            //处理异常
            myServer.server.HandleException = new Action<Exception>(ex =>
            {
                Console.WriteLine(ex.Message);
            });

            bool startBool= myServer.StartSocket();
            Console.WriteLine("socket server start:{0}", startBool.ToString());

        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            if(ConnectBtn.Text == "Connect")
            {
                myClient = new _SocketClient();
                //创建客户端对象，默认连接本机127.0.0.1,端口为12345
                string ip = ipTB.Text.Trim();
                int port = int.Parse(portTB.Text);
                myClient.InitSocket(ip, port);
                myClient.client.Property = string.Format("ip:{0}", ip);
                //绑定当收到服务器发送的消息后的处理事件
                myClient.client.HandleRecMsg = new Action<byte[], SocketClient>((bytes, theClient) =>
                {
                    string msg = Encoding.UTF8.GetString(bytes);
                    Console.WriteLine($"收到消息:{msg}");
                    printLog("[client][RX]" + msg);
                });

                //绑定向服务器发送消息后的处理事件
                myClient.client.HandleSendMsg = new Action<byte[], SocketClient>((bytes, theClient) =>
                {
                    string msg = Encoding.UTF8.GetString(bytes);
                    Console.WriteLine($"向服务器发送消息:{msg}");
                    printLog("[client][TX]" + msg);
                });

                //开始运行客户端
                bool result= myClient.ConnectServer();
                if (result) ConnectBtn.Text = "Disconnect";
                printLog("[client]connect server:"+result.ToString());
            }
            else
            {
                bool result=myClient.DisconnectServer();
                printLog("[client]disconnct:" + result.ToString());
                ConnectBtn.Text = "Connect";
            }
        }

        private void SocketSendBtn_Click(object sender, EventArgs e)
        {
            string data = commandTB.Text.Trim();
            if(myClient != null)
            {
                myClient.Query(data);
            }
        }
    }
}
