using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Win32;
using HikerEditor.Models;
using HikerEditor.Models.Editor;
using HikerEditor.Models.Editor.Actions;
using HikerEditor.Models.Interfaces;
using HikerEditor.Views;

namespace HikerEditor.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private IEntity _selectedEntity
;
        /// <summary>
        /// Заголовок окна
        /// </summary>
        public string MainTitle { get { return "Hiker: <new game>"; } }

        /// <summary>
        /// Команда создания сущности
        /// </summary>
        public RelayCommand CreateEntityCommand { get; set; }

        /// <summary>
        /// Команда открытия окна для создания проекта
        /// </summary>
        public RelayCommand NewProjectWindowCommand { get; set; }

        /// <summary>
        /// Команда открытия сущности
        /// </summary>
        public RelayCommand OpenSettingsCommand { get; set; }

        /// <summary>
        /// Список всех сущностей
        /// </summary>
        public ObservableCollection<IEntity> Entities { get; set; }

        /// <summary>
        /// Модель логики редактора прокинутая во вью-модель
        /// </summary>
        public IEditor Editor { get => HikerEditor.Models.Editor.Editor.EditorInstance; private set {} }

        /// <summary>
        /// Выбранная сущность в редакторе
        /// </summary>
        public IEntity SelectedEntity
        {
            get
            {
                return _selectedEntity;
            }
            set
            {
                _selectedEntity = value; 
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            Entities = new ObservableCollection<IEntity>(Editor.GameProject.Entities);

            NewProjectWindowCommand = new RelayCommand(o =>
            {
                NewProjectWindow newProjectWindow = new NewProjectWindow();
                newProjectWindow.Show();
            });

            OpenSettingsCommand = new RelayCommand(o =>
            {
                SettingsWindow settingWindow = new SettingsWindow();
                settingWindow.Show();
            });

            CreateEntityCommand = new RelayCommand(o => Entities.Add(new BaseEntity() { Name = "Entity" }));

            Entities.CollectionChanged += EntitiesOnCollectionChanged;
        }

        private void EntitiesOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if(e.Action == NotifyCollectionChangedAction.Add)
                Editor.Do(new NewEntityAction() { NewEntityName = "Entity" });
        }

        ~MainWindowViewModel()
        {
            Entities.CollectionChanged -= EntitiesOnCollectionChanged;
        }
    }
}
