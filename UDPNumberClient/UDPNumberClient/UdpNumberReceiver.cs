using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UdpNumberReceiver
{
    class UdpNumberReceiver
    {
        static void Main(string[] args)
        {
            //Creates a UdpClient for reading incoming data.
            
            UdpClient udpReceiver = new UdpClient(9000);

            //Creates an IPEndPoint to record the IP Address and port number of the sender.
            //This IPEndPoint will allow you to read datagrams sent from a specific ip-source on port 9999
            // 192.168.3.224/127.0.0.1 
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(ip, 9000);
           
            //BROADCASTING
            //This IPEndPoint will allow you to read datagrams sent from any ip-source on port 9999
          // IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 9999);
           
            // Blocks until a message returns on this socket from a remote host.
            Console.WriteLine("Receiver is blocked");
            try
            {
                while (true)
                {
                    Byte[] receiveBytes = udpReceiver.Receive(ref RemoteIpEndPoint);

                    string receivedData = Encoding.ASCII.GetString(receiveBytes);

                    Console.WriteLine("Sender: " + receivedData.ToString());
                    Console.WriteLine("This message was sent from " +
                                                RemoteIpEndPoint.Address.ToString() +
                                                " on their port number " +
                                                RemoteIpEndPoint.Port.ToString());
                    Thread.Sleep(200);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
