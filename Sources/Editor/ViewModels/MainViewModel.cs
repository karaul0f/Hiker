using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.ComponentModel;
using System.Media;
using System.Runtime.CompilerServices;
using Microsoft.Win32;
using HikerEditor.Models;
using HikerEditor.Models.Editor;
using HikerEditor.Models.Editor.Actions;
using HikerEditor.Models.Interfaces;
using HikerEditor.ViewModels.Commands;
using HikerEditor.ViewModels.Commands.ECS;
using HikerEditor.ViewModels.Commands.Windows;
using HikerEditor.Views;

namespace HikerEditor.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private IEntity _selectedEntity;
        /// <summary>
        /// Заголовок окна
        /// </summary>
        public string MainTitle => "Hiker: " + Editor.GameProject.Name;

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
        /// Список всех сущностей в проекте
        /// </summary>
        public ObservableCollection<IEntity> Entities { get; set; }

        /// <summary>
        /// Список всех систем в проекте
        /// </summary>
        public ObservableCollection<ISystem> Systems { get; set; }

        /// <summary>
        /// Модель логики редактора прокинутая во вью-модель
        /// </summary>
        public IEditor Editor { get => HikerEditor.Models.Editor.Editor.EditorInstance; private set {} }

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

        public MainWindowViewModel()
        {
            Entities = new ObservableCollection<IEntity>(Editor.GameProject.Entities);
            Systems = new ObservableCollection<ISystem>(Editor.GameProject.Systems);

            NewProjectWindowCommand = new NewProjectWindowCommand();
            SettingsWindowCommand = new SettingsWindowCommand();

            CreateEntityCommand = new CreateEntityCommand(Entities);
            CreateSystemCommand = new CreateSystemCommand(Systems);

            Entities.CollectionChanged += EntitiesOnCollectionChanged;
        }

        private void EntitiesOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if(e.Action == NotifyCollectionChangedAction.Add)
                Editor.Do(new NewEntity());

        }

        ~MainWindowViewModel()
        {
            Entities.CollectionChanged -= EntitiesOnCollectionChanged;
        }
    }
}
