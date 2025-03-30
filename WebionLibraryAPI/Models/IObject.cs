namespace WebionLibraryAPI.Models;
/// <summary>
/// Definisco un interfaccia per estendere un campo comune di tutte le classi del db, ossia l'id.
/// </summary>
public interface IObjects 
{
    public int Id { get; set; }
}