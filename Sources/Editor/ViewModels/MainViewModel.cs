using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using HikerEditor.Models.Editor.Actions;
using HikerEditor.Models.Interfaces;
using HikerEditor.ViewModels.Commands;
using HikerEditor.ViewModels.Commands.ECS;
using HikerEditor.ViewModels.Commands.Game;
using HikerEditor.ViewModels.Commands.Windows;

namespace HikerEditor.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private String _projectName;
        /// <summary>
        /// Заголовок окна
        /// </summary>
        public string MainTitle
        {
            get => "Hiker: " + _projectName;
            set
            {
                _projectName = value;
                OnPropertyChanged();
            }
        } 

        /// <summary>
        /// Команда создания проекта
        /// </summary>
        public NewProjectWindowViewModel NewProjectWindowViewModel { get; set; }

        /// <summary>
        /// Команда открытия проекта
        /// </summary>
        public OpenProjectCommand OpenProjectCommand { get; set; }

        /// <summary>
        /// Команда сохранения проекта
        /// </summary>
        public SaveProjectCommand SaveProjectCommand { get; set; }

        /// <summary>
        /// Команда создания сущности
        /// </summary>
        public CreateEntityCommand CreateEntityCommand { get; set; }

        /// <summary>
        /// Команда удаления сущности
        /// </summary>
        public DeleteEntityCommand DeleteEntityCommand { get; set; }

        /// <summary>
        /// Команда создания системы
        /// </summary>
        public CreateSystemCommand CreateSystemCommand { get; set; }

        /// <summary>
        /// Команда создания ресурса
        /// </summary>
        public CreateResourceCommand CreateResourceCommand { get; set; }

        /// <summary>
        /// Команда удаления ресурса
        /// </summary>
        public DeleteResourceCommand DeleteResourceCommand { get; set; }

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
        /// Выбранный объект в редакторе
        /// </summary>
        public ISelectable SelectedObject
        {
            get => Editor.SceneEditor.SelectedObject;
            set
            {
                Editor.SceneEditor.SelectedObject = value as ISelectable;

                // FIXME: для простоты было выделены отдельные св-ва
                // подумать над тем, чтобы объеденить в одно св-во.
                OnPropertyChanged(SelectedEntity?.ToString());
                OnPropertyChanged(SelectedResource?.ToString());
                OnPropertyChanged(SelectedSystem?.ToString());

                OnPropertyChanged();
            }
        }

        public IEntity SelectedEntity
        {
            get => Editor.SceneEditor.SelectedObject as IEntity;
            set => SelectedObject = value as ISelectable;
        } 

        public IResource SelectedResource
        {
            get => Editor.SceneEditor.SelectedObject as IResource;
            set => SelectedObject = value as ISelectable;
        }

        public ISystem SelectedSystem => Editor.SceneEditor.SelectedObject as ISystem;

        public MainWindowViewModel()
        {
            Entities = Editor.GameProject.Entities as ObservableCollection<IEntity>;
            Systems = Editor.GameProject.Systems as ObservableCollection<ISystem>;
            Resources = Editor.GameProject.Resources as ObservableCollection<IResource>;

            NewProjectWindowCommand = new NewProjectWindowCommand(this);
            SettingsWindowCommand = new SettingsWindowCommand();

            NewProjectWindowViewModel = new NewProjectWindowViewModel();
            OpenProjectCommand = new OpenProjectCommand(Editor);
            SaveProjectCommand = new SaveProjectCommand(Editor);

            BuildAppCommand = new BuildAppCommand(AppBuilder);
            PlayAppCommand = new PlayAppCommand(AppBuilder, Game);

            CreateEntityCommand = new CreateEntityCommand(Editor, Entities);
            CreateSystemCommand = new CreateSystemCommand(Systems);
            CreateResourceCommand = new CreateResourceCommand(Editor, Resources);

            DeleteEntityCommand = new DeleteEntityCommand(Editor, Entities);
            DeleteResourceCommand = new DeleteResourceCommand(Editor, Resources);

            MainTitle = Editor.GameProject.Name;

            Editor.SceneEditor.OnSelectionChanged += SceneEditorOnSelectionChanged;
            Editor.GameProject.OnProjectNameChanged += GameProjectOnProjectNameChanged;
        }

        private void GameProjectOnProjectNameChanged(string newName)
        {
            MainTitle = newName;
        }

        private void SceneEditorOnSelectionChanged(ISelectable selectedObject)
        {
            SelectedObject = selectedObject;
        }

    }
}
