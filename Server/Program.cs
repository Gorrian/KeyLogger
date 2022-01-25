using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener Listener = new TcpListener(IPAddress.Any, Int32.Parse(args[0]));
            Listener.Start();
            Console.WriteLine("Servidor funcionando en puerto ("+args[0]+")");
            Console.WriteLine("Esperando conexion...");

            Socket Puerta = Listener.AcceptSocket();
            
            Console.WriteLine("Conexion aceptada de "+ Puerta.RemoteEndPoint);
            Console.WriteLine("Esperando mensaje");
            byte[] Recive=new byte[100];
            int longitud=Puerta.Receive(Recive);
        }
    }
}
