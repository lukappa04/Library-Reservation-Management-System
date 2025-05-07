using Microsoft.VisualBasic;

namespace WebionLibraryAPI.Exceptions;

public class DataAlreadyExistExc : Exception
{
    public DataAlreadyExistExc(string data) : base($"Il dato {data} è attualmente già presente a db")
    {

    }

}