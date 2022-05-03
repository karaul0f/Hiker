namespace HikerEditor.Models.Interfaces
{
    /// <summary>
    /// Интерфейс для реализации ресурсов (файлов) в проекте
    /// </summary>
    public interface IResource
    {
        string FilePath { get; set; }
    } 
}
