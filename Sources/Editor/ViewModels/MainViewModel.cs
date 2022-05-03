using System.Collections.ObjectModel;
using System.Collections.Specialized;
using HikerEditor.Models.Editor.Actions;
using HikerEditor.Models.Interfaces;
using HikerEditor.ViewModels.Commands;
using HikerEditor.ViewModels.Commands.ECS;
using HikerEditor.ViewModels.Commands.Windows;

namespace HikerEditor.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        /// <summary>
        /// Заголовок окна
        /// </summary>
        public string MainTitle
        {
            get => "Hiker: " + Editor.GameProject.Name;
            set
            {
                Editor.GameProject.Name = value;
                OnPropertyChanged();
            }
        } 

        /// <summary>
        /// Команда создания проекта
        /// </summary>
        public RelayCommand CreateProjectCommand { get; set; }

        /// <summary>
        /// Команда открытия проекта
        /// </summary>
        public RelayCommand OpenProjectCommand { get; set; }

        /// <summary>
        /// Команда сохранения проекта
        /// </summary>
        public RelayCommand SaveProjectCommand { get; set; }

        /// <summary>
        /// Команда создания сущности
        /// </summary>
        public CreateEntityCommand CreateEntityCommand { get; set; }

        /// <summary>
        /// Команда создания системы
        /// </summary>
        public CreateSystemCommand CreateSystemCommand { get; set; }

        /// <summary>
        /// Команда открытия окна для создания проекта
        /// </summary>
        public NewProjectWindowCommand NewProjectWindowCommand { get; set; }

        /// <summary>
        /// Команда открытия настроек программы
        /// </summary>
        public SettingsWindowCommand SettingsWindowCommand { get; set; }

        /// <summary>
        /// Команда построения игрового приложения
        /// </summary>
        public BuildAppCommand BuildAppCommand { get; set; }

        /// <summary>
        /// Команда запуска игрового приложения
        /// </summary>
        public PlayAppCommand PlayAppCommand { get; set; }

        /// <summary>
        /// Список всех сущностей в проекте
        /// </summary>
        public ObservableCollection<IEntity> Entities { get; set; }

        /// <summary>
        /// Список всех систем в проекте
        /// </summary>
        public ObservableCollection<ISystem> Systems { get; set; }

        /// <summary>
        /// Список всех ресурсов (файлов) в проекте
        /// </summary>
        public ObservableCollection<IResource> Resources { get; set; }

        /// <summary>
        /// Выбранная сущность в редакторе
        /// </summary>
        public IEntity SelectedEntity
        {
            get => Editor.SceneEditor.SelectedEntity;
            set
            {
                Editor.SceneEditor.SelectedEntity = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            Entities = new ObservableCollection<IEntity>(Editor.GameProject.Entities);
            Systems = new ObservableCollection<ISystem>(Editor.GameProject.Systems);
            Resources = new ObservableCollection<IResource>(Editor.GameProject.Resources);

            NewProjectWindowCommand = new NewProjectWindowCommand();
            SettingsWindowCommand = new SettingsWindowCommand();

            BuildAppCommand = new BuildAppCommand(AppBuilder);
            PlayAppCommand = new PlayAppCommand(AppBuilder);

            CreateEntityCommand = new CreateEntityCommand(Editor, Entities);
            CreateSystemCommand = new CreateSystemCommand(Systems);

            Editor.SceneEditor.OnSelectionChanged += SceneEditorOnSelectionChanged;
        }

        private void SceneEditorOnSelectionChanged(IEntity newEntity)
        {
            SelectedEntity = newEntity;
        }

        ~MainWindowViewModel()
        {
            
        }
    }
}
