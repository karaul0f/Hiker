using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Win32;
using HikerEditor.Models;
using HikerEditor.Views;

namespace HikerEditor.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
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
        public ObservableCollection<Entity> Entities { get; set; }

        public MainWindowViewModel()
        {
            Entities = new ObservableCollection<Entity>();

            OpenSettingsCommand = new RelayCommand(o =>
            {
                SettingsWindow settingWindow = new SettingsWindow();
                settingWindow.Show();
            });

            CreateEntityCommand = new RelayCommand(o => Entities.Add(new Entity() { Name = "Entity" }));
        }
    }
}
