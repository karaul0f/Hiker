using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Win32;
using HikerEditor.Models;
using HikerEditor.Models.Editor;
using HikerEditor.Models.Interfaces;
using HikerEditor.Views;

namespace HikerEditor.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        /// <summary>
        /// Заголовок окна
        /// </summary>
        public string MainTitle { get { return "Hiker: <new game>"; } }

        /// <summary>
        /// Команда создания сущности
        /// </summary>
        public RelayCommand CreateEntityCommand { get; set; }

        /// <summary>
        /// Команда открытия сущности
        /// </summary>
        public RelayCommand OpenSettingsCommand { get; set; }

        /// <summary>
        /// Список всех сущностей
        /// </summary>
        public ObservableCollection<IEntity> Entities { get; set; }

        public MainWindowViewModel()
        {
            Entities = new ObservableCollection<IEntity>();

            OpenSettingsCommand = new RelayCommand(o =>
            {
                SettingsWindow settingWindow = new SettingsWindow();
                settingWindow.Show();
            });

            CreateEntityCommand = new RelayCommand(o => Entities.Add(new BaseEntity() { Name = "Entity" }));
        }
    }
}
