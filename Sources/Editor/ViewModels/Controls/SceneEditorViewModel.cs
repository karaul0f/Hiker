using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Media3D;
using HikerEditor.Models.Editor;
using HikerEditor.Models.Interfaces;
using HikerEditor.Utils;

namespace HikerEditor.ViewModels
{
    /// <summary>
    /// ВьюМодель редактора сцены
    /// </summary>
    public class SceneEditorViewModel: ViewModelBase
    {
        private IEntity _selectedEntity;

        /// <summary>
        /// Выбранная сущность в редакторе
        /// </summary>
        public IEntity SelectedEntity
        {
            get => _selectedEntity;
            set
            {
                _selectedEntity = value;
                OnPropertyChanged();
            }
        }
    }
}
