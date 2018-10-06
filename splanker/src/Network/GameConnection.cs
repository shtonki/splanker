using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace splanker.src.Network
{
    class GameConnection
    {
        public void Connect()
        {
            var macAddr =
            (
                from nic in NetworkInterface.GetAllNetworkInterfaces()
                where nic.OperationalStatus == OperationalStatus.Up
                select nic.GetPhysicalAddress().ToString()
            ).FirstOrDefault();

            if (macAddr.StartsWith("0860"))
            {
                Console.WriteLine("seba");
            }
            else
            {
                Console.WriteLine("not seba");
            }
        }

        public void BeClient()
        {
            const int PORT_NO = 5000;
            const string SERVER_IP = "127.0.0.1";
            {
                // data to send to the server
                string textToSend = DateTime.Now.ToString();

                // create a TCPClient object at the IP and port no.
                TcpClient client = new TcpClient(SERVER_IP, PORT_NO);
                NetworkStream nwStream = client.GetStream();
                byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);

                // send the text
                Console.WriteLine("Sending : " + textToSend);
                nwStream.Write(bytesToSend, 0, bytesToSend.Length);

                // read back the text
                byte[] bytesToRead = new byte[client.ReceiveBufferSize];
                int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
                Console.WriteLine("Received : " + Encoding.ASCII.GetString(bytesToRead, 0, bytesRead));
                Console.ReadLine();
                client.Close();
            }
        }


        public void BeHost()
        {
            const int PORT_NO = 5000;
            const string SERVER_IP = "127.0.0.1";

            {
                // listen at the specified IP and port no. 
                IPAddress localAdd = IPAddress.Parse(SERVER_IP);
                TcpListener listener = new TcpListener(localAdd, PORT_NO);
                Console.WriteLine("Listening...");
                listener.Start();

                // incoming client connected 
                TcpClient client = listener.AcceptTcpClient();

                // get the incoming data through a network stream 
                NetworkStream nwStream = client.GetStream();
                byte[] buffer = new byte[client.ReceiveBufferSize];

                // read incoming stream 
                int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

                // convert the data received into a string 
                string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Received : " + dataReceived);

                // write back the text to the client 
                Console.WriteLine("Sending back : " + dataReceived);
                nwStream.Write(buffer, 0, bytesRead);
                client.Close();
                listener.Stop();
                Console.ReadLine();
            }
        }
    }
}
