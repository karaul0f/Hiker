using System;
using HikerEditor.Models.GameProject;

namespace HikerEditor.Models.Interfaces
{
    /// <summary>
    /// Интерфейс билдера игровых приложений
    /// </summary>
    public interface IAppBuilder
    {
        /// <summary>
        /// Путь до компилятора
        /// </summary>
        String PathToCompiler { get; set; }

        /// <summary>
        /// Построить приложение
        /// </summary>
        /// <param name="gameProject">Игровой проект, из которого надо сделать приложение</param>
        /// <param name="directory">Директория, в которой будет приложение</param>
        /// <returns>True - компиляция прошла успешно, False - с ошибками.</returns>
        bool Build(Project gameProject, string directory);
    }
}
