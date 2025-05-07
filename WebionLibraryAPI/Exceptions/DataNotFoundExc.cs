namespace WebionLibraryAPI.Exceptions;

public class DataNotFoundExc : Exception
{
    public DataNotFoundExc(int data) : base ($"Il dato {data} non è stato trovato")
    {

    }
}