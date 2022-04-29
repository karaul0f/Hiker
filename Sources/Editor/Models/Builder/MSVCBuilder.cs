using System;
using System.Configuration;
using HikerEditor.Models.Interfaces;
using HikerEditor.Models.GameProject;

namespace HikerEditor.Models
{
    /// <summary>
    /// Построение игровых приложений на базе компилятора от Microsoft Visual Studio
    /// </summary>
    public class MSVCBuilder: IAppBuilder
    {
        private static MSVCBuilder _instance;

        public String PathToCompiler
        {
            get => ConfigurationManager.AppSettings["PathToMsBuild"];
            set => ConfigurationManager.AppSettings["PathToMsBuild"] = value;
        }

        public bool Build(Project gameProject, string directory)
        {

            return false;
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
