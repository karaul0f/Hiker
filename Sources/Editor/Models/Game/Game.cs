﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikerEditor.Models.Interfaces;

namespace HikerEditor.Models.Game
{
    public class Game: IGame
    {
        private static Game _instance;

        public void Play(string pathToGameDirectory)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(pathToGameDirectory + @"/" + "Runtime.exe");
            startInfo.WorkingDirectory = pathToGameDirectory;
            Process.Start(startInfo);
        }

        /// <summary>
        /// Получение экземпляра класса взаимодействия со скомпилированной игрой (синглтон)
        /// </summary>
        public static Game GameInstance
        {
            get
            {
                if (_instance == null)
                    _instance = new Game();

                return _instance;
            }
        }
    }
}
