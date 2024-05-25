namespace App.Core.Exceptions;
public class DisconnectedException(string message="Disconnected.") : IOException(message){}
public class NullConnectionException(string message="Connecting to null is prohibited.") : IOException(message) {}