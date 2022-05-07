﻿using System;
using HikerEditor.Models.Interfaces;

namespace HikerEditor.Models.GameProject
{
    public class BaseResource: IResource, ISelectable
    {
        public string Name { get; set; }
        public string FilePath { get; set; }
    }
}
