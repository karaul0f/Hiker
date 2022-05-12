using System;
using System.Configuration;
using System.IO;
using HikerEditor.Models.Interfaces;
using HikerEditor.Models.GameProject;

namespace HikerEditor.Models
{
    /// <summary>
    /// Построение игровых приложений на базе компилятора от Microsoft Visual Studio
    /// </summary>
    public class MSVCBuilder: IAppBuilder
    {
        private string[] _filesToCopy =
        {
            @"Runtime.exe",
            @"sfml-graphics-2.dll",
            @"sfml-graphics-d-2.dll",
            @"sfml-system-2.dll",
            @"sfml-system-d-2.dll",
            @"sfml-window-2.dll",
            @"sfml-window-d-2.dll"
        };

        private static MSVCBuilder _instance;

        public String PathToCompiler
        {
            get => ConfigurationManager.AppSettings["PathToMsBuild"];
            set => ConfigurationManager.AppSettings["PathToMsBuild"] = value;
        }

        public bool Build(Project gameProject, string outputDirectory)
        {
            string pathToBin = Directory.GetCurrentDirectory() + @"\Runtime";

            foreach (var file in _filesToCopy)
            {
                string outputFilePath = outputDirectory + @"\" + file;

                if (File.Exists(outputFilePath))
                    File.Delete(outputFilePath);

                File.Copy(pathToBin + @"\" + file, outputFilePath);
            }
                

            return true;
        }

        /// <summary>
        /// Получение экземпляра билдера приложений (синглтон)
        /// </summary>
        public static MSVCBuilder AppBuilderInstance
        {
            get
            {
                if (_instance == null)
                    _instance = new MSVCBuilder();

                return _instance;
            }
        }
    }
}
