using System;
using HikerEditor.Models.Interfaces;

namespace HikerEditor.Models.GameProject
{
    public class BaseResource: IResource
    {
        public string FilePath { get; set; }
    }
}
