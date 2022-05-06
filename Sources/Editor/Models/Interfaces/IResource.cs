namespace HikerEditor.Models.Interfaces
{
    /// <summary>
    /// Интерфейс для реализации ресурсов (файлов) в проекте
    /// </summary>
    public interface IResource
    {
        /// <summary>
        /// Название ресурса
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Путь к файлу ресурса
        /// </summary>
        string FilePath { get; set; }
    } 
}
