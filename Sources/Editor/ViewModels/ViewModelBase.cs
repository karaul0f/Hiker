using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using HikerEditor.Models.Interfaces;

namespace HikerEditor.ViewModels
{
    /// <summary>
    /// Базовая ViewModel с реализацией INotifyPropertyChanged
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) 
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Модель логики редактора прокинутая во вью-модель
        /// </summary>
        protected IEditor Editor => HikerEditor.Models.Editor.Editor.EditorInstance;

        /// <summary>
        /// Модель логики билдера прокинутая во вью-модель
        /// </summary>
        protected IAppBuilder AppBuilder => HikerEditor.Models.MSVCBuilder.AppBuilderInstance;
    }
}
