using System.Net.Sockets;
using App.Core.Multithreading;
namespace App.Client;
public class Client
{
    public Client(string address, int port, ProtocolType protocol, int buffer_size = 1024)
    {
        Resolver = new(address, "DNS Resolver");
        ((IRunnable) Resolver).Start();
        
        Socket = new(Resolver.Address, port, protocol, buffer_size);
        Socket.Open();
    }
    private Core.Net.Resolver Resolver { get; }
    private Net.Socket Socket { get; }
    public void Stop()
    {
        ((IRunnable) Resolver).Stop();
        Socket.Close();
    }
}