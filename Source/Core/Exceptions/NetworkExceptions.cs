namespace App.Core.Exceptions;
public class DisconnectedException(string message="Disconnected.") : IOException(message){}