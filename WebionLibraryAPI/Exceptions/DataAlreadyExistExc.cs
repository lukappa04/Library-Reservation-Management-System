using Microsoft.VisualBasic;

namespace WebionLibraryAPI.Exceptions;

public class DataAlreadyExistExc : Exception
{
    public DataAlreadyExistExc() : base($"Il dato è attualmente già presente a db")
    {

    }

}