using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikerEditor.Models.Interfaces;

namespace HikerEditor.Models.Editor
{
    public class VisualComponent: IComponent
    {
        public Position WorldPosition { get; set; }
        public String PathToImage { get; set; }
    }
}
