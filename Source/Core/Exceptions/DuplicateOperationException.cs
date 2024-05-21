namespace App.Core.Exceptions;
public class DuplicateOperationException(string message = "Unsafe Access!") : Exception(message) {

}