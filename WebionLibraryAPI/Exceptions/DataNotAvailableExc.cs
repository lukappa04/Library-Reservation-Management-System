namespace WebionLibraryAPI.Exceptions;

public class DataNotAvailableExc : Exception
{
    public DataNotAvailableExc (string data) : base ($"Dato {data} non disponibile")
    {
        
    }
}