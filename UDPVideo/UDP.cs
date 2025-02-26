﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using UDPVideo.Models;

namespace UDPVideo
{
	class UDP
	{
		private static int _nextId = 1;

		UdpClient updserver = new UdpClient(7777);

		public void ReceiverData()
		{

			IPAddress ip = IPAddress.Any;
            IPEndPoint remoteIpEndPoint = new IPEndPoint(ip, 7777);
            Video video = new Video();

			Byte[] receivedBytes = updserver.Receive(ref remoteIpEndPoint);
			Console.WriteLine("received information from sensor: ");

			string receivedData = Encoding.ASCII.GetString(receivedBytes);
            string[] data = receivedData.Split("|");

			video.piMessage = (data[0]);
			video.date = DateTime.ParseExact(data[1], "yyyy-MM-dd HH:mm:ss.ffffff", System.Globalization.CultureInfo.InvariantCulture);
            video.pictureid = (data[2]);
            Console.WriteLine(receivedData);
            if (Consumer.PostToReceiver<Video>("https://camsanctuary.azurewebsites.net/api/receiver", video)
                .Result)
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine("Failure");
            }
		}
	}
}
