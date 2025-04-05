namespace StructuralVisualizer1;

public class CustomExceptions
{
    
[Serializable]
public class TparamException : Exception
{
   public TparamException() : base() { }
   public TparamException(string message) : base(message) { }
   public TparamException(string message, Exception inner) : base(message, inner) { }
   
}

}