
/*
 * UDPNumberServer
 *
 * Author Michael Claudius, ZIBAT Computer Science
 * Version 1.0. 2015.08.31
 * Copyright 2015 by Michael Claudius
 * Revised 2014.09.10
 * All rights reserved
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UDPNumberSender
{
    class UdpNumberSender
    {
        static void Main(string[] args)
        {
            int number = 0;

            IPAddress ip = IPAddress.Parse("127.0.0.1"); //

            //BROADCASTING the sender and remote endpoint for broadcasting
           //UdpClient udpSender = new UdpClient(0); 
            //Using Remote endpoint
           IPEndPoint RemoteIpEndPoint = new IPEndPoint(ip, 3000); 

          UdpClient udpSender = new UdpClient("127.0.0.1", 3000); //

            while (true)
            {
                Byte[] sendBytes = Encoding.ASCII.GetBytes("The number is: " + number);
                try
                {
                    //Using remote endpoint needs UdpClient (0) for broadcasting
                    //udpSender.Send(sendBytes, sendBytes.Length, RemoteIpEndPoint);
             
                    //Just sending out needs UdpClient(9999)
                   udpSender.Send(sendBytes, sendBytes.Length);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                number++;
                Console.WriteLine(" " + number);
                Thread.Sleep(100);
            }

        }
    }
}

/**



using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace TCPEchoServer
{
    class TCPEchoServer
    {

        public static void Main(string[] args)
        {
            TcpListener serverSocket = new TcpListener(6789);
            serverSocket.Start();
            Console.WriteLine("Server started");

            TcpClient connectionSocket = serverSocket.AcceptTcpClient();
            //Socket connectionSocket = serverSocket.AcceptSocket();
            Console.WriteLine("Server activated");

            Stream ns = connectionSocket.GetStream();
           // Stream ns = new NetworkStream(connectionSocket);

            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true; // enable automatic flushing

            string message = sr.ReadLine();
            string answer = "";
            while (message != null && message != "")
            {

                Console.WriteLine("Client: " + message);
                answer = message.ToUpper();
                sw.WriteLine(answer);
                message = sr.ReadLine();

            }

            ns.Close();
            connectionSocket.Close();
            serverSocket.Stop();

        }
    }
    
}
*/



