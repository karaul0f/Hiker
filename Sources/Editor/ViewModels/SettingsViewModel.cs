using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikerEditor.ViewModels
{
    public class SettingsViewModel: ViewModelBase
    {
        /// <summary>
        /// Путь до компилятора Microsoft Visual Studio
        /// </summary>
        public string PathToMsBuild
        {
            get => AppBuilder.PathToCompiler;
            set => AppBuilder.PathToCompiler = value;
        } 

        /// <summary>
        /// Текущая локализация приложения
        /// </summary>
        public string Language { get; set; }
    }
}
