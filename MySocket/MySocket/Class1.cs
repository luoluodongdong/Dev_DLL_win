using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NONATEST
{
    /// <summary>
    /// Socket server class
    /// </summary>
    public class _SocketServer
    {
        //创建服务器对象，默认监听本机0.0.0.0，端口12345
        /// <summary>
        /// server
        /// </summary>
        public SocketServer server;
        /// <summary>
        /// init server with (string ip,int port)
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <returns>true/false</returns>
        public bool InitSocket(string ip, int port)
        {
            server=new SocketServer(ip,port);
            return true;
        }
        /// <summary>
        /// start server
        /// </summary>
        /// <returns></returns>
        public bool StartSocket()
        {
            //服务器启动
            return server.StartServer();

        }
  
    }
    /// <summary>
    /// Socket client class
    /// </summary>
    public class _SocketClient
    {
        /// <summary>
        /// client
        /// </summary>
        public SocketClient client;
        /// <summary>
        /// init client with(sting ip,int port)
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <returns>true/false</returns>
        public bool InitSocket(string ip, int port)
        {
            client = new SocketClient(ip, port);
            return true;
        }
        /// <summary>
        /// conncet server
        /// </summary>
        /// <returns>true/false</returns>
        public bool ConnectServer()
        {
            return client.StartClient();
        }
        /// <summary>
        /// disconnect server
        /// </summary>
        /// <returns>true/false</returns>
        public bool DisconnectServer()
        {
            return client.Close();
        }
        /// <summary>
        /// query request
        /// </summary>
        /// <param name="data"></param>
        /// <returns>string data</returns>
        public bool Query(string data)
        {
            return client.Send(data);
        }
    }
}
