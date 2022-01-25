using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Client
{
    class Program
    {
        private static ASCIIEncoding ASCII=new ASCIIEncoding();
        private static BinaryFormatter bf = new BinaryFormatter();
        private static void SendInfo(string Info, TcpClient Connection){
            
            Stream TCP_stream = Connection.GetStream();
            byte[]send=ASCII.GetBytes(Info);
            TCP_stream.Write(send,0,send.Length);
            //Stream TCP_stream = Connection.GetStream();
        }
        private static string ConvertKeyToString(){
            char[] Temp=new char[(char)Console.ReadKey().Key];
            return new String(Temp);
        }
        static void Main(string[] args)
        {
            Console.Clear();
            bool Error=false;
            ArrayList KeysPressed = new ArrayList();
            TcpClient Tcp_conection=new TcpClient();
            String Test=Console.ReadLine();
            Tcp_conection.Connect(args[0], Int32.Parse(args[1]));
            string Key;
            while(Error==false){
                Key=ConvertKeyToString();
                Console.Clear();
                SendInfo(Key,Tcp_conection);
            }
        }
    }
}
