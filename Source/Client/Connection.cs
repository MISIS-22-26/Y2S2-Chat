using System.Net.Sockets;
using App.Core.Socket;
namespace App.Client;
public struct Connection
{
	public Socket<TcpClient> tcp;
	public Socket<UdpClient> udp;
}