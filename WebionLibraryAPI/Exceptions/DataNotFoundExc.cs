namespace WebionLibraryAPI.Exceptions;

public class DataNotFoundExc : Exception
{
    public DataNotFoundExc() : base ($"Il dato non è stato trovato")
    {

    }
}