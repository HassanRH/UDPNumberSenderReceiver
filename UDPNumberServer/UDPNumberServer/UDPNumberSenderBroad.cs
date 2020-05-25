/*
 * UDPNumberServer
 *
 * Author Michael Claudius, ZIBAT Computer Science
 * Version 1.0. 2015.08.31
 * Copyright 2015 by Michael Claudius
 * Revised 2015.09.10
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
    class UDPNumberSenderBroad
    {
        static void MainX(string[] args)
        {
            int number = 0;
           
            UdpClient udpServer = new UdpClient(0);
            udpServer.EnableBroadcast = true;
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, 9999);

            Console.WriteLine("Broadcast started: Press Enter");
            Console.ReadLine();

            while (true)
            {
                Byte[] sendBytes = Encoding.ASCII.GetBytes("The number is: " + number);
                try
                {
                    udpServer.Send(sendBytes, sendBytes.Length, endPoint); //, endPoint

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

                number++;
                Console.WriteLine(" " + number);
                Thread.Sleep(100);
            }

        }
    }
}


